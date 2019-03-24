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
    public class EFCaloriesRepository : IRepository<DailyCalories>
    {
        WeightLossContext db;
        public EFCaloriesRepository(WeightLossContext db)
        {
            this.db = db;
        }
        public EFCaloriesRepository(string connStr)
        {
            db = new WeightLossContext(connStr);
        }

        public void Create(DailyCalories item)
        {
            db.DailyCalories.Add(item);
            db.SaveChanges();
        }

        public DailyCalories FindById(int id)
        {
            return db.DailyCalories.Find(id);
        }

        public IEnumerable<DailyCalories> Get()
        {
            return db.DailyCalories.AsNoTracking().ToList();
        }

        public IEnumerable<DailyCalories> Get(Func<DailyCalories, bool> predicate)
        {
            return db.DailyCalories.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(DailyCalories item)
        {
            db.DailyCalories.Remove(item);
            db.SaveChanges();
        }

        public void Update(DailyCalories item)
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
