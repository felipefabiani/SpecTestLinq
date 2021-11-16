namespace SpecificationDesignPattern.Logic.ViewModels;

public class MovieSearchVM
{
    public MovieSearchVM(
            bool isForKidOnly,
            bool isAvailableOnCD,
            decimal minimumRating)
    {
        IsForKidOnly = isForKidOnly;
        IsAvailableOnCD = isAvailableOnCD;
        MinimumRating = minimumRating;
    }
    public static MovieSearchVM GetDefault() => new(false, false, 0M);

    public bool IsForKidOnly { get; set; }
    public bool IsAvailableOnCD { get; set; }
    public decimal MinimumRating { get; set; }
}
