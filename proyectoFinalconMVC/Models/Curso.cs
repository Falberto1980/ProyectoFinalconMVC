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

        [Required(ErrorMessage = "Debe completar campo")]
        public string nombre { get; set; }

        [Required]
        public Categoria categoria { get; set; }
    }
}
