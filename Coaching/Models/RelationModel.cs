using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Coaching.Models
{
    public class RelationModel
    {
        public int UserId;
        public UserModel ApplicationUser;
        public int CoachId;
        public UserModel CoachUser;
    }
}
