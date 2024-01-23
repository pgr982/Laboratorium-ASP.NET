using Data;
using Laboratorium_3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Laboratorium_3.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Laboratorium_3ContextConnection") ?? throw new InvalidOperationException("Connection string 'Laboratorium_3ContextConnection' not found.");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddDefaultIdentity<IdentityUser>()
.AddEntityFrameworkStores<AppDbContext>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Laboratorium_3Context>();

//builder.Services.AddSingleton<IContactService, MemoryContactService>();
builder.Services.AddTransient<IContactService, EFContactService>();
//builder.Services.AddSingleton<IPostService, MemoryPostService>();
builder.Services.AddTransient<IPostService, EFPostService>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseMiddleware<LastVisitCookie>();

app.UseAuthentication();
app.UseAuthorization(); 
app.UseSession();                                        
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
