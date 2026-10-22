using Microsoft.EntityFrameworkCore;
using MiniGorevTakip.Data;
using MiniGorevTakip.Models;

namespace MiniGorevTakip.Services;

// Görevleri SQL Server'da saklar (Entity Framework Core ile).
// Controller hiç değişmedi: aynı ITaskService arayüzünü kullanıyor, sadece arkasındaki sınıf farklı.
public class EfTaskService : ITaskService
{
    private readonly AppDbContext _db;

    public EfTaskService(AppDbContext db)
    {
        _db = db;
    }

    public IReadOnlyList<TaskItem> GetAll()
    {
        // Önce tamamlanmamışlar, sonra en yeni görevler üstte.
        return _db.Tasks
            .AsNoTracking()
            .OrderBy(t => t.IsCompleted)
            .ThenByDescending(t => t.CreatedAt)
            .ToList();
    }

    public TaskItem? GetById(int id)
    {
        return _db.Tasks.AsNoTracking().FirstOrDefault(t => t.Id == id);
    }

    public void Add(TaskItem task)
    {
        task.CreatedAt = DateTime.Now;
        task.IsCompleted = false;

        _db.Tasks.Add(task);
        _db.SaveChanges();
    }

    public bool Update(TaskItem task)
    {
        var existing = _db.Tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existing is null) return false;

        existing.Title = task.Title;
        existing.Description = task.Description;
        _db.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var existing = _db.Tasks.FirstOrDefault(t => t.Id == id);
        if (existing is null) return false;

        _db.Tasks.Remove(existing);
        _db.SaveChanges();
        return true;
    }

    public bool ToggleComplete(int id)
    {
        var existing = _db.Tasks.FirstOrDefault(t => t.Id == id);
        if (existing is null) return false;

        existing.IsCompleted = !existing.IsCompleted;
        _db.SaveChanges();
        return true;
    }
}
