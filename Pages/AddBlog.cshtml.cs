using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bussines.Pages
{
    public class AddBlogModel : PageModel
    {
        private readonly ILogger<AddBlogModel> _logger;
        
        public AddBlogModel(ILogger<AddBlogModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            
        }
    }
}