using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomain
{
    [Table("Department",Schema ="dbo")]
   public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int DepartmentId { get; set; }
        [Required]
        [Column(TypeName ="varchar")]
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [Display(Name = "Department Code")]
        public string DepartmentCode { get; set; }
        [Column(TypeName ="bit")]
        [Display(Name ="Active")]
        public Boolean Active { get; set; }
    }
}
