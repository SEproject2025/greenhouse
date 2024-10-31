// This file configures your application and registers services (like the DataContext) 
// so the app knows about them.
//----------------------------------------------------------------------------------
using greenhouse.Providers;
using greenhouse.Components;
using greenhouse.Data;
using greenhouse.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(); // Required for Identity UI
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

if (builder.Environment.IsDevelopment())
{
    // Use SQLite if on dev.
    builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
}
else
{
    // Else use "prod"
    builder.Services.AddDbContext<DataContext>(options =>
        options.UseMySql(
            builder.Configuration.GetConnectionString("MySqlConnection"),
            new MySqlServerVersion(new Version(8, 0, 23)) // Replace with your MySQL server version
        )
    );
}


builder.Services.AddHttpClient("MyHttpClient", client =>
{
    var baseAddress = builder.Configuration["ApiBaseUrl"];
    client.BaseAddress = new Uri(baseAddress);
}); // Register HttpClient

builder.Services.AddControllers(); // Add this line


// Add the application Identity provider
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/api/auth/login"; // Set your login path
    options.LogoutPath = "/logout"; // Set your logout path
    options.SlidingExpiration = true; // Enable sliding expiration
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set cookie expiration time
});

builder.Services.AddAuthorizationCore(); // Ensure this is present
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

//  Registering IPlantService with AddScoped allows any other parts of the app to request IPlantService and receive an instance of PlantService.
builder.Services.AddScoped<IPlantService, PlantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();


app.UseAuthentication();
app.UseAuthorization();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

app.Run();

// I was here

// I was here as well!