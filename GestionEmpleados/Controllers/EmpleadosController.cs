using GestionEmpleados.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EmpleadosController : Controller
{
    private readonly GestionEmpleadosContext _context;

    public EmpleadosController(GestionEmpleadosContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var empleados = await _context.Empleados
        .Include(e => e.IdDepartamentoNavigation) 
        .Include(e => e.EmpleadoProyectos)
            .ThenInclude(ep => ep.IdProyectoNavigation)
        .Where(e => e.EmpleadoProyectos.Any())
        .ToListAsync();

        return View(empleados);
    }
}
