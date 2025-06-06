using System;

namespace FanApp.Models
{
    public class AlbumItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
    }
} 