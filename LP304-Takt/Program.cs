using System.Text;
using System.Text.Json.Serialization;
using LP304_Takt.Data;
using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Repositories;
using LP304_Takt.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddTransient<IAreaService, AreaService>();
builder.Services.AddScoped<IStationRepository, StationRepository>();
builder.Services.AddTransient<IStationService, StationService>();
builder.Services.AddScoped<IConfigRepository, ConfigRepository>();
builder.Services.AddTransient<IConfigService, ConfigService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddScoped<IAlarmRepository, AlarmRepository>();
builder.Services.AddTransient<IAlarmService, AlarmService>();
builder.Services.AddScoped<IEventStatusRepository, EventStatusRepository>();
builder.Services.AddTransient<IEventStatusService, EventStatusService>();
builder.Services.AddScoped<IAlarmTypeRepository, AlarmTypeRepository>();
builder.Services.AddTransient<IAlarmTypeService, AlarmTypeService>();

//builder.Services.AddScoped<IQueueRepository, QueueRepository>();
//builder.Services.AddTransient<IQueueService, QueueService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DataContext>(options =>
{

    //options.UseMySql(builder.Configuration.GetConnectionString("DbString"),
    // ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DbString")),
    //builder =>
    //{
    //    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    //});

    var connectionString = builder.Configuration.GetConnectionString("DbString");
    options.UseSqlServer(connectionString);
});


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>();
        await SeedData.CreateAdminOnStartup(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization(); 

app.MapControllers();

app.Run();
