using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bussines.Models;
using Npgsql;

namespace Bussines.Dao
{
    public interface IDao <T>
    {
        public T GetById(int id);
        public List<T> GetAll();
        public void Save(T t);
        public void Delete(T t);
        public void DeleteById(int id);
    }
}