using System.Collections.Generic;
using Bussines.DAO;
using Bussines.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bussines
{
    public class SecurePageModel : PageModel
    {
        public Users Users;
        
        
        public IActionResult OnGet()
        {
            var usersId = HttpContext.Session.GetInt32("users_id");
            if (usersId == null)
            {
                return Redirect("SignIn");
            }
            var usersDao = new UsersDao();
            Users = usersDao.GetById((int) usersId);
            return null;
        }
        
       
    }
}