using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Bussines.Dao;
using Bussines.Models;
using Npgsql;

namespace Bussines.DAO
{
    public class CommentDao : IDao<Comment>
    {
        
        public override string ToString()
        {
            return "comment";
        }
        public Comment GetById(int id)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var command = new NpgsqlCommand(this.SelectById(id), connection);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                var user = GetComment(reader);
                return user;
            }
            else { return null; }
        }

        public List<Comment> GetAll()
        {
            var allComment = new List<Comment>();
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var command = new NpgsqlCommand(this.SelectAll(), connection);
            var reader = command.ExecuteReader();
            
            if (!reader.HasRows) return allComment;

            
            foreach (DbDataRecord record in reader)
            {
                var comment = GetComment(record);
                allComment.Add(comment);
            }
            return allComment;
        }

      

        public void Save(Comment com)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var s = this.Insert(
                new[] {"users_id", "comment_text", "creation_date"},
                new object[] {com.User_id, com.Comment_text, com.creation_date.ToString("d")});
            var command = new NpgsqlCommand(
                this.Insert(
                    new[] {"users_id", "comment_text", "creation_date"},
                    new object[] {com.User_id, com.Comment_text, com.creation_date.ToString("d")}),
                connection);
            command.ExecuteNonQuery();
        }

        public void Delete(Comment t)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        private static Comment GetComment(IDataRecord record)
        {
            return new Comment(
                int.Parse(record["id"].ToString()),
                int.Parse(record["users_id"].ToString()),
                record["comment_text"].ToString(),
                DateTime.Parse(record["creation_date"].ToString()));
        }
    }
}