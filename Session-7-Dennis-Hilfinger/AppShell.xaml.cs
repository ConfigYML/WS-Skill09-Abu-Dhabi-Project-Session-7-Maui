namespace Session_7_Dennis_Hilfinger
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AboutAirlinePage), typeof(AboutAirlinePage));
            Routing.RegisterRoute(nameof(AmenitiesPage), typeof(AmenitiesPage));
            Routing.RegisterRoute(nameof(FlightSearchPage), typeof(FlightSearchPage));
            Routing.RegisterRoute(nameof(SeatReservationPage), typeof(SeatReservationPage));
        }
    }
}
