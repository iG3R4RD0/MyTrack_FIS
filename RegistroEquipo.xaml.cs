namespace AppNueva;

public partial class RegistroEquipo : ContentPage
{
    private string rutaImagenSeleccionada = string.Empty;
    public RegistroEquipo()
	{
		InitializeComponent();
	}
    //selecciona la foto desde la galeria
    private async void SeleccionarImagen(object sender, EventArgs e)
    {
        try
        {
            var foto = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Selecciona una imagen del equipo"
            });

            if (foto != null)
            {
                rutaImagenSeleccionada = foto.FullPath;
                imgEquipo.Source = ImageSource.FromFile(rutaImagenSeleccionada);
                lblPlaceholderImagen.IsVisible = false; // Oculta el texto
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo cargar la imagen: {ex.Message}", "OK");
        }
    }

    // Guardar el equipo
    private async void GuardarEquipo (object sender, EventArgs e)
    {
        // Validaciones obligatorias
        if (string.IsNullOrWhiteSpace(txtNombreEquipo.Text) ||
            pkrTipoEquipo.SelectedIndex == -1 ||
            string.IsNullOrWhiteSpace(txtCarga.Text))
        {
            await DisplayAlert("Error", "Por favor completa el nombre, tipo y capacidad de carga.", "OK");
            return;
        }

        string nombre = txtNombreEquipo.Text.Trim();
        string tipo = pkrTipoEquipo.SelectedItem.ToString();
        string carga = txtCarga.Text.Trim();
        string uso = txtUso.Text?.Trim() ?? "Sin especificar";

        //mensaje de confirmacion del equipo
        await DisplayAlert("Éxito", $"Equipo registrado correctamente:\n\n• Nombre: {nombre}\n• Tipo: {tipo}\n• Carga: {carga}", "OK");

        await Navigation.PopAsync();
    }
}