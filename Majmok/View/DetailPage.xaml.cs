namespace Majmok.View;

public partial class DetailPage : ContentPage
{
	DetailViewModel _viewModel;
	Random ran = new Random();
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		_viewModel = vm;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		_viewModel.Hatter = Color.FromRgb(ran.Next(256), ran.Next(256), ran.Next(256));
    }
}