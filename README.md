# MiniGorevTakip

ASP.NET Core MVC ile geliştirilen, görev oluşturma ve takip işlemlerini gerçekleştirmeyi amaçlayan web uygulaması.

Bu proje kapsamında web uygulaması geliştirme, veritabanı işlemleri ve Windows üzerinde IIS kullanarak yayınlama deneyimi edinilmiştir.

## Kullanılan Teknolojiler

- **C#**
- **ASP.NET Core MVC (.NET 8)**
- **Entity Framework Core**
- **Microsoft SQL Server**
- **Razor Views, HTML ve CSS**
- **IIS (Internet Information Services)**
- **HTTPS ve TLS sertifikaları**

## Proje Yapısı

| Katman / Klasör | Açıklama |
|---|---|
| `Controllers` | HTTP isteklerini karşılar ve uygulama akışını yönetir. |
| `Models` | Görev verilerini temsil eden modelleri içerir. |
| `Views` | Kullanıcı arayüzünü oluşturan Razor sayfalarını içerir. |
| `Data` | Veritabanı bağlamını ve veri erişimi yapılandırmasını içerir. |
| `Services` | Görev işlemlerinin iş mantığını Controller katmanından ayırır. |
| `Migrations` | Veritabanı şeması değişikliklerini yönetir. |
| `wwwroot` | CSS ve diğer statik dosyaları içerir. |

## Mimari

Uygulama ASP.NET Core MVC mimarisiyle geliştirilmiştir.

`TasksController`, görev işlemleri için `ITaskService` arayüzünü kullanır. `EfTaskService`, bu işlemleri Entity Framework Core üzerinden gerçekleştirir. Bu yapı, Controller ile veri erişim mantığının birbirinden ayrılmasını sağlar.

Entity Framework Core, SQL Server ile veri işlemlerini yürütmek için kullanılır.

## IIS Üzerinde Yayınlama ve Test

Proje, Windows işletim sistemi üzerinde IIS kullanılarak yayınlanmıştır.

Gerçekleştirilen çalışmalar:

- IIS sitesi ve uygulama havuzunun yapılandırılması
- Yayın dosyalarının ayrı bir klasörde tutulması
- SQL Server üzerinde uygulama için ayrı bir veritabanının hazırlanması
- Uygulama havuzu için gerekli veritabanı izinlerinin yapılandırılması
- HTTPS bağlaması ve test sertifikasının oluşturulması
- Yerel ağdaki bir mobil cihazdan HTTPS bağlantısının test edilmesi
- Uygulama üzerinden eklenen bir görevin veritabanına kaydedildiğinin doğrulanması

**Yayınlama notu:** Bu çalışma, uygulamanın Windows bilgisayar üzerinde IIS ile yerel ağda test edilmesini kapsar. Uygulamanın herkese açık internette yayımlandığı anlamına gelmez.

## Yerel Ortamda Çalıştırma

1. Uygun .NET SDK sürümünü ve SQL Server'ı kurun.
2. `appsettings.json` içindeki `DefaultConnection` bağlantı dizesini kendi ortamınıza göre düzenleyin.
3. Gerekli NuGet paketlerini yükleyin.
4. Veritabanı şemasını migration dosyalarına uygun şekilde oluşturun.
5. Uygulamayı Visual Studio veya `dotnet run` komutuyla çalıştırın.

## Öğrenilenler

- MVC mimarisi ve katmanların sorumlulukları
- Routing ve endpoint eşleştirmesi
- Servis arayüzleri ve bağımlılık enjeksiyonu
- Entity Framework Core ve migration işlemleri
- IIS, uygulama havuzları ve ASP.NET Core Module (ANCM)
- IP adresi, port, HTTPS ve sertifika yapılandırması
- Yayınlama öncesi yedekleme ve rollback yaklaşımı

## Güvenlik

- Üretim bağlantı ayarları, parolalar, özel anahtarlar ve özel sertifika dosyaları kaynak kod deposuna eklenmemelidir.
- Test sertifikaları yalnızca yetkili test cihazlarında kullanılmalıdır.
- Gerçek kullanım için kimlik doğrulama, yetkilendirme ve sunucu güvenliği ayrıca değerlendirilmelidir.

## Amaç

Bu proje, ASP.NET Core MVC ile web uygulaması geliştirme, SQL Server ile veri yönetimi ve IIS üzerinde yayınlama süreçlerinde edinilen deneyimleri göstermek amacıyla hazırlanmıştır.
