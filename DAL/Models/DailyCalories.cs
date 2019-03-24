using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("CalorieNorms")]
    public class DailyCalories
    {
        public int Id { get; set; }
        public Sex Sex { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        [Column("Level")]
        public ActivityLevel ActivityLevel { get; set; }
        public CalorieRange CalorieRange { get; set; }
    }
}
