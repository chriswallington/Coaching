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
    public class DeleteModel : PageModel
    {
        private readonly ITaskService _taskService;

        public DeleteModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [BindProperty]
        public TaskModel TaskModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskModel = await _taskService.GetTask(id);

            if (TaskModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskModel = await _taskService.DeleteTask(id);

            return RedirectToPage("./Index");
        }
    }
}
