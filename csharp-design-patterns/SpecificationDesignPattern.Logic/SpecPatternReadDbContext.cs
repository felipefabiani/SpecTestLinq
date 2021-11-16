namespace SpecificationDesignPattern.Logic;
public class SpecPatternReadDbContext : DbContext
{
    public SpecPatternReadDbContext(DbContextOptions<SpecPatternReadDbContext> options)
        : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public virtual DbSet<MovieEntity> Movies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpecPatternReadDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
