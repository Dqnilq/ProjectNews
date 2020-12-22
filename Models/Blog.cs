using System;

namespace Bussines.Models
{
    public class Blog : IEntity
    {
        public int Id { get; set; }
        
        public int User_id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Content { get; set; }
        
        public string Photoslink { get; set; }
        
        public DateTime registration_date  { get; set; }
        
        
        
        
        public Blog(int id, string name, string description, int user_id, DateTime registrationDate, string content, string photoslink)
        {
            Id = id;
            Name = name;
            Description = description;
            User_id = user_id;
            registration_date = registrationDate;
            Content = content;
            Photoslink = photoslink;
        }
        
        public Blog(string name, string description, int user_id, DateTime registrationDate, string content, string photoslink)
        {
            Name = name;
            Description = description;
            User_id = user_id;
            registration_date = registrationDate;
            Content = content;
            Photoslink = photoslink;
        }
    }
}