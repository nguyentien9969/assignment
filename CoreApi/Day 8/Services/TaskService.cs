using Task = Day_8.Models.Task;
namespace Day_8.Services
{
    public class TaskService : ITaskService
    {
        private static readonly List<Task> _taskList = new List<Task>();
        public Task Add(Task task)
        {
            _taskList.Add(task);
            return task;
        }


        public List<Task> Add(List<Task> tasks)
        {
            _taskList.AddRange(tasks);
            return tasks;
        }

        public Task? Edit(Task task)
        {
            var entity = _taskList.FirstOrDefault(d => d.Id == task.Id);
            if (entity == null) return null;

            entity.Title = task.Title;
            entity.Description = task.Description;
            entity.Completed = task.Completed;
            return entity;
        }

        public bool Exits(Guid id)
        {
            return _taskList.Any(d => d.Id == id);
        }

        public List<Task> GetAll()
        {
            return _taskList;
        }

        public Task? GetOne(Guid id)
        {
            return _taskList.FirstOrDefault(o => o.Id == id);
        }

        public void Remove(Guid id)
        {
            var entity = _taskList.FirstOrDefault(o => o.Id == id);
            if (entity != null)
            {
                _taskList.Remove(entity);
            }
        }

        public void Remove(List<Guid> ids)
        {
            _taskList.RemoveAll(d => ids.Contains(d.Id));
        }
    }
}