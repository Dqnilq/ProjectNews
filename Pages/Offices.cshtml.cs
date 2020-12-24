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
    public class OfficesModel : PageModel
    {
        public List<Officess> Officeses { get; set; }

        public void OnGet()
        {
            var officedao = new OfficeDao();
            
            Officeses = officedao.GetAll();
        }
    }
}