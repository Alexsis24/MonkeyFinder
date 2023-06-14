namespace MonkeyFinder.ViewModel;

[QueryProperty(nameof(Monkey), "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    IMap map;
    public MonkeyDetailsViewModel(IMap map) 
    {
        this.map = map;
    }
    [ObservableProperty]
    Monkey monkey;

    [RelayCommand]
    async Task OpenMapAsync()
    {
        try
        {
            await map.OpenAsync(Monkey.Latitude, Monkey.Longitude, 
                new MapLaunchOptions
                {
                    Name = Monkey.Name,
                    NavigationMode = NavigationMode.None
                });
        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", $"Unable to open map: {ex.Message}", "OK");
        }
    }

    //if you use modals (Shell.PresentationMode) use this to hava a backbutton
    /*[RelayCommand]
    async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }*/
}
