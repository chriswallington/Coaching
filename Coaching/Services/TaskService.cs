using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coaching.Data;
using Coaching.Interfaces;
using Coaching.Models;

namespace Coaching.Services
{
    public class TaskService : ITaskService
    {

        public List<TaskModel> GetTasks()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Tasks.ToList();
            }
        }

        public TaskModel GetTask(int TaskId)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return context.Tasks.Find(TaskId);
            }
        }
    }

}
