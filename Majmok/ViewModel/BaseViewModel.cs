namespace Majmok.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    public bool IsNotBusy => !isBusy;

    [ObservableProperty]
    string title;

    public ObservableCollection<Monkey> MajmokLista { get; } = new();

    public BaseViewModel()
	{
	}
}