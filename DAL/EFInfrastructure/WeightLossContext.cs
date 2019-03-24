using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFInfrastructure
{
    public class WeightLossContext:DbContext
    {
        public WeightLossContext():base()
        {

        }
        public WeightLossContext(string connString) : base(connString)
        {

        }
        static WeightLossContext()
        {
            Database.SetInitializer<WeightLossContext>(new DbInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DailyCalories> DailyCalories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Product> Products { get; set; }

    }
}
