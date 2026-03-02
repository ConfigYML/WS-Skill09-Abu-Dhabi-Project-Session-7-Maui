using Session_7_Dennis_Hilfinger.Models;
using System.Collections.ObjectModel;

namespace Session_7_Dennis_Hilfinger;

public partial class AmenitiesPage : ContentPage
{
	public ObservableCollection<Amenity> Amenities { get; set; } = new ObservableCollection<Amenity>();
	public AmenitiesPage()
	{
		InitializeComponent();
		LoadAmenities();
	}

	private async void LoadAmenities()
	{
		/*try
		{*/
            using var stream = await FileSystem.OpenAppPackageFileAsync("amenities.csv");
            using var reader = new StreamReader(stream);

            var contents = reader.ReadToEnd();
            var lines = contents.Split("\r\n");

			Amenities.Clear();
            foreach (var line in lines)
            {
				var values = line.Split(';');
				if (values.Length == 2)
				{
					Amenities.Add(new Amenity()
					{
						Service = values[0],
						Price = values[1]
					});
				}
				
            }
            AmenitiesView.ItemsSource = Amenities;
        /*} catch
		{
			await DisplayAlert("Error", "Something went wrong while loading amenities. Please try again later", "Ok");
			return;
		}*/
		
	}
    private async void Back(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}