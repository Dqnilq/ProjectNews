using System;
using System.Collections.Generic;
using Bussines.Models;

namespace Bussines.Dao
{
    public interface IDaoBase 
    {
        public abstract string UploadContent(string content);
        public abstract string DeleteContent(string content);
        
        public abstract string UploadBlog(string content);
        public abstract string DeleteBlog(string content);
        
        public abstract string UploadOffice(string content);
        public abstract string DeleteOffice(string content);
        
        public abstract string UploadBVideo(string content);
        public abstract string DeleteVideo(string content);
        
        
        public abstract string UploadComment(string content);
        public abstract string DeleteComment(string content);
        
    }
}