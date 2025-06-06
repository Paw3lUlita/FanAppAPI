using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FanClubAPI.Models;

[Table("setlists")]
[Index("ConcertId", Name = "ConcertId")]
[Index("SongId", Name = "SongId")]
[Index(nameof(ConcertId), nameof(SongOrder), IsUnique = true)]
public partial class Setlists
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [Column(TypeName = "int(11)")]
    public int ConcertId { get; set; }

    [Column(TypeName = "int(11)")]
    public int SongId { get; set; }

    [Column(TypeName = "int(11)")]
    public int SongOrder { get; set; }

    [ForeignKey("ConcertId")]
    [InverseProperty("Setlists")]
    [JsonIgnore]
    public virtual Concerts? Concert { get; set; }

    [ForeignKey("SongId")]
    [InverseProperty("Setlists")]
    [JsonIgnore]
    public virtual Songs? Song { get; set; }
}
