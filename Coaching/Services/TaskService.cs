using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coaching.Data;
using Coaching.Interfaces;
using Coaching.Models;
using Microsoft.VisualBasic;

namespace Coaching.Services
{
    public class TaskService : ITaskService
    {
        private ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<TaskModel> GetTasks()
        {
            return _context.Tasks.ToList();
        }
        public async Task<TaskModel> GetTask(int taskId)
        {
            var found = await _context.Tasks.FindAsync(taskId);
            return found;
        }
        //public TaskModel GetTask(int TaskId)
        //{
        //    return _context.Tasks.Find(TaskId);
        //}

        public void AddTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void EditTask(TaskModel task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(TaskModel task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }

}
