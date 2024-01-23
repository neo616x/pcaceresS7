using serviciosWeb.Modelos;
using System.Net;

namespace serviciosWeb.Vistas;

public partial class ActEliminar : ContentPage
{
	public ActEliminar(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text=datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text=datos.apellido;    
        txtEdad.Text=datos.edad.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string edad = txtEdad.Text;


            string url = "http://192.168.2.5/moviles/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido + "&edad=" + edad;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(url, "PUT", parametros);
            Navigation.PushAsync(new inicio());

        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;
            string url = "http://192.168.2.5/moviles/post.php?codigo:" + codigo;
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues(url, "DELETE", parametros);
            Navigation.PushAsync(new inicio());
        }
        catch (Exception ex)
        {

            DisplayAlert("ERROR", ex.Message, "CERRAR");
        }

    }
}