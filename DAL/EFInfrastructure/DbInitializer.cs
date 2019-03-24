using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;

namespace DAL.EFInfrastructure
{
    class DbInitializer:DropCreateDatabaseIfModelChanges<WeightLossContext>
    {
        protected override void Seed(WeightLossContext context)
        {
            DailyCalories calories1 = new DailyCalories
            {
                Sex = Sex.Male,
                MinAge = 17,
                MaxAge = 40,
                ActivityLevel = ActivityLevel.Low,
                CalorieRange = new CalorieRange
                {
                    Min = 2400,
                    Max = 2600
                }
            };
            DailyCalories calories2 = new DailyCalories
            {
                Sex = Sex.Male,
                MinAge = 17,
                MaxAge = 40,
                ActivityLevel = ActivityLevel.Middle,

                CalorieRange = new CalorieRange
                {
                    Min = 2600,
                    Max = 2800
                }
            };
            DailyCalories calories3 = new DailyCalories
            {
                Sex = Sex.Male,
                MinAge = 17,
                MaxAge = 40,
                ActivityLevel = ActivityLevel.High,

                CalorieRange = new CalorieRange
                {
                    Min = 2800,
                    Max = 3200
                }
            };
            DailyCalories calories4 = new DailyCalories
            {
                Sex = Sex.Male,
                MinAge = 41,
                MaxAge = 60,
                ActivityLevel = ActivityLevel.Low,

                CalorieRange = new CalorieRange
                {
                    Min = 2000,
                    Max = 2200
                }
            };
            DailyCalories calories5 = new DailyCalories
            {
                Sex = Sex.Male,
                MinAge = 41,
                MaxAge = 60,
                ActivityLevel = ActivityLevel.Middle,

                CalorieRange = new CalorieRange
                {
                    Min = 2400,
                    Max = 2600
                }
            };
            DailyCalories calories6 = new DailyCalories
            {
                Sex = Sex.Male,
                MinAge = 41,
                MaxAge = 60,
                ActivityLevel = ActivityLevel.High,

                CalorieRange = new CalorieRange
                {
                    Min = 2600,
                    Max = 2800
                }
            };
            DailyCalories calories7 = new DailyCalories
            {
                Sex = Sex.Male,
                MinAge = 61,
                MaxAge = 150,
                ActivityLevel = ActivityLevel.Low,

                CalorieRange = new CalorieRange
                {
                    Min = 2000,
                    Max = 2000
                }
            };
            DailyCalories calories8 = new DailyCalories
            {
                Sex = Sex.Male,
                MinAge = 61,
                MaxAge = 150,
                ActivityLevel = ActivityLevel.Middle,

                CalorieRange = new CalorieRange
                {
                    Min = 2200,
                    Max = 2400
                }
            };
            DailyCalories calories9 = new DailyCalories
            {
                Sex = Sex.Male,
                MinAge = 61,
                MaxAge = 150,
                ActivityLevel = ActivityLevel.High,

                CalorieRange = new CalorieRange
                {
                    Min = 2400,
                    Max = 2600
                }
            };
            //Для женщин
            DailyCalories calories10 = new DailyCalories
            {
                Sex = Sex.Female,
                MinAge = 17,
                MaxAge = 40,
                ActivityLevel = ActivityLevel.Low,

                CalorieRange = new CalorieRange
                {
                    Min = 1800,
                    Max = 2000
                }
            };
            DailyCalories calories11 = new DailyCalories
            {
                Sex = Sex.Female,
                MinAge = 17,
                MaxAge = 40,
                ActivityLevel = ActivityLevel.Middle,

                CalorieRange = new CalorieRange
                {
                    Min = 2000,
                    Max = 2200
                }
            };
            DailyCalories calories12 = new DailyCalories
            {
                Sex = Sex.Female,
                MinAge = 17,
                MaxAge = 40,
                ActivityLevel = ActivityLevel.High,

                CalorieRange = new CalorieRange
                {
                    Min = 2200,
                    Max = 2400
                }
            };
            DailyCalories calories13 = new DailyCalories
            {
                Sex = Sex.Female,
                MinAge = 41,
                MaxAge = 60,
                ActivityLevel = ActivityLevel.Low,

                CalorieRange = new CalorieRange
                {
                    Min = 1600,
                    Max = 1800
                }
            };
            DailyCalories calories14 = new DailyCalories
            {
                Sex = Sex.Female,
                MinAge = 41,
                MaxAge = 60,
                ActivityLevel = ActivityLevel.Middle,

                CalorieRange = new CalorieRange
                {
                    Min = 1800,
                    Max = 2000
                }
            };
            DailyCalories calories15 = new DailyCalories
            {
                Sex = Sex.Female,
                MinAge = 41,
                MaxAge = 60,
                ActivityLevel = ActivityLevel.High,

                CalorieRange = new CalorieRange
                {
                    Min = 2000,
                    Max = 2200
                }
            };
            DailyCalories calories16 = new DailyCalories
            {
                Sex = Sex.Female,
                MinAge = 61,
                MaxAge = 150,
                ActivityLevel = ActivityLevel.Low,

                CalorieRange = new CalorieRange
                {
                    Min = 1600,
                    Max = 1600
                }
            };
            DailyCalories calories17 = new DailyCalories
            {
                Sex = Sex.Female,
                MinAge = 61,
                MaxAge = 150,
                ActivityLevel = ActivityLevel.Middle,

                CalorieRange = new CalorieRange
                {
                    Min = 1800,
                    Max = 1800
                }
            };
            DailyCalories calories18 = new DailyCalories
            {
                Sex = Sex.Female,
                MinAge = 61,
                MaxAge = 150,
                ActivityLevel = ActivityLevel.High,

                CalorieRange = new CalorieRange
                {
                    Min = 2000,
                    Max = 2000
                }
            };
            context.DailyCalories.AddRange(new DailyCalories[] {
                calories1,
                calories2,
                calories3,
                calories4,
                calories5,
                calories6,
                calories7,
                calories8,
                calories9,
                calories10,
                calories11,
                calories12,
                calories13,
                calories14,
                calories15,
                calories16,
                calories17,
                calories18
            });
            context.SaveChanges();
            Role role1 = new Role { RoleName = "User" };
            Role role2 = new Role { RoleName = "Admin" };
            context.Roles.Add(role1);
            context.Roles.Add(role2);
            User admin = new User
            {
                Login = "Boss",
                Password = "321",
                Age = 65,
                ActivityLevel = ActivityLevel.Low,
                Sex = Sex.Male
            };
            admin.Roles.Add(role1);
            admin.Roles.Add(role2);
            context.Users.Add(admin);
            context.SaveChanges();
            Product p1 = new Product
            {
                Name = "Milk 3.2%",
                EnergyValue = 59
            };
            Product p2 = new Product
            {
                Name = "Cottage cheese bold 9%",
                EnergyValue = 157
            };
            Product p3 = new Product
            {
                Name = "Wheat bread",
                EnergyValue = 266
            };
            Product p4 = new Product
            {
                Name = "French fries",
                EnergyValue = 276
            };
            Product p5 = new Product
            {
                Name = "Oatmeal cookies with raisins",
                EnergyValue = 441
            };

            context.Products.AddRange(new Product[] { p1, p2, p3, p4, p5});
        }
    }
}
