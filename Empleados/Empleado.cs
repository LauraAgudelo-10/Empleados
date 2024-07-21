using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PosicionActual { get; set; }
        public decimal Salario { get; set; }
        public List<HistorialPosicion> HistorialPosiciones { get; set; } = new List<HistorialPosicion>();

        public decimal CalcularBonoAnual()
        {
            decimal porcentajeBono = PosicionActual.ToLower().Contains("gerente") ? 0.20m : 0.10m;
            return Salario * porcentajeBono;
        }

        public class HistorialPosicion
        {
            public int EmpleadoId { get; set; }
            public string Posicion { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime? FechaFin { get; set; }
        }
    }
}