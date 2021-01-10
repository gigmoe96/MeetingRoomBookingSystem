using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookingDomain
{
    [Table("Staff",Schema ="dbo")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }
        [Column(TypeName ="varchar")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Column(TypeName ="varchar")]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Column(TypeName ="varchar")]
        [Display(Name ="Password")]
        public string Password { get; set; }
        [Column(TypeName ="varchar")]
        [Display(Name ="User Role")]
        public string UserRole { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}
