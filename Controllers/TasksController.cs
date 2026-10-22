using Microsoft.AspNetCore.Mvc;
using MiniGorevTakip.Models;
using MiniGorevTakip.Services;

namespace MiniGorevTakip.Controllers;

public class TasksController : Controller
{
    private readonly ITaskService _tasks;

    public TasksController(ITaskService tasks)
    {
        _tasks = tasks;
    }

    // GET /Tasks  -> Görev Liste
    public IActionResult Index()
    {
        return View(_tasks.GetAll());
    }

    // GET /Tasks/Create  -> Boş form
    [HttpGet]
    public IActionResult Create()
    {
        return View(new TaskItem());
    }

    // POST /Tasks/Create  -> Formu kaydet
    // [Bind] sadece listelenen alanları formdan alır (Id, IsCompleted gibi alanlar dışarıdan değiştirilemez).
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Title,Description")] TaskItem task)
    {
        if (!ModelState.IsValid)
        {
            return View(task);
        }

        _tasks.Add(task);
        TempData["Message"] = "Görev eklendi.";
        return RedirectToAction(nameof(Index));
    }

    // GET /Tasks/Edit/3  -> Dolu form(düzenleme formu)
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _tasks.GetById(id);
        if (task is null) return NotFound();

        return View(task);
    }

    // POST /Tasks/Edit  -> Değişikliği kaydet
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Edit([Bind("Id,Title,Description")] TaskItem task)
    {
        if (!ModelState.IsValid)
        {
            return View(task);
        }

        if (!_tasks.Update(task)) return NotFound();

        TempData["Message"] = "Görev güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    // POST /Tasks/ToggleComplete/3  -> Tamamlandı / geri al
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult ToggleComplete(int id)
    {
        if (!_tasks.ToggleComplete(id)) return NotFound();

        return RedirectToAction(nameof(Index));
    }

    // POST /Tasks/Delete/3  -> Sil
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        if (!_tasks.Delete(id)) return NotFound();

        TempData["Message"] = "Görev silindi.";
        return RedirectToAction(nameof(Index));
    }

    // Canlıda beklenmeyen hata olursa Program.cs buraya yönlendirir.
    public IActionResult Error()
    {
        return View();
    }
}