using Empleados;
//Referencia de autorizacion
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpleadosAPI.Controllers
{
    [ApiController]
    [Route("empleados")]
    //Agregar la restriccion
    //[Authorize]
    public class EmpleadosController : ControllerBase
    {
        //Se crea una lista de empleados
        private static List<Empleado> empleados = new List<Empleado>()
        {
            new Empleado { Id = 1, Nombre = "Laura Agudelo", PosicionActual = "Desarrollador", Salario = 8000000 },
            new Empleado { Id = 2, Nombre = "Sara Vidal", PosicionActual = "Gerente de Proyecto", Salario = 10000000 },
            new Empleado { Id = 3, Nombre = "Sofia Perez", PosicionActual = "Gerente de Ventas", Salario = 5000000 },
            new Empleado { Id = 4, Nombre = "Juan Pablo Ruiz", PosicionActual = "Administrador", Salario = 6000000 },
            new Empleado { Id = 5, Nombre = "Diego Mora", PosicionActual = "Desarrollador", Salario = 7000000 }
        };


        // GET: /api/empleados
        //Devuelve una lista de todos los empleados
        [HttpGet]
        [Route("listarEmpleados")]
        //Autorizacion de rol
        [Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<Empleado>> Get()
        {
            return empleados;
        }

        // GET: /api/empleados/{id}
        //Devuelve detalles de un empleado específico por ID.
        [HttpGet]
        [Route("consultarEmpleado")]
        //Autorizacion de rol
        [Authorize(Roles = "Admin")]
        public ActionResult<Empleado> Get(int id)
        {
            var empleado = empleados.FirstOrDefault(e => e.Id == id);
            if (empleado == null)
            {
                return NotFound(new { message = "Empleado no encontrado" });
            }
            return empleado;
        }

        // POST: /api/empleados
        //Agrega un nuevo empleado.
        [HttpPost]
        [Route("agregarEmpleado")]
        //Autorizacion de rol
        [Authorize(Roles = "Admin")]
        public ActionResult<Empleado> Post([FromBody] Empleado nuevoEmpleado)
        {
            nuevoEmpleado.Id = empleados.Max(e => e.Id) + 1;
            empleados.Add(nuevoEmpleado);
            return CreatedAtAction(nameof(Get), new { id = nuevoEmpleado.Id }, nuevoEmpleado);
        }

        // PUT: /api/empleados/{id}
        //Actualiza un empleado existente.
        [HttpPut]
        [Route("actualizarEmpleado")]
        //Autorizacion de rol
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, [FromBody] Empleado empleadoActualizado)
        {
            var empleado = empleados.FirstOrDefault(e => e.Id == id);
            if (empleado == null)
            {
                return NotFound(new { message = "Empleado no encontrado" });
            }
            empleado.Nombre = empleadoActualizado.Nombre;
            empleado.PosicionActual = empleadoActualizado.PosicionActual;
            empleado.Salario = empleadoActualizado.Salario;
            return Ok(new { message = "Empleado actualizado exitosamente" });
        }


        // POST: /api/empleados/{id}
        //Elimina un empleado.
        [HttpDelete]
        [Route("eliminarEmpleado")]
        //Autorizacion de rol
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var empleado = empleados.FirstOrDefault(e => e.Id == id);
            if (empleado == null)
            {
                return NotFound(new { message = "Empleado no encontrado" });
            }
            empleados.Remove(empleado);
            return Ok(new { message = "Empleado eliminado exitosamente" });
        }
    }
}
