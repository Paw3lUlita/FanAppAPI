using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FanClubAPI.Models;

[Table("concerts")]
public partial class Concerts
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [StringLength(200)]
    public string? Title { get; set; }

    public DateOnly Date { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? Venue { get; set; }

    [StringLength(255)]
    public string? TicketUrl { get; set; }

    [InverseProperty("Concert")]
    public virtual ICollection<Setlists> Setlists { get; set; } = new List<Setlists>();
}
