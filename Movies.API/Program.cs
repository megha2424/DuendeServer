using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Movies.API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MoviesAPIContext>(options =>
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MoviesAPIContext") ??
                                throw new InvalidOperationException(
                                    "Connection string 'MoviesAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5005";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("something", policy => policy.RequireClaim("client_id", "movieClient"));
});

var app = builder.Build();
SeedDatabase(app);

void SeedDatabase(WebApplication webApplication)
{
    using var scope = webApplication.Services.CreateScope();
    var services = scope.ServiceProvider;
    var moviesApiContext = services.GetRequiredService<MoviesAPIContext>();
    MoviesApiSeed.AsyncSeed(moviesApiContext);
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