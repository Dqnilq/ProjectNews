using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Bussines.Dao;
using Bussines.Models;
using Npgsql;

namespace Bussines.DAO
{
    public  class UsersDao : IDao<Users>
    {
        public override string ToString()
        {
            return "users";
        }

        public Users GetById(int id)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var command = new NpgsqlCommand(this.SelectById(id), connection);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                var user = GetUser(reader);
                return user;
            }
            else { return null; }
        }

        public List<Users> GetAll()
        {
            var allUsers = new List<Users>();
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var command = new NpgsqlCommand(this.SelectAll(), connection);
            var reader = command.ExecuteReader();
            if (!reader.HasRows) return allUsers;
            foreach (DbDataRecord record in reader)
            {
                var user = GetUser(record);
                allUsers.Add(user);
            }

            return allUsers;
        }

        public void Save(Users user)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var s = this.Insert(
                                        new[] {"name", "password", "user_name", "phone_num", "registration_date"},
                                        new object[] {user.Name, user.Password, user.UserName, user.PhoneNum, user.registration_date.ToString("d")});
            var command = new NpgsqlCommand(
                this.Insert(
                    new[] {"name", "password", "user_name", "phone_num", "registration_date"},
                    new object[] {user.Name, user.Password, user.UserName, user.PhoneNum, user.registration_date.ToString("d")}),
                connection);
            command.ExecuteNonQuery();
        }

        public void Delete(Users user)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var command = new NpgsqlCommand(this.Delete(user.Id), connection);
            command.ExecuteNonQuery();
        }

        public void DeleteById(int id)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var command = new NpgsqlCommand(this.Delete(id), connection);
            command.ExecuteNonQuery();
        }

        // public List<Course> GetCourses(int userId)
        // {
        //     var courses = new List<Course>();
        //     using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
        //     {
        //         connection.Open();
        //         var cmdText = $"SELECT course.* FROM users " +
        //                       $"JOIN users_to_course ON users.id = users_to_course.users_id " +
        //                       $"JOIN course ON users_to_course.course_id = course.id " +
        //                       $"WHERE users.id = {userId};";
        //         var command = new NpgsqlCommand(cmdText, connection);
        //         var reader = command.ExecuteReader();
        //         if (reader.HasRows)
        //         {
        //             foreach (DbDataRecord record in reader)
        //             {
        //                 var course = new CourseDao().GetCourse(record);
        //                 courses.Add(course);
        //             }
        //         }
        //     }
        //     return courses;
        // }

        // public void AddCourseToUser(int userId, int courseId)
        // {
        //     using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get()))
        //     {
        //         connection.Open();
        //         var command1 = new NpgsqlCommand(
        //             $"UPDATE users " +
        //             $"SET number_of_courses = number_of_courses + 1 " +
        //             $"WHERE id = {userId};", 
        //             connection);
        //         command1.ExecuteNonQuery();
        //         var command2 = new NpgsqlCommand(
        //             $"UPDATE course " +
        //             $"SET post_count = post_count + 1 " +
        //             $"WHERE id = {courseId};", 
        //             connection);
        //         command2.ExecuteNonQuery();
        //         var command3 = new NpgsqlCommand(
        //             PgsqlFormat.Insert(
        //                 "users_to_course",
        //                 new[] {"users_id", "course_id"}, 
        //                 new object[] {userId, courseId}),
        //             connection);
        //         command3.ExecuteNonQuery();
        //     }
        // }

        public Users TrySignin(string name, string password)
        {
            var user = GetByName(name);
            
            if (user == null)
                return null;

            return user.Password == password ? user : null;
        }

        public Users TrySignup(string name, string password, string userName, string phoneNum)
        {
            var user = GetByName(name);

            if (user != null)
                return null;

            user = new Users(name, password, DateTime.Now, userName, phoneNum);
            Save(user);
            
            return user;
        }

        private Users GetByName(string name)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var command = new NpgsqlCommand(this.SelectByField("name", name), connection);
            var reader = command.ExecuteReader();
            if (!reader.HasRows) return null;
            reader.Read();
            var user = GetUser(reader);
            return user;
        }

        private static Users GetUser(IDataRecord record)
        {
            return new Users(
                int.Parse(record["id"].ToString()),
                record["name"].ToString(),
                record["password"].ToString(),
                DateTime.Parse(record["registration_date"].ToString()),
                record["user_name"].ToString(),
                record["phone_num"].ToString());
        }
    }
}