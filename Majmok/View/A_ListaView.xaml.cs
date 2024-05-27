namespace Majmok.View;

public partial class A_ListaView : ContentView
{
	A_ListaViewModel model;
	public A_ListaView(A_ListaViewModel v)
	{
		InitializeComponent();
		model = v;
		BindingContext = model;
	}
}