using AssessmentEF.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.Entities.Dtos
{
    public class PersonnelDto:BaseModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public decimal PersonnelSalary { get; set; }
    }
}
