using System;

namespace ITeam.Application.Mapper;

public interface IToDtoMapper<TDto, TEntity>
{
    TDto ToDto(TEntity entity);
}
