using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomain
{
    [Table("MeetingRoom", Schema = "dbo")]
    public class MeetingRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeetingRoomId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [Display(Name = "MeetingRoom Name")]
        public string MeetingRoomName { get; set; }
        [Required]
        [Column(TypeName = "int")]
        [Display(Name = "Room Capacity")]
        public int RoomCapacity { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        [Display(Name = "Projector")]
        public bool Projector { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        [Display(Name = "Active")]
        public bool Active { get; set; }
    }
}
