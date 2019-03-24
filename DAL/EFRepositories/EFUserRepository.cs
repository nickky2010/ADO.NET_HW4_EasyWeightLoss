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
    public class EFUserRepository : IRepository<User>
    {
        WeightLossContext db;
        public EFUserRepository(WeightLossContext db)
        {
            this.db = db;
        }
        public EFUserRepository(string connStr)
        {
            db = new WeightLossContext(connStr);
        }

        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public User FindById(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> Get()
        {
            return db.Users.AsNoTracking().ToList();
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return db.Users.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(User item)
        {
            db.Users.Remove(item);
            db.SaveChanges();
        }

        public void Update(User item)
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
