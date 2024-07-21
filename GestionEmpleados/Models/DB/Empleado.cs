using System;
using System.Collections.Generic;

namespace GestionEmpleados.Models.DB;

public partial class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string PosicionActual { get; set; }
    public decimal Salario { get; set; }
    public int? IdDepartamento { get; set; }
    public virtual Departamento? IdDepartamentoNavigation { get; set; }
    public virtual ICollection<HistorialPosicione> HistorialPosiciones { get; set; } = new HashSet<HistorialPosicione>();
    public virtual ICollection<EmpleadoProyecto> EmpleadoProyectos { get; set; } = new HashSet<EmpleadoProyecto>();
}
