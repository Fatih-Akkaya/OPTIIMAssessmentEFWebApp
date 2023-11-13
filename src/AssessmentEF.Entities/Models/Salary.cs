using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.Entities.Models
{
    public class Salary:BaseModel
    {
        public int PersonnelId { get; set; }
        public Department Department { get; set; } = Department.None;
        public decimal PersonnelSalary { get; set; } = 0;      
    }
    public enum Department
    {
        None,
        Finance,
        HumanResources,
        RD,
        Accounting,
        SoftwareDevelopement,
    }
}
