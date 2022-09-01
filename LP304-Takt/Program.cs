using System.Data.Common;
using LP304_Takt.Models;
using LP304_Takt.Repositories;
using LP304_Takt.Service;
using LP304_Takt.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAlarmRepository, AlarmRepository>();
builder.Services.AddScoped<IAlarmService, AlarmService>();
builder.Services.AddScoped<IAlarmTypeRepository, AlarmTypeRepository>();
builder.Services.AddScoped<IAlarmTypeService, AlarmTypeService>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IConfigRepository, ConfigRepository>();
builder.Services.AddScoped<IConfigService, ConfigService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventStatusRepository, EventStatusRepository>();
builder.Services.AddScoped<IEventStatusService, EventStatusService>();
builder.Services.AddScoped<IMacRepository, MacRepository>();
builder.Services.AddScoped<IMacService, MacService>();
//builder.Services.AddScoped<IOrderAlarmRepository, OrderAlarmRepository>();
//builder.Services.AddScoped<IOrderAlarmService, OrderAlarmService>();
//builder.Services.AddScoped<IOrderEventRepository, OrderEventRepository>();
//builder.Services.AddScoped<IOrderEventService, OrderEventService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IQueueRepository, QueueRepository>();
builder.Services.AddScoped<IQueueService, QueueService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IStationRepository, StationRepository>();
builder.Services.AddScoped<IStationService, StationService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<LP304Context>(options =>
{
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

app.UseAuthorization(); 

app.MapControllers();

app.Run();
