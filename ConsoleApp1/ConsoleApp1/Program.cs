
IEnumerableTest();
await SpecificationTestAsync().ConfigureAwait(false);
await ExpressionTestAsync().ConfigureAwait(false);

Console.ReadLine();

async Task ExpressionTestAsync()
{
    try
    {
        using var db = new SpecPatternReadDbContext();
        Expression<Func<MovieEntity, bool>> condition1 = x => x.Id == 1;

        var movies1 = await db.Movies
            .Where(condition1)
            .ToListAsync();
        movies1.Print();

        Expression<Func<MovieEntity, bool>> condition2 = x => x.Id == 2;
        var movies2 = await db.Movies
            .Where(condition2)
            .ToListAsync();

        movies2.Print();

        BinaryExpression orExpression = Expression.OrElse(condition1.Body, condition2.Body);
        Expression<Func<MovieEntity, bool>> expression = Expression.Lambda<Func<MovieEntity, bool>>(orExpression, condition1.Parameters.Single());

        var movies3 = await db.Movies
            .Where(expression)
            .ToListAsync();

        movies3.Print();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

async Task SpecificationTestAsync()
{
    try
    {
        using var db = new SpecPatternReadDbContext();
        var movies = await db.Movies.ToListAsync();
        movies.Print();
        
        var spec = Specification<MovieEntity>.All
            .And(new MovieForKidsSpecification());

        var movies1 = await db.Movies
            .Where(spec.ToExpression())
            .ToListAsync();
        
        movies1.Print();

        spec = spec.And(new AvailableOnCdSpecification());

        var movies2 = await db.Movies
            .Where(spec.ToExpression())
            .ToListAsync();
        
        movies2.Print();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void IEnumerableTest()
{
    try
    {
        var lst = new List<Person>
        {
            new Person { Id = 1, Name = "Test1"},
            new Person { Id = 2, Name = "Test2"},
            new Person { Id = 3, Name = "Test3"},
            new Person { Id = 4, Name = "Test4"}
        };

        Specification<Person> specification = Specification<Person>.All;
        specification.FilterAndPrint(lst);
        specification = specification.And(new IdSpecification());
        specification.FilterAndPrint(lst);
        specification = specification.And(new NameSpecification());
        specification.FilterAndPrint(lst);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}