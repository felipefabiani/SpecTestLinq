namespace SpecificationDesignPattern.Logic.Helpers;

public abstract class Specification<T>
{
    public static readonly Specification<T> All = new IdentitySpecification<T>();
    public abstract Expression<Func<T, bool>> ToExpression();

    public bool IsSatisfiedBy(T entity) => ToExpression().Compile()(entity);

    public Specification<T> And(Specification<T> specification)
    {
        if (this == All) return specification;
        else if (specification == All) return this;

        return new AndSpecification<T>(this, specification);
    }
    public Specification<T> Or(Specification<T> specification)
    {
        if (this == All || specification == All) return All;
           
        return new OrSpecification<T>(this, specification);
    }
    public Specification<T> Not() => new NotSpecification<T>(this);
}

internal sealed class AndSpecification<T>: Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public AndSpecification(Specification<T> left, Specification<T> right)
    {
        _left = left ?? throw new ArgumentNullException(nameof(left));
        _right = right ?? throw new ArgumentNullException(nameof(right));
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T, bool>> leftExpression = _left.ToExpression();
        Expression<Func<T, bool>> rightExpression = _right.ToExpression();
        BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
        return Expression.Lambda<Func<T,bool>>(andExpression, leftExpression.Parameters.Single());
    }
}
internal sealed class OrSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public OrSpecification(Specification<T> left, Specification<T> right)
    {
        _left = left ?? throw new ArgumentNullException(nameof(left));
        _right = right ?? throw new ArgumentNullException(nameof(right));
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T, bool>> leftExpression = _left.ToExpression();
        Expression<Func<T, bool>> rightExpression = _right.ToExpression();
        BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);
        return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters.Single());
    }
}

internal sealed class NotSpecification<T> : Specification<T>
{
    private readonly Specification<T> _specification;

    public NotSpecification(Specification<T> specification)
    {
        _specification = specification ?? throw new ArgumentNullException(nameof(specification));
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T, bool>> expression = _specification.ToExpression();
        UnaryExpression notExpression = Expression.Not(expression.Body);
        return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
    }
}

internal sealed class IdentitySpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression() => x => true;
}