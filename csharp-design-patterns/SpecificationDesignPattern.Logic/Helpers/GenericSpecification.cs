namespace SpecificationDesignPattern.Logic.Helpers;
public class GenericSpecification<T>
{
    public Expression<Func<T, bool>> Expression { get; }

    public GenericSpecification(Expression<Func<T, bool>> expression)
    {
        Expression = expression;
    }

    public bool IsSatisfiedBy(T entity) => Expression.Compile().Invoke(entity);
}
