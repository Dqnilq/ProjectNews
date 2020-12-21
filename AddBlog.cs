using System;
using System.Text.RegularExpressions;
using Bussines.DAO;
using Bussines.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Bussines
{
    public static class AddBlog
    {
        public static void Add(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var name = context.Request.Headers["name_content"];  
                var desc = context.Request.Headers["description"];
                var content = context.Request.Headers["content"];
                var photolink = context.Request.Headers["photolink"];
                var userId = context.Session.GetInt32("users_id");
            
            
                var blog = new Blog(name, desc, (int)userId, DateTime.Now, content, photolink);
                
                new BlogDao().Save(blog);
            
                context.Response.Headers.Add("result", "ok");
            });
            
        }
    }
}