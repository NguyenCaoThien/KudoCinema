using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KudoCinema.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Phone]
        [Required]
        public string  PhoneNumber{ get; set; }

        public bool IsSubcribed { get; set; }


        [Display(Name="Day of birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }


        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }
        
    }
}