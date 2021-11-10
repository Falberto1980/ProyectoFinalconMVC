using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using proyectoFinalconMVC.Context;
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

        
        [Required(ErrorMessage = "Debe completar alias")]
        [MaxLength(10)]
        public string alias { get; set; }

        [Required(ErrorMessage = "Debe completar su nombre")]
        [DataType(DataType.Text)]
        public string nombreCompleto { get; set; }

        [Required(ErrorMessage = "Debe completar el DNI")]
        public long dni { get; set; }

        [Required(ErrorMessage = "Debe completar mail")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El Mail debe tener un " +
            "formato valido.")]
        public string mail { get; set; }

        [Required(ErrorMessage = "Debe completar su edad")]
        [Range(18, 120, ErrorMessage = "ingrese una edad valida")]
        public int edad { get; set; }


        ///Relaciones
        ///--------------------------

        [NotMapped]
        public List<Curso> cursos
        {
            get => inscripciones?.Select(i => i.curso).ToList(); 

            set => inscripciones?.AddRange(value.Select(i => new InscripcionAlumno(alumno:this, curso:i)));
        }

       
        ///la interfaz lazyloads que ademas nos provee carga en la creacion.
        ///
        private ILazyLoader LazyLoader { get; set; }
        private List<InscripcionAlumno> _inscripciones = new List<InscripcionAlumno>();
        public List<InscripcionAlumno> inscripciones { get=>LazyLoader.Load(this, ref _inscripciones); set=> _inscripciones=value; }

    }
}
