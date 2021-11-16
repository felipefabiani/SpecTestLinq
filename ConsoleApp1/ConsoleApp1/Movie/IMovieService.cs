
public interface IMovieService
{
    Task<IReadOnlyList<MovieEntity>> GetList(Specification<MovieEntity> specification);
}
