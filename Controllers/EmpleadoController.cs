using Microsoft.AspNetCore.Mvc;
using AppCRUD.Data;
using AppCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCRUD.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public EmpleadoController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _appDbContext.Empledos.ToListAsync();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Nuevo()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            await _appDbContext.Empledos.AddAsync(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _appDbContext.Empledos.FirstAsync(e => e.IdEmpleado == id);
            return View(empleado);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            _appDbContext.Empledos.Update(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _appDbContext.Empledos.FirstAsync(e => e.IdEmpleado == id);
            _appDbContext.Empledos.Remove(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

    }
}
