# Mini Görev Takip

ASP.NET Core MVC (.NET 8) + Entity Framework Core + SQL Server Express.

## Önce veritabanı (bir kez)
```
sqlcmd -S .\SQLEXPRESS -E -C -Q "CREATE DATABASE MiniGorevTakipDb"
```

## Migration (tabloyu oluşturma)
```
dotnet new tool-manifest
dotnet tool install dotnet-ef
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Çalıştırma
```
dotnet build
dotnet run
```
Tarayıcıda: http://localhost:5080
