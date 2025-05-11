public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Film> Films { get; } = new();
    private readonly ApiService _api = new();

    public async Task LoadFilmsAsync()
    {
        var films = await _api.GetTopFilmsAsync();
        Films.Clear();
        foreach (var film in films)
            Films.Add(film);
    }

    public event PropertyChangedEventHandler PropertyChanged;
}