using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bussines.Pages
{
    public class PersonModel : PageModel
    {
        private readonly ILogger<PersonModel> _logger;

        public PersonModel(ILogger<PersonModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}