using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FanClubAPI.Models;

[Table("songs")]
[Index("AlbumId", Name = "AlbumId")]
public partial class Songs
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [Column(TypeName = "int(11)")]
    public int AlbumId { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    [StringLength(10)]
    public string? Duration { get; set; }

    [Column(TypeName = "int(11)")]
    public int? TrackNumber { get; set; }

    [Column(TypeName = "text")]
    public string? Lyrics { get; set; }

    [ForeignKey("AlbumId")]
    [InverseProperty("Songs")]
    [JsonIgnore]
    public virtual Albums? Album { get; set; }

    [InverseProperty("Song")]
    public virtual ICollection<Setlists> Setlists { get; set; } = new List<Setlists>();
}
