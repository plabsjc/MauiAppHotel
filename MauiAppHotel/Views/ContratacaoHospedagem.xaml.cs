using MauiAppHotel.Models;
using System.Threading.Tasks;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        var hoje = DateTime.Today;

        PropriedadesApp = (App)Application.Current;

        pickerQuarto.ItemsSource = PropriedadesApp.listaQuartos;

        datePickerCheckIn.MinimumDate = hoje;
        datePickerCheckIn.MaximumDate = hoje.AddDays(30);
        datePickerCheckIn.Date = hoje;
        //datePickerCheckOut.MinimumDate = datePickerCheckIn.Date.AddDays(1);
        //datePickerCheckOut.MaximumDate = datePickerCheckIn.Date.AddDays(7);
        var dataSelecionadaCheckIn = datePickerCheckIn.Date;
        datePickerCheckOut.MinimumDate = dataSelecionadaCheckIn.AddDays(1);
        datePickerCheckOut.MaximumDate = dataSelecionadaCheckIn.AddDays(7);
        datePickerCheckOut.Date = dataSelecionadaCheckIn.AddDays(1);



    }
     
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if((Quarto)pickerQuarto.SelectedItem == null)
            {
                await DisplayAlert("Ops!!!", "Selecione o tipo de Suíte!", "Ok");
            }
            else if (stepperAdultos.Value == 0)
            {
                await DisplayAlert("Ops!!!", "Selecione ao menos uma pessoa adulta!", "OK");
            }
            else if (datePickerCheckOut.Date <= datePickerCheckIn.Date)
            {
                await DisplayAlert("Ops!!!", "Data CheckOut menor ou igual a data do CheckIn", "OK");
            }
            else
            {
                Hospedagem h = new Hospedagem
                {
                    QuartoSelecionado = (Quarto)pickerQuarto.SelectedItem,
                    QuantidadeAdultos = Convert.ToInt32(stepperAdultos.Value),
                    QuantidadeCriancas = Convert.ToInt32(stepperCriancas.Value),
                    DataCheckIn = datePickerCheckIn.Date,
                    DataCheckOut = datePickerCheckOut.Date
                };

                await Navigation.PushAsync(new HospedagemContratada()
                {
                    BindingContext = h
                });
            }
                
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void datePickerCheckIn_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;
        DateTime dataSelecionadaCheckIn = elemento.Date;
        var novaMinima = dataSelecionadaCheckIn.AddDays(1);
        var novaMaxima = dataSelecionadaCheckIn.AddDays(7);

        datePickerCheckOut.MinimumDate = novaMinima;
        datePickerCheckOut.MaximumDate = novaMaxima;

        // ⚠️ Corrige a data se estiver fora do intervalo
        if (datePickerCheckOut.Date < novaMinima || datePickerCheckOut.Date > novaMaxima)
        {
            datePickerCheckOut.Date = novaMinima;
        }
    }
}