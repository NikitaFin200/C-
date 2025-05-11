sealed partial class App : Application
{
    public FavoritesViewModel FavoritesViewModel { get; } = new();

    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;
        if (rootFrame == null)
        {
            rootFrame = new Frame();
            Window.Current.Content = rootFrame;
        }
        rootFrame.Navigate(typeof(MainPage), e.Arguments);
        Window.Current.Activate();
    }
}