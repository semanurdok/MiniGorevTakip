using System.ComponentModel.DataAnnotations;

namespace MiniGorevTakip.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Başlık zorunludur.")]
    [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
    [Display(Name = "Başlık")]
    public string Title { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
    [Display(Name = "Açıklama")]
    public string? Description { get; set; }

    [Display(Name = "Tamamlandı")]
    public bool IsCompleted { get; set; }

    [Display(Name = "Oluşturulma Tarihi")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
