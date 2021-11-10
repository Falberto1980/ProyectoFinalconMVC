using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using proyectoFinalconMVC.Context;

namespace proyectoFinalconMVC.Models
{
    public class InscripcionAlumno
    {
        [Key]
        public int id { get; set; }
        private ILazyLoader LazyLoader { get; set; }
        public int IDalumno { get; set; }

        private Alumno _alumno;
        public Alumno alumno { get => LazyLoader.Load(this, ref _alumno); set => _alumno = value; }




        public int IDcurso { get; set; }

        private Curso _curso;
        
        public Curso curso { get => LazyLoader.Load(this, ref _curso); set=>_curso=value; }

        public InscripcionAlumno() { }
        public InscripcionAlumno(int IDalumno, int IDcurso)
        {
            this.IDalumno = IDalumno;
            this.IDcurso = IDcurso;
            
        }
        public InscripcionAlumno(Alumno alumno, Curso curso):this(alumno.id, curso.id)
        {
            this.alumno = alumno;
            this.curso = curso;
        }
    }
}
