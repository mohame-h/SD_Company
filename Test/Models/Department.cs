using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Test.Models
{
    [Table("Department", Schema = "Company")]
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int DeptNo { get; set; }

        [Required]
        public string DeptName { get; set; }

        [Required]
        public string Location { get; set; }

        [InverseProperty(nameof(Employee.DeptNoNavigation))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
