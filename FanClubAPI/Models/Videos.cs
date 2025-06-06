using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FanClubAPI.Models;

[Table("videos")]
public partial class Videos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [StringLength(200)]
    public string? Title { get; set; }

    [StringLength(255)]
    public string YoutubeUrl { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UploadedAt { get; set; }
}
