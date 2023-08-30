﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using clases;
using System.Data.SqlClient;
using accesoAdatos;
using System.Net;

namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> Listar()
        {
            List<Articulo> listaDeArticulos = new List<Articulo>();


            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.SetearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca,A.IdCategoria,A.ImagenUrl,A.Precio,C.Id as 'IdCategoria',C.Descripcion as 'DescripcionCategoria',M.Id as 'IdMarca',M.Descripcion as 'DescripcionMarca', A.Activo from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id AND IdCategoria = C.Id AND A.Activo = 1");
                datos.EjecutarLectura();

                return CargarLista(datos);

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
                datos.SetearConsulta("insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio, Activo) values('" + nuevo.CodigoArticulo + "', '" + nuevo.NombreArticulo + "', '" + nuevo.DescripcionArticulo + "',@IdMarca, @IdCategoria, '" + nuevo.UrlImagenArticulo + "'," + nuevo.PrecioArticulo + ", 1)");

                datos.SetearParametros("@IdMarca", nuevo.MarcaArticulo.IdMarca);
                datos.SetearParametros("@IdCategoria", nuevo.CategoriaArticulo.IdCategoria);

                //se tiene que ejecutar lectura pero como es un insert no se puede EjecutarLectura() entonces llama a EjecutarAccion();

                datos.EjecutarAccion();

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

        public void modificar(Articulo articuloAModificar)
        {
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.SetearConsulta("update ARTICULOS set Codigo = @CodigoArticulo, Nombre = @NombreArticulo,Descripcion = @DescripcionArticulo,IdMarca = @MarcaArticulo, IdCategoria = @CategoriaArticulo, ImagenUrl = @UrlImagenArticulo,precio = @PrecioArticulo where Id = @Id");

                datos.SetearParametros("@CodigoArticulo", articuloAModificar.CodigoArticulo);
                datos.SetearParametros("@NombreArticulo", articuloAModificar.NombreArticulo);
                datos.SetearParametros("@DescripcionArticulo", articuloAModificar.DescripcionArticulo);
                datos.SetearParametros("@MarcaArticulo", articuloAModificar.MarcaArticulo.IdMarca);
                datos.SetearParametros("@CategoriaArticulo", articuloAModificar.CategoriaArticulo.IdCategoria);
                datos.SetearParametros("UrlImagenArticulo", articuloAModificar.UrlImagenArticulo);
                datos.SetearParametros("@PrecioArticulo", articuloAModificar.PrecioArticulo);
                datos.SetearParametros("@Id", articuloAModificar.Id);

                datos.EjecutarAccion();

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

        public void EliminarFisico(int id)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.SetearConsulta("delete from ARTICULOS where Id = @Id");
                datos.SetearParametros("@Id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        public void EliminarLogico(int id)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                datos.SetearConsulta("update ARTICULOS set Activo = 0 where id = @id");
                datos.SetearParametros("@id", id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public void Activar(int id)
        {
            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.SetearConsulta("update ARTICULOS set Activo = 1 where id = @id");
                datos.SetearParametros("@id", id);
                datos.EjecutarAccion();



            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public List<Articulo> ListarInactivos()
        {

            ConexionDatos datos = new ConexionDatos();

            try
            {
                datos.SetearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca,A.IdCategoria,A.ImagenUrl,A.Precio,C.Id as 'IdCategoria',C.Descripcion as 'DescripcionCategoria',M.Id as 'IdMarca',M.Descripcion as 'DescripcionMarca', A.Activo from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id AND IdCategoria = C.Id AND A.Activo = 0");
                datos.EjecutarLectura();

                return CargarLista(datos);

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

        public List<Articulo> filtrarAvanzado(string campo, string criterio, string filtro)
        {
            ConexionDatos datos = new ConexionDatos();
            try
            {
                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca,A.IdCategoria,A.ImagenUrl,A.Precio,C.Id as 'IdCategoria',C.Descripcion as 'DescripcionCategoria',M.Id as 'IdMarca',M.Descripcion as 'DescripcionMarca', A.Activo from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id AND IdCategoria = C.Id AND A.Activo = 1 AND ";

                switch (campo)
                {
                    case "Artículo":

                        switch (criterio)
                        {
                            case "Comienza con...":
                                consulta += "A.Nombre like '" + filtro + "%'";

                                break;

                            case "Termina con...":

                                consulta += "A.Nombre like '%" + filtro + "'";

                                break;
                            default://Contiene...

                                consulta += "A.Nombre like '%" + filtro + "%'";
                                break;

                        }


                        break;

                    case "Marca":

                        switch (criterio)
                        {
                            case "Comienza con...":
                                consulta += "M.Descripcion like '" + filtro + "%'";

                                break;

                            case "Termina con...":

                                consulta += "M.Descripcion like '%" + filtro + "'";

                                break;
                            default://Contiene...

                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;

                        }


                        break;

                    default://precio

                        switch (criterio)
                        {
                            case "Mayor a...":
                                consulta += "A.Precio >" + filtro;

                                break;

                            case "Menor a...":

                                consulta += "A.Precio <" + filtro;

                                break;
                            default://Igual a...

                                consulta += "A.Precio =" + filtro;
                                break;

                        }

                        break;


                }
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

               

                return CargarLista(datos);
            }
            catch (Exception ex)
            {

               throw ex;
            }
        }

        private List<Articulo> CargarLista(ConexionDatos datos)
        {
            List<Articulo> lista = new List<Articulo>();
            while (datos.Lector.Read())
            {
                Articulo aux = new Articulo();
                aux.Id = (int)datos.Lector["Id"];
                aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                aux.NombreArticulo = (string)datos.Lector["Nombre"];
                aux.DescripcionArticulo = (string)datos.Lector["Descripcion"];
                aux.CategoriaArticulo = new Categoria();
                aux.CategoriaArticulo.IdCategoria = (int)datos.Lector["IdCategoria"];
                aux.CategoriaArticulo.DescripcionCategoria = (string)datos.Lector["DescripcionCategoria"];
                aux.MarcaArticulo = new Marca();
                aux.MarcaArticulo.IdMarca = (int)datos.Lector["IdMarca"];
                aux.MarcaArticulo.DescripcionMarca = (string)datos.Lector["DescripcionMarca"];

                if (!(datos.Lector["ImagenUrl"] is DBNull)) //para que lo lea solo si no es Null
                {
                    aux.UrlImagenArticulo = (string)datos.Lector["ImagenUrl"];


                }
                aux.PrecioArticulo = (decimal)datos.Lector["Precio"];

                aux.Activo = (bool)datos.Lector["Activo"];
                lista.Add(aux);
            }

            return lista;

        }
        public bool soloNumeros(string cadena)
        {
            int cont = 0;

            foreach (char caracter in cadena)
            { 
                if(caracter == '.')
                {
                    cont++;
                }

                if (!(char.IsNumber(caracter)) && caracter != '.')
                {
                    return false; //si no es Número retorna falso a validarFiltro
                }
                
                if(cont >= 2)
                {
                    return false;
                }
            }

            return true;

        }
    }
}
