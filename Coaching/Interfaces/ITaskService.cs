using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coaching.Models;

namespace Coaching.Interfaces
{
    public interface ITaskService
    {
        Task<TaskModel> GetTask(int taskId);
        Task<List<TaskModel>> GetTasks();

        Task<TaskModel> AddTask(TaskModel task);
        Task<TaskModel> EditTask(TaskModel task);
        Task<TaskModel> DeleteTask(int TaskId);
    }
}
