using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Bussines.Dao;
using Bussines.Models;
using Npgsql;

namespace Bussines.DAO
{
    public class OfficeDao : IDao<Officess>
    {
        
        public override string ToString()
        {
            return "offices";
        }

        public Officess GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Officess> GetAll()
        {
            var allOffices = new List<Officess>();
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var command = new NpgsqlCommand(this.SelectAll(), connection);
            var reader = command.ExecuteReader();
            
            if (!reader.HasRows) return allOffices;

            // while ()
            // {
            //     
            // }
            foreach (DbDataRecord record in reader)
            {
                var office = GetOffice(record);
                allOffices.Add(office);
            }
            return allOffices;
        }

        public void Save(Officess off)
        {
            using NpgsqlConnection connection = new NpgsqlConnection(ConnectionString.Get());
            connection.Open();
            var s = this.Insert(
                new[] {"name", "users_id", "creation_date", "price", "photolink"},
                new object[] {off.Name, off.User_id, off.registration_date.ToString("d"), off.Price, off.Photoslink});
            var command = new NpgsqlCommand(
                this.Insert(
                    new[] {"name", "users_id", "creation_date", "price", "photolink"},
                    new object[] {off.Name, off.User_id, off.registration_date.ToString("d"), off.Price, off.Photoslink}),
                connection);
            command.ExecuteNonQuery();
        }

        public void Delete(Officess t)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        private static Officess GetOffice(IDataRecord record)
        {
            return new Officess(
                int.Parse(record["id"].ToString()),
                record["name"].ToString(),
                record["price"].ToString(),
                int.Parse(record["users_id"].ToString()),
                DateTime.Parse(record["creation_date"].ToString()),
                record["photolink"].ToString());
        }
    }
}