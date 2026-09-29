namespace AppNueva;

public partial class PaginaMensaje : ContentPage
{
	public PaginaMensaje()
	{
		InitializeComponent();
	}
    public PaginaMensaje(string rol)
    {
        InitializeComponent();

        Content = new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Children =
            {
                new Label
                {
                    Text = $"Pantalla: {rol}",
                    FontSize = 24,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Colors.Black
                },
                new Button
                {
                    Text = "Volver",
                    Margin = new Thickness(0, 20, 0, 0),
                    Command = new Command(async () => await Navigation.PopAsync())
                }
            }
        };
    }
}