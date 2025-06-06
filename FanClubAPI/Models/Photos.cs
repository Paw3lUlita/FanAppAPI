using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FanClubAPI.Models;

[Table("photos")]
public partial class Photos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [StringLength(200)]
    public string? Title { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [StringLength(255)]
    public string Url { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? UploadedAt { get; set; }
}
