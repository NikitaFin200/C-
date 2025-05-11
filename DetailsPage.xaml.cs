public sealed partial class DetailsPage : Page
{
    private readonly ApiService _api = new();

    public Film Film { get; set; }

    public DetailsPage()
    {
        this.InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        int filmId = (int)e.Parameter;
        Film = await _api.GetFilmDetailsAsync(filmId);
        this.DataContext = Film;
    }

    private void AddToFavorites_Click(object sender, RoutedEventArgs e)
    {
        ((App)Application.Current).FavoritesViewModel.AddToFavorites(Film);
    }
}
