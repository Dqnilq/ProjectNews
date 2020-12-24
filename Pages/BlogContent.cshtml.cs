using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.DAO;
using Bussines.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bussines.Pages
{
    public class BlogContentModel : PageModel
    {
        public Blog Blog;
        
        public Users Users;
        public void OnGet(string User_Id)
        {
            var id = int.Parse(User_Id);
            Users = new UsersDao().GetById(id);
            Blog = new BlogDao().GetById(id);
        }
    }
}