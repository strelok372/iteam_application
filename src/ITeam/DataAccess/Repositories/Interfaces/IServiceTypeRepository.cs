using System;
using ITeam.DataAccess.Models;

namespace ITeam.DataAccess.Repositories;

public interface IServiceTypeRepository
{
    public Task<ServiceTypeEntity?> GetServiceTypeByIdAsync(int id);

}
