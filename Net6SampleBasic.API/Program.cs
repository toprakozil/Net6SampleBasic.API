using Net6SampleBasic.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Net6SampleBasic.API.Services;


/// <summary>
/// AddServices Method
/// Add services to the container.
/// 
void AddServices(WebApplicationBuilder builder)
{
    builder.Services.AddJWTTokenService(builder.Configuration);
    builder.Services.AddControllers();

    builder.Services.AddDbContext<ItemsContext>(options =>
    {
        options.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=SampleItemsDb;Trusted_Connection=True;");

        options.LogTo(Console.WriteLine);
        options.EnableSensitiveDataLogging(true);
    });
    builder.Services.AddScoped<IItemRepository, ItemRepository>();
}
/// <summary>
/// Recreate DB
/// Create DB on the fly for demo purposes
void ReCreateDB(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var context = scope.ServiceProvider.GetService<ItemsContext>();
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            //Console.WriteLine(ex.ToString());
            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            logger.LogError(ex, "DB creation error");
        }
    }
}


var builder = WebApplication.CreateBuilder(args);

AddServices(builder);

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Pass the token below."
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
                new string[] {}
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

ReCreateDB(app);








app.Run();
