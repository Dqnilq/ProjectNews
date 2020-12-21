using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bussines.Pages
{
    public class AddOfficeModel : PageModel
    {
        private readonly ILogger<AddOfficeModel> _logger;
        
        public AddOfficeModel(ILogger<AddOfficeModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            
        }
    }
}