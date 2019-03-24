using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADORepositories
{
    public class ADOProductRepository : IRepository<Product>
    {
        IDbConnection connection;
        string ConnectionString;
        public ADOProductRepository(IDbConnection connection)
        {
            ConnectionString = connection.ConnectionString;
            this.connection = connection;
        }
        public ADOProductRepository(string connectionString)
        {
            ConnectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }
        public void Create(Product product)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"INSERT INTO Products VALUES (@Name, @EnergyValue)", (SqlConnection)connection);
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
                command.Parameters.Add("@EnergyValue", SqlDbType.Int, 0, "EnergyValue");
                command.Parameters["@Name"].Value = product.Name;
                command.Parameters["@EnergyValue"].Value = product.EnergyValue;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Product FindById(int id)
        {
            Product product = null;
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"select * from Products p where (p.Id=@findId)", (SqlConnection)connection);
                command.Parameters.Add("@findId", SqlDbType.Int, 0, "Id");
                command.Parameters["@findId"].Value = id;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product = new Product();
                    product.Id = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.EnergyValue = reader.GetInt32(2);
                }
                connection.Close();
            }
            return product;
        }

        public IEnumerable<Product> Get()
        {
            List<Product> products = new List<Product>();
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"select * from Products", (SqlConnection)connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.Id = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.EnergyValue = reader.GetInt32(2);
                    products.Add(p);
                }
                connection.Close();
            }
            return products;
        }

        public IEnumerable<Product> Get(Func<Product, bool> predicate)
        {
            return Get().Where(predicate);
        }

        public void Remove(Product product)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"DELETE FROM Products WHERE (Id=@p)", (SqlConnection)connection);
                command.Parameters.Add("@p", SqlDbType.Int, 0, "Id");
                command.Parameters["@p"].Value = product.Id;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Product product)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"update Products set Name=@p1, EnergyValue=@p2 where (Id=@pp1)", (SqlConnection)connection);
                command.Parameters.Add("@p1", SqlDbType.NVarChar, 50, "Name");
                command.Parameters.Add("@p2", SqlDbType.Int, 0, "EnergyValue");
                command.Parameters["@Name"].Value = product.Name;
                command.Parameters["@EnergyValue"].Value = product.EnergyValue;
                command.Parameters.Add("@pp1", SqlDbType.Int, 0, "Id");
                command.Parameters["@pp1"].SourceVersion = DataRowVersion.Original;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    connection.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
