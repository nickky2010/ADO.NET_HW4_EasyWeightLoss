using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFInfrastructure
{
    class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(u => u.ClientId);
            Property(p => p.Login).HasColumnName("Nickname");
            Property(p => p.Login).IsRequired().HasMaxLength(10);
            Map(m => { m.Properties(u => new { u.ClientId, u.Login, u.Password }); m.ToTable("Clients"); })
                .Map(m => { m.Properties(u => new { u.ClientId, u.Age, u.ActivityLevel, u.Sex }); m.ToTable("ClientProfiles"); });

            HasMany(u => u.Roles).WithMany(r => r.Users).Map(m => { m.ToTable("ClientRoles"); m.MapLeftKey("ClientId"); m.MapRightKey("RoleId"); });
        }
    }
}
