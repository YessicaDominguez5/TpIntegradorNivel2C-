using clases;
using negocio;
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

                negocio.agregar(articulo); // envía el articulo a la función agregar de ArticuloNegocio.
                MessageBox.Show("Agregado exitosamente");
                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
