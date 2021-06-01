using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Test.Models
{
    [Table("Project", Schema = "Company")]
    public partial class Project
    {
        [Key]
        public int ProjectNo { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string Budget { get; set; }
    }
}
