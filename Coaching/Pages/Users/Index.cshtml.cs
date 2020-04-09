using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coaching.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coaching.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public IndexModel(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

    
    }
}