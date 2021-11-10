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
    public class Curso
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe completar campo")]
        public string nombre { get; set; }

        [Required]
        public Categoria categoria { get; set; }

        [NotMapped]
        public List<Alumno> alumnos {
            get => inscripciones?.Select(i=>i.alumno).ToList();
            set=>inscripciones?.AddRange(value.Select(i => new InscripcionAlumno(alumno: i, curso: this))); 
        }

        ///la interfaz lazyloads que ademas nos provee carga en la creacion.
        ///
        private ILazyLoader LazyLoader { get; set; }
        private List<InscripcionAlumno> _inscripciones = new List<InscripcionAlumno>();
        public List<InscripcionAlumno> inscripciones { get => LazyLoader.Load(this, ref _inscripciones); set => _inscripciones = value; }

    }
}
