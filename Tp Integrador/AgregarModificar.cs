using clases;
using negocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Tp_Integrador
{
    public partial class frmAgregarModificar : Form
    {
        private Articulo _articulo = null;
        private OpenFileDialog archivo = null;
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
                if (_articulo is null)
                {
                    _articulo = new Articulo();
                    //si el articulo está en null(o sea es Agregar)hay que crear un nuevo objeto, si está en modificar no

                }
                
                if (ValidarFormulario() == true)
                { 
                    _articulo.CodigoArticulo = tBoxCodigo.Text;
                    _articulo.NombreArticulo = tBoxNombre.Text;
                    _articulo.DescripcionArticulo = tBoxDescripcion.Text;
                    _articulo.UrlImagenArticulo = tBoxImagen.Text;
                    _articulo.PrecioArticulo = decimal.Parse(tBoxPrecio.Text);
                    _articulo.MarcaArticulo = (Marca)cBoxMarca.SelectedItem;
                    _articulo.CategoriaArticulo = (Categoria)cBoxCategoria.SelectedItem;

                    if (_articulo.Id != 0)
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
                    if (archivo != null && !(tBoxImagen.Text.ToUpper().Contains("HTTP")) && !File.Exists(ConfigurationManager.AppSettings["Articulos-App"] + archivo.SafeFileName))
                    {
                        File.Copy(archivo.FileName, ConfigurationManager.AppSettings["Articulos-App"] + archivo.SafeFileName);

                    }

                    Close();
                
                }

                

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

                cBoxMarca.DataSource = marNegocio.listar();
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
                else
                {
                    cBoxCategoria.SelectedIndex = -1; //para que no haya ninguna Categoría por defecto.
                    cBoxMarca.SelectedIndex = -1;

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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png"; //filtrar todos los que sean de ese tipo

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                tBoxImagen.Text = archivo.FileName;
                CargarImagen(archivo.FileName);

            }
        }

     

        private void tBoxCodigo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tBoxCodigo.Text))
            {
                tBoxCodigo.BackColor = Color.Red;
            }
            else
            {
                tBoxCodigo.BackColor = Color.White;
            }
        }

        private void tBoxNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tBoxNombre.Text))
            {
                tBoxNombre.BackColor = Color.Red;
            }
            else
            {
                tBoxNombre.BackColor = Color.White;
            }
        }

        private void tBoxPrecio_TextChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (string.IsNullOrEmpty(tBoxPrecio.Text))
            {
                tBoxPrecio.BackColor = Color.Red;
             
            }
            else
            {
                tBoxPrecio.BackColor = Color.White;
            }
            if(!(negocio.soloNumeros(tBoxPrecio.Text)))
            {
                tBoxPrecio.BackColor = Color.Red;


            }
            else
            {
                tBoxPrecio.BackColor = Color.White;

            }
            
        }



        private bool ValidarFormulario()
        {
            bool validar = true;
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (string.IsNullOrEmpty(tBoxCodigo.Text))
            {
                tBoxCodigo.BackColor = Color.Red;

                validar = false;
            }
            if (string.IsNullOrEmpty(tBoxNombre.Text))
            {
                tBoxNombre.BackColor = Color.Red;
                validar = false;
            }
            if (string.IsNullOrEmpty(tBoxPrecio.Text))
            {
                tBoxPrecio.BackColor = Color.Red;

                validar = false;
                
            }
            if(!negocio.soloNumeros(tBoxPrecio.Text))
            {
                validar = false;

            }
            if(cBoxMarca.SelectedItem == null)
            {
                labelMarcaIncorrecta.Visible = true;

                validar = false;
            }
            else
            {
                labelMarcaIncorrecta.Visible = false;
                
            }
            if(cBoxCategoria.SelectedItem == null)
            {
                 labelCategoriaIncorrecta.Visible = true;
                validar = false;
            }
            else
            {
                labelCategoriaIncorrecta.Visible = false;
                
            }




            return validar;
        }

        private void cBoxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxMarca.SelectedItem != null)
            {
                labelMarcaIncorrecta.Visible = false;
            }
        }

        private void cBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxCategoria.SelectedItem != null)
            {
                labelCategoriaIncorrecta.Visible = false;
            }
        }

       
    }
}
