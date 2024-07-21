INSERT INTO Departamentos (Id, Nombre, Ubicacion)
VALUES
(1, 'Recursos Humanos', 'Edificio A'),
(2, 'Tecnolog�a', 'Edificio B'),
(3, 'Marketing', 'Edificio C');

INSERT INTO Proyectos (Id, Nombre, Descripcion, FechaInicio, FechaFin)
VALUES
(1, 'Desarrollo de Aplicaci�n', 'Desarrollo de una nueva aplicaci�n m�vil', '2024-01-01', '2024-12-31'),
(2, 'Campa�a Publicitaria', 'Campa�a para el lanzamiento de un producto', '2024-03-01', '2024-06-30'),
(3, 'Reestructuraci�n de Sistemas', 'Actualizaci�n de sistemas internos', '2024-05-01', '2024-11-30');

INSERT INTO Empleados (Id, Nombre, PosicionActual, Salario, IdDepartamento)
VALUES
(1, 'Juan P�rez', 'Desarrollador', 50000, 2),
(2, 'Ana G�mez', 'Analista de Marketing', 45000, 3),
(3, 'Luis Fern�ndez', 'Especialista en Recursos Humanos', 47000, 1),
(4, 'Mar�a L�pez', 'Contadora', 48000, 1),
(5, 'Pedro Mart�nez', 'Asistente Administrativo', 40000, 2);

INSERT INTO HistorialPosiciones (Id, IdEmpleado, Posicion, FechaInicio, FechaFin)
VALUES
(1, 1, 'Junior Developer', '2023-01-01', '2023-12-31'),
(2, 2, 'Coordinador de Marketing', '2023-02-01', '2023-12-31'),
(3, 3, 'Asistente de Recursos Humanos', '2023-01-01', '2023-12-31');

INSERT INTO EmpleadoProyectos (IdEmpleado, IdProyecto, FechaAsignacion)
VALUES
(1, 1, '2024-01-02'),	-- Juan P�rez trabajando en el proyecto 'Desarrollo de Aplicaci�n'
(2, 2, '2024-03-05'),	-- Ana G�mez trabajando en el proyecto 'Campa�a Publicitaria'
(4, 3, '2024-05-10'),	-- Mar�a L�pez trabajando en el proyecto 'Reestructuraci�n de Sistemas'
(4, 1, '2024-05-10');	-- Mar�a L�pez trabajando en el proyecto 'Desarrollo de Aplicaci�n'



