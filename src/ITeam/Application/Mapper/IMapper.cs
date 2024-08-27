namespace ITeam.Application.Mapper;

public interface IMapper<TDto, TEntity> : IToDtoMapper<TDto, TEntity>, IToEntityMapper<TDto, TEntity> { }
