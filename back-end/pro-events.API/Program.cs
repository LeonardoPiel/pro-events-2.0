using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using pro_events.API.Persistence;
using pro_events.Application.IServices;
using pro_events.Application.ServicesRepository;
using pro_events.Domain.Identity;
using pro_events.Persistence;
using pro_events.Persistence.Interfaces;
using pro_events.Persistence.IPersistence;
using pro_events.Persistence.PersistenceRepository;
using pro_events.Persistence.Repository;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProEventsContext>(
	context => context.UseSqlite(builder.Configuration.GetConnectionString("sqlite"))
);

builder.Services.AddIdentityCore<User>(options =>
	{
		options.Password.RequireDigit = false;
		options.Password.RequireNonAlphanumeric = false;
		options.Password.RequireDigit = false;
		options.Password.RequireLowercase = false;
		options.Password.RequireUppercase = false;
		options.Password.RequiredLength = 4;
	})
    .AddRoles<Role>()
    .AddRoleManager<RoleManager<Role>>()
	.AddSignInManager<SignInManager<User>>()
    .AddRoleValidator<RoleValidator<Role>>()
	.AddEntityFrameworkStores<ProEventsContext>()
	.AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["secret_key"])),
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventsPersistence, EventPersistence>();

builder.Services.AddScoped<ITicketLotService, TicketLotService>();
builder.Services.AddScoped<ITicketLotPersistence, TicketLotPersistence>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserPersistence, UserPersistence>();


builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IDefaultPersistence, DefaultPersistence>();

builder.Services.AddControllers().AddJsonOptions(options => 
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.PropertyNamingPolicy = null;
	});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = @"Use [post] Users/login at UserController for login and insert Bearer token for auhtenticate. Sample: Bearer 123456abcdef",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Scheme = "Bearer"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
                    Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
                },
				Scheme = "oauth2",
				Name = "Bearer",
				In = ParameterLocation.Header
			},
			new List<string>()
		}
	});
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
