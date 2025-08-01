using Microsoft.EntityFrameworkCore;
using MyApp.Data;

var builder = WebApplication.CreateBuilder(args);// Inicialize a single instance of the web aplication builder class. Witch set up the configurations, services and web server

// Add services to the container.
builder.Services.AddControllersWithViews();// Add MVC services to a conteiner with support to both controllers and views. It's alows the aplication to handle HTTP requests and handles HTML views.
builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));// Add the DbContext service to the container, configuring it to use SQL Server with a connection string from the configuration.

var app = builder.Build();// Compile the application and create a web host that will run the application.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS for security.
app.UseRouting(); // Enable routing middleware to match incoming requests to endpoints.

app.UseAuthorization();// Enable authorization middleware to enforce security policies.

app.MapStaticAssets();// Map static assets to be served directly from the wwwroot folder. Assets like CSS, JavaScript, and images can be served without going through the MVC pipeline.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
