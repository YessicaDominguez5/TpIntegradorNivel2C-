using clases;
using negocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp_Integrador
{
    public partial class frmAgregarModificar : Form
    {
        public frmAgregarModificar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //cierra la ventana con el cancelar
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio(); 

            try
            {
                articulo.CodigoArticulo = tBoxCodigo.Text;
                articulo.NombreArticulo = tBoxNombre.Text;
                articulo.DescripcionArticulo = tBoxDescripcion.Text;
                articulo.UrlImagenArticulo = tBoxImagen.Text;
                articulo.PrecioArticulo = decimal.Parse(tBoxPrecio.Text);
                articulo.MarcaArticulo = (Marca)cBoxMarca.SelectedItem;
                articulo.CategoriaArticulo = (Categoria)cBoxCategoria.SelectedItem;

                negocio.agregar(articulo); // envía el articulo a la función agregar de ArticuloNegocio.
                MessageBox.Show("Agregado exitosamente");
                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAgregarModificar_Load(object sender, EventArgs e)
        {
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            MarcaNegocio marNegocio = new MarcaNegocio();

            try
            {
                cBoxCategoria.DataSource = catNegocio.listar();
                cBoxMarca.DataSource= marNegocio.listar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void tBoxImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(tBoxImagen.Text);
        }
        private void CargarImagen(string imagen)
        {
            try
            {

                pBoxArticulo.Load(imagen);

                //función para cargar la imagen del Picture Box durante el Load.
            }
            catch (Exception)
            {

                pBoxArticulo.Load("https://i0.wp.com/alpinismoyalgomas.org/wp-content/uploads/2023/01/placeholder-wire-image.jpg?ssl=1");

                //Si entra al catch, muestra la imagen por defecto.
            }

        }

    }
}
