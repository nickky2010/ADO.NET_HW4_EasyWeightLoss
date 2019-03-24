using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DapperRepositories
{
    public class DapperProductRepository : IRepository<Product>
    {
        IDbConnection connection;
        public DapperProductRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
        public DapperProductRepository(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }
        public void Create(Product item)
        {
            throw new NotImplementedException();
        }


        public Product FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get()
        {
            List<Product> products = connection.Query<Product>("select * from Products").ToList();
            return products;
        }

        public IEnumerable<Product> Get(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product item)
        {
            throw new NotImplementedException();
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
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
