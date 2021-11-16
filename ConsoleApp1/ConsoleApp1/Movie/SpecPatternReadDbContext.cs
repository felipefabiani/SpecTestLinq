public class SpecPatternReadDbContext : DbContext
{
    //public SpecPatternReadDbContext(DbContextOptions<SpecPatternReadDbContext> options)
    //    : base(options)
    //{
    //    ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    //}

    public virtual DbSet<MovieEntity> Movies { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=SpecPattern.Dev;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpecPatternReadDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
