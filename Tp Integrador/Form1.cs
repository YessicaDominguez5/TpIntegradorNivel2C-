using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
                    CargarImagen(lista[0].UrlImagenArticulo); //Trae la imagen del primer objeto de la lista.
                    OcultarColumnas();

                    btnActivarArticulo.Enabled = false;
                    btnActivarArticulo.Visible = false;
                    btnCancelarActivar.Enabled = false;
                    btnCancelarActivar.Visible = false;

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

            CargarImagen(listaInactiva[0].UrlImagenArticulo); //Trae la imagen del primer objeto de la lista.
            OcultarColumnas();

            MostrarBotones(false);

            btnActivarArticulo.Enabled = true;
            btnActivarArticulo.Visible = true;
            btnCancelarActivar.Enabled = true;
            btnCancelarActivar.Visible = true;


        }

        private void btnCancelarActivar_Click(object sender, EventArgs e)
        {
            Cargar();
            MostrarBotones(true);

            
        }

        private void btnActivarArticulo_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea Activar el artículo?", "Activando...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                    negocio.Activar(seleccionado.Id);

                    
                    Cargar();
                    MostrarBotones(true);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
            private void MostrarBotones(bool mostrar)
            {
                btnAgregar.Enabled = mostrar;
                btnAgregar.Visible = mostrar;
                btnModificar.Enabled = mostrar  ;
                btnModificar.Visible = mostrar  ;
                btnEliminarFisico.Enabled = mostrar ;
                btnEliminarFisico.Visible = mostrar;       
                btnEliminarLogico.Enabled = mostrar;
                btnEliminarLogico.Visible = mostrar;
                btnActivar.Enabled = mostrar;
                btnActivar.Visible = mostrar;


            }

        private void btnFiltroSimple_Click(object sender, EventArgs e)
        {
          
        }

        private void OcultarColumnas()
        {

            dgvListaArticulos.Columns["UrlImagenArticulo"].Visible = false;  //para que no se vea la columna de url (con el nombre de la clase Articulo).
            dgvListaArticulos.Columns["Id"].Visible = false;
            dgvListaArticulos.Columns["Activo"].Visible = false;



        }

        private void tBoxFiltroSimple_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = tBoxFiltroSimple.Text;

            if (filtro.Length >= 3)
            {

                listaFiltrada = lista.FindAll(x => x.NombreArticulo.ToUpper().Contains(filtro.ToUpper()) || x.CategoriaArticulo.DescripcionCategoria.ToUpper().Contains(filtro.ToUpper()) || x.MarcaArticulo.DescripcionMarca.ToUpper().Contains(filtro.ToUpper()));//Donde el nombre del Articulo contiene lo que esta en el TextBox, encontrar todos esos
                MostrarBotones(false);



            }
            else
            {
                listaFiltrada = lista;
                MostrarBotones(true);

            }

            //se limpia y se guarda listaFiltrada
            dgvListaArticulos.DataSource = null;
            dgvListaArticulos.DataSource = listaFiltrada;
            OcultarColumnas();

        }
    }
}
