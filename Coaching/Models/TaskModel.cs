using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coaching.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public bool Archived { get; set; }

    }
}
