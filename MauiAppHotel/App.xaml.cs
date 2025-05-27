namespace MauiAppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
        #if WINDOWS
            window.Width = 400;
            window.Height = 800;
        #endif

            return window;

        }
    }
}