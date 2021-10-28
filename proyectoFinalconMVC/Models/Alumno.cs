using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoFinalconMVC.Models
{
    public class Alumno
    {
        public int id { get; set; }

        public string alias { get; set; }

        public string nombreCompleto { get; set; }

        public string dni { get; set; }

        public string mail { get; set; }

        public int edad { get; set; }

       // public List<Curso> cursosSeleccionados { get; set; }
    }
}
