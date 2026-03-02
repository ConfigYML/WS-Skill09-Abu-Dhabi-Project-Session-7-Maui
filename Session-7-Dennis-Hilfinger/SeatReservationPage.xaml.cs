using System.Runtime.InteropServices.ObjectiveC;

namespace Session_7_Dennis_Hilfinger;

public partial class SeatReservationPage : ContentPage
{
	public SeatReservationPage()
	{
		InitializeComponent();
	}

    private async void SelectTicket(object sender, EventArgs e)
    {
        await DisplayAlert("Info", "Feature not implemented yet.", "Ok");
        return;
    }

    private async void ReserveSeat(object sender, EventArgs e)
    {
        await DisplayAlert("Info", "Feature not implemented yet.", "Ok");
        return;
    }

    private async void Back(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}