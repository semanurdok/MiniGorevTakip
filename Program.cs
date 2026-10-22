using Microsoft.EntityFrameworkCore;
using MiniGorevTakip.Data;
using MiniGorevTakip.Services;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

if (!OperatingSystem.IsWindows())
{
    throw new PlatformNotSupportedException(
        "Bu yapılandırma yalnızca Windows üzerinde desteklenir.");
}

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(
        new DirectoryInfo(@"C:\MiniGorevTakipVeri\Anahtarlar"))
    .ProtectKeysWithDpapi(protectToLocalMachine: true);

// MVC (Controller + View) desteğini ekler.
builder.Services.AddControllersWithViews();

// Bağlantı metni appsettings.json içinden okunur.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("appsettings.json içinde 'DefaultConnection' bulunamadı.");

// EF Core + SQL Server. DbContext her HTTP isteği için ayrı (scoped) oluşturulur.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Servis de scoped olmalı, çünkü scoped olan DbContext'e ihtiyaç duyuyor.
builder.Services.AddScoped<ITaskService, EfTaskService>();

var app = builder.Build();

// Canlıda (Development dışında) hata olursa kullanıcıya sade bir hata sayfası göster.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Tasks/Error");
}

// Not: Şimdilik HTTPS yönlendirmesi KAPALI. Yerel ağda düz HTTP ile deneyeceğiz.

app.UseStaticFiles();   // wwwroot içindeki css/js/resim dosyaları
app.UseRouting();

// Adres boşsa -> TasksController.Index açılır.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tasks}/{action=Index}/{id?}");

app.Run();
