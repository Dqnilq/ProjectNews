using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Bussines.Dao;
using Bussines.Models;
using Npgsql;

namespace Bussines.DAO
{
    public class BlogDao : IDao<Blog>
    {
        
        public override string ToString()
        {
            return "blog";
        }
        
        public Blog GetById(int id)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var command = new NpgsqlCommand(this.SelectById(id), connection);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                var user = GetBlog(reader);
                return user;
            }
            else { return null; }
        }

        public List<Blog> GetAll()
        {
            var allBlogs = new List<Blog>();
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var command = new NpgsqlCommand(this.SelectAll(), connection);
            var reader = command.ExecuteReader();
            
            if (!reader.HasRows) return allBlogs;

           
            foreach (DbDataRecord record in reader)
            {
                var blog = GetBlog(record);
                allBlogs.Add(blog);
            }
            return allBlogs;
        }

        public void Save(Blog blg)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var s = this.Insert(
                new[] {"users_id", "name_content", "description", "content", "creation_date", "photolink"},
                new object[] {blg.User_id, blg.Name, blg.Description, blg.Content, blg.registration_date.ToString("d"), blg.Photoslink});
            var command = new NpgsqlCommand(
                this.Insert(
                    new[] {"users_id", "name_content", "description", "content", "creation_date", "photolink"},
                    new object[] {blg.User_id, blg.Name, blg.Description, blg.Content, blg.registration_date.ToString("d"), blg.Photoslink}),
                connection);
            command.ExecuteNonQuery();
        }

        public void Delete(Blog t)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public static Blog GetBlog(IDataRecord record)
        {
            return new Blog(
                int.Parse(record["id"].ToString()),
                record["name_content"].ToString(),
                record["description"].ToString(),
                int.Parse(record["users_id"].ToString()),
                DateTime.Parse(record["creation_date"].ToString()),
                record["content"].ToString(),
                record["photolink"].ToString());
        }
    }
}