public class Person
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;

    public override string ToString() => $@"{Id} {Name}";
}