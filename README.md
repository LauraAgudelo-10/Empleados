Este repositorio contiene una solución con tres proyectos diferentes que implementan una aplicación de gestión de empleados. Para su correcto funcionamiento, se detallan los pasos para configurar y ejecutar cada uno de los proyectos.

Tener en cuenta:

•	Se debe tener .NET 8.0

•	Herramienta de línea de comandos de .NET (CLI)

•	Editor de código (Visual Studio, VS Code, etc.)

•	Programa SQL server


 Proyectos:
 
1.	Programación en C

Este proyecto incluye la implementación de una clase Empleado con propiedades y métodos para gestionar empleados y su historial de posiciones.

•	Configuración y ejecución:
-	Clonar el repositorio
-	Restaurar dependencias
-	Compilar el proyecto
-	Ejecutar el proyecto

2.	ASP.NET Core API

Este proyecto proporciona una API Web para gestionar empleados.

•	Configuración y ejecución:
-	Clonar el repositorio
-	Restaurar dependencias
-	Compilar el proyecto
-	Ejecutar el proyecto

•	Endpoints disponibles:
-	GET /api/empleados - Lista todos los empleados
-	GET /api/empleados /{id} - Detalles de un empleado específico
-	POST /api/empleados - Agrega un nuevo empleado
-	PUT /api/empleados /{id} - Actualiza un empleado
-	DELETE /api/empleados /{id} - Elimina un empleado

3.	Autenticación y Autorización

Este proyecto gestiona la autenticación con JWT y la autorización basada en roles, se encuentra en el proyecto de ASP .NET Core API.

•	Configuración y ejecución:
-	Clonar el repositorio
-	Restaurar dependencias
-	Compilar el proyecto
-	Ejecutar el proyecto

•	Endpoints disponibles:
-	Inicio de sesión: /api/Autenticacion/inicioSesion
-	Registro: /api/Autenticacion/registrarUsuario

•	Roles:
-	Admin: Acceso completo a los endpoints de empleados
-	User: Solo puede listar empleados

4.	Base de Datos

Este proyecto incluye la configuración de la base de datos y datos iniciales de un sistema de gestión de empleados.

•	Archivos de configuración:
-	EsquemaBD_GestionEmpleados.sql: Contiene el script para crear la base de datos y las tablas
-	DatosDB_GestionEmpleados.sql: Contiene datos para poblar las tablas

•	Configuración de la base de datos:
-	Ejecutar Scripts: Usar SQL para ejecutar los scripts del archivo “EsquemaBD_GestionEmpleados.sql” para crear la base de datos y las tablas. Luego, ejecutar “DatosDB_GestionEmpleados.sql” para insertar datos iniciales

•	Migraciones con Entity Framework Core:
-	Clonar el repositorio
-	Restaurar dependencias
-	Configurar la cadena de conexión en el archivo appsettings.json en caso de ser necesario
-	Compilar el proyecto
-	Ejecutar el proyecto: Cuando la aplicación esté en ejecución, se abrirá el navegador con una vista y con la información solicitada
