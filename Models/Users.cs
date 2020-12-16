using System;

namespace Bussines.Models
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        
        public string user_name { get; set; }
        
        public string phone_num { get; set; }
        
        public DateTime registration_date  { get; set; }
        

        public Users(string name, string password, DateTime registrationDate , string user_name, string phone_num)
        {
            Name = name;
            Password = password;
            registration_date = registrationDate;
            user_name = this.user_name;
            phone_num = this.phone_num;
        }
        
        public Users(int id, string name, string password, DateTime registrationDate, string user_name, string phone_num)
        {
            Id = id;
            Name = name;
            Password = password;
            registration_date = registrationDate;
            user_name = this.user_name;
            phone_num = this.phone_num;
        }
    }
}