using System;

namespace Bussines.Models
{
    public class Officess : IEntity
    {
        public int Id { get; set; }
        
        public int User_id { get; set; }
        
        public string Name { get; set; }
        
        public string Price { get; set; }
        
        public string Photoslink { get; set; }
        
        public DateTime registration_date  { get; set; }
        
        
        
        
        public Officess(int id, string name, string price, int user_id, DateTime registrationDate , string photoslink)
        {
            Id = id;
            Name = name;
            Price = price;
            User_id = user_id;
            registration_date = registrationDate;
            Photoslink = photoslink;
        }
        
        public Officess(string name, string price, string photoslink, int user_id)
        {
            Name = name;
            Price = price;
            Photoslink = photoslink;
            User_id = user_id;
        }
    }
}