﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedList
{
    public class Alumno
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Alumno(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public Alumno(string nombre) 
        {
            this.nombre = nombre;
        }
    }
}
