using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coaching.Data;
using Coaching.Models;

namespace Coaching.Pages.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly Coaching.Data.ApplicationDbContext _context;

        public DetailsModel(Coaching.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TaskModel TaskModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskModel = await _context.Tasks.FirstOrDefaultAsync(m => m.TaskId == id);

            if (TaskModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
