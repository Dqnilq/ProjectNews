using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bussines.Pages
{
    public class SigninModel : PageModel
    {
        private readonly ILogger<SigninModel> _logger;

        public SigninModel(ILogger<SigninModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}