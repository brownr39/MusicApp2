﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Required(ErrorMessage = "Genre name is required")]
        [MaxLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}