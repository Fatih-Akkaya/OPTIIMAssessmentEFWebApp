using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AssessmentEF.MVC.Models
{
    public class Salary:BaseModel
    {
        public int PersonnelId { get; set; }
        [Display(Name = "Departman")]
        public Department Department { get; set; } = Department.None;
        [Display(Name = "Ücret")]
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
