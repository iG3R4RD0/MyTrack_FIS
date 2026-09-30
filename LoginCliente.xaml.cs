namespace AppNueva;

public partial class LoginCliente : ContentPage
{
	public LoginCliente()
	{
		InitializeComponent();
	}

    private async void ContinuarClienteClicked(object sender, EventArgs e)
    {
        string correo = txtCorreo.Text?.Trim().ToLower() ?? string.Empty;
        string contraseña = txtContraseña.Text ?? string.Empty;

        if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
        {
            await DisplayAlert("Error", "Por favor llena todos los campos.", "OK");
            return;
        }

        // Detección automática por credenciales de personal interno
        if (correo == "admin@longhorn.com" && contraseña == "admin123")
        {
            await Navigation.PushAsync(new PaginaMensaje("Administrador"));
        }
        else if (correo == "encargaditoito@longhorn.com" && contraseña == "taller123")
        {
            await Navigation.PushAsync(new PaginaMensaje("Encargado de Taller"));
        }
        else if (correo == "empleado@longhorn.com" && contraseña == "emp123")
        {
            await Navigation.PushAsync(new PaginaMensaje("Empleado"));
        }
        else
        {
            // Usuario general ingresa como Cliente
            await Navigation.PushAsync(new PaginaMensaje("Cliente"));
        }
        
    }

    private async void OnContinuarGoogleClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Google Auth", "Iniciando sesión con Google...", "OK");
        await Navigation.PushAsync(new PaginaMensaje("Cliente (Google)"));
    }

    private async void OnContinuarAppleClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Apple Auth", "Iniciando sesión con Apple...", "OK");
        await Navigation.PushAsync(new PaginaMensaje("Cliente (Apple)"));
    }
}