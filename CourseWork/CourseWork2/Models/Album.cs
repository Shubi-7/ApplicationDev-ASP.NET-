using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;


namespace CourseWork2.Models
{
    public class Album
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CopyNumber { get; set; }
        public string Studio { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string TrackLength { get; set; }
        public bool IsAgeBar { get; set; }
        public decimal FinePerDay { get; set; }

        [NotMapped]
        public HttpPostedFile AlbumImage { get; set; }
        public string AlbumImagePath { get; set; }
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Producer> Producers { get; set; }




    }
}