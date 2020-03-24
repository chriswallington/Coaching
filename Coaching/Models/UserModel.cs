using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Coaching.Models
{
    public class UserModel : IdentityUser
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public List<TaskModel> Tasks { get; set; }

    }
}
