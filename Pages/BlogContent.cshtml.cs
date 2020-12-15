using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bussines.Pages
{
    public class BlogContentModel : PageModel
    {
        private readonly ILogger<BlogContentModel> _logger;

        public BlogContentModel(ILogger<BlogContentModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}