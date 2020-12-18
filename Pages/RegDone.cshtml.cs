using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bussines.Pages
{
    public class RegDoneModel : SecurePageModel
    {
        private readonly ILogger<RegDoneModel> _logger;

        public RegDoneModel(ILogger<RegDoneModel> logger)
        {
            _logger = logger;
        }

    }
}