namespace Majmok.ViewModel;
[QueryProperty(nameof(M),nameof(M))]
public partial class DetailViewModel : ObservableObject
{
	[ObservableProperty]
	Monkey m;

    [ObservableProperty]
    Color hatter;

	public DetailViewModel(MonkeyService service)
	{		
	}

	[RelayCommand]
	async Task GoBackAsync()
	{
		await Shell.Current.GoToAsync("..", true);
	}
}