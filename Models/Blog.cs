namespace Bussines.Models
{
    public class Blog : IEntity
    {
        
        public int Id { get; set; }
        
        public string Heading { get; set; }
        
        public string Description { get; set; }
        
        public string Context { get; set; }
        
        public string PhotosLink { get; set; }
        
        
        public Blog(int id, string heading, string description, string context, string photosLink)
        {
            Id = id;
            Heading = heading;
            Description = description;
            Context = context;
            PhotosLink = photosLink;
        }
    }
}