namespace MyTaskApi.Domain;

public class Task
{
  public int Id {get; set;}
  public string Title {get; init;} = string.Empty;
  public string Description{get; init;} = string.Empty;

}