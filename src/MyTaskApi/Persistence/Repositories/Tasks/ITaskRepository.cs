namespace MyTaskApi.Persistence.Repositories.Tasks;
public interface ITaskRepository 
{
  Task<Domain.Task> Create(Domain.Task task);
  Task<Domain.Task> Get(int id);
  Task<IEnumerable<Domain.Task>> GetAll();
  Task<Domain.Task> Update(Domain.Task taskChanges);
  Task Delete(int id);
}