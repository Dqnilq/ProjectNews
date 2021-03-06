﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Bussines.DAO;
using Bussines.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Bussines
{
    public static class Authorization
    {
         public static void Start(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var request = context.Request;
                if (request.Headers["new_user"]  == "true")
                {
                    SignUp(context);
                }
                else
                {
                    SignIn(context);
                }
            });
        }

        public static void Exit(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var request = context.Request;
                if (request.Headers.ContainsKey("exit"))
                {
                    context.Response.Headers.Add("result", "ok");
                    context.Session.Remove("users_id");
                }
                else
                {
                    context.Response.Headers.Add("result", "failed");
                }
            });
        }

        private static void SignIn(HttpContext context)
        {
            var name = context.Request.Headers["name"];
            var password = context.Request.Headers["password"];
            var user = new UsersDao().TrySignin(name, hashPassword(password));
            var type_session = context.Request.Cookies[".AspNetCore.Session"];
            var rememberme = context.Request.Headers["remember"].ToString();
            
            
           context.Session.SetString("123", "123");

           context.Response.Cookies.Delete(".AspNetCore.Session");
            
           if (rememberme == "false")
           {
               context.Response.Cookies.Append(".AspNetCore.Session", type_session);
           }
           else
           {
               context.Response.Cookies.Append(".AspNetCore.Session", type_session, new CookieOptions(){Expires = DateTimeOffset.MaxValue});
           }
            
            MakeResponse(context, user);
        }

        private static void SignUp(HttpContext context)
        {
            var name = context.Request.Headers["name"];
            var password = context.Request.Headers["password"];
            var userName = context.Request.Headers["user_name"];
            var phoneNum = context.Request.Headers["phone_num"];
            var valid = Validate(name, password);
            if (!valid)
            {
                MakeErrorResponse(context);
                return;
            }
            var user = new UsersDao().TrySignup(name, hashPassword(password), userName, phoneNum);
            MakeResponse(context, user);
        }
    
        private static bool Validate(string name, string password)
        {
            var regexName = new Regex("^[a-zA-Zа-яёА-ЯЁ]{3,20}$");
            var checkName = regexName.IsMatch(name);
            
            var regexPassword = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$");
            var checkPassword = regexPassword.IsMatch(password);

            return checkName && checkPassword;
        }

        private static void MakeResponse(HttpContext context, Users user)
        {
            if (user != null)
            {
                context.Response.Headers.Add("result", "ok");
                context.Session.SetInt32("users_id", user.Id);
                context.Session.SetString("users_name", user.Name);
                
            }
            
            else
            {
                context.Response.Headers.Add("result", "failed");
            }
        }

        private static void MakeErrorResponse(HttpContext context)
        {
            context.Response.Headers.Add("result", "error");
        }
        
        private static bool ComparePassword(string pwd, string hashed) => hashPassword(pwd).Equals(hashed);

        private static string hashPassword(string pwd)
        {
            var md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pwd));  
  
            var result = md5.Hash;  

            var strBuilder = new StringBuilder();  
            
            foreach (var t in result)
            {
                strBuilder.Append(t.ToString("x2"));
            }

            return strBuilder.ToString();  
        }
    }
}