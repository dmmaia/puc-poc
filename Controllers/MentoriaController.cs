using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nodo.Models;
using ProductManagement.Data;

namespace PucPoc.Controllers
{
    public class MentoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MentoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
           return View(await _context.Mentorias.ToListAsync());
        }

         public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agendar(
           [FromBody] Mentoria mentoria)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
               _context.Mentorias.Add(mentoria);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    success = true,
                    message = "Mentoria criada com sucesso",
                    id = mentoria.ID
                });
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Erro ao salvar Mentoria:");
                Console.WriteLine(ex.ToString());

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner exception:");
                    Console.WriteLine(ex.InnerException.Message);
                }

                 return StatusCode(500, new
                {
                    success = false,
                    message = "Erro ao salvar a mentoria."
                });
            }
            
        }

        public async Task<IActionResult> Editar(int id)
        {
            var mentoria = await _context.Mentorias.FindAsync(id);

            if (mentoria == null)
            {
                return NotFound();
            }

            return View(mentoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Mentoria mentoria)
        {
            if (!ModelState.IsValid)
            {
                return View(mentoria);
            }

            _context.Mentorias.Update(mentoria);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var mentoria = await _context.Mentorias.FindAsync(id);

            if (mentoria == null)
            {
                return NotFound();
            }

            _context.Mentorias.Remove(mentoria);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
