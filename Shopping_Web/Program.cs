// === 建立 WebApplicationBuilder 容器 ===
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Shopping_Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 設定DB連線
// ToDo 看之後有沒有 Config 之類的方式
builder.Services.AddDbContext<Shopping_WebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Shopping_WebContext") ?? throw new InvalidOperationException("there is no Shopping_WebContext ConnectionString in Config!")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// HTTP轉換成HTTPS
app.UseHttpsRedirection();

// 載入靜態資源 例如：html, javascript, css, image... 等等
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();

// 授權驗證
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 執行程式
app.Run();
