
    public class MovieService : IMovieService, IDisposable
    {
        private readonly SpecPatternReadDbContext _context;

        public MovieService(IDbContextFactory<SpecPatternReadDbContext> dbFactory)
        {
            ArgumentNullException.ThrowIfNull(nameof(dbFactory));
            _context = dbFactory.CreateDbContext();
            ArgumentNullException.ThrowIfNull(nameof(_context));
        }

        public async Task<IReadOnlyList<MovieEntity>> GetList(Specification<MovieEntity> specification)
            => await _context.Movies
            // .Where(specification.ToExpression())
            .ToListAsync();

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
