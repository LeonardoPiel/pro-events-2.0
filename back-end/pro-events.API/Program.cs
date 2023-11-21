using Microsoft.EntityFrameworkCore;
using pro_events.API.Persistence;
using pro_events.Application.IServices;
using pro_events.Application.ServicesRepository;
using pro_events.Persistence;
using pro_events.Persistence.IPersistence;
using pro_events.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProEventsContext>(
	context => context.UseSqlite(builder.Configuration.GetConnectionString("sqlite"))
);

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventsPersistence, EventsPersistence>();
builder.Services.AddScoped<IProEventsPersistence, ProEventsPersistence>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
