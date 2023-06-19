using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using Service.Concrete;
using Service.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "MyAPI",
        Description = "Testing"  
      });
});
builder.Services.AddMvcCore()
    .AddApiExplorer();

//Allow CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        // Configure CORS policy according to your requirements
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
//Service Activator
builder.Services.AddSingleton<ITestService>(new TestService());
builder.Services.AddSingleton<IMenuService>(new MenuService());
builder.Services.AddSingleton<IAdminService>(new AdminService());
builder.Services.AddSingleton<IPermissionService>(new PermissionService());
builder.Services.AddSingleton<IRoleService>(new RoleService());
builder.Services.AddSingleton<IUserProfileService>(new UserProfileService());
//JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

            };
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json","MyAPI");
    }); 
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseCors();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.MapControllers();

app.Run();
