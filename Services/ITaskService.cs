using MiniGorevTakip.Models;

namespace MiniGorevTakip.Services;

public interface ITaskService
{
    IReadOnlyList<TaskItem> GetAll();
    TaskItem? GetById(int id);
    void Add(TaskItem task);
    bool Update(TaskItem task);
    bool Delete(int id);
    bool ToggleComplete(int id);
}
