using SpecificationDesignPattern.Logic.Helpers;

namespace Logic.Movies
{
    public interface IMovieService
    {
        Task<IReadOnlyList<MovieEntity>> GetList(Specification<MovieEntity> specification);
    }
}