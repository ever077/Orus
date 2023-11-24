USE [master]
/****** Object:  Database [ORUS]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  Table [dbo].[Asistencia]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  Table [dbo].[Cargo]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  Table [dbo].[Modulo]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  Table [dbo].[Permiso]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  Table [dbo].[Personal]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[buscar_asistencia_id]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[buscar_cargo]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[buscar_personal]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[buscar_personal_identidad]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[confirmar_salida_asistencia]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[editar_cargo]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[editar_personal]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[eliminar_permiso]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[eliminar_personal]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[insertar_asistencia]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[insertar_cargo]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[insertar_permiso]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[insertar_personal]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[insertar_usuario]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[mostrar_permiso]    Script Date: 29/09/2023 22:25:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_permiso]
@Id_usuario int
as
SELECT Id_modulo FROM Permiso WHERE Id_usuario=@Id_usuario
GO
/****** Object:  StoredProcedure [dbo].[mostrar_personal]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[obtener_id_usuario]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[restaurar_personal]    Script Date: 29/09/2023 22:25:32 ******/
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
/****** Object:  StoredProcedure [dbo].[validar_usuario]    Script Date: 29/09/2023 22:25:32 ******/
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
