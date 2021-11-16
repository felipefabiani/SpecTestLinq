
public class MovieEntity : Entity
{
    public virtual string Name { get; }
    public virtual DateTimeOffset ReleaseDate { get; }
    public virtual MpaaRating MpaaRating { get; }
    public virtual string Genre { get; }
    public virtual decimal Rating { get; }
    
    protected MovieEntity()
    {
    }


    public override string ToString() => $@"{Id} {Name, -30} {ReleaseDate:dd/MM/yyyy} {MpaaRating, -4} {Rating, 4}";
}
