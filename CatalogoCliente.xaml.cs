namespace AppNueva;
using System.Collections.ObjectModel;

public partial class CatalogoCliente : ContentPage
{
	public ObservableCollection <Camion> ListaCamiones { get; set; }
	public CatalogoCliente()
	{
		InitializeComponent();

        ListaCamiones = new ObservableCollection<Camion>
        {
            new Camion
            {
                Nombre = "Camión Caja 26'",
                Imagen = "camioncaja24.jpg",
                Especificaciones = "Largo: 26 pies\nAncho: 102 pulg.\nAltura: 102 pulg.\nLiftgate: Sí",
                IdealPara = "? Muebles\n? Electrodomésticos\n? Pallets / Mercancía"
            },
            new Camion
            {
                Nombre = "Camión Caja 24'",
                Imagen = "camioncaja26.jpg",
                Especificaciones = "Largo: 24 pies\nAncho: 102 pulg.\nAltura: 100 pulg.\nLiftgate: Opcional",
                IdealPara = "? Mudanzas\n? Electrónica\n? Recolección"
            },
            new Camion
            {
                Nombre = "Camión de Volteo",
                Imagen = "camionvolteo.jpg",
                Especificaciones = "Capacidad: 10-20+ yd³\nTipo: Tierra, grava, arena, escombros",
                IdealPara = "? Construcción\n? Excavaciones\n? Terrenos"
            },
            new Camion
            {
                Nombre = "Trailer de Volteo",
                Imagen = "trailervoleto.jpg",
                Especificaciones = "Largo: 12-16 pies\nCapacidad: 10-16 yd³\nTipo: Grava, escombros",
                IdealPara = "? Proyectos pequeños\n? Remodelaciones"
            },
            new Camion
            {
                Nombre = "Trailer de Basura",
                Imagen = "trailerbasura.jpg",
                Especificaciones = "Largo: 14-20 pies\nAltura paredes: Altas\nCapacidad: Varía",
                IdealPara = "? Muebles\n? Electrodomésticos\n? Limpieza"
            },
            new Camion
            {
                Nombre = "Plataforma (Flatbed)",
                Imagen = "logo.png",
                Especificaciones = "Largo: 20-26+ pies\nAncho: 102 pulg.\nCarga útil: Varía",
                IdealPara = "? Madera\n? Tubería\n? Estructuras de acero"
            }
        };

        CvCamiones.ItemsSource = ListaCamiones;
    }

    private async void OnSolicitarCotizacionClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var camion = button?.BindingContext as Camion;

        if (camion != null)
        {
            await DisplayAlert("Cotización", $"Has solicitado cotización para: {camion.Nombre}", "OK");
        }
    }
    private async void OnIrAChatClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaChat());
    }
}