namespace Majmok.View;

public partial class W_ListaView : ContentView
{
	W_ListaViewModel _model;
	public W_ListaView(W_ListaViewModel m)
	{
		InitializeComponent();
		BindingContext = m;
		_model = m;
	}

    private void ContentView_Loaded(object sender, EventArgs e)
    {
		_model.GetMonkeysCommand.Execute(this);
    }
}