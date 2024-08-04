

using Microsoft.EntityFrameworkCore;
using Amazon_EF.Data;
using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Amazon_EF.Repository;
var builder = WebApplication.CreateBuilder(args);

#region Config Services          
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//For Swaggere UI 
builder.Services.AddSwaggerGen(); 
#endregion


#region Connection      
//Injection For DataBase 
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region AlloW Depdancy Injection For Class 

//builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

#endregion

var app = builder.Build();

#region For Update Database When I Build Project   
//Ask CLR For Creating Object From DBContext 
using var scope = app.Services.CreateScope();

//try
//{
var servies = scope.ServiceProvider;
var dbContext = servies.GetRequiredService<StoreContext>();
//}

//finally
//{
//    scope.Dispose();
//}

var loggerFactory = servies.GetRequiredService<ILoggerFactory>();

try
{
    //Migration Data 
    await dbContext.Database.MigrateAsync();

    //Seeding Data 
    await DataSeeding.seedAsync(dbContext);
 }
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();

<<<<<<< HEAD
    logger.LogError(ex, "An error happened When during migration");
=======
    logger.LogError(ex, "An error happened during migration");
>>>>>>> 0173e1400cf8cf99be3a34875c52a7c6779176e5
}

#endregion



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Amazon V1");
});
app.Run();
