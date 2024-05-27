namespace Majmok.View;

public partial class W_ListaView : ContentView
{
	public W_ListaView(W_ListaViewModel m)
	{
		InitializeComponent();
		BindingContext = m;
	}
}