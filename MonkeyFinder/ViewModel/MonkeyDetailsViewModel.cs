namespace MonkeyFinder.ViewModel;

[QueryProperty(nameof(Monkey), "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    public MonkeyDetailsViewModel() 
    {
        
    }
    [ObservableProperty]
    Monkey monkey;

    //if you use modals (Shell.PresentationMode) use this to hava a backbutton
    /*[RelayCommand]
    async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }*/
}
