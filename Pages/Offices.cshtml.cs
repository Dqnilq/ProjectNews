using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bussines.Pages
{
    public class OfficesModel : PageModel
    {
        private readonly ILogger<OfficesModel> _logger;

        public OfficesModel(ILogger<OfficesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}