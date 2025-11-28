using Carter;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProgressTrackingService.DataBase;
using ProgressTrackingService.Extensions;
using Shared;
using StackExchange.Redis;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURATION LOADING ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var jwtSettings = builder.Configuration.GetSection("Jwt");
var redisHost = builder.Configuration["ConnectionStrings:RedisConnection"] ?? "localhost";

// --- 2. ADD SERVICES (Core Functionality) ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddLogging(); // Ensure logging is registered

// --- 3. DATABASE: DbContext and Outbox (CRITICAL FOR CONSISTENCY) ---

// a. Register the primary DbContext
builder.Services.AddDbContext<ProgressTrackingDbContext>(options =>
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

// b. Register the Redis Connection Multiplexer
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(redisHost));


// --- 4. MASSTRANSIT AND EF CORE OUTBOX ---
builder.Services.AddMassTransit(x =>
{
    x.AddEntityFrameworkOutbox<ProgressTrackingDbContext>(o =>
    {
        o.QueryDelay = TimeSpan.FromSeconds(5);
        o.UseBusOutbox();     // ensures publish/send is stored in the Outbox table    
    });

    x.AddConsumers(Assembly.GetExecutingAssembly());

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQ:Host"], "/", h =>
        {
            h.Username(builder.Configuration["RabbitMQ:Username"] ?? "guest");
            h.Password(builder.Configuration["RabbitMQ:Password"] ?? "guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});


// --- 5. MEDIATR AND PIPELINE (CRITICAL FOR TRANSACTIONAL SCOPE) ---

var assembly = Assembly.GetExecutingAssembly();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(assembly);

    // Register the Transaction Pipeline Behavior (using the shared IResult marker)
    cfg.AddOpenBehavior(typeof(TransactionalMiddleware.TransactionPipelineBehavior<,>));
});




builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter(configurator: config => config.WithValidatorLifetime(ServiceLifetime.Scoped));


// --- 6. AUTHENTICATION (Required for [Authorize] on endpoints) ---

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]!)),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true
    };
});
builder.Services.AddAuthorization();


var app = builder.Build();

// --- 7. DATABASE INITIALIZATION ---
await app.IntializeDataBase();
// --- 8. MIDDLEWARE PIPELINE ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapCarter();
app.MapControllers();

app.Run();