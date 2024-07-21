INSERT INTO Departamentos (Id, Nombre, Ubicacion)
VALUES
(1, 'Recursos Humanos', 'Edificio A'),
(2, 'Tecnología', 'Edificio B'),
(3, 'Marketing', 'Edificio C');

INSERT INTO Proyectos (Id, Nombre, Descripcion, FechaInicio, FechaFin)
VALUES
(1, 'Desarrollo de Aplicación', 'Desarrollo de una nueva aplicación móvil', '2024-01-01', '2024-12-31'),
(2, 'Campaña Publicitaria', 'Campaña para el lanzamiento de un producto', '2024-03-01', '2024-06-30'),
(3, 'Reestructuración de Sistemas', 'Actualización de sistemas internos', '2024-05-01', '2024-11-30');

INSERT INTO Empleados (Id, Nombre, PosicionActual, Salario, IdDepartamento)
VALUES
(1, 'Juan Pérez', 'Desarrollador', 50000, 2),
(2, 'Ana Gómez', 'Analista de Marketing', 45000, 3),
(3, 'Luis Fernández', 'Especialista en Recursos Humanos', 47000, 1),
(4, 'María López', 'Contadora', 48000, 1),
(5, 'Pedro Martínez', 'Asistente Administrativo', 40000, 2);

INSERT INTO HistorialPosiciones (Id, IdEmpleado, Posicion, FechaInicio, FechaFin)
VALUES
(1, 1, 'Junior Developer', '2023-01-01', '2023-12-31'),
(2, 2, 'Coordinador de Marketing', '2023-02-01', '2023-12-31'),
(3, 3, 'Asistente de Recursos Humanos', '2023-01-01', '2023-12-31');

INSERT INTO EmpleadoProyectos (IdEmpleado, IdProyecto, FechaAsignacion)
VALUES
(1, 1, '2024-01-02'),	-- Juan Pérez trabajando en el proyecto 'Desarrollo de Aplicación'
(2, 2, '2024-03-05'),	-- Ana Gómez trabajando en el proyecto 'Campaña Publicitaria'
(4, 3, '2024-05-10'),	-- María López trabajando en el proyecto 'Reestructuración de Sistemas'
(4, 1, '2024-05-10');	-- María López trabajando en el proyecto 'Desarrollo de Aplicación'



