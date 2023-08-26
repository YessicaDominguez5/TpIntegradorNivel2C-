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
        private Articulo _articulo = null;
        public frmAgregarModificar()//constructor para agregar
        {
            InitializeComponent();
        }
        public frmAgregarModificar(Articulo articuloSeleccionado) //constructor para modificar
        {
            InitializeComponent();
            _articulo = articuloSeleccionado; //al articulo de la línea 18 le asignamos el artículo seleccionado en el Modificar
            Text = "Modificar Artículo";
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //cierra la ventana con el cancelar
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio(); 

            try
            {
                    if(_articulo is null)
                    {
                       _articulo = new Articulo();
                       //si el articulo está en null(o sea es Agregar)hay que crear un nuevo objeto, si está en modificar no

                    }
                _articulo.CodigoArticulo = tBoxCodigo.Text;
                _articulo.NombreArticulo = tBoxNombre.Text;
                _articulo.DescripcionArticulo = tBoxDescripcion.Text;
                _articulo.UrlImagenArticulo = tBoxImagen.Text;
                _articulo.PrecioArticulo = decimal.Parse(tBoxPrecio.Text);
                _articulo.MarcaArticulo = (Marca)cBoxMarca.SelectedItem;
                _articulo.CategoriaArticulo = (Categoria)cBoxCategoria.SelectedItem;

                if(_articulo.Id != 0)
                {
                    //si el Id no es 0 es porque estoy modificando

                    negocio.modificar(_articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                negocio.agregar(_articulo); // envía el articulo a la función agregar de ArticuloNegocio.
                MessageBox.Show("Agregado exitosamente");
                }

               
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
                cBoxCategoria.ValueMember = "IdCategoria"; //clave para asignar un valor predeterminado en la línea 89
                cBoxCategoria.DisplayMember = "DescripcionCategoria";//valor

                cBoxMarca.DataSource= marNegocio.listar();
                cBoxMarca.ValueMember = "IdMarca";
                cBoxMarca.DisplayMember = "DescripcionMarca";


                if (_articulo != null)//si es null es porque no paso por el agregar todavia, si es null es un articulo a modificar
                {
                    //se precarga el artículo en el modificar
                    tBoxCodigo.Text = _articulo.CodigoArticulo.ToString();
                    tBoxNombre.Text = _articulo.NombreArticulo;
                    tBoxDescripcion.Text = _articulo.DescripcionArticulo;
                    tBoxImagen.Text = _articulo.UrlImagenArticulo;
                    CargarImagen(_articulo.UrlImagenArticulo);
                    tBoxPrecio.Text = _articulo.PrecioArticulo.ToString();

                    cBoxCategoria.SelectedValue = _articulo.CategoriaArticulo.IdCategoria;
                    cBoxMarca.SelectedValue = _articulo.MarcaArticulo.IdMarca;



                }

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
