using System;
using System.Text.RegularExpressions;
using Bussines.DAO;
using Bussines.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Bussines
{
    public static class AddComment
    {
        public static void Add(IApplicationBuilder app)
        {
            app.Run(async context =>
            { 
                var userId = context.Session.GetInt32("users_id");
                var comment_text = context.Request.Headers["comment_text"]; 
            
            
                var comment = new Comment((int)userId, comment_text, DateTime.Now);
            
                new CommentDao().Save(comment);
            
                context.Response.Headers.Add("result", "ok");
            });
            
        }
    }
}