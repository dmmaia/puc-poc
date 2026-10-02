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
            Console.WriteLine(await _context.Mentorias.ToListAsync());
           return View(await _context.Mentorias.ToListAsync());
        }

         public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agendar(
           [FromBody] Mentoria mentoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Mentorias.Add(mentoria);
                    _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
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

                throw;
            }
            return Ok(new
            {
                success = true,
                message = "Mentoria criada com sucesso"
            });
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
