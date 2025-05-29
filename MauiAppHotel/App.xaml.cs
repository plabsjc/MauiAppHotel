using MauiAppHotel.Models;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public List<Quarto> listaQuartos = new List<Quarto>
        {
            new Quarto()
            {
                Descricao = "Suíte Super Luxo",
                ValorDiariaAdulto = 110.00,
                ValorDiariaCrianca = 55.00
            },

            new Quarto()
            {
                Descricao = "Suíte Luxo",
                ValorDiariaAdulto = 90.00,
                ValorDiariaCrianca = 45.00
            },

            new Quarto()
            {
                Descricao = "Suíte Simples",
                ValorDiariaAdulto = 80.00,
                ValorDiariaCrianca = 40.00
            }
        };
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.ContratacaoHospedagem());

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
#if WINDOWS
            window.Width = 400;
            window.Height = 800;
#endif

            return window;

        }


    }
}