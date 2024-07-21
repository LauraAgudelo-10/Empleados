using System;
using System.Collections.Generic;

namespace GestionEmpleados.Models.DB;

public partial class EmpleadoProyecto
{
    public int IdEmpleado { get; set; }
    public Empleado IdEmpleadoNavigation { get; set; }
    public int IdProyecto { get; set; }
    public Proyecto IdProyectoNavigation { get; set; }
    public DateTime FechaAsignacion { get; set; }
}
