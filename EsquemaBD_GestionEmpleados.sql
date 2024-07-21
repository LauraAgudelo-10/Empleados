---Esquema de base de datos SQL para un sistema de gestión de empleados

CREATE DATABASE GestionEmpleados;

USE GestionEmpleados;

CREATE TABLE Departamentos (
    Id INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Ubicacion NVARCHAR(100) NOT NULL,
	PRIMARY KEY (Id)
);

CREATE TABLE Proyectos (
    Id INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion TEXT,
    FechaInicio DATE NOT NULL,
    FechaFin DATE,
	PRIMARY KEY (Id)
);

CREATE TABLE Empleados (
    Id INT NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    PosicionActual NVARCHAR(100) NOT NULL,
    Salario DECIMAL(10, 2) NOT NULL,
    IdDepartamento INT,
    FOREIGN KEY (IdDepartamento) REFERENCES Departamentos(Id),
	PRIMARY KEY (Id)
);

CREATE TABLE HistorialPosiciones (
    Id INT NOT NULL,
    IdEmpleado INT,
    Posicion NVARCHAR(100) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleados(Id),
	PRIMARY KEY (Id)
);

CREATE TABLE EmpleadoProyectos (
    IdEmpleado INT NOT NULL,
    IdProyecto INT NOT NULL,
    FechaAsignacion DATE NOT NULL,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleados(Id),
    FOREIGN KEY (IdProyecto) REFERENCES Proyectos(Id),
    PRIMARY KEY (IdEmpleado, IdProyecto)
);