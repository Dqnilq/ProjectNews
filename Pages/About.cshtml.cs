using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.DAO;
using Bussines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bussines.Pages
{
    public class AboutModel : PageModel
    {
        
        public List<Comment> Commentt { get; set; }
        public void OnGet()
        {
            var commentdao = new CommentDao();
            Commentt = commentdao.GetAll();
        }
        
        public void OnPost()
        {
            
        }
    }
}