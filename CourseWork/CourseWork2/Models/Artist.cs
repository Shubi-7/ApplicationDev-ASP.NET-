﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork2.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(55)]
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Album> Album { get; set; }

    }
}