using System;

namespace Bussines.Models
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        
        public string UserName { get; set; }
        
        public string PhoneNum { get; set; }
        
        public DateTime registration_date  { get; set; }
        

        public Users(string name, string password, DateTime registrationDate , string user_name, string phone_num)
        {
            Name = name;
            Password = password;
            registration_date = registrationDate;
            UserName = user_name;
            PhoneNum = phone_num;
        }
        
        public Users(int id, string name, string password, DateTime registrationDate, string user_name, string phone_num)
        {
            Id = id;
            Name = name;
            Password = password;
            registration_date = registrationDate;
            UserName = user_name;
            PhoneNum = phone_num;
        }
    }
}