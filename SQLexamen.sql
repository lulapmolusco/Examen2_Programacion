CREATE DATABASE REPARACIONESTECNICAS
GO
 
USE ReparacionesTecnicas
GO
 
CREATE TABLE Tecnicos
(
	IDtecnico int identity(1,1) PRIMARY KEY,
    Nombre varchar(50),
	Especialidad varchar(50)
)
 
GO

CREATE TABLE Usuarios
(
    IDusuario int identity(1,1) PRIMARY KEY,
    Nombre varchar(50) NOT NULL,
	Telefono varchar(15) CONSTRAINT UQ_Telefono UNIQUE (Telefono),
    CorreoE varchar(50),
)
 
GO

CREATE TABLE Asignaciones
(
	IDasignaciones int identity(1,1) PRIMARY KEY,
	IDtecnico int,
	IDreparacion varchar(50),
	FechaAsignacion datetime CONSTRAINT df_FechaAsignacion DEFAULT GETDATE(),
	FOREIGN KEY (IDtecnico) REFERENCES Tecnicos(IDtecnico)
)
 
GO
 
CREATE TABLE Equipo
(
    IDequipo int identity(1,1) PRIMARY KEY,
    TipoEquipo varchar(50) NOT NULL,
    Modelo varchar(50),
    IDusuario int,
    FOREIGN KEY (IDusuario) REFERENCES Usuarios(IDusuario)
)
 
GO
 
CREATE TABLE Reparaciones
(
    IDReparaciones int identity(1,1) PRIMARY KEY,
    IDequipo int,
    FOREIGN KEY (IDequipo) REFERENCES Equipo(IDequipo),
    FechaSolicitud datetime CONSTRAINT df_FechaSolicitud DEFAULT GETDATE(),
    Estado char(1),
    IDasignacion int,
    FOREIGN KEY (IDasignacion) REFERENCES Asignaciones(IDasignaciones)
)
 
GO
 
CREATE TABLE DetallesReparaciones
(
    IDdetallesReparacion int identity(1,1) PRIMARY KEY,
    IDreparacion int,
    FOREIGN KEY (IDreparacion) REFERENCES Reparaciones(IDreparaciones),
    Descripcion varchar(50),
    FechaInicio datetime CONSTRAINT df_FechaInicio DEFAULT GETDATE(),
    FechaFin datetime CONSTRAINT df_FechaFin DEFAULT GETDATE()
)
 
GO
  
INSERT INTO Tecnicos(Nombre, Especialidad) VALUES 
('Pablo', 'Soporte en Telecomunicaciones'), 
('Lucas', 'Soporte al Cliente')
GO
 
INSERT INTO Usuarios(Nombre, CorreoE, Telefono) VALUES 
('Karla', ' karlarodri@gmail.com', '89607415'), 
('David', 'davidaguero@gmail.com', '88705694'), 
('Carlos', 'caloperez@gmail.com', '60302565')
GO
  
INSERT INTO Equipo(TipoEquipo, Modelo, IDusuario) VALUES
('Router', 'ASUS RT-AC68U', 1),
('Impresora', 'HP LaserJet Pro', 2),
('Celular', 'Samsung Galaxy S22', 3)
GO
 
INSERT INTO Reparaciones(IDequipo, Estado) VALUES
(1, 'a'),
(2, 'b'),
(3, 'c')
GO
 
INSERT INTO Asignaciones(IDreparacion, IDtecnico) VALUES
(1, 1),
(2, 2),
(3, 3)
GO
 
INSERT INTO DetallesReparaciones (IDreparacion, Descripcion) VALUES
(1, 'Desconectar el cable de alimentación del router y esperar al menos 10 segundos antes de volver a conectarlo.'),
(2, 'Verificar si los cartuchos de tinta o tóner tienen suficiente tinta o tóner.'),
(3, 'Sustitución de la batería.')
GO
 
CREATE PROCEDURE CONSULTAR_USUARIOS
AS
	BEGIN
		SELECT * FROM Usuarios
	END
GO
 
CREATE PROCEDURE CONSULTAR_USUARIOS_ID
@ID INT
AS
	BEGIN
		SELECT * FROM Usuarios WHERE IDusuario = @ID
	END
GO
 
CREATE PROCEDURE BORRAR_USUARIOS_ID
@ID INT
AS
	BEGIN
		DELETE Usuarios WHERE IDusuario = @ID
	END
GO
 
CREATE PROCEDURE INSERTAR_USUARIO
@NOMBRE VARCHAR(50),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
	BEGIN
		INSERT INTO Usuarios(Nombre, CorreoE, Telefono) VALUES (@NOMBRE, @CORREO, @TELEFONO)
	END
GO
 
CREATE PROCEDURE ACTUALIZAR_USUARIO_ID
@ID INT,
@NOMBRE VARCHAR(50),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
	BEGIN
		UPDATE Usuarios SET Nombre = @NOMBRE, CorreoE = @CORREO, Telefono = @TELEFONO WHERE IDusuario = @ID
	END
GO
 
CREATE PROCEDURE CONSULTAR_TECNICOS
AS
	BEGIN
		SELECT * FROM Tecnicos
	END
GO
 
CREATE PROCEDURE CONSULTAR_TECNICOS_ID
@IDTECNICO INT
AS
	BEGIN
		SELECT * FROM Tecnicos WHERE IDtecnico = @ID
	END
GO
 
CREATE PROCEDURE BORRAR_TECNICOS_ID
@ID INT
AS
	BEGIN
		DELETE Tecnicos WHERE IDtecnico = @ID
	END
GO
 
CREATE PROCEDURE INSERTAR_TECNICO
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
	BEGIN
		INSERT INTO Tecnicos(Nombre, Especialidad) VALUES (@NOMBRE, @ESPECIALIDAD)
	END
GO
 
CREATE PROCEDURE ACTUALIZAR_TECNICO_ID
@ID INT,
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
	BEGIN
		UPDATE Tecnicos SET Nombre = @NOMBRE, Especialidad = @ESPECIALIDAD WHERE IDtecnico = @ID
	END
GO
 
CREATE PROCEDURE CONSULTAR_EQUIPOS
AS
	BEGIN
		SELECT * FROM Equipo
	END
GO
 
CREATE PROCEDURE CONSULTAR_EQUIPOS_ID
@ID INT
AS
	BEGIN
		SELECT * FROM Equipo WHERE IDequipo = @ID
	END
GO
 
CREATE PROCEDURE BORRAR_EQUIPOS_ID
@ID INT
AS
	BEGIN
		DELETE Equipo WHERE IDequipo = @ID
	END
GO
 
CREATE PROCEDURE INSERTAR_EQUIPO
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@IDUSUARIO INT
AS
	BEGIN
		INSERT INTO Equipo(TipoEquipo, Modelo, IDusuario) VALUES (@TIPOEQUIPO, @MODELO, @IDUSUARIO)
	END
GO
 
CREATE PROCEDURE ACTUALIZAR_EQUIPO_ID
@ID INT,
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@IDUSUARIO INT
AS
	BEGIN
		UPDATE Equipo SET TipoEquipo = @TIPOEQUIPO, Modelo = @MODELO, IDusuario = @IDUSUARIO WHERE IDequipo = @ID
	END
GO
