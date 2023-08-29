using clases;
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
    public partial class FormVerDetalle : Form
    {
        public FormVerDetalle()
        {
            InitializeComponent();
        }

        public FormVerDetalle(Articulo articulo)
        {
            InitializeComponent();
            labelDetalleNombre.Text = articulo.NombreArticulo;
            labelDetalleCodigoLit.Text = articulo.CodigoArticulo;
            labelDetalleDescripcionLit.Text = articulo.DescripcionArticulo;
            labelDetalleCategoriaLit.Text = articulo.CategoriaArticulo.DescripcionCategoria;
            labelDetalleMarcaLit.Text = articulo.MarcaArticulo.DescripcionMarca;
            labelDetallePrecioLit.Text = articulo.PrecioArticulo.ToString();
            try
            {
                pBoxVerDetalle.Load(articulo.UrlImagenArticulo);
            }
            catch (Exception)
            {

                pBoxVerDetalle.Load("https://i0.wp.com/alpinismoyalgomas.org/wp-content/uploads/2023/01/placeholder-wire-image.jpg?ssl=1");

                //Si entra al catch, muestra la imagen por defecto.
            }
        }

       

        
    }
}
