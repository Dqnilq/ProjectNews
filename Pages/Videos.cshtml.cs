﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bussines.Pages
{
    public class VideosModel : PageModel
    {
        private readonly ILogger<VideosModel> _logger;

        public VideosModel(ILogger<VideosModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}