namespace Majmok.ViewModel;

public partial class W_ListaViewModel : BaseViewModel
{
    MonkeyService monkeyService;
    public W_ListaViewModel(MonkeyService ms)
	{
        monkeyService = ms;
        Title = "Majom lista - Windows";
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

            foreach (var monkey in majmok)
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

}