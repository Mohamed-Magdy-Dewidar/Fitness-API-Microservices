using Shared;
using System.ComponentModel.DataAnnotations;

namespace ProgressTrackingService.Entities;


public class WeightEntry : BaseEntity<Guid>
{
    [Required]
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;

    [Range(30, 500)]
    public decimal Weight { get; set; }

    public DateOnly DateRecorded { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }
    public DateTime RecordedAtUtc { get; set; } = DateTime.UtcNow;
}