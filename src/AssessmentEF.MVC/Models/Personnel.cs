using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentEF.MVC.Models
{
    public class Personnel:BaseModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Adı")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Soyadı")]
        public String Surname { get; set; }
        [Required]
        [Display(Name = "Doğum Tarihi")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Cinsiyeti")]
        public Gender Gender { get; set; }
        public virtual Salary Salary { get; set; }
    }

    public enum Gender
    {
        [Display(Name = "Kadın")] Female = 1,
        [Display(Name = "Erkek")] Male = 2
    }
}
