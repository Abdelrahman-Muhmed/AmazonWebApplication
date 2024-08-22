
using Microsoft.EntityFrameworkCore;
using Amazon_Core.IRepository;
using Amazon_Core.Model;
using Amazon_Api.Helpers;
using Amazon_EF.SqlRepository.Repository;
using StackExchange.Redis;
using Amazon_EF.RedisRepository;
using Amazon_EF.Data;
using Amazon_EF.IdentityData;
using Microsoft.AspNetCore.Identity;
using Amazon_Core.Model.IdentityModel;
using Amazon_EF.IdentityData.DataSeedingFile;
using Amazon_Core.Service;
using Amazon_Service.ServiceRepo;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Amazon_Core.Model.OrderModel;



var builder = WebApplication.CreateBuilder(args);

#region Config Services          
// Add services to the container.

builder.Services.AddControllers()
    //For Solve System.Text.Json.JsonException: A possible object cycle was detected. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
    //Show me when i getAdress 
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.MaxDepth = 64; // Optional: increase max depth if needed
    });

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

//Injection for Identity 
builder.Services.AddDbContext<ApplicationIdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});


#endregion

#region AlloW Depdancy Injection For Class 

//builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//For Unit Of Work So i dont need Make IGenericRepository 
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddScoped(typeof(IOrdersService), typeof(OrderesService));

builder.Services.AddScoped(typeof(IProductService), typeof(ProductServic));


//For connect with 
builder.Services.AddScoped<IConnectionMultiplexer>((serviceProvider) =>
{
    var connection = builder.Configuration.GetConnectionString("RedisConnection");
    return ConnectionMultiplexer.Connect(connection);
}

);

//For Basket Repository (Memory DataBase)
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//System.InvalidOperationException: 'No service for type Error From var ApplicationUserSeedingData = servies.GetRequiredService<UserManager<ApplictionUser>>();
//    'Microsoft.AspNetCore.Identity.UserManager`1[Amazon_Core.Model.IdentityModel.ApplictionUser]' has been registered.'
builder.Services.AddIdentity<ApplictionUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationIdentityContext>();

//For IAuthService 
builder.Services.AddScoped(typeof(IAuthServic), typeof(AuthService));

//Injection For Add Autntication
//Without this AddJwtBearer("Bearer") he give use the Invalid Opearations Error So I have know hime Whatg the Kind Of Schema 
//Now i will add the valdiate for Claim What Come With Schema 
//"Bearer" == JwtBearerDefaults.AuthenticationScheme
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;       // For make this The Default in Any Endpoint Work With Authrization 
}


)
    .AddJwtBearer(option =>
       option.TokenValidationParameters = new TokenValidationParameters()
       {
           ValidateAudience = true,
           ValidAudience = builder.Configuration["JWT:audience"],
           ValidateIssuer = true,
           ValidIssuer = builder.Configuration["JWT:issure"],
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:AuthKey"] ?? string.Empty)),
           ValidateLifetime = true,
           ClockSkew = TimeSpan.Zero
       } //The defualt handler for Bearer Schema 

    );

#endregion

#region Auto Mapping 
//builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
//builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register AutoMapper and PictureUrlResolver
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<PictureUrlResolver>(); // ???????????????

#endregion


var app = builder.Build();


#region For Update Database When I Build Project   
//Ask CLR For Creating Object From DBContext 
using var scope = app.Services.CreateScope();

//try
//{
//Aske cli to Make Object From Class 
var servies = scope.ServiceProvider;
var dbContext = servies.GetRequiredService<StoreContext>();
var IdentitydbContext = servies.GetRequiredService<ApplicationIdentityContext>();
var ApplicationUserSeedingData = servies.GetRequiredService<UserManager<ApplictionUser>>();
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
    await IdentitydbContext.Database.MigrateAsync();
    //Seeding Data 
    await DataSeeding.seedAsync(dbContext);
    await OrderDataSeeding.seedAsync(dbContext);
    //Seeding Data To Make Admin User 
    await ApplicationDataSeeding.SeedData(ApplicationUserSeedingData);

 }
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();


    logger.LogError(ex, "An error happened When during migration");

}

#endregion


// Configure the HTTP request pipeline.
#region Configure Kestral MeddleWare 


// Add Static For Picture 
app.UseStaticFiles();
#region Handle Not Found End Point Error  
//app.UseStatusCodePagesWithRedirects("/ErrorEndPoint/{0}");
/*app.UseStatusCodePagesWithReExecute("/ErrorEndPoint/{0}");*/ // It's Not Make Redirct For Page 

#endregion

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Amazon V1");

  
}); 
#endregion

app.Run();
