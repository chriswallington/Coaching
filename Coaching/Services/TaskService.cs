using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coaching.Data;
using Coaching.Interfaces;
using Coaching.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Coaching.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }
        public async Task<TaskModel> GetTask(int? taskId)
        {
            return await _context.Tasks.FindAsync(taskId);
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> EditTask(TaskModel task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> DeleteTask(int? taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            
            return task;
        }
    }

}
