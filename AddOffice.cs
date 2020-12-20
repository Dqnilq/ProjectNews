using System.Text.RegularExpressions;
using Bussines.DAO;
using Bussines.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Bussines
{
    public static class AddOffice
    {
        public static void Add(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var name = context.Request.Headers["name"];  // change
                var price = context.Request.Headers["price"];
                var photolink = context.Request.Headers["photolink"];
                var phoneNum = context.Request.Headers["phone_num"];
                var user_id = context.Session.GetInt32("users_id");
            
            
                var office = new Offices(name, price, photolink, (int)user_id);
            
                new OfficeDao().Save(office);
            
                context.Response.Headers.Add("result", "ok");
            });
            
        }
    }
}