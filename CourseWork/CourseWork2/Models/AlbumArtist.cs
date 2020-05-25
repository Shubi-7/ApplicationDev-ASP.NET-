﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseWork2.Models
{
    public class AlbumArtist
    {
        [Key, Column(Order = 1)]
        public int ArtistId { get; set; }

        [Key, Column(Order = 2)]
        public int AlbumId { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }

    }
}