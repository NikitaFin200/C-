public class FavoritesViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Film> Favorites { get; } = new();

    public void AddToFavorites(Film film)
    {
        if (!Favorites.Any(f => f.KinopoiskId == film.KinopoiskId))
            Favorites.Add(film);
    }

    public event PropertyChangedEventHandler PropertyChanged;
}