using CommunityToolkit.Mvvm.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonkeyFinder.ViewModel;

//betetr way that uses generated communitytoolkits
public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel()
    {
        
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;

    public bool IsNotBusy => !IsBusy;

}

//One way to do it

//public class BaseViewModel : INotifyPropertyChanged
//{
//    bool isBusy;
//    string title;

//    public bool IsBusy
//    {
//        get => isBusy;
//        set
//        {
//            if (isBusy == value)
//                return;

//            isBusy = value;
//            OnPropertyChanged();
//            OnPropertyChanged(nameof(IsNotBusy));
//        }
//    }

//    public bool IsNotBusy => !IsBusy;

//    public string Title
//    {
//        get => title;
//        set
//        {
//            if (title == value)
//                return;

//            title = value;
//            OnPropertyChanged();
//        }
//    }

//    public event PropertyChangedEventHandler PropertyChanged;

//    public void OnPropertyChanged([CallerMemberName] string name = null)
//    {
//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
//    }
//}
