
namespace MyTaskApi.Domain;

public class Task
{
  public int Id { get; set; }
  public string Title { get; init; } = string.Empty;
  public string Description { get; init; } = string.Empty;
  public Enums.TaskStatus TaskStatus { get; set; } = Enums.TaskStatus.PENDING;
  public DateTime? DueDate { get; set; }
  public DateTime CraetedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}