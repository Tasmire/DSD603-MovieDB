using DM.MovieApi;
using DSD603_MovieDB.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

//https://www.themoviedb.org/settings/api
string bearerToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4NGUzNjEyODQ0NGJmNTUxYTNmN2I2YmY3ZjkwOWZlMiIsIm5iZiI6MTc0OTU0NzAyMy42MDA5OTk4LCJzdWIiOiI2ODQ3ZjgwZmIyYzRiMmEzY2EyOTM1OGMiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.-J80aMkC4d3Oy70VryNE0OygKYNLgBUwL1GG1CWkW6Q";
MovieDbFactory.RegisterSettings(bearerToken);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
