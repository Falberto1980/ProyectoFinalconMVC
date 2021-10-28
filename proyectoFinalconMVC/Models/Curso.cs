using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoFinalconMVC.Models
{
    public class Curso
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public Categoria categoria { get; set; }
    }
}
