using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.Entities.Models
{
    public class Personnel:BaseModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public virtual Salary Salary { get; set; }
    }

    public enum Gender
    {
        Female,
        Male
    }
}
