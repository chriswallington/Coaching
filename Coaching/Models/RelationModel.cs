using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Coaching.Models
{
    public class RelationModel
    {
        public int UserId { get; set; }
        public UserModel ApplicationUser { get; set; }
        public int CoachId { get; set; }
        public UserModel CoachUser { get; set; }

    }

}
