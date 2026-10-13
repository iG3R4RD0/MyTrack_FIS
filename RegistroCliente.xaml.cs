namespace AppNueva;

public partial class RegistroCliente : ContentPage
{
	public RegistroCliente()
	{
		InitializeComponent();
	}

    private async void OnGuardarRegistroClicked(object sender, EventArgs e)
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

        if (txtConfirmarContraseña.Text != txtConfirmarContraseña.Text)
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
            return;
        }

        // Aqui se agregazz para guardar en la base de datos
        await DisplayAlert("Éxito", "Cuenta creada correctamente.", "OK");

        // Regresar a la pantalla anterior
        await Navigation.PopAsync();

    }
}