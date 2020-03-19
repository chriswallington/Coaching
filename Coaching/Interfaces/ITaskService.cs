using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coaching.Models;

namespace Coaching.Interfaces
{
    public interface ITaskService
    {
        List<TaskModel> GetTasks();
        TaskModel GetTask(int TaskId);
    }
}
