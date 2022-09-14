using System.Text.Json.Serialization;
using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Repositories;
using LP304_Takt.Services;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

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
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IRoleService, RoleService>();
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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();

app.UseAuthorization(); 

app.MapControllers();

app.Run();
