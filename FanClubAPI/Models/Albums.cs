using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FanClubAPI.Models;

[Table("albums")]
public partial class Albums
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public DateOnly? ReleaseDate { get; set; }

    [StringLength(255)]
    public string? CoverUrl { get; set; }

    [InverseProperty("Album")]
    public virtual ICollection<Songs> Songs { get; set; } = new List<Songs>();
}
