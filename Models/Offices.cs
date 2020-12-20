using System;

namespace Bussines.Models
{
    public class Offices : IEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Price { get; set; }
        
        public string Photoslink { get; set; }
        
        public string PhoneNum { get; set; }
        
        public string UserName { get; set; }
        public DateTime registration_date  { get; set; }
        
        
        public Offices(string name, int price, DateTime registrationDate, string photoslink, string phoneNum, string userName)
        {
            Name = name;
            Price = price;
            registration_date = registrationDate;
            Photoslink = photoslink;
            PhoneNum = phoneNum;
            UserName = userName;

        }
        
        public Offices(int id, string name, int price, DateTime registrationDate , string photoslink, string phoneNum, string userName)
        {
            Id = id;
            Name = name;
            Price = price;
            registration_date = registrationDate;
            Photoslink = photoslink;
            PhoneNum = phoneNum;
            UserName = userName;
        }
    }
}