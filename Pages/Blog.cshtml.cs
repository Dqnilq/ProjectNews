using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.DAO;
using Bussines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;


namespace Bussines.Pages
{
    public class BlogModel : PageModel
    {
        public List<Blog> Blogs { get; set; }
        
        public void OnGet()
        {
            var blogdao = new BlogDao();
            Blogs = blogdao.GetAll();
        }
        
    }
}