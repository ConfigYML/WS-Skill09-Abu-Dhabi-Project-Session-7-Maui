namespace Session_7_Dennis_Hilfinger;

public partial class AboutAirlinePage : ContentPage
{
    public AboutAirlinePage()
	{
		InitializeComponent();
        LoadText();
	}

    private async void LoadText()
    {
       
        using var stream = await FileSystem.OpenAppPackageFileAsync("aboutUs.txt");
        using var reader = new StreamReader(stream);

        var contents = await reader.ReadToEndAsync();

        AboutLabel.Text = contents.ToString();
    }

    private async void Back(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}