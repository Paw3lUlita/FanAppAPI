using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FanClubAPI.Models;

[Table("news")]
public partial class News
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Content { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PublishDate { get; set; }
}
