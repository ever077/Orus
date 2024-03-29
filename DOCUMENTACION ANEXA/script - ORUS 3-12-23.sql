USE [master]
GO
/****** Object:  Database [ORUS]    Script Date: 03/12/2023 3:13:34 ******/
CREATE DATABASE [ORUS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ORUS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ORUS.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ORUS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ORUS_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ORUS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ORUS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ORUS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ORUS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ORUS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ORUS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ORUS] SET ARITHABORT OFF 
GO
ALTER DATABASE [ORUS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ORUS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ORUS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ORUS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ORUS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ORUS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ORUS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ORUS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ORUS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ORUS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ORUS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ORUS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ORUS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ORUS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ORUS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ORUS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ORUS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ORUS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ORUS] SET  MULTI_USER 
GO
ALTER DATABASE [ORUS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ORUS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ORUS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ORUS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ORUS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ORUS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ORUS] SET QUERY_STORE = ON
GO
ALTER DATABASE [ORUS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ORUS]
GO
/****** Object:  User [orus]    Script Date: 03/12/2023 3:13:34 ******/
CREATE USER [orus] FOR LOGIN [orus] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [orus]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [orus]
GO
/****** Object:  Table [dbo].[Asistencia]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencia](
	[Id_asistencia] [int] IDENTITY(1,1) NOT NULL,
	[Id_personal] [int] NULL,
	[Fecha_entrada] [datetime] NULL,
	[Fecha_salida] [datetime] NULL,
	[Estado] [varchar](50) NULL,
	[Horas] [numeric](18, 2) NULL,
	[Observacion] [varchar](max) NULL,
 CONSTRAINT [PK_Asistencia] PRIMARY KEY CLUSTERED 
(
	[Id_asistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[Id_cargo] [int] IDENTITY(1,1) NOT NULL,
	[Cargo] [varchar](max) NULL,
	[SueldoPorHora] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[Id_cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CopiaBd]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CopiaBd](
	[Id_copia] [int] IDENTITY(1,1) NOT NULL,
	[Ruta] [varchar](max) NOT NULL,
 CONSTRAINT [PK_CopiaBd] PRIMARY KEY CLUSTERED 
(
	[Id_copia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulo]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulo](
	[Id_modulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [varchar](max) NULL,
 CONSTRAINT [PK_Modulo] PRIMARY KEY CLUSTERED 
(
	[Id_modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Id_permiso] [int] IDENTITY(1,1) NOT NULL,
	[Id_modulo] [int] NULL,
	[Id_usuario] [int] NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[Id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[Id_personal] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](max) NULL,
	[Identificacion] [varchar](max) NULL,
	[Pais] [varchar](max) NULL,
	[Id_cargo] [int] NULL,
	[SueldoPorHora] [numeric](18, 2) NULL,
	[Estado] [varchar](max) NULL,
	[Codigo] [varchar](max) NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[Id_personal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NULL,
	[Login] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Icono] [image] NULL,
	[Estado] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_Asistencia_Personal] FOREIGN KEY([Id_personal])
REFERENCES [dbo].[Personal] ([Id_personal])
GO
ALTER TABLE [dbo].[Asistencia] CHECK CONSTRAINT [FK_Asistencia_Personal]
GO
ALTER TABLE [dbo].[Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_Modulo] FOREIGN KEY([Id_modulo])
REFERENCES [dbo].[Modulo] ([Id_modulo])
GO
ALTER TABLE [dbo].[Permiso] CHECK CONSTRAINT [FK_Permiso_Modulo]
GO
ALTER TABLE [dbo].[Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_Usuario] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[Usuario] ([Id_usuario])
GO
ALTER TABLE [dbo].[Permiso] CHECK CONSTRAINT [FK_Permiso_Usuario]
GO
ALTER TABLE [dbo].[Personal]  WITH CHECK ADD  CONSTRAINT [FK_Personal_Cargo] FOREIGN KEY([Id_cargo])
REFERENCES [dbo].[Cargo] ([Id_cargo])
GO
ALTER TABLE [dbo].[Personal] CHECK CONSTRAINT [FK_Personal_Cargo]
GO
/****** Object:  StoredProcedure [dbo].[buscar_asistencia_id]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscar_asistencia_id]
@Id_personal int
as
select * from Asistencia
where Id_personal=@Id_personal and Asistencia.Estado='ENTRADA'

GO
/****** Object:  StoredProcedure [dbo].[buscar_cargo]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscar_cargo]
@Buscador varchar(50)
as
SELECT Id_cargo,Cargo,SueldoPorHora as [Sueldo por hora] FROM Cargo
WHERE Cargo LIKE '%' + @Buscador + '%'

GO
/****** Object:  StoredProcedure [dbo].[buscar_personal]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[buscar_personal]
@Desde as int,
@Hasta as int,
@Buscador varchar(50)
as
Set Nocount On;
Select
Id_personal,Nombres,Identificacion,SueldoPorHora,Cargo,Id_cargo,Estado,Codigo, Pais
from
(Select Id_personal, Nombres, Identificacion, Personal.SueldoPorHora, Cargo.Cargo, Personal.Id_cargo, Estado, Codigo, Pais,
Row_Number() Over(Order by Id_personal) 'Numero_de_fila'
from Personal
inner join Cargo on Cargo.Id_cargo=Personal.Id_cargo) as Paginado
Where (Paginado.Numero_de_fila >= @Desde) and (Paginado.Numero_de_fila <= @Hasta)
and (Nombres + Identificacion Like '%' + @Buscador + '%')

GO
/****** Object:  StoredProcedure [dbo].[buscar_personal_identidad]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscar_personal_identidad]
@Buscador varchar(50)
as
select * from Personal
where Identificacion=@Buscador

GO
/****** Object:  StoredProcedure [dbo].[buscar_personal_nombre]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscar_personal_nombre]
@Buscador as varchar(MAX)
as
select Id_personal, Nombres from Personal
where Nombres LIKE '%' + @Buscador + '%'
GO
/****** Object:  StoredProcedure [dbo].[buscar_usuario_nombre]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscar_usuario_nombre]
@Buscador as varchar(MAX)
as
select * from Usuario
where Nombres LIKE '%' + @Buscador + '%'
or Login LIKE '%' + @Buscador + '%'
GO
/****** Object:  StoredProcedure [dbo].[confirmar_salida_asistencia]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[confirmar_salida_asistencia]
@Id_personal int,
@Fecha_salida datetime,
@Horas numeric(18,2)
as
Update Asistencia
set
Fecha_salida = @Fecha_salida,
Horas = @Horas,
Estado = 'SALIDA'
where Id_personal = @Id_personal and Estado = 'ENTRADA'

GO
/****** Object:  StoredProcedure [dbo].[editar_cargo]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editar_cargo]
@Id_cargo int,
@Cargo varchar(max),
@SueldoPorHora numeric(18,2)
as
if EXISTS (SELECT Cargo FROM Cargo WHERE Cargo = @Cargo AND Id_cargo <> @Id_cargo)
Raiserror ('Ya existe un cargo con este nombre, ingrese otro', 16, 1)
else
UPDATE Cargo set Cargo = @Cargo, SueldoPorHora = @SueldoPorHora
WHERE Id_cargo = @Id_cargo

GO
/****** Object:  StoredProcedure [dbo].[editar_permiso]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editar_permiso]
@Id_modulo int,
@Id_usuario int
as
if NOT EXISTS (SELECT Id_permiso FROM Permiso WHERE Id_modulo=@Id_modulo and Id_usuario=@Id_usuario)
insert into Permiso
values (@Id_modulo, @Id_usuario)
GO
/****** Object:  StoredProcedure [dbo].[editar_personal]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editar_personal]
@Id_personal int,
@Nombres as varchar(max),
@Identificacion as varchar(max),
@Pais as varchar(max),
@Id_cargo as int,
@SueldoPorHora as numeric(18,2)
as
if exists (Select Identificacion from Personal where Identificacion=@Identificacion and Id_personal<>@Id_personal)
Raiserror('Ya existe un registro con esta identificacion',16,1)
else
Update Personal set Nombres=@Nombres, Identificacion=@Identificacion, Pais=@Pais, Id_cargo=@Id_cargo, SueldoPorHora=@SueldoPorHora
where
Id_personal=@Id_personal

GO
/****** Object:  StoredProcedure [dbo].[editar_ruta_copia_bd]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editar_ruta_copia_bd]
@Ruta as varchar(MAX)
as
if @Ruta = ''
RAISERROR ('No se puede ingresar una ruta vacia',16,1)
else
update CopiaBd set Ruta=@Ruta
GO
/****** Object:  StoredProcedure [dbo].[editar_usuario]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editar_usuario]
@Id_usuario as int,
@Nombres as varchar(50),
@Login as varchar(50),
@Password as varchar(50),
@Icono as image
as
if exists (select Usuario.Login from Usuario where @Login=Usuario.Login and @Id_usuario<>Id_usuario)
Raiserror('Ya existe un Usuario con ese Login',16,1)
else
update Usuario set Nombres=@Nombres, Login=@Login, Password=@Password, Icono=@Icono
where Id_usuario=@Id_usuario
GO
/****** Object:  StoredProcedure [dbo].[eliminar_permiso]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminar_permiso]
@Id_usuario int
as
delete from Permiso
where Id_usuario=@Id_usuario

GO
/****** Object:  StoredProcedure [dbo].[eliminar_personal]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminar_personal]
@Id_personal int
as
Update Personal set Estado='ELIMINADO'
where Id_personal = @Id_personal

GO
/****** Object:  StoredProcedure [dbo].[eliminar_usuario]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminar_usuario]
@Id_usuario as int
as
update Usuario set Estado='ELIMINADO'
where @Id_usuario=Id_usuario
GO
/****** Object:  StoredProcedure [dbo].[insertar_asistencia]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertar_asistencia]
@Id_personal int,
@Fecha_entrada datetime,
@Fecha_salida datetime,
@Estado varchar(50),
@Horas numeric(18,2),
@Observacion varchar(MAX)
as
insert into Asistencia
values(@Id_personal, @Fecha_entrada, @Fecha_salida, @Estado, @Horas, @Observacion)

GO
/****** Object:  StoredProcedure [dbo].[insertar_cargo]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertar_cargo]
@Cargo varchar(max),
@SueldoPorHora numeric(18,2)
as
if EXISTS (SELECT Cargo FROM Cargo WHERE Cargo = @Cargo)
Raiserror ('Ya existe un cargo con este nombre, ingrese otro', 16, 1)
else
INSERT INTO Cargo VALUES (@Cargo, @SueldoPorHora)

GO
/****** Object:  StoredProcedure [dbo].[insertar_modulo]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertar_modulo]
@Modulo as varchar(max)
as
insert into Modulo values (@Modulo)
GO
/****** Object:  StoredProcedure [dbo].[insertar_permiso]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertar_permiso]
@Id_modulo int,
@Id_usuario int
as
if EXISTS (SELECT Id_permiso FROM Permiso WHERE Id_modulo=@Id_modulo and Id_usuario=@Id_usuario)
RAISERROR ('Ya existe un registro con ese Permiso, por favor ingrese otro',16,1)
else
insert into Permiso
values (@Id_modulo, @Id_usuario)

GO
/****** Object:  StoredProcedure [dbo].[insertar_personal]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertar_personal]
@Nombres as varchar(max),
@Identificacion as varchar(max),
@Pais as varchar(max),
@Id_cargo as int,
@SueldoPorHora as numeric(18,2)
as
declare @Estado varchar(max)
declare @Codigo varchar(max)
declare @Id_personal int
set @Estado='ACTIVO'
set @Codigo='-'
if Exists(select Identificacion from Personal where Identificacion=@Identificacion)
Raiserror('Ya existe un registro con esta identificacion',16,1)
else
Insert into Personal
values(@Nombres, @Identificacion, @Pais, @Id_cargo, @SueldoPorHora, @Estado, @Codigo)
Select @Id_personal=scope_identity()
Update Personal set Codigo=@Id_personal where Id_personal=@Id_personal

GO
/****** Object:  StoredProcedure [dbo].[insertar_ruta_copia_bd]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertar_ruta_copia_bd]
@Ruta as varchar(MAX)
as
if @Ruta = ''
RAISERROR ('No se puede ingresar una ruta vacia',16,1)
else
insert into CopiaBd values(@Ruta)
GO
/****** Object:  StoredProcedure [dbo].[insertar_usuario]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertar_usuario]
@Nombres varchar(50),
@Login varchar(50),
@Password varchar(50),
@Icono image
as
declare @Estado varchar(50)
set @Estado = 'ACTIVO'
if EXISTS (SELECT Login FROM Usuario WHERE Login=@Login)
RAISERROR ('Ya existe un registro con ese Usuario, por favor ingrese otro',16,1)
else
insert into Usuario
values (@Nombres, @Login, @Password, @Icono, @Estado)

GO
/****** Object:  StoredProcedure [dbo].[mostrar_asistencias_diarias]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrar_asistencias_diarias]
@desde as date,
@hasta as date,
@semana as int
as
SET Language 'Spanish';
select Personal.Nombres, Personal.Identificacion, CONVERT(date, Fecha_salida) as Fecha, SUM(Horas) as Horas, 
@desde as Desde, @hasta as Hasta, DATENAME(WEEKDAY, Fecha_salida) as Dia, @semana as Semana, SueldoPorHora,
Asistencia.Fecha_entrada as Fecha_y_Hora_Entrada, Asistencia.Fecha_salida as Fecha_y_Hora_Salida
from Asistencia inner join Personal on Asistencia.Id_personal = Personal.Id_personal
where Fecha_salida >= @desde and Fecha_salida <= @hasta and Personal.Estado = 'ACTIVO'
group by Personal.Nombres, Personal.Identificacion, CONVERT(date, Fecha_salida), DATENAME(WEEKDAY, Fecha_salida),
SueldoPorHora, Asistencia.Fecha_entrada, Asistencia.Fecha_salida
order by CONVERT(date, Fecha_salida) asc
GO
/****** Object:  StoredProcedure [dbo].[mostrar_asistencias_diarias_id]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrar_asistencias_diarias_id]
@desde as date,
@hasta as date,
@semana as int,
@Id_personal as int
as
SET Language 'Spanish';
select Personal.Nombres, Personal.Identificacion, CONVERT(date, Fecha_salida) as Fecha, SUM(Horas) as Horas, 
@desde as Desde, @hasta as Hasta, DATENAME(WEEKDAY, Fecha_salida) as Dia, @semana as Semana, SueldoPorHora,
Asistencia.Estado, Asistencia.Observacion, Asistencia.Fecha_entrada as Fecha_y_Hora_Entrada,
Asistencia.Fecha_salida as Fecha_y_Hora_Salida
from Asistencia inner join Personal on Asistencia.Id_personal = Personal.Id_personal
where Fecha_salida >= @desde and Fecha_salida <= @hasta and @Id_personal = Asistencia.Id_personal
and Personal.Estado = 'ACTIVO'
group by Personal.Nombres, Personal.Identificacion, CONVERT(date, Fecha_salida), DATENAME(WEEKDAY, Fecha_salida),
SueldoPorHora, Asistencia.Estado, Asistencia.Observacion, Asistencia.Fecha_entrada, Asistencia.Fecha_salida
order by CONVERT(date, Fecha_salida) asc
GO
/****** Object:  StoredProcedure [dbo].[mostrar_nombre_bd]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_nombre_bd]
as
select DB_NAME() as NombreBd
GO
/****** Object:  StoredProcedure [dbo].[mostrar_permiso]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrar_permiso]
@Id_usuario int
as
SELECT Permiso.Id_modulo, Modulo.Modulo FROM Permiso inner join Modulo ON Permiso.Id_modulo=Modulo.Id_modulo
WHERE Id_usuario=@Id_usuario
GO
/****** Object:  StoredProcedure [dbo].[mostrar_personal]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrar_personal]
@Desde as int,
@Hasta as int
as
Set Nocount On;
Select
Id_personal,Nombres,Identificacion,SueldoPorHora,Cargo,Id_cargo,Estado,Codigo,Pais
from
(Select Id_personal, Nombres, Identificacion, Personal.SueldoPorHora, Cargo.Cargo, Personal.Id_cargo, Estado, Codigo, Pais,
Row_Number() Over(Order by Id_personal) 'Numero_de_fila'
from Personal
inner join Cargo on Cargo.Id_cargo=Personal.Id_cargo) as Paginado
Where (Paginado.Numero_de_fila >= @Desde) and (Paginado.Numero_de_fila <= @Hasta)

GO
/****** Object:  StoredProcedure [dbo].[obtener_id_usuario]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[obtener_id_usuario]
@Login varchar(50)
as
select Id_usuario from Usuario
where Login=@Login

GO
/****** Object:  StoredProcedure [dbo].[restaurar_bd]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[restaurar_bd]
@Nombre_bd as varchar(MAX),
@Ruta as varchar(MAX)
as
declare @Db_name as varchar(MAX) = 'N''' + CONVERT(VARCHAR(MAX), @Nombre_bd) + ''''
declare @delete_backuphistory as nvarchar(MAX)
declare @stop_connection as nvarchar(MAX)
declare @delete_db as nvarchar(MAX)
declare @restore_db as nvarchar(MAX)

SET @delete_backuphistory = N'msdb.dbo.sp_delete_database_backuphistory @database_name = ' + @Db_name
EXEC @delete_backuphistory

SET @stop_connection = N'ALTER DATABASE ' + @Nombre_bd + N' SET SINGLE_USER WITH ROLLBACK IMMEDIATE'
EXEC @stop_connection

SET @delete_db = N'DROP DATABASE ' + @Nombre_bd
EXEC @delete_db

SET @restore_db = N'RESTORE DATABASE ' + @Nombre_bd + N' FROM DISK = ' + @Ruta + N' WITH FILE = 1, NOUNLOAD, STATS = 10, RECOVERY'
EXEC @restore_db
GO
/****** Object:  StoredProcedure [dbo].[restaurar_personal]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[restaurar_personal]
@Id_personal as int
as
update Personal
set Estado = 'ACTIVO'
where Id_personal = @Id_personal

GO
/****** Object:  StoredProcedure [dbo].[restaurar_usuario]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[restaurar_usuario]
@Id_usuario as int
as
update Usuario
set Estado = 'ACTIVO'
where Id_usuario = @Id_usuario
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_copia_bd]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_insertar_copia_bd]
@Nombre_bd as varchar(MAX),
@Sub_carpeta as varchar(MAX),
@Nombre_respaldo as varchar(MAX)
as
SET NOCOUNT ON
DECLARE @Ruta as varchar(MAX),
@BdName as varchar(MAX)
SET @Ruta = '''' + CONVERT(VARCHAR(MAX), @Sub_carpeta) + '\' + CONVERT(VARCHAR(MAX), @Nombre_respaldo) + ''''
SET @BdName = CONVERT(VARCHAR(MAX), @Nombre_bd)
EXEC ('BACKUP DATABASE ' + @BdName + ' TO DISK = ' + @Ruta)
GO
/****** Object:  StoredProcedure [dbo].[validar_usuario]    Script Date: 03/12/2023 3:13:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[validar_usuario]
@Password varchar(50),
@Login varchar(50)
as
select * from Usuario
where Password = @Password and Login = @Login and Estado = 'ACTIVO'

GO
USE [master]
GO
ALTER DATABASE [ORUS] SET  READ_WRITE 
GO
