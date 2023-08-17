using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clases;
using negocio;

namespace Tp_Integrador
{
    public partial class FormCatalogo : Form
    {
        private List<Articulo> lista;

        public FormCatalogo()
        {
            InitializeComponent();
        }

        private void FormCatalogo_Load(object sender, EventArgs e)
        {
            Cargar();

        }
            

        private void dgvListaArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem; //de la fila actual trae el objeto enlazado.
            CargarImagen(seleccionado.UrlImagenArticulo); // trae la imagen del articulo seleccionado a la picture box.
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarModificar nuevoArticulo = new frmAgregarModificar();
            nuevoArticulo.ShowDialog();
            Cargar();
        }

            private void Cargar()
            {
                // Carga en el Load la lista en el Data Grid View
                ArticuloNegocio negocio = new ArticuloNegocio();

                try
                {
                    lista = negocio.Listar();
                    dgvListaArticulos.DataSource = lista;
                    dgvListaArticulos.Columns["UrlImagenArticulo"].Visible = false;  //para que no se vea la columna de url (con el nombre de la clase Articulo).
                    CargarImagen(lista[0].UrlImagenArticulo); //Trae la imagen del primer objeto de la lista.

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }



        
    }
}
