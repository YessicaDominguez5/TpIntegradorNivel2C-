﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace accesoAdatos
{
    public class ConexionDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector 
        {

            get { return lector; } 
        }




        public ConexionDatos()
        {
            conexion= new SqlConnection("server =.\\SQLEXPRESS; database = CATALOGO_DB; integrated security = true");
            comando = new SqlCommand();

        }

        public void SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
            conexion.Open();
            lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void CerrarConexion()
        {
            if(lector != null) 
            {
                lector.Close();
                conexion.Close();
            
            }



        }

    }
}
