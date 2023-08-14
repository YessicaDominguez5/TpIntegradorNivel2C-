﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using clases;
using System.Data.SqlClient;
using accesoAdatos;

namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo>Listar()
        {
             List<Articulo> listaDeArticulos = new List<Articulo>();


            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.SetearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca,A.IdCategoria,A.ImagenUrl,A.Precio,C.Id as 'IdCategoria',C.Descripcion as 'DescripcionCategoria',M.Id as 'IdMarca',M.Descripcion as 'DescripcionMarca' from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id AND IdCategoria = C.Id");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.NombreArticulo = (string)datos.Lector["Nombre"];
                    aux.DescripcionArticulo = (string)datos.Lector["Descripcion"];
                    aux.CategoriaArticulo = new Categoria();
                    aux.CategoriaArticulo.DescripcionCategoria = (string)datos.Lector["DescripcionCategoria"];
                    aux.MarcaArticulo = new Marca();
                    aux.MarcaArticulo.DescripcionMarca = (string)datos.Lector["DescripcionMarca"];
                    aux.UrlImagenArticulo = (string)datos.Lector["ImagenUrl"];
                    aux.PrecioArticulo = (decimal)datos.Lector["Precio"];

                    listaDeArticulos.Add(aux);

                }

                return listaDeArticulos;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {

                datos.CerrarConexion();
            }


        }

        public void agregar(Articulo nuevo) //recibe el artículo que se manda dentro del evento Aceptar_Click desde el formulario AgregarModificar
        {
            ConexionDatos datos = new ConexionDatos();

            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }
    }
}
