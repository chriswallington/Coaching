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
    public class IndexModel : PageModel
    {
        private readonly Coaching.Data.ApplicationDbContext _context;

        public IndexModel(Coaching.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaskModel> TaskModel { get;set; }

        public async Task OnGetAsync()
        {
            TaskModel = await _context.Tasks.ToListAsync();
        }
    }
}
