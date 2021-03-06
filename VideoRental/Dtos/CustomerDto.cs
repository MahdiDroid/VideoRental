﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRental.Models;

namespace VideoRental.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsScubscribedToNewsletter { get; set; }
       
        public int MembershipTypeId { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}