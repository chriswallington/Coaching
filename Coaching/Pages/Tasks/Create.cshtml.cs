using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Coaching.Data;
using Coaching.Interfaces;
using Coaching.Models;
using Coaching.Services;

namespace Coaching.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly ITaskService _taskService;

        public CreateModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaskModel TaskModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _taskService.AddTask(TaskModel);

            return RedirectToPage("./Index");
        }
    }
}
