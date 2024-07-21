using System;
using System.Collections.Generic;

namespace GestionEmpleados.Models.DB;

public partial class Departamento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Ubicacion { get; set; } = null!;
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
