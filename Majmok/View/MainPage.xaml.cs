namespace Majmok.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = mainViewModel;
		if (DeviceInfo.Platform == DevicePlatform.Android)
		{
			layout.Add(new A_ListaView( new A_ListaViewModel( new MonkeyService())));
		}
		else if (DeviceInfo.Platform == DevicePlatform.WinUI)
		{
			layout.Add(new W_ListaView(new W_ListaViewModel()));
		}

	}
}