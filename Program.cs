// This file configures your application and registers services (like the DataContext) 
// so the app knows about them.
//----------------------------------------------------------------------------------
using greenhouse.Components;
using greenhouse.Data;
using greenhouse.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<DataContext>(options =>
	 options.UseMySql(
		builder.Configuration.GetConnectionString("MySqlConnection"),
		new MySqlServerVersion(new Version(8, 0, 23)) // Replace with your MySQL server version
	)
);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DataContext>();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapRazorPages();

app.Run();
