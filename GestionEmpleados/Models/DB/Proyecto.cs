using System;
using System.Collections.Generic;

namespace GestionEmpleados.Models.DB;

public partial class Proyecto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly? FechaFin { get; set; }
    public virtual ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; } = new List<EmpleadoProyecto>();
}
