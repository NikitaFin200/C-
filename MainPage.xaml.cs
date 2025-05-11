public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel { get; } = new();

    public MainPage()
    {
        this.InitializeComponent();
        this.Loaded += async (s, e) => await ViewModel.LoadFilmsAsync();
    }

    private void Film_ItemClick(object sender, ItemClickEventArgs e)
    {
        var film = (Film)e.ClickedItem;
        Frame.Navigate(typeof(DetailsPage), film.KinopoiskId);
    }
}