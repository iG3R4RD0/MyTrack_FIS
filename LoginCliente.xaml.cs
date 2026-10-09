using AppNueva.PostgreConect;

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

        Usuario usuario = Procedimientos.GetUserPas(correo);
        //Recordar implementar BCrypt para la contraseña en el futuro
        if (usuario.Password == contraseña)
        {
            Usuario usuarioA = Procedimientos.GetUserID(usuario.UsuarioID);

            // Detección automática por credenciales de personal interno
            if (usuarioA.Tipo == "ADMIN")
            {
                await Navigation.PushAsync(new PaginaMensaje("Administrador"));
            }
            if (usuarioA.Tipo == "TALLER")
            {
                await Navigation.PushAsync(new PaginaMensaje("Encargado de Taller"));
            }
            if (usuarioA.Tipo == "EMPLEADO")
            {
                await Navigation.PushAsync(new PaginaMensaje("Empleado"));
            }
            if (usuarioA.Tipo == "CLIENTE")
            {
                await Navigation.PushAsync(new PaginaMensaje("Cliente"));
            }
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