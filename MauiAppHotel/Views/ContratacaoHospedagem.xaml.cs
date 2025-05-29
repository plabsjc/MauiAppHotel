using System.Threading.Tasks;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pickerQuarto.ItemsSource = PropriedadesApp.listaQuartos;

        datePickerCheckIn.MinimumDate = DateTime.Now;
        datePickerCheckIn.MaximumDate = DateTime.Now.AddDays(30);
        datePickerCheckOut.MinimumDate = datePickerCheckIn.Date.AddDays(1);
        datePickerCheckOut.MaximumDate = datePickerCheckIn.Date.AddDays(7);
        


    }
     
    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new HospedagemContratada());
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void datePickerCheckIn_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;
        DateTime dataSelecionadaCheckIn = elemento.Date;
        datePickerCheckOut.MinimumDate = dataSelecionadaCheckIn.AddDays(1);
        datePickerCheckOut.MaximumDate = dataSelecionadaCheckIn.AddDays(30);
    }
}