﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clases
{
    public class Marca
    {
        public int IdMarca { get; set; }

        public string DescripcionMarca { get; set;}

        public override string ToString()
        {
            return DescripcionMarca;

            //Para que retorne la descripción del objeto
        }
    }
}
