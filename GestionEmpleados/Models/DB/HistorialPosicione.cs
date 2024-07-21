using System;
using System.Collections.Generic;

namespace GestionEmpleados.Models.DB;

public partial class HistorialPosicione
{
    public int Id { get; set; }
    public int? IdEmpleado { get; set; }
    public string Posicion { get; set; } = null!;
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
