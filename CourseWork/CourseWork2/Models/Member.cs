using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseWork2.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MembershipNo { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string MemberCategoryId { get; set; }
        [ForeignKey("MemberCategoryId")]
        public virtual MemberCategory MemberCategory { get; set; }



    }
}