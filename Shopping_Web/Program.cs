// === �إ� WebApplicationBuilder �e�� ===
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Shopping_Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// �]�wDB�s�u
// ToDo �ݤ��ᦳ�S�� Config �������覡
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

// HTTP�ഫ��HTTPS
app.UseHttpsRedirection();

// ���J�R�A�귽 �Ҧp�Ghtml, javascript, css, image... ����
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();

// ���v����
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ����{��
app.Run();
