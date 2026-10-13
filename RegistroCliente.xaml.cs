using AppNueva.PostgreConect;

namespace AppNueva;

public partial class RegistroCliente : ContentPage
{
	public RegistroCliente()
	{
		InitializeComponent();
	}

    private async void OnGuardarRegistroClicked(object sender, EventArgs e)
    {
        try 
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtCorreoRegistro.Text) ||
            string.IsNullOrWhiteSpace(txtContraseñaRegistro.Text))
            {
                await DisplayAlert("Error", "Por favor completa los campos obligatorios.", "OK");
                return;
            }

            if (!chkMayorEdad.IsChecked)
            {
                await DisplayAlert("Requisito", "Debes confirmar que eres mayor de edad para registrarte.", "OK");
                return;
            }

            if (txtContraseñaRegistro.Text != txtConfirmarContraseña.Text)
            {
                await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
                return;
            }

            Usuario nuevo = new Usuario
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreoRegistro.Text,
                Password = txtContraseñaRegistro.Text,
                Tipo = "Cliente",
                Estatus = true
            };

            int userId = Procedimientos.InsertarUsuario(nuevo);

            if (userId <= 0)
            {
                await DisplayAlert("Error", "Ocurrió un error al crear la cuenta. Por favor intenta nuevamente.", "OK");
            }
            await DisplayAlert("Éxito", "Cuenta creada correctamente.", "OK");

            // Regresar a la pantalla anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error al crear la cuenta: {ex.Message}", "OK");
            return;
        }
    }
}