using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//usar referencias
using EmpleadosAPI.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EmpleadosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        //Obtener secretkey
        private readonly string secretkey;
        //obtener lista de usuarios
        private static List<Usuario> Usuarios = new List<Usuario>();
        //Crear constructor
        public AutenticacionController(IConfiguration config)
        {
            secretkey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        //Método para permitir autenticar al usuario
        [HttpPost]
        [Route("inicioSesion")]
        public IActionResult Validar([FromBody] Usuario request)
        {
            var user = Usuarios.SingleOrDefault(u => u.Correo == request.Correo && u.Clave == request.Clave);

            if (user != null) {
                
                var keyBytes = Encoding.ASCII.GetBytes(secretkey);
                //solicitudes de permisos
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Correo));
                claims.AddClaim(new Claim(ClaimTypes.Role, user.Rol));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5), //el tiempo en el que expira el token
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256Signature)
                };

                //Lectura del token
                var tokenHandler = new JwtSecurityTokenHandler();
                //Creacion del token
                var tokenConfig =tokenHandler.CreateToken(tokenDescriptor); 
                //Obtener el token creado
                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                //Retornar el token
                return StatusCode(StatusCodes.Status200OK, new {token = tokenCreado});
            }
            else
            {
                //Si el usuario no está autenticado, muestra que no está autorizado
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }

        [HttpPost]
        [Route("registrarUsuario")]
        public IActionResult Registrar([FromBody] Usuario request)
        {
            //Validar si el usuario existe
            var existingUser = Usuarios.SingleOrDefault(u => u.Correo == request.Correo);
            if (existingUser != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new { message = "El usuario ya existe." });
            }
            //Agregar nuevo usuario
            Usuarios.Add(request);

            return StatusCode(StatusCodes.Status201Created, new { message = "Usuario registrado con éxito." });
        }

    }
}
