using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FanClubAPI.Models;

[Table("members")]
public partial class Members
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Role { get; set; } = null!;

    public DateOnly? JoinDate { get; set; }

    public DateOnly? LeaveDate { get; set; }

    [Column(TypeName = "text")]
    public string? Bio { get; set; }

    [StringLength(255)]
    public string? PhotoUrl { get; set; }
}
