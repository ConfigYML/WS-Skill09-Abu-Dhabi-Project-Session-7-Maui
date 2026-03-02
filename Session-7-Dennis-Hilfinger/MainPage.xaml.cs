namespace Session_7_Dennis_Hilfinger
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToSearch(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("FlightSearchPage");
        }
        private async void GoToReserve(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SeatReservationPage");
        }
        private async void GoToAmenities(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AmenitiesPage");
        }
        private async void GoToAbout(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AboutAirlinePage");
        }

    }
}
