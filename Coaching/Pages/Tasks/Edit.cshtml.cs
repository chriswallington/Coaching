using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coaching.Data;
using Coaching.Interfaces;
using Coaching.Models;

namespace Coaching.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly ITaskService _taskService;

        public EditModel(ITaskService taskService)
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
            var taskToEdit = await _taskService.GetTask(id);

            if (taskToEdit == null)
            {
                return NotFound();
            }

            await _taskService.EditTask(taskToEdit);

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(TaskModel).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TaskModelExists(TaskModel.TaskId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        //private bool TaskModelExists(int id)
        //{
        //    return _taskService.GetTask(id).IsCompletedSuccessfully;
        //    //return _context.Tasks.Any(e => e.TaskId == id);
        //}
    }
}
