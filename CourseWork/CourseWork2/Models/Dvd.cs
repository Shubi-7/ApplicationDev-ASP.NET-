using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork2.Models
{
    public class Dvd
    {
        public int Id { get; set; }
        public string CopyNo { get; set; }
        public string AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}