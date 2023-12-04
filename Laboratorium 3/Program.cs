using Data;
using Laboratorium_3.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();

//builder.Services.AddSingleton<IContactService, MemoryContactService>();
builder.Services.AddTransient<IContactService, EFContactService>();
//builder.Services.AddSingleton<IPostService, MemoryPostService>();
builder.Services.AddTransient<IPostService, EFPostService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
