using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CourseWork2.ViewModels
{
    public class AlbumViewModel
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
        public string StudioName { get; set; }
        public string CoverImagePath { get; set; }
        public int[] ArtistIds { get; set; }
        public int[] ProducerIds { get; set; }
        public SelectList ArtistList { get; set; }
        public SelectList Producers { get; set; }
    }
}
