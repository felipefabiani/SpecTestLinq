//using CSharpFunctionalExtensions;
//using Microsoft.EntityFrameworkCore;
//using SpecificationDesignPattern.Logic;
//using SpecificationDesignPattern.Logic.Movies;

//namespace Logic.Movies
//{
//    public class MovieRepository
//    {
//        private readonly SpecPatternDbContext _context;

//        public MovieRepository(IDbContextFactory<SpecPatternDbContext> dbFactory)
//        {
//            ArgumentNullException.ThrowIfNull(nameof(dbFactory));

//            _context = dbFactory.CreateDbContext();
//            ArgumentNullException.ThrowIfNull(nameof(_context));
//        }

//        public async Task<Maybe<Movie>> GetOne(long id) => await _context.Movies.FindAsync(id);

//        public async Task<IReadOnlyList<Movie>> GetList(
//            bool forKidsOnly,
//            double minimumRating,
//            bool availableOnCD)
//        => await _context.Movies
//            .AsNoTracking()
//            .Where(x =>
//                (x.MpaaRating <= MpaaRating.PG || !forKidsOnly) &&
//                x.Rating >= minimumRating &&
//                (x.ReleaseDate <= DateTimeOffset.Now.AddMonths(-6) || !availableOnCD)
//            ).ToListAsync();
//    }
//}
