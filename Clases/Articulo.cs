using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel; //librería para el DisplayName
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases
{
    public class Articulo

    {
        
        public int Id{ get; set; }
        
        [DisplayName("     Código   ")] //Nombre para las columnas, se le puede agregar tildes y espacios, va arriba de la property
        public string CodigoArticulo { get; set; }

        [DisplayName("      Artículo   ")]
        public string NombreArticulo { get; set; }

        [DisplayName("   Descripción")]
        public string DescripcionArticulo { get; set; }

        [DisplayName("      Marca   ")]

        public Marca MarcaArticulo { get; set; }

        [DisplayName("     Categoría   ")]

        public Categoria CategoriaArticulo { get; set; }

       // [DisplayName("Url de la Imagen")]
        public string UrlImagenArticulo { get; set; }

        [DisplayName("     Precio   ")]

        public decimal PrecioArticulo { get; set; }

        public bool Activo { get; set; }
    }
}






