using SpecificationDesignPattern.Logic.Helpers;

namespace SpecificationDesignPattern.UI.Components.Movies;

public partial class MovieListComponent
{
    [Parameter]
    public EventCallback<MovieEntity> OnMovieSelected { get; set; }

    [Parameter]
    public MovieSearchVM? MovieSearch { get; set; }

    [Inject] IMovieService MovieService { get; set; } = null!;

    private bool _dense = false;
    private bool _hover = true;
    private bool _striped = true;
    private bool _bordered = false;
    private bool _loading = false;
    private string _searchString1 = string.Empty;
    private MovieEntity? _selectedItem1 = null;

    private IReadOnlyList<MovieEntity> _movies = new List<MovieEntity>();
    private bool FilterFunc1(MovieEntity movie) => FilterFunc(movie, _searchString1);
    private static bool FilterFunc(MovieEntity movie, string searchString)
        => movie switch
        {
            { Name: var name } when name.Contains(searchString, StringComparison.OrdinalIgnoreCase) => true,
            { Genre: var genre } when genre.Contains(searchString, StringComparison.OrdinalIgnoreCase) => true,
            _ => false
        };

    protected override async Task OnParametersSetAsync()
    {
        if (MovieSearch is null)
        {
            return;
        }

        try
        {
            _loading = true;
            //var spec = Specification<MovieEntity>.All;

            //if (MovieSearch.IsForKidOnly)
            //{
            //    spec = spec.And(MovieEntity.IsSuitableForChildren);
            //}

            //if (MovieSearch.IsAvailableOnCD)
            //{
            //    spec = spec.And(MovieEntity.HasCDVersion);
            //}


            var forKids = new MovieForKidsSpecification();
            var onCD = new AvailableOnCdSpecification();

            Specification<MovieEntity> spec = onCD.And(forKids.Not());
            _movies = await MovieService.GetList(spec);
            _movies = _movies
                .AsEnumerable()
                .Where(spec.ToExpression().Compile())
                .ToList();
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, MudBlazor.Severity.Error);
            Snackbar.Add("Unexpected error.", MudBlazor.Severity.Error);
        }
        finally
        {
            _loading = false;
        }
    }
}
