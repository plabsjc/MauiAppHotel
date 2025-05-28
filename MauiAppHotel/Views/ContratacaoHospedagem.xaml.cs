namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        datePickerCheckIn.Date = DateTime.Today;
        datePickerCheckOut.MinimumDate = DateTime.Today.AddDays(1);
        datePickerCheckIn.MinimumDate = DateTime.Today;

        
    }
}