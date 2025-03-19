using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTaskApi.Persistence.Repositories.Tasks;

namespace MyTaskApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController(ITaskRepository taskRepository) : ControllerBase
{
  //CRUD 
  // POST 
  // GET 
  // GET 
  // PUT 
  // DELETE
  ITaskRepository _taskRepository => taskRepository;

  [HttpPost]
  public async Task<ActionResult> Post(CreateTaskRequest request)
  {
    var task = request.ToDomain();

    await _taskRepository.Create(task);

    var response = CreateTaskResponse.FromDomain(task);
    return CreatedAtAction(actionName: nameof(Get), routeValues: new { id = task.Id }, value: response);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult> Get(int id)
  {
    var task = await _taskRepository.Get(id);

    var response = CreateTaskResponse.FromDomain(task);
    return Ok(response);
  }

  [HttpGet]
  public async Task<ActionResult> GetAll()
  {
    var tasks = await _taskRepository.GetAll();

    var response = tasks.Select(t => CreateTaskResponse.FromDomain(t));
    return Ok(response);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult> Put(int id, CreateTaskRequest request)
  {
    var task = request.ToDomain(id);

    await _taskRepository.Update(task);

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> Delete(int id)
  {
    await _taskRepository.Delete(id);
    return NoContent();
  }

  public record CreateTaskRequest(string title, string description)
  {
    public Domain.Task ToDomain()
    {
      return new Domain.Task() { Title = title, Description = description };
    }

    public Domain.Task ToDomain(int id)
    {
      return new Domain.Task() { Id = id, Title = title, Description = description };
    }
  }

  public record CreateTaskResponse(int id, string title, string description)
  {
    public static CreateTaskResponse FromDomain(Domain.Task task)
    {
      return new CreateTaskResponse(task.Id, task.Title, task.Description);
    }
  }
}
