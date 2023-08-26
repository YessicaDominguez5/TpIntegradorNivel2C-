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
            if(dgvListaArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem; //de la fila actual trae el objeto enlazado.
                CargarImagen(seleccionado.UrlImagenArticulo); // trae la imagen del articulo seleccionado a la picture box.
            }
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
               
                    dgvListaArticulos.Columns["Id"].Visible = false;
                    dgvListaArticulos.Columns["Activo"].Visible = false;

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;

            try
            {
                if(dgvListaArticulos.CurrentRow is null) // Si no se seleccionó nada, pedimos y no cerramos el programa con el return.
                {
                    MessageBox.Show("Por favor selecciona un item");
                    return;
                }
            seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;

            frmAgregarModificar ArticuloAModificar = new frmAgregarModificar(seleccionado);
            ArticuloAModificar.ShowDialog();
            Cargar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            Eliminar(true);
        }

        private void Eliminar(bool logico = false) //EliminarFisico y EliminarLogico llaman a la funcion eliminar pasandole el id del item seleccionado, el = false hace que mandar el parametro sea opcional
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar?", "Eliminando...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;

                    if(logico)
                    {
                        negocio.EliminarLogico(seleccionado.Id);

                    }
                    else
                    {
                    negocio.EliminarFisico(seleccionado.Id);

                    }
                    Cargar();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            List<Articulo> listaInactiva = negocio.ListarInactivos();

            dgvListaArticulos.DataSource = listaInactiva;

            dgvListaArticulos.Columns["UrlImagenArticulo"].Visible = false;  //para que no se vea la columna de url (con el nombre de la clase Articulo).
            CargarImagen(listaInactiva[0].UrlImagenArticulo); //Trae la imagen del primer objeto de la lista.

            dgvListaArticulos.Columns["Id"].Visible = false;
            dgvListaArticulos.Columns["Activo"].Visible = false;




        }
    }
}
