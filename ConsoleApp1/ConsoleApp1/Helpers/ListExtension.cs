public static class ListExtension
{
    public static void Print<T>(this IReadOnlyList<T> list)
    {
        Console.WriteLine("---------------------------------------------------------");
        foreach (var p in list)
        {
            Console.WriteLine(p);
        }
    }

    public static void FilterAndPrint(this Specification<Person> specification, IReadOnlyList<Person> people)
    {
        var printList = people.Where(specification.ToExpression().Compile()).ToList();
        printList.Print();
    }
}
