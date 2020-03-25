using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coaching.Data;
using Coaching.Interfaces;
using Coaching.Models;

namespace Coaching.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly ITaskService _taskService;

        public IndexModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IList<TaskModel> TaskModel { get;set; }

        public async Task OnGetAsync()
        {
            TaskModel = await _taskService.GetTasks();
        }
    }
}
