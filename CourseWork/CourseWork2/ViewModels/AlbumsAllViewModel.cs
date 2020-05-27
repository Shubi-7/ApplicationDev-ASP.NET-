using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2.ViewModels
{
    public class AlbumsAllViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
        public string StudioName { get; set; }
        public string CoverImagePath { get; set; }
        public string[] ArtistNames { get; set; }
        public string[] ProducerNames { get; set; }
    }
}
