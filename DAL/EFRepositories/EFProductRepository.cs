using DAL.EFInfrastructure;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFRepositories
{
    public class EFProductRepository : IRepository<Product>
    {
        WeightLossContext db;

        public EFProductRepository(WeightLossContext dbContext)
        {
            db = dbContext;
        }
        public EFProductRepository(string cnnString)
        {
            db = new WeightLossContext(cnnString);
        }
        public void Create(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
        }

        public Product FindById(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> Get()
        {
            List<Product> pr = db.Products.AsNoTracking().ToList();
            return pr;
        }

        public IEnumerable<Product> Get(Func<Product, bool> predicate)
        {
            return db.Products.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(Product item)
        {
            db.Products.Remove(item);
            db.SaveChanges();

        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
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
