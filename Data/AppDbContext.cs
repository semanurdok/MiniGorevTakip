using Microsoft.EntityFrameworkCore;
using MiniGorevTakip.Models;

namespace MiniGorevTakip.Data;

// EF Core'un veritabanıyla konuşan ana sınıfı.
// DbSet<TaskItem> = veritabanındaki "Tasks" tablosunun kodda karşılığı.
// Sütun uzunlukları ve zorunluluklar TaskItem üzerindeki [Required], [StringLength] gibi
// özniteliklerden (attribute) okunur.
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
