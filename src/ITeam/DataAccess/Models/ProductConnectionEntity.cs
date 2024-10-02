using System;

namespace ITeam.DataAccess.Models;

public record ProductConnectionEntity
{
    public int Id { get; set; }

    public int FirstProductId { get; set; }
    public ProductEntity FirstProduct { get; set; }

    public int SecondProductId { get; set; }
    public ProductEntity SecondProduct { get; set; }

    public int ProductConnectionTypeId { get; set; }
    public ProductConnectionTypeEntity ProductConnectionType { get; set; }
}
