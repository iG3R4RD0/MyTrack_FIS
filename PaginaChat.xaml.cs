namespace AppNueva;

public partial class PaginaChat : ContentPage
{
	public PaginaChat()
	{
		InitializeComponent();
	}
    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnIrACatalogoClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CatalogoCliente());
    }
}