namespace Majmok.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    public bool IsNotBusy => !isBusy;

    [ObservableProperty]
    string title;

    public ObservableCollection<Monkey> MajmokLista { get; } = new();

    MonkeyService monkeyService;

    public MainViewModel(MonkeyService ms)
	{
		monkeyService = ms;
        Title = "Majom lista";
	}

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var majmok = await monkeyService.GetMonkeys();

            if (MajmokLista.Count != 0)
                MajmokLista.Clear();

            foreach(var monkey in majmok)
                MajmokLista.Add(monkey);

        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }
    
    [RelayCommand]
    Task GoToDetails(Monkey M)
    {
        return Shell.Current.GoToAsync($"{nameof(DetailPage)}",
            new Dictionary<string, object>
            {
                ["M"] = M
            }
            );
    }
}