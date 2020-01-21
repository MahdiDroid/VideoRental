using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRental.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsScubscribedToNewsletter { get; set; }

        [Display(Name="Membership Type")]
        public int MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}