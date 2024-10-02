using System;

namespace ITeam.Application.Services.Exceptions.NotFoundExceptions;

public class ProductNotFoundException : NotFoundException
{
    public const string name = "Product";
    public ProductNotFoundException(int productId) : base(productId, name) { }
}
