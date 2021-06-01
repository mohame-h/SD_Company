using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Test.Models
{
    [Table("Works_on")]
    public partial class WorksOn
    {
        [Key]
        [Column(Order = 1)]
        [Range(1, int.MaxValue)]
        public int EmpNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [Range(1, int.MaxValue)]
        public int ProjectNo { get; set; }

        [Required]
        public string Job { get; set; }

        [Column("Enter_Date", TypeName = "datetime")]
        public DateTime EnterDate { get; set; }
    }
}
