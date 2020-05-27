using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseWork2.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int AlbumId { get; set; }
        public int LoanTypeId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal FineAmount { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [ForeignKey("Member Id")]
        public virtual Member Members { get; set; }
        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }
        [ForeignKey("LoanTypeId")]
        public virtual LoanType LoanType { get; set; }



    }
}