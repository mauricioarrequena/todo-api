
using Microsoft.EntityFrameworkCore;

namespace MyTaskApi.Persistence.Repositories.Tasks;
public class TaskRepository(AppDbContext appDbContext) : ITaskRepository
{
  AppDbContext _appDbContext => appDbContext;
  public async Task<Domain.Task> Create(Domain.Task task)
  {
    await _appDbContext.AddAsync(task);
    await _appDbContext.SaveChangesAsync();
    return task;
  }

  public async Task<Domain.Task> Get(int id)
  {
    return (await _appDbContext.Tasks.FindAsync(id))!;
  }

  public async Task<IEnumerable<Domain.Task>> GetAll()
  {
    return await _appDbContext.Tasks.ToListAsync();
  }

  public async Task<Domain.Task> Update(Domain.Task taskChanges)
  {
    var task = await _appDbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == taskChanges.Id);
    if (task == null)
    {
      throw new KeyNotFoundException($"Transaction with Id {taskChanges.Id} not found");
    }

    _appDbContext.Tasks.Update(taskChanges);
    await _appDbContext.SaveChangesAsync();
    return task;
  }

  public async Task Delete(int id)
  {
    var task = await _appDbContext.Tasks.FindAsync(id);
    if (task == null)
    {
      throw new KeyNotFoundException($"Transaction with Id {id} not found");
    }
    _appDbContext.Tasks.Remove(task);
    await _appDbContext.SaveChangesAsync();
  }

}

