﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public  class CategoriaManager
    {
        public List<Categoria> listar()
        {

            List<Categoria> listaCategorias = new List<Categoria>();
            AccesoADatos conexion = new AccesoADatos();

            try
            {
                conexion.setearConsulta("Select IdCategoria, Descripcion from Categorias");
                conexion.ejecutarQuery();
                while (conexion.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    //aux.Id = (int)conexion.Lector["IdCategoria"];
                    aux.Id = (byte)conexion.Lector["IdCategoria"];
                    try
                    {
                        aux.Descripcion = (string)conexion.Lector["Descripcion"];
                    }
                    catch (Exception)
                    {
                        aux.Descripcion = "Error al leer la categoría";
                    }
                    listaCategorias.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
            return listaCategorias;
        }
    }
}
