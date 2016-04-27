using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.Models
{
    public class Playlist
    {
        private MusicContext db = new MusicContext();

        
        public int PlaylistID { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; }

        
    }
}