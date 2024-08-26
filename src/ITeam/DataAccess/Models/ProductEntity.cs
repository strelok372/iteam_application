using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITeam.DataAccess.Models;

public record ProductEntity
{
    public int Id { get; set; }
    public int ModuleId { get; set; }
    public ModuleEntity Module { get; set; }
    public int SequenceNumber { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string MaterialLink { get; set; }
    public string PreviewLink { get; set; }
}
