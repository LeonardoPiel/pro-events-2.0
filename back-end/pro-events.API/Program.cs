using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using pro_events.API.Persistence;
using pro_events.Application.IServices;
using pro_events.Application.ServicesRepository;
using pro_events.Persistence;
using pro_events.Persistence.IPersistence;
using pro_events.Persistence.PersistenceRepository;
using pro_events.Persistence.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProEventsContext>(
	context => context.UseSqlite(builder.Configuration.GetConnectionString("sqlite"))
);

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventsPersistence, EventPersistence>();

builder.Services.AddScoped<ITicketLotService, TicketLotService>();
builder.Services.AddScoped<ITicketLotPersistence, TicketLotPersistence>();

builder.Services.AddScoped<IProEventsPersistence, ProEventsPersistence>();

builder.Services.AddControllers()
	.AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
} 
);

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
