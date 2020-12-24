using System;

namespace Bussines.Models
{
    public class Comment : IEntity 
    {
        public int Id { get; set; }
        
        public int User_id { get; set; }
        
        public string Comment_text { get; set; }
        
        
        public DateTime creation_date  { get; set; }
        
        
        
        
        public Comment(int id, int userId, string commentText, DateTime creationDate)
        {
            Id = id;
            User_id = userId;
            Comment_text = commentText;
            creation_date = creationDate;
        }
        
        public Comment(int userId, string commentText, DateTime registrationDate)
        {
            User_id = userId;
            Comment_text = commentText;
            creation_date = registrationDate;
        }
    }
}