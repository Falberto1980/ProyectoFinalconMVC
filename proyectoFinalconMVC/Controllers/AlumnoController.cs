using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectoFinalconMVC.Context;
using proyectoFinalconMVC.Models;

namespace proyectoFinalconMVC.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly PortalDatabaseContext _context;

        public AlumnoController(PortalDatabaseContext context)
        {
            _context = context;
        }

        // GET: Alumno
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alumnos.ToListAsync());
        }

        // GET: Alumno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Si no se habilita el lazyload (actualmente activo, revisar los modelos)
            //var alumno = await _context.Alumnos.Include(a=>a.inscripciones).ThenInclude(i=>i.curso)

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.id == id);
           

            if (alumno == null)
            {
                return NotFound();
            } 

            return View(alumno);
        }

        // GET: Alumno/Create
        public IActionResult Create()
        {
            ViewBag.listaCursos = _context.Cursos.ToList();

            return View();
        }

        // POST: Alumno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Alumno alumno, [FromForm]int[] cursos)
        {
            if (ModelState.IsValid)
            {
                var dni = _context.Alumnos.SingleOrDefault(i => i.dni == alumno.dni) == null;

                if (!dni) ModelState.AddModelError(nameof(Alumno.dni), "El DNI ya existe");

                try
                {
                    alumno.cursos = _context.Cursos.Where(i => cursos.Any(id => id == i.id)).ToList();
                    _context.Add(alumno);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }
            ViewBag.listaCursos = _context.Cursos.ToList();
            return View(alumno);
        }

        // GET: Alumno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            ViewBag.listaCursos = _context.Cursos.ToList();

            return View(alumno);
        }

        // POST: Alumno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Alumno alumno, [FromForm] int[] cursos)
        {
            /*
            if (id != alumno.id)
            {
                return NotFound();
            }
            */
            if (ModelState.IsValid)
            {
                try
                {
                    //Clear and Up
                    _context.InscripcionAlumno.RemoveRange(_context.InscripcionAlumno.Where(i => i.IDalumno == alumno.id).ToList());

                    alumno.cursos = _context.Cursos.Where(i => cursos.Any(id => id == i.id)).ToList();

                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.id == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumnos.Any(e => e.id == id);
        }
    }
}
