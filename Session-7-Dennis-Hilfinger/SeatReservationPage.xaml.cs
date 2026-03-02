using Android.AdServices.AdSelection;
using AndroidX.ConstraintLayout.Core.State.Helpers;
using Session_7_Dennis_Hilfinger.Models;
using System.Net.Http.Json;
using System.Runtime.InteropServices.ObjectiveC;

namespace Session_7_Dennis_Hilfinger;

public partial class SeatReservationPage : ContentPage
{
    Button? reservedSeat = null;
	public SeatReservationPage()
	{
		InitializeComponent();
	}

    private async void SelectTicket(object sender, EventArgs e)
    {
        BusinessLayout.IsVisible = false;
        FirstClassLayout.IsVisible = false;

        if(String.IsNullOrEmpty(TicketInput.Text.Trim()))
        {
            await DisplayAlert("Info", "Please enter a ticket number.", "Ok");
            return;
        }

        reservedSeat = null;
        HttpClient client = new HttpClient();
        var cabinType = await client.GetFromJsonAsync<CabinType>($"http://10.0.2.2:5000/api/ticket/{TicketInput.Text.Trim()}");

        if ( cabinType == null )
        {
            await DisplayAlert("Error", "Ticket could not be found.", "Ok");
            return;
        }

        switch (cabinType.Type)
        {
            case "economy":
                await DisplayAlert("Info", "The seat reservation feature is only available for business and first class tickets.", "Ok");
                return;
            case "business":
                BusinessLayout.IsVisible = true;
                break;
            case "first":
                FirstClassLayout.IsVisible = true;
                break;
        }
    }

    private async void SelectSeat(object sender, EventArgs e)
    {
        Button seat  = (Button)sender;
        
        if (reservedSeat != null)
        {
            reservedSeat.BackgroundColor = Color.FromArgb("FFF79420");
        }
        seat.BackgroundColor = Color.FromArgb("FF196AA6");
        reservedSeat = seat;
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