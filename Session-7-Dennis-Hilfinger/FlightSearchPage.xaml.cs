using Session_7_Dennis_Hilfinger.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace Session_7_Dennis_Hilfinger;

public partial class FlightSearchPage : ContentPage
{
	private ObservableCollection<Schedule> schedules = new ObservableCollection<Schedule>();
	private List<Airport> airports = new List<Airport>();
	public FlightSearchPage()
	{
		InitializeComponent();
		FillPickers();
	}

	private async void FillPickers()
	{
		HttpClient client = new HttpClient();
        airports = await client.GetFromJsonAsync<List<Airport>>("http://10.0.2.2:5000/api/port/list");
        
        foreach (var airport in airports)
		{
			DepartureAirportPicker.Items.Add(airport.Name.ToString());
			ArrivalAirportPicker.Items.Add(airport.Name.ToString());
		}
	}

	private async void Search(object sender, EventArgs e)
	{
		if (DepartureAirportPicker.SelectedItem == null || ArrivalAirportPicker.SelectedItem == null)
		{
			await DisplayAlert("Error", "Please select a departure and an arrival airport to proceed.", "Ok");
			return;
		}
		var departureId = airports.FirstOrDefault(air => air.Name == DepartureAirportPicker.SelectedItem.ToString()).Id;
		var arrivalId = airports.FirstOrDefault(air => air.Name == ArrivalAirportPicker.SelectedItem.ToString()).Id;
		var date = FlightDatePicker.Date;
		HttpClient client = new HttpClient();
		var flights = await client
			.GetFromJsonAsync<List<Schedule>>(
			$"http://10.0.2.2:5000/api/schedule/list?from={departureId}&to={arrivalId}&date={date.Year}-{date.Month}-{date.Day}"
			);
		var test = await client.GetStringAsync($"http://10.0.2.2:5000/api/schedule/list?from={departureId}&to={arrivalId}&date={date.Year}-{date.Month}-{date.Day}");
		schedules.Clear();
		foreach(var flight in flights)
		{
			schedules.Add(flight);
        }
		FlightsView.ItemsSource = schedules;
	}

    private async void Back(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}