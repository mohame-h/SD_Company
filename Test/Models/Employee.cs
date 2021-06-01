using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Test.Models
{
    [Table("Employee", Schema = "HumanResourse")]
    public partial class Employee
    {
        [Key]
        public int EmpNo { get; set; }

        [Required]
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }

        [Required]
        public int Salary { get; set; }

        [Range(1, int.MaxValue)]
        public int? DeptNo { get; set; }

        [ForeignKey(nameof(DeptNo))]
        [InverseProperty(nameof(Department.Employees))]
        public virtual Department DeptNoNavigation { get; set; }
    }
}
