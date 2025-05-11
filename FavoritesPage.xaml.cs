public sealed partial class FavoritesPage : Page
{
    public FavoritesViewModel ViewModel => ((App)Application.Current).FavoritesViewModel;

    public FavoritesPage()
    {
        this.InitializeComponent();
        this.DataContext = ViewModel;
    }

    private void Film_ItemClick(object sender, ItemClickEventArgs e)
    {
        var film = (Film)e.ClickedItem;
        Frame.Navigate(typeof(DetailsPage), film.KinopoiskId);
    }
}