using System;

namespace ITeam.Application.Mapper;

public interface IToEntityMapper<TDto, TEntity>
{
    TEntity ToEntity(TDto entity);
}
