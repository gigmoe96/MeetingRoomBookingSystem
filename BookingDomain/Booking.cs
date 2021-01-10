using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomain
{
    [Table("Booking",Schema ="dbo")]
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [Required]
        [Column(TypeName ="Datetime2")]
        [Display(Name ="Booking Date")]
        public DateTime BookingDate { get; set; }
        [Required]
        [Column(TypeName ="Datetime2")]
        [Display(Name ="From")]
        public DateTime StartTime { get; set; }
        [Required]
        [Column(TypeName ="Datetime2")]
        [Display(Name ="To")]
        public DateTime EndTime { get; set; }
        [Column(TypeName ="bit")]
        [Display(Name ="Extended")]
        public bool Extended { get; set; }
        [Column(TypeName ="Datetime2")]
        [Display(Name ="Extended To")]
        public DateTime ExtendedTime { get; set; }
        [Required]
        [Column(TypeName ="int")]
        [Display(Name ="Attendees")]
        public int Attendees { get; set; }
        [Required]
        [Column(TypeName ="varchar")]
        [Display(Name ="Description")]
        public string MeetingDescription { get; set; }
        [ForeignKey("Staff")]
        [Required]
        public int StaffId { get; set; }
        [ForeignKey("MeetingRoom")]
        [Required]
        public int MeetingRoomId { get; set; }
        public virtual MeetingRoom MeetingRoom { get; set; }
        public virtual Staff Staff { get; set; }

    }
}
