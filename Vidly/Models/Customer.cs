using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [YearsOld18ToBeMember]
        public DateTime? Birthdate { get; set; }    

        [Display(Name = "Subscribed to new letter?")]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Required(ErrorMessage = "Select a Membership type please")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        
        public MembershipType MembershipType { get; set; }



    }
}