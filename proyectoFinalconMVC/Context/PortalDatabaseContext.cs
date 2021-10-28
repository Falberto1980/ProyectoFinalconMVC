using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoFinalconMVC.Models;

namespace proyectoFinalconMVC.Context
{
    public class PortalDatabaseContext : DbContext
    {
        public PortalDatabaseContext(DbContextOptions<PortalDatabaseContext> options): base(options)
        {
        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
    }
}
