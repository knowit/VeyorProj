using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VeyorProj.WebApp.Models.Entity;

namespace VeyorProj.WebApp.Data
{
    public class DbRepo : IDbRepo
    {
        private IDbConnection OpenConnection()
        {
            IDbConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            conn.Open();
            return conn;
        }

        public List<item> GetItems()
        {
            List<item> list;

            using (IDbConnection connection = OpenConnection())
            {
                list = connection.Query<item>("items_get", CommandType.StoredProcedure).ToList();
            }

            return list;
        }

        public item GetItem(int rowid)
        {
            item i;

            using (IDbConnection connection = OpenConnection())
            {
                i = connection.Query<item>("item_get", new { rowid = rowid }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return i;
        }

        public void AddItem(item input)
        {
            using (IDbConnection connection = OpenConnection())
            {
                connection.Execute("item_add", new { name = input.name, description = input.description, rating = input.rating, price = input.price }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateItem(item input)
        {
            using (IDbConnection connection = OpenConnection())
            {
                connection.Execute("item_update", new { rowid = input.rowid, name = input.name, description = input.description, rating = input.rating, price = input.price }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteItem(int rowid)
        {
            using (IDbConnection connection = OpenConnection())
            {
                connection.Execute("item_delete", new { rowid = rowid }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}