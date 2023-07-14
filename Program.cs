using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FirstBlazorApp.Data;
using MyBlog.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using CsvHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddSingleton < MyBlogApiServerSide>();

builder.Services.AddDbContextFactory<MyBlogDbContext>(opt =>
opt.UseSqlite($"Data Source={builder.Environment.ContentRootPath}/MyBlog.db"));
MyBlogDbContextFactory myBlogDbContextFactory = new MyBlogDbContextFactory();
myBlogDbContextFactory.CreateDbContext(new string[1]).Database.Migrate();

builder.Services.AddScoped<MyBlog.Data.Interfaces.IMyBlogApi, MyBlogApiServerSide>();

//builder.Services.AddSqlite<MyBlogDbContext>($"Data Source={builder.Environment.ContentRootPath}/MyBlog.db") ;
//services.AddScoped<IMyBlogApi, MyBlogApiServerSide>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbContextFactory<MyBlogDbContext> factory)
//{
//    factory.CreateDbContext().Database.Migrate();
//}

//IDbContextFactory<MyBlogDbContext> factory;
//factory.CreateDbContext().Database.Migrate();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers();
app.Run();
