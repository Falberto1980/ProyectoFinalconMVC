using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoFinalconMVC.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace proyectoFinalconMVC.Context
{
    public class PortalDatabaseContext : DbContext
    {
        public PortalDatabaseContext(DbContextOptions<PortalDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public DbSet<InscripcionAlumno> InscripcionAlumno { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // install - package Microsoft.EntityFrameworkCore.Proxies
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies();
            }*/


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(m =>
            {
                m.Property(i => i.id).UseIdentityColumn().ValueGeneratedOnAdd();
                m.HasKey(i => i.id);

                m.Property(i=>i.alias)
                    .IsRequired()
                    .HasMaxLength(10);

                m.Property(i => i.dni)
                    .IsRequired();
                m.HasIndex(i => i.dni).IsUnique();

                m.Property(i => i.edad)
                .IsRequired();

                m.Property(i => i.mail)
                    .IsRequired();

                m.Property(i => i.nombreCompleto)
                    .IsRequired();

                //m.OwnsMany(i => i.inscripciones).WithOwner(i=>i.alumno).HasPrincipalKey(i => i.id);
                m.HasMany(i => i.inscripciones).WithOne(i => i.alumno).HasForeignKey(i => i.IDalumno);
                //m.HasMany(i => i.cursos).WithOne().HasForeignKey(i => i.inscripciones);

                m.ToTable(nameof(Alumnos));
            });

            modelBuilder.Entity<Curso>(m =>
            {
                m.Property(i => i.id).UseIdentityColumn().ValueGeneratedOnAdd();
                m.HasKey(i => i.id);

                m.Property(i => i.categoria)
                    .HasColumnType("int");

                m.Property(i => i.nombre)
                    .IsRequired();

                // m.OwnsMany(i => i.inscripciones).WithOwner(i=>i.curso).HasPrincipalKey(i => i.id);
                m.HasMany(i => i.inscripciones).WithOne(i=>i.curso).HasForeignKey(i => i.IDcurso);
               // m.HasMany(i => i.alumnos).WithOne().HasForeignKey(i => i.inscripciones);

                m.ToTable("Cursos");
            });

            modelBuilder.Entity<InscripcionAlumno>(m =>
            {
                m.Property(i=>i.id).UseIdentityColumn().ValueGeneratedOnAdd();
                m.HasKey(i=>i.id);

                m.HasOne(i=>i.alumno)
                    .WithMany(a=>a.inscripciones)
                    .HasForeignKey(i=>i.IDalumno).IsRequired();

                m.HasOne(i => i.curso)
                   .WithMany(a => a.inscripciones)
                   .HasForeignKey(i => i.IDcurso).IsRequired();

                m.ToTable(nameof(InscripcionAlumno));
            });
        }
    }
}
