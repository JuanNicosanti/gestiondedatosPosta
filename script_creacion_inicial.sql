----- Creación de Esquema ------

create schema ROAD_TO_PROYECTO
GO

----- Funciones -----
create function ROAD_TO_PROYECTO.SacarTildes(@Usuario nvarchar(255))
returns nvarchar(255)
as begin
return (replace(replace(replace(replace(replace (@Usuario, 'á', 'a'),'é','e'),'í','i'),'ó','o'),'ú','u'))
end
GO

create function ROAD_TO_PROYECTO.SacarDosPuntos(@DosPuntos nvarchar(255))
returns nvarchar(255)
as begin
return replace(@DosPuntos,':',0)
end
GO

create function ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@NumeroString nvarchar(255))
returns numeric(18,2)
	as begin
		return replace(@NumeroString,',','.')
	end
GO

create function ROAD_TO_PROYECTO.OfertaGanadora(@Publicacion int, @Oferta numeric(18,2) )
returns int 
as begin
IF exists (select Publicacion_Cod from gd_esquema.Maestra where publicacion_cod=@Publicacion group by publicacion_cod having count(*)= 1)
  return 1
ELSE IF (select max(Oferta_Monto) from gd_esquema.Maestra where Publicacion_Cod = @Publicacion) = @Oferta
  return 1
  return 0
  end
 GO

------ Creación de Tablas -----
PRINT 'Creando Tablas...'

--Domicilio
create table ROAD_TO_PROYECTO.Domicilio(
DomiId int identity(1,1) PRIMARY KEY,
Calle nvarchar(100),
Numero numeric(18,0),
Piso numeric(18,0),
Depto nvarchar(50),
CodPostal nvarchar(50),
Localidad nvarchar(100),
Ciudad nvarchar(100)
)
GO

--Usuario
create table ROAD_TO_PROYECTO.Usuario (
Usuario nvarchar(255) PRIMARY KEY,
Contraseña nvarchar(255) NOT NULL,
Mail nvarchar(50),
Habilitado bit default 1,
Nuevo bit default 1,
Reputacion numeric(18,2),
FechaCreacion datetime,
Domicilio int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Domicilio,
LogsFallidos TinyInt default 0
)
GO

--Rubro
create table ROAD_TO_PROYECTO.Rubro(
RubrId int identity(1,1) PRIMARY KEY,
DescripCorta nvarchar(80),
DescripLarga nvarchar(255)
)
GO

--Cliente
create table ROAD_TO_PROYECTO.Cliente (
ClieId int identity(1,1) PRIMARY KEY,
TipoDocumento nvarchar(5),
NroDocumento numeric(18,0),
Apellido nvarchar(255),
Nombres nvarchar(255),
FechaNacimiento datetime,
Telefono numeric(18,0),
CONSTRAINT Cliente_Tipo_Nro_Doc UNIQUE (TipoDocumento, NroDocumento)
)
GO

--Empresa
create table ROAD_TO_PROYECTO.Empresa(
EmprId int identity(1,1) PRIMARY KEY,
RazonSocial nvarchar(255),
CUIT nvarchar(50),
FechaCreacion datetime,
NombreContacto nvarchar(100),
Rubro int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Rubro,
Telefono numeric(18,0),
CONSTRAINT Empresa_Tipo_Nro_Doc UNIQUE (RazonSocial, CUIT)
) 
GO

--Rol
create table ROAD_TO_PROYECTO.Rol(
RolId int identity(1,1) PRIMARY KEY,
Nombre nvarchar(255) NOT NULL,
Habilitado bit default 1
)
GO

--Funciones
create table ROAD_TO_PROYECTO.Funcion(
FuncId int identity(1,1) PRIMARY KEY,
Descripcion nvarchar(255),
Funcion text
)
GO

--Funciones_Por_Rol
create table ROAD_TO_PROYECTO.Funciones_Por_Rol(
RolId int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Rol,
FuncId int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Funcion,
PRIMARY KEY (RolId, FuncId)
)
GO

--Roles_Por_Usuario
create table ROAD_TO_PROYECTO.Roles_Por_Usuario(
UserId nvarchar(255) FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Usuario,
RolId int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Rol,
IdExterno int,
PRIMARY KEY (UserId, RolId)
)
GO

--Visibilidad
create table ROAD_TO_PROYECTO.Visibilidad(
VisiId int PRIMARY KEY,
Descripcion nvarchar(255),
ComiFija numeric (18,2),
ComiVariable numeric (18,2),
ComiEnvio numeric (18,2) default 0
)
GO

--Estado
create table ROAD_TO_PROYECTO.Estado(
EstadoId int identity(1,1) PRIMARY KEY,
Descripcion nvarchar(50)
)
GO

--Tipo_Publicacion
create table ROAD_TO_PROYECTO.Tipo_Publicacion(
TipoPubliId int identity (1,1) PRIMARY KEY,
Descripcion nvarchar(255)
)
GO

--Publicacion
create table ROAD_TO_PROYECTO.Publicacion(
PublId int PRIMARY KEY,
Descipcion nvarchar(255) NOT NULL,
Stock numeric(18,0) NOT NULL,
FechaInicio datetime NOT NULL,
FechaFin datetime NOT NULL,
Precio numeric(18,2) NOT NULL,
Visibilidad int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Visibilidad NOT NULL,
Rubro int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Rubro NOT NULL,
Tipo int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Tipo_Publicacion NOT NULL,
Estado int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Estado NOT NULL,
UserId nvarchar(255) FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Usuario NOT NULL,
EnvioHabilitado int default 0
)
GO

--Transaccion
create table ROAD_TO_PROYECTO.Transaccion(
TranId int identity(1,1) PRIMARY KEY,
TipoTransac nvarchar(50),
Fecha datetime,
Cantidad numeric(18,0),
Monto numeric(18,2),
Ganadora bit,
PubliId int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Publicacion,
ClieId int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Cliente,
ConEnvio bit default 0
)
GO

--Oferta
create table ROAD_TO_PROYECTO.Oferta(
OferId int identity(1,1) PRIMARY KEY,
Monto numeric(18,2),
Ganadora bit default 0,
TranId int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Transaccion
)

GO
--Compra
create table ROAD_TO_PROYECTO.Compra(
CompId int identity(1,1) PRIMARY KEY,
Cantidad numeric(18,0),
TranId int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Transaccion
)
GO


--Calificacion
create table ROAD_TO_PROYECTO.Calificacion(
CaliId int PRIMARY KEY,
TranId int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Transaccion,
CantEstrellas numeric(18,1),
Descipcion nvarchar(255)
)
GO

--Factura
create table ROAD_TO_PROYECTO.Factura(
FactNro numeric(18,0) PRIMARY KEY,
PubliId int FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Publicacion,
Fecha datetime,
Monto numeric(18,2),
FormaPago nvarchar(255),
)
GO

--Item_Factura
create table ROAD_TO_PROYECTO.Item_Factura(
ItemId int identity(1,1) PRIMARY KEY,
FactNro numeric(18,0) FOREIGN KEY REFERENCES ROAD_TO_PROYECTO.Factura,
Cantidad numeric(18,0),
Detalle nvarchar(255),
Monto numeric(18,2)
)
GO

----- Migración de Datos -----
PRINT 'Comenzando Migración de Datos...'

--Domicilios
PRINT 'Migrando Domicilios...'
insert into ROAD_TO_PROYECTO.Domicilio
select publ_empresa_dom_calle, publ_empresa_nro_calle,publ_empresa_piso,publ_empresa_depto,publ_empresa_cod_postal, NULL, NULL
from gd_esquema.Maestra
where publ_empresa_dom_calle is not null
group by publ_empresa_dom_calle, publ_empresa_nro_calle,publ_empresa_piso,publ_empresa_depto,publ_empresa_cod_postal
UNION
select Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal, NULL, NULL
from gd_esquema.Maestra
where Cli_Dom_Calle is not null
group by Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal
GO

--Usuarios 
PRINT 'Asignando Usuarios...'
insert into ROAD_TO_PROYECTO.Usuario
select ROAD_TO_PROYECTO.SacarTildes(LOWER(Cli_Apeliido+RIGHT(Cli_Nombre,1))), SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('SHA2_256', 'password')), 3, 255),Cli_Mail,1,0,NULL,GETDATE() as Fecha, (select DomiId from ROAD_TO_PROYECTO.Domicilio where RTRIM(Calle) like RTRIM(Cli_Dom_Calle) and Numero = Cli_Nro_Calle and Piso = Cli_Piso and Depto = Cli_Depto and CodPostal = Cli_Cod_Postal) as Domicilio, 0 
from gd_esquema.Maestra
where Cli_Apeliido is not null and Cli_Nombre is not null
group by Cli_Apeliido,Cli_Nombre,Cli_Mail,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,cli_depto,Cli_Cod_Postal
UNION
select ROAD_TO_PROYECTO.SacarDosPuntos(LOWER('razonsocial'+RIGHT(publ_empresa_razon_social,2))), SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('SHA2_256', 'password')), 3, 255),publ_empresa_mail,1,0,NULL,getdate(), (select DomiId from ROAD_TO_PROYECTO.Domicilio where RTRIM(Calle) like RTRIM(Publ_Empresa_Dom_Calle) and Numero = Publ_Empresa_Nro_Calle and Piso = Publ_Empresa_Piso and Depto = Publ_Empresa_Depto and CodPostal = Publ_Empresa_Cod_Postal), 0
from gd_esquema.Maestra
where publ_empresa_razon_social is not null
group by publ_empresa_razon_social,publ_empresa_mail, Publ_Empresa_Dom_Calle,Publ_empresa_Nro_Calle,Publ_Empresa_Piso,Publ_Empresa_Depto,Publ_Empresa_Cod_Postal

--Rubros
PRINT 'Migrando Rubros...'
insert into ROAD_TO_PROYECTO.Rubro (DescripLarga)
values ('Sin especificar')
insert into ROAD_TO_PROYECTO.Rubro
select NULL,publicacion_rubro_descripcion
from gd_esquema.Maestra
where publicacion_rubro_descripcion is not null
group by Publicacion_Rubro_Descripcion
GO
  
--Cliente
PRINT 'Migrando Clientes...'
insert into ROAD_TO_PROYECTO.Cliente
select 'DNI', Cli_Dni, Cli_Apeliido, Cli_Nombre, Cli_Fecha_Nac, NULL
from gd_esquema.Maestra
where Cli_Dni is not null
group by Cli_Dni, Cli_Apeliido, Cli_Nombre, Cli_Fecha_Nac
GO

--Empresa
PRINT 'Migrando Empresas...'
insert into ROAD_TO_PROYECTO.Empresa
select Publ_Empresa_Razon_Social, Publ_Empresa_Cuit, Publ_Empresa_Fecha_Creacion, NULL, (select RubrId from ROAD_TO_PROYECTO.Rubro where DescripLarga = 'Sin especificar'), NULL
from gd_esquema.Maestra
where Publ_Empresa_Cuit is not null
group by Publ_Empresa_Razon_Social, Publ_Empresa_Cuit, Publ_Empresa_Fecha_Creacion
order by Publ_Empresa_Razon_Social
GO

--Tal vez pueda determinar el rubro de la empresa segun el rubro de las publicaciones, igual es relativo

--Rol
PRINT 'Creando Roles...'
insert into ROAD_TO_PROYECTO.Rol values('Administrador',1)
insert into ROAD_TO_PROYECTO.Rol values('Cliente',1)
insert into ROAD_TO_PROYECTO.Rol values('Empresa',1)
GO

--Funciones
PRINT 'Creando Funciones...'
insert into ROAD_TO_PROYECTO.Funcion values('ABM Rol','Codigo en C# que habilite esta funcion')
insert into ROAD_TO_PROYECTO.Funcion values('ABM Usuario','Codigo en C# que habilite esta funcion')
insert into ROAD_TO_PROYECTO.Funcion values('ABM Visibilidad','Codigo en C# que habilite esta funcion')
insert into ROAD_TO_PROYECTO.Funcion values('ABM Rubro','Codigo en C# que habilite esta funcion')
insert into ROAD_TO_PROYECTO.Funcion values('Generar Publicación','Codigo en C# que habilite esta funcion')
insert into ROAD_TO_PROYECTO.Funcion values('Comprar/Ofertar','Codigo en C# que habilite esta funcion')
insert into ROAD_TO_PROYECTO.Funcion values('Historial de Cliente','Codigo en C# que habilite esta funcion')
insert into ROAD_TO_PROYECTO.Funcion values('Calificar al Vendedor','Codigo en C# que habilite esta funcion')
insert into ROAD_TO_PROYECTO.Funcion values('Consulta de facturas realizadas al vendedor','Codigo en C# que habilite esta funcion')
insert into ROAD_TO_PROYECTO.Funcion values('Listado Estadístico','Codigo en C# que habilite esta funcion')

--Funciones por rol
PRINT 'Creando Funciones Por Rol...'
insert into ROAD_TO_PROYECTO.Funciones_Por_Rol select RolId,FuncId from ROAD_TO_PROYECTO.Rol,ROAD_TO_PROYECTO.Funcion where Nombre = 'Administrador' and Descripcion in ('ABM Rubro','ABM Rol','ABM Visibilidad','ABM Usuario')
insert into ROAD_TO_PROYECTO.Funciones_Por_Rol select RolId,FuncId from ROAD_TO_PROYECTO.Rol,ROAD_TO_PROYECTO.Funcion where nombre = 'Cliente' and Descripcion in ('Generar Publicación','Comprar/Ofertar','Historial de Cliente','Calificar al Vendedor','Consulta de facturas realizadas al vendedor','Listado Estadístico')
insert into ROAD_TO_PROYECTO.Funciones_Por_Rol select RolId,FuncId from ROAD_TO_PROYECTO.Rol,ROAD_TO_PROYECTO.Funcion where nombre = 'Empresa' and Descripcion in ('Generar Publicación','Consulta de facturas realizadas al vendedor','Listado Estadístico')
--Roles por usuario
PRINT 'Creando Roles por Usuario...'
insert into ROAD_TO_PROYECTO.Roles_Por_Usuario
select ROAD_TO_PROYECTO.SacarTildes(LOWER(Apellido+RIGHT(Nombres,1))), (select RolId from ROAD_TO_PROYECTO.Rol where Nombre = 'Cliente'), ClieId
from ROAD_TO_PROYECTO.Cliente
UNION
select ROAD_TO_PROYECTO.SacarDosPuntos(LOWER('razonsocial'+RIGHT(RazonSocial,2))), (select RolId from ROAD_TO_PROYECTO.Rol where Nombre = 'Empresa'), EmprId
from ROAD_TO_PROYECTO.Empresa
GO

--Visibilidad
PRINT 'Migrando Visibilidades...'
insert into ROAD_TO_PROYECTO.Visibilidad (VisiId, Descripcion, ComiFija, ComiVariable)
select Publicacion_Visibilidad_Cod, Publicacion_Visibilidad_Desc, Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje
from gd_esquema.Maestra
where Publicacion_Visibilidad_Cod is not null
group by publicacion_visibilidad_cod, Publicacion_Visibilidad_Desc, Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje
GO

update ROAD_TO_PROYECTO.Visibilidad
set ComiEnvio = 0.05
where VisiId = 10002 or VisiId = 10003
GO

update ROAD_TO_PROYECTO.Visibilidad
set ComiEnvio = 0.01
where VisiId = 10004 or VisiId = 10005
GO

--Estado
PRINT 'Migrando Estados de publicaciones...'
insert into ROAD_TO_PROYECTO.Estado values('Borrador')
insert into ROAD_TO_PROYECTO.Estado values('Activa')
insert into ROAD_TO_PROYECTO.Estado values('Pausada')
insert into ROAD_TO_PROYECTO.Estado values('Finalizada')
GO

--Tipo_Publicacion
PRINT 'Migrando Tipos de publicaciones...'
insert into ROAD_TO_PROYECTO.Tipo_Publicacion 
select Publicacion_Tipo
from gd_esquema.Maestra
where Publicacion_Tipo is not null
group by Publicacion_Tipo
GO

--Publicacion
PRINT 'Migrando publicaciones...'
insert into ROAD_TO_PROYECTO.Publicacion
select Publicacion_Cod, Publicacion_Descripcion, Publicacion_Stock, Publicacion_Fecha, Publicacion_Fecha_Venc, Publicacion_Precio, Publicacion_Visibilidad_Cod, (select RubrId from ROAD_TO_PROYECTO.Rubro where publicacion_rubro_descripcion = DescripLarga) as Rubro, (select TipoPubliId from ROAD_TO_PROYECTO.Tipo_Publicacion where Publicacion_Tipo = Descripcion) as TipoPublicacion, 4 as Estado, (select Usuario from ROAD_TO_PROYECTO.Usuario where Mail = Publ_Cli_Mail or Mail = Publ_Empresa_Mail) as Usuario, 0
from gd_esquema.Maestra
where Publicacion_Cod is not null
group by Publicacion_Cod, Publicacion_Descripcion, Publicacion_Stock, Publicacion_Fecha, Publicacion_Fecha_Venc, Publicacion_Precio, Publicacion_Visibilidad_Cod, Publicacion_Rubro_Descripcion,Publ_Cli_Mail, Publicacion_Tipo, Publ_Empresa_Mail
GO

--Transaccion
PRINT 'Migrando transacciones...'
insert into ROAD_TO_PROYECTO.Transaccion
select 'Compra', Compra_Fecha, Compra_Cantidad, null, null, Publicacion_Cod, (select ClieId from ROAD_TO_PROYECTO.Cliente where Cli_Dni = NroDocumento), 0
from gd_esquema.Maestra
where Publicacion_Tipo = 'Compra Inmediata' and Compra_Fecha is not null 
group by publicacion_cod, Compra_Fecha, Compra_Cantidad, Cli_Dni
union
select 'Oferta', Oferta_Fecha, 1, Oferta_Monto, 0, Publicacion_Cod, (select ClieId from ROAD_TO_PROYECTO.Cliente where Cli_Dni = NroDocumento), 0
from gd_esquema.Maestra
where Publicacion_Tipo = 'Subasta' and Oferta_Fecha is not null
group by Publicacion_Cod, Oferta_Fecha, Oferta_Monto, Cli_Dni
GO

update t1 set Ganadora = 1
from ROAD_TO_PROYECTO.Transaccion t1
where TipoTransac = 'Oferta' and TranId in (select top 1 t2.TranId 
											from ROAD_TO_PROYECTO.Transaccion t2
											where t2.TipoTransac = 'Oferta' and t1.PubliId = t2.PubliId
											order by t2.PubliId, t2.Monto desc)

insert into ROAD_TO_PROYECTO.Oferta (Monto, Ganadora, TranId)
select Monto, Ganadora, TranId
from ROAD_TO_PROYECTO.Transaccion
where TipoTransac = 'Oferta'
GO

insert into ROAD_TO_PROYECTO.Compra(Cantidad, TranId)
select Cantidad, TranId
from ROAD_TO_PROYECTO.Transaccion
where TipoTransac = 'Compra'
GO

--Calificacion
insert into ROAD_TO_PROYECTO.Calificacion
select Calificacion_Codigo, t.TranId,Calificacion_Cant_Estrellas/2,Calificacion_Descripcion
from gd_esquema.Maestra gd,ROAD_TO_PROYECTO.TRANSACCION t,ROAD_TO_PROYECTO.Cliente c
where t.PubliId = gd.Publicacion_Cod and t.clieid = c.ClieId and c.NroDocumento = gd.Cli_Dni and t.fecha = Compra_Fecha and t.cantidad = Compra_Cantidad and gd.Calificacion_Cant_Estrellas is not null and (t.ganadora = 1 or t.tipotransac = 'Compra') 
GO

ALTER TABLE ROAD_TO_PROYECTO.Transaccion
DROP COLUMN Monto

ALTER TABLE ROAD_TO_PROYECTO.Transaccion
DROP COLUMN Ganadora

ALTER TABLE ROAD_TO_PROYECTO.Transaccion
DROP COLUMN Cantidad

--Factura
insert into ROAD_TO_PROYECTO.Factura
select gd.Factura_Nro,Publicacion_Cod, gd.factura_fecha,gd.factura_total, gd.forma_pago_desc
from gd_esquema.Maestra gd
where  Factura_nro is not null 
group by factura_nro,Factura_Fecha,Factura_Total,Forma_Pago_Desc,Publicacion_Cod
GO

--FUNCIONES PARA MIGRAR ITEMS

create function ROAD_TO_PROYECTO.EspecificarDetalle(@Cantidad numeric(18,0), @Monto numeric(18,2), @PrecioVisibilidad numeric(18,2), @PorcentajeComision numeric(18,2), @PrecioPublicacion numeric(18,2))
returns nvarchar(255)
as begin
if @Monto = @PrecioVisibilidad
return 'Precio por tipo publicación'
else if ROUND(@Monto,0) = ROUND(@PrecioPublicacion * @PorcentajeComision * @Cantidad,0)
 or ROUND(@Monto,0) = ROUND(@PrecioPublicacion * @PorcentajeComision * @Cantidad,0,1)
 or ROUND(@Monto,0,1) = ROUND(@PrecioPublicacion * @PorcentajeComision * @Cantidad,0)
 or ROUND(@Monto,0,1) = ROUND(@PrecioPublicacion * @PorcentajeComision * @Cantidad,0,1)
return 'Comisión por productos vendidos'
return 'Otras Comisiones'
end 
GO

--Item Factura
insert into ROAD_TO_PROYECTO.Item_Factura
select f.FactNro, gd.Item_Factura_Cantidad,ROAD_TO_PROYECTO.EspecificarDetalle(gd.Item_Factura_Cantidad,gd.Item_Factura_Monto,gd.Publicacion_Visibilidad_Precio,gd.Publicacion_Visibilidad_Porcentaje,gd.Publicacion_Precio), gd.Item_Factura_Monto
from gd_esquema.Maestra gd,ROAD_TO_PROYECTO.Factura f
where gd.Factura_Nro is not null and f.FactNro = gd.Factura_Nro and ROAD_TO_PROYECTO.EspecificarDetalle(gd.Item_Factura_Cantidad,gd.Item_Factura_Monto,gd.Publicacion_Visibilidad_Precio,gd.Publicacion_Visibilidad_Porcentaje,gd.Publicacion_Precio) is not null
GO

----- Otras Funciones -----

----- Stored Procedures -----
--Asignar Fecha del archivo de configuración

CREATE PROCEDURE ROAD_TO_PROYECTO.Asignar_Fecha
@Fecha datetime
as begin
	delete from ROAD_TO_PROYECTO.Fecha
	insert into ROAD_TO_PROYECTO.Fecha values (@Fecha)
end
GO

--Listado Roles
CREATE PROCEDURE ROAD_TO_PROYECTO.ListaRoles
	as begin
		select RolId, Nombre, Habilitado 
		from ROAD_TO_PROYECTO.Rol
		order by RolId
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.ListaFunciones
	as begin
		select Descripcion
		from ROAD_TO_PROYECTO.Funcion
		group by Descripcion
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.FuncionesDeUnRol
@Rol int
	as begin
		select ROAD_TO_PROYECTO.Funcion.Descripcion as Descripcion
		from ROAD_TO_PROYECTO.Funciones_Por_Rol join ROAD_TO_PROYECTO.Funcion on ROAD_TO_PROYECTO.Funciones_Por_Rol.FuncId = ROAD_TO_PROYECTO.Funcion.FuncId
		where ROAD_TO_PROYECTO.Funciones_Por_Rol.RolId = @Rol
		group by Descripcion
	end
GO

--Alta Rol
CREATE PROCEDURE ROAD_TO_PROYECTO.AltaRol
@Nombre nvarchar(255)
as begin
	declare @RolId int
	if not exists (select Nombre from ROAD_TO_PROYECTO.Rol where Nombre = @Nombre)
	begin
		insert into ROAD_TO_PROYECTO.Rol values(@Nombre,1)
		select @RolId = SCOPE_IDENTITY()
		return @RolId
	end
end
GO

--Asignar una funcion a un rol
CREATE PROCEDURE ROAD_TO_PROYECTO.AsignarFuncionARol
@RolId int,
--@Rol nvarchar(255),
@Funcion nvarchar(255)
as begin
--declare @RolId int = (select rolid from ROAD_TO_PROYECTO.Rol where Nombre = @Rol)
declare @FuncId int = (select funcid from ROAD_TO_PROYECTO.Funcion where Descripcion = @Funcion)

if not exists(select FuncId from ROAD_TO_PROYECTO.Funciones_Por_Rol where RolId = @RolId and FuncId = @FuncId)
insert into ROAD_TO_PROYECTO.Funciones_Por_Rol values (@RolId,@FuncId)
end
GO

--Desasignar una funcion a un rol
CREATE PROCEDURE ROAD_TO_PROYECTO.DesasignarFuncionARol
@RolId int,
--@Rol nvarchar(255),
@Funcion nvarchar(255)
as begin
--declare @RolId int = (select rolid from ROAD_TO_PROYECTO.Rol where Nombre = @Rol)
declare @FuncId int = (select funcid from ROAD_TO_PROYECTO.Funcion where Descripcion = @Funcion)

if exists(select FuncId from ROAD_TO_PROYECTO.Funciones_Por_Rol where RolId = @RolId and FuncId = @FuncId)
delete ROAD_TO_PROYECTO.Funciones_Por_Rol where FuncId = @FuncId and RolId = @RolId
end
GO 

--Dar de baja un rol
CREATE PROCEDURE ROAD_TO_PROYECTO.BajaRol
@Rol int
as begin
update ROAD_TO_PROYECTO.Rol set Habilitado = 0 where RolId = @Rol
delete ROAD_TO_PROYECTO.Roles_Por_Usuario where RolId = @Rol
end
GO

--Mostrar un Rol en base a un idRol
CREATE PROCEDURE ROAD_TO_PROYECTO.DetalleDeUnRol
@Rol int
as begin
	select Nombre as nombreRol
	from ROAD_TO_PROYECTO.Rol
	where Rol.RolId = @Rol
end
GO

--Mostrar idRol en base a un Rol
CREATE PROCEDURE ROAD_TO_PROYECTO.IdBasadoANombreRol
@Nombre nvarchar(255)
as begin
	select RolId as id
	from ROAD_TO_PROYECTO.Rol
	where Nombre = @Nombre
end
GO

--Habilitar un rol
CREATE PROCEDURE ROAD_TO_PROYECTO.HabilitarRol
@Rol int
as begin
	update ROAD_TO_PROYECTO.Rol set Habilitado = 1 where RolId = @Rol
end
GO



--Modificar Rol
CREATE PROCEDURE ROAD_TO_PROYECTO.Modificacion_Rol
	@RolId int,
	@Nombre nvarchar(255)
	as begin
		update ROAD_TO_PROYECTO.Rol
		set Nombre = @Nombre
		where RolId = @RolId
	end
GO

--Listado Rubros
CREATE PROCEDURE ROAD_TO_PROYECTO.ListaRubros
	as begin
		select DescripLarga
		from ROAD_TO_PROYECTO.Rubro
		order by DescripLarga
	end
GO

--Actualización de los logs fallidos de un usuario
CREATE PROCEDURE ROAD_TO_PROYECTO.Usuario_Logs_Fallidos
	@Usuario nvarchar(255),
	@Contraseña nvarchar(255)
	as
	begin
	if(select habilitado from ROAD_TO_PROYECTO.Usuario where @Usuario = Usuario)=1
	begin
		--Incremento el contrador si no coinciden las contraseñas
		update ROAD_TO_PROYECTO.Usuario set LogsFallidos = LogsFallidos + 1
		where Usuario = @Usuario and Contraseña != @Contraseña
		--Reinicio el contador si coinciden las contraseñas
		update ROAD_TO_PROYECTO.Usuario set LogsFallidos = 0
		where Usuario = @Usuario and Contraseña = @Contraseña
	end
		--Inhabilito a los usuarios con 3 logs fallidos
		update ROAD_TO_PROYECTO.Usuario set Habilitado = 0
		where LogsFallidos = 3
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Usuario_Login
	@username nvarchar(255),
	@password nvarchar(255)
	as
	begin 
		execute ROAD_TO_PROYECTO.Usuario_Logs_Fallidos @Usuario = @username, @Contraseña = @password
		select u.Usuario as username, u.Contraseña as password, u.Habilitado as habilitado, rpu.RolId as rol 
		from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu
		where Usuario = @username and Contraseña = @password
		and u.Usuario = rpu.UserId
		
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Alta_Domicilio
	@Calle nvarchar(100),
	@Numero numeric(18,0),
	@Piso numeric(18,0),
	@Depto nvarchar(50),
	@CodPostal nvarchar(50),
	@Localidad nvarchar(100),
	@Ciudad nvarchar(100)
	as
	begin
		if not exists(select * from ROAD_TO_PROYECTO.Domicilio where @Calle = Calle and @Numero = Numero and @Piso = Piso and @Depto = Depto and @CodPostal = CodPostal and @Localidad = Localidad and @Ciudad = Ciudad)
		insert into ROAD_TO_PROYECTO.Domicilio (Calle, Numero, Piso, Depto, CodPostal, Localidad, Ciudad)
		values (@Calle, @Numero, @Piso, @Depto, @CodPostal, @Localidad, @Ciudad)
	end
GO


CREATE PROCEDURE ROAD_TO_PROYECTO.Alta_Usuario
	@Usuario nvarchar(255),
	@Contraseña nvarchar(255),
	@Mail nvarchar(50),
	@FechaActual datetime
	as
	begin
		if(not exists(select u.Usuario from ROAD_TO_PROYECTO.Usuario u where u.Usuario = @Usuario))
		begin
			insert into ROAD_TO_PROYECTO.Usuario (Usuario, Contraseña, Mail, Habilitado, Nuevo, Reputacion, FechaCreacion,/*Domicilio,*/ LogsFallidos)
			values (@Usuario, @Contraseña, @Mail, 1, 1, null, @FechaActual, 0)
		end
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Alta_Rol_Usuario
	@Usuario nvarchar(255),
	@RolAsignado nvarchar(255),
	@IdExterno int

	as
	begin
		if not exists(select rpu.UserId,rpu.RolId from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu where rpu.UserId = @Usuario and rpu.RolId = (select RolId from ROAD_TO_PROYECTO.Rol r where r.Nombre = @RolAsignado))
		begin
			insert into ROAD_TO_PROYECTO.Roles_Por_Usuario (UserId, RolId, IdExterno)
			values (@Usuario, (select RolId from ROAD_TO_PROYECTO.Rol r where r.Nombre = @RolAsignado), @IdExterno)
		end					
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Domicilio_Usuario
	@Usuario nvarchar(255),
	@Calle nvarchar(100),
	@Numero numeric(18,0),
	@Piso numeric(18,0),
	@Depto nvarchar(50),
	@CodPostal nvarchar(50),
	@Localidad nvarchar(100),
	@Ciudad nvarchar(100)
	as
	begin
		execute ROAD_TO_PROYECTO.Alta_Domicilio @Calle = @Calle, @Numero = @Numero, @Piso = @Piso, @Depto = @Depto, @CodPostal = @CodPostal, @Localidad = @Localidad, @Ciudad = @Ciudad
		update ROAD_TO_PROYECTO.Usuario 
		set Domicilio = (select DomiId from ROAD_TO_PROYECTO.Domicilio
						where Calle = @Calle and Numero = @Numero and Piso = @Piso and Depto = @Depto and CodPostal = @CodPostal and Localidad = @Localidad and Ciudad = @Ciudad)
		where Usuario = @Usuario
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Alta_Cliente
	@Usuario nvarchar(255),
	@Contraseña nvarchar(255),
	@Mail nvarchar(50),
	@RolAsignado nvarchar(255),
	@TipoDocumento nvarchar(5),
	@NroDocumento numeric(18,0),
	@Apellido nvarchar(255),
	@Nombres nvarchar(255),
	@FechaNacimiento datetime,
	@Telefono numeric(18,0),
	@FechaActual datetime,

	@Calle nvarchar(100),
	@Numero numeric(18,0),
	@Piso numeric(18,0),
	@Depto nvarchar(50),
	@CodPostal nvarchar(50),
	@Localidad nvarchar(100)

	as
	begin
		declare	@IdExterno int, @Ciudad nvarchar(100)		
		if(@RolAsignado = 'Cliente')
		begin
			if not exists(select c.NroDocumento from ROAD_TO_PROYECTO.Cliente c where c.TipoDocumento = @TipoDocumento and c.NroDocumento = @NroDocumento)
			begin
				execute ROAD_TO_PROYECTO.Alta_Usuario @Usuario = @Usuario, @Contraseña = @Contraseña, @Mail = @Mail, @FechaActual = @FechaActual
									
				insert into ROAD_TO_PROYECTO.Cliente (TipoDocumento, NroDocumento, Apellido, Nombres, FechaNacimiento, Telefono)
				values (@TipoDocumento, @NroDocumento, @Apellido, @Nombres, @FechaNacimiento, @Telefono)
			
				select @IdExterno = SCOPE_IDENTITY()
				execute ROAD_TO_PROYECTO.Alta_Rol_Usuario @Usuario = @Usuario, @RolAsignado = @RolAsignado, @IdExterno = @IdExterno
				execute ROAD_TO_PROYECTO.Domicilio_Usuario @Usuario = @Usuario, @Calle = @Calle, @Numero = @Numero, @Piso = @Piso, @Depto = @Depto, @CodPostal = @CodPostal, @Localidad = @Localidad, @Ciudad = @Ciudad
			end
		end
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Alta_Empresa
	@Usuario nvarchar(255),
	@Contraseña nvarchar(255),
	@Mail nvarchar(50),
	@RolAsignado nvarchar(255),
	@RazonSocial nvarchar(255),
	@CUIT nvarchar(50),
	@FechaCreacion datetime,
	@NombreContacto nvarchar(100),
	@Rubro nvarchar(255),
	@Telefono numeric(18,0),
	@FechaActual datetime,

	@Calle nvarchar(100),
	@Numero numeric(18,0),
	@Piso numeric(18,0),
	@Depto nvarchar(50),
	@CodPostal nvarchar(50),
	@Localidad nvarchar(100),
	@Ciudad nvarchar(100)

	as
	begin
		declare	@IdExterno int

		if(@RolAsignado = 'Empresa')
		begin
			if not exists(select e.EmprId from ROAD_TO_PROYECTO.Empresa e where e.CUIT = @CUIT and e.RazonSocial = @RazonSocial)
			begin
				execute ROAD_TO_PROYECTO.Alta_Usuario @Usuario = @Usuario, @Contraseña = @Contraseña, @Mail = @Mail, @FechaActual = @FechaActual
				
				insert into ROAD_TO_PROYECTO.Empresa (RazonSocial, CUIT, FechaCreacion, NombreContacto, Rubro, Telefono)
				values (@RazonSocial, @CUIT, @FechaCreacion, @NombreContacto, (select RubrId from ROAD_TO_PROYECTO.Rubro r where r.DescripLarga = @Rubro), @Telefono)
			
				select @IdExterno = SCOPE_IDENTITY()
				execute ROAD_TO_PROYECTO.Alta_Rol_Usuario @Usuario = @Usuario, @RolAsignado = @RolAsignado, @IdExterno = @IdExterno
				execute ROAD_TO_PROYECTO.Domicilio_Usuario @Usuario = @Usuario, @Calle = @Calle, @Numero = @Numero, @Piso = @Piso, @Depto = @Depto, @CodPostal = @CodPostal, @Localidad = @Localidad, @Ciudad = @Ciudad
			end
		end
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Modificacion_Usuario
	@Usuario nvarchar(255),
	@Contraseña nvarchar(255),
	@Mail nvarchar(50)
	as
	begin
		update ROAD_TO_PROYECTO.Usuario
		set Contraseña = @Contraseña, Mail = @Mail
		where Usuario = @Usuario
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Modificacion_Cliente
	@Usuario nvarchar(255),
	@Contraseña nvarchar(255),
	@Mail nvarchar(50),
	@RolAsignado nvarchar(255),
	@TipoDocumento nvarchar(5),
	@NroDocumento numeric(18,0),
	@Apellido nvarchar(255),
	@Nombres nvarchar(255),
	@FechaNacimiento datetime,
	@Telefono numeric(18,0),

	@Calle nvarchar(100),
	@Numero numeric(18,0),
	@Piso numeric(18,0),
	@Depto nvarchar(50),
	@CodPostal nvarchar(50),
	@Localidad nvarchar(100)

	as
	begin
		declare @Ciudad nvarchar(100)
		if(@RolAsignado = 'Cliente')
		begin
			execute ROAD_TO_PROYECTO.Modificacion_Usuario @Usuario = @Usuario, @Contraseña = @Contraseña, @Mail = @Mail
									
			update ROAD_TO_PROYECTO.Cliente 
			set TipoDocumento = @TipoDocumento, NroDocumento = @NroDocumento, Apellido = @Apellido, Nombres = @Nombres, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono
			where ClieId = (select IdExterno from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r where rpu.UserId = @Usuario and rpu.RolId = r.RolId and r.Nombre = 'Cliente')
			
			execute ROAD_TO_PROYECTO.Domicilio_Usuario @Usuario = @Usuario, @Calle = @Calle, @Numero = @Numero, @Piso = @Piso, @Depto = @Depto, @CodPostal = @CodPostal, @Localidad = @Localidad, @Ciudad = @Ciudad
		end
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Modificacion_Empresa
	@Usuario nvarchar(255),
	@Contraseña nvarchar(255),
	@Mail nvarchar(50),
	@RolAsignado nvarchar(255),
	@RazonSocial nvarchar(255),
	@CUIT nvarchar(50),
	@FechaCreacion datetime,
	@NombreContacto nvarchar(100),
	@Rubro nvarchar(255),
	@Telefono numeric(18,0),

	@Calle nvarchar(100),
	@Numero numeric(18,0),
	@Piso numeric(18,0),
	@Depto nvarchar(50),
	@CodPostal nvarchar(50),
	@Localidad nvarchar(100),
	@Ciudad nvarchar(100)

	as
	begin
		if(@RolAsignado = 'Empresa')
		begin
			execute ROAD_TO_PROYECTO.Modificacion_Usuario @Usuario = @Usuario, @Contraseña = @Contraseña, @Mail = @Mail
				
			update ROAD_TO_PROYECTO.Empresa 
			set RazonSocial = @RazonSocial, CUIT = @CUIT, FechaCreacion = @FechaCreacion, NombreContacto = @NombreContacto, Rubro = (select RubrId from ROAD_TO_PROYECTO.Rubro r where r.DescripLarga = @Rubro), Telefono = @Telefono
			where EmprId = (select IdExterno from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r where rpu.UserId = @Usuario and rpu.RolId = r.RolId and r.Nombre = 'Empresa')

			execute ROAD_TO_PROYECTO.Domicilio_Usuario @Usuario = @Usuario, @Calle = @Calle, @Numero = @Numero, @Piso = @Piso, @Depto = @Depto, @CodPostal = @CodPostal, @Localidad = @Localidad, @Ciudad = @Ciudad

		end
	end
GO


CREATE PROCEDURE ROAD_TO_PROYECTO.Cambiar_Contraseña
	@Usuario nvarchar(255),
	@Contraseña nvarchar(255),
	@ContraseñaNueva nvarchar(255)
	as
	begin
		if exists(select Usuario,Contraseña from ROAD_TO_PROYECTO.Usuario where @Usuario = Usuario and @Contraseña = Contraseña)
		begin
			update ROAD_TO_PROYECTO.Usuario set Contraseña = @ContraseñaNueva
			where @Usuario = Usuario
		end
	end
GO

--Busqueda de un cliente según parámetros
CREATE PROCEDURE ROAD_TO_PROYECTO.Buscar_Cliente
	@Mail nvarchar(50),
	@NroDocumento numeric(18,0),
	@Apellido nvarchar(255),
	@Nombres nvarchar(255)
	as
	begin
		--update u set Habilitado = 0
		select u.Usuario, u.Mail, c.TipoDocumento, c.NroDocumento, c.Apellido, c.Nombres
		from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Cliente c, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu
		where rpu.UserId = u.Usuario and rpu.RolId = (select RolId from ROAD_TO_PROYECTO.Rol r where r.Nombre = 'Cliente') and rpu.IdExterno = c.ClieId
		and c.Nombres like '%' + @Nombres +'%'
		and c.Apellido like '%' + @Apellido +'%'
		and c.TipoDocumento = 'DNI'
		and (c.NroDocumento = @NroDocumento or @NroDocumento is null)
        and u.Mail like '%' + @Mail +'%'
	end
GO

--Busqueda de una empresa según parámetros
CREATE PROCEDURE ROAD_TO_PROYECTO.Buscar_Empresa
	@RazonSocial nvarchar(255),
	@CUIT nvarchar(50),
	@Mail nvarchar(50)
	as
	begin
		--update u set Habilitado = 0
		select u.Usuario, u.Mail, e.RazonSocial, e.CUIT
		from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Empresa e, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu
		where rpu.UserId = u.Usuario and rpu.RolId = (select RolId from ROAD_TO_PROYECTO.Rol r where r.Nombre = 'Empresa') and rpu.IdExterno = e.EmprId
		and e.RazonSocial like '%'+ @RazonSocial +'%'
		and (e.CUIT = @CUIT or @CUIT is null)
		and u.Mail like '%'+ @Mail +'%'
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Baja_Usuario
	@Usuario nvarchar(255)
	as
	begin
		update u set Habilitado = 0
		from ROAD_TO_PROYECTO.Usuario u
		where u.Usuario = @Usuario
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Comisiones_Visibilidad
	@UserId nvarchar(255)
	as
	begin
		declare @cantPubli int
		select @cantPubli = COUNT(*)
		from ROAD_TO_PROYECTO.Publicacion
		where UserId = @UserId
		if(@cantPubli = 0)
		begin
			select Descripcion
			from ROAD_TO_PROYECTO.Visibilidad
			order by Descripcion
		end
		if(@cantPubli > 0)
		begin
			select Descripcion
			from ROAD_TO_PROYECTO.Visibilidad
			where Descripcion != 'Gratis'
			order by Descripcion
		end
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Comisiones_Valores
	@Visibilidad nvarchar(255)
	as
	begin
		select ComiFija, ComiVariable, ComiEnvio from ROAD_TO_PROYECTO.Visibilidad where Descripcion = @Visibilidad
	end
GO

--Alta de una publicación, las publicaciones recién creadas se suponen como Borrador hasta ser activadas por el vendedor
CREATE PROCEDURE ROAD_TO_PROYECTO.Alta_Publicacion
	@Descipcion nvarchar(255),
	@Stock numeric(18,0),
	@FechaInicio datetime,
	@FechaFin datetime,
	@PrecioString nvarchar(255),
	@VisiDesc nvarchar(255),
	@RubroDesc nvarchar(255),
	@TipoDesc nvarchar(255),
	@EstadoDesc nvarchar(50),
	@VendedorId nvarchar(255),
	@EnvioHabilitado int	

	as begin
		declare @VisiId int, @RubroId int, @TipoPubliId int, @EstadoId int, @PubliIdAnterior int, @PubliId int, @Precio numeric(18,2)
		set @Precio = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@PrecioString)		
		select @VisiId = VisiId from ROAD_TO_PROYECTO.Visibilidad where Descripcion = @VisiDesc
		select @RubroId = RubrId from ROAD_TO_PROYECTO.Rubro where DescripLarga = @RubroDesc
		select @TipoPubliId = TipoPubliId from ROAD_TO_PROYECTO.Tipo_Publicacion where Descripcion = @TipoDesc
		select @EstadoId = EstadoId from ROAD_TO_PROYECTO.Estado where Descripcion = @EstadoDesc
		select top 1 @PubliIdAnterior = PublId from ROAD_TO_PROYECTO.Publicacion order by PublId desc
		set @PubliId = @PubliIdAnterior +1

		insert into ROAD_TO_PROYECTO.Publicacion (PublId, Descipcion, Stock, FechaInicio, FechaFin, Precio, Visibilidad, Rubro, Tipo, Estado, UserId, EnvioHabilitado)
		values(@PubliId, @Descipcion, @Stock, @FechaInicio, @FechaFin, @Precio, @VisiId, @RubroId, @TipoPubliId, @EstadoId, @VendedorId, @EnvioHabilitado)
	end
GO

--Modificación de una publicación en estado Borrador
CREATE PROCEDURE ROAD_TO_PROYECTO.Modificacion_Publicacion
	@PubliId int,
	@Descipcion nvarchar(255),
	@Stock numeric(18,0),
	@FechaInicio datetime,
	@FechaFin datetime,
	@PrecioString nvarchar(255),
	@VisiDesc nvarchar(255),
	@RubroDesc nvarchar(255),
	@TipoDesc nvarchar(255),
	@VendedorId nvarchar(255),
	@EnvioHabilitado int	

	as begin
		declare @VisiId int, @RubroId int, @TipoPubliId int, @EstadoId int, @Precio numeric(18,2)		
		select @EstadoId = EstadoId from ROAD_TO_PROYECTO.Estado where Descripcion = 'Borrador'
		set @Precio = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@PrecioString)
		if((select Estado from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId) = @EstadoId)
		begin
			select @VisiId = VisiId from ROAD_TO_PROYECTO.Visibilidad where Descripcion = @VisiDesc
			select @RubroId = RubrId from ROAD_TO_PROYECTO.Rubro where DescripLarga = @RubroDesc
			select @TipoPubliId = TipoPubliId from ROAD_TO_PROYECTO.Tipo_Publicacion where Descripcion = @TipoDesc

			update ROAD_TO_PROYECTO.Publicacion 
			set PublId = @PubliId, Descipcion = @Descipcion, Stock = @Stock, 
			FechaInicio = @FechaInicio, FechaFin = @FechaFin,
			Precio = @Precio, Visibilidad = @VisiId, Rubro = @RubroId, Tipo = @TipoPubliId, EnvioHabilitado = @EnvioHabilitado
			where PublId = @PubliId
		end
	end
GO

--Cambio de estado de una publicacion
CREATE PROCEDURE ROAD_TO_PROYECTO.Activar_Publicacion
	@PubliId int
	as begin
		declare @EstadoId int
		select @EstadoId = EstadoId from ROAD_TO_PROYECTO.Estado where Descripcion = 'Activa'
		update ROAD_TO_PROYECTO.Publicacion
		set Estado = @EstadoId
		where PublId = @PubliId
	end
GO

--Facturacion inicial de una publicacion, se cobra la comisión inicial por tipo de publicacion siempre y cuando no sea una publicación gratuita
CREATE PROCEDURE ROAD_TO_PROYECTO.Facturar_Publicacion
	@PublId int
	as begin
		if((select ComiFija from ROAD_TO_PROYECTO.Visibilidad v, ROAD_TO_PROYECTO.Publicacion p where p.PublId = @PublId and p.Visibilidad = v.VisiId) != 0) 
		begin
		declare @UltimaFactura int, @FacturaActual int

		select top 1 @UltimaFactura = FactNro from ROAD_TO_PROYECTO.Factura order by FactNro desc
		set @FacturaActual = @UltimaFactura + 1

		insert into ROAD_TO_PROYECTO.Factura (FactNro, PubliId, Fecha)--, Monto, FormaPago) 
		values(@FacturaActual, @PublId, (select FechaInicio from ROAD_TO_PROYECTO.Publicacion where PublId = @PublId))

		insert into ROAD_TO_PROYECTO.Item_Factura (FactNro, Cantidad, Detalle, Monto) 
		values (@FacturaActual, 1, 'Precio por tipo publicación', (select ComiFija from ROAD_TO_PROYECTO.Visibilidad v, ROAD_TO_PROYECTO.Publicacion p where p.PublId = @PublId and p.Visibilidad = v.VisiId))

		update ROAD_TO_PROYECTO.Factura
		set Monto = (select sum(Monto) from ROAD_TO_PROYECTO.Item_Factura where FactNro = @FacturaActual)
		where FactNro = @FacturaActual

		end
	end
GO

--Cambio de estado de una publicacion
CREATE PROCEDURE ROAD_TO_PROYECTO.Pausar_Publicacion
	@PubliId int
	as begin
	declare @EstadoId int
	select @EstadoId = EstadoId from ROAD_TO_PROYECTO.Estado where Descripcion = 'Pausada'
		update ROAD_TO_PROYECTO.Publicacion
		set Estado = @EstadoId
		where PublId = @PubliId
	end
GO

--Cambio de estado de una publicacion
CREATE PROCEDURE ROAD_TO_PROYECTO.Finalizar_Publicacion
	@PubliId int
	as begin
		declare @EstadoId int
		select @EstadoId = EstadoId from ROAD_TO_PROYECTO.Estado where Descripcion = 'Finalizada'
		if exists (select * from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId and Estado <> @EstadoId)
		begin
			update ROAD_TO_PROYECTO.Publicacion
			set Estado = @EstadoId
			where PublId = @PubliId
		end
	end
GO

--Compra en una compra inmediata
CREATE PROCEDURE ROAD_TO_PROYECTO.Comprar_Publicacion
	@PubliId int,
	@FechaActual datetime,
	@Cantidad numeric(18,0),
	@Usuario nvarchar(255),
	@ConEnvio bit
	as begin
		declare @TranId int
		if(@Usuario <> (select UserId from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId))
		begin
		declare @CompradorId int 
		set @CompradorId = (select rpu.IdExterno from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r where @Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente')
		--Verific si la cantidad a comprar es menor que el stock disponible
		if((select Stock from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId) >= @Cantidad)
		begin
			insert into ROAD_TO_PROYECTO.Transaccion(Fecha, PubliId, ClieId, ConEnvio)
			values(@FechaActual, @PubliId, @CompradorId, @ConEnvio)
			select @TranId = SCOPE_IDENTITY()
			insert into ROAD_TO_PROYECTO.Compra(Cantidad, TranId)
			values(@Cantidad, @TranId)
			
		end
		end
	end
GO

--Oferta en una subasta
CREATE PROCEDURE ROAD_TO_PROYECTO.Ofertar_Publicacion
	@PubliId int,
	@FechaActual datetime,
	@MontoOfertaString nvarchar(255),
	@Usuario nvarchar(255),
	@ConEnvio bit
	as begin
		if(@Usuario <> (select UserId from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId))
		begin
			declare @TranId int
			declare @MontoOferta numeric(18,2)
			declare @OfertanteId int 
			set @OfertanteId = (select rpu.IdExterno from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r where @Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente')
			set @MontoOferta = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@MontoOfertaString)
			--Verifico que la oferta sea mayor al precio actual de la subasta
			if((select Precio from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId) < @MontoOferta)
				begin
				insert into ROAD_TO_PROYECTO.Transaccion (Fecha, PubliId, ClieId, ConEnvio)
				values(@FechaActual, @PubliId, @OfertanteId, @ConEnvio)
				select @TranId = SCOPE_IDENTITY()
				insert into ROAD_TO_PROYECTO.Oferta(Monto, TranId)
				values(@MontoOferta, @TranId)

				--Actualizo el precio de la subasta
				update ROAD_TO_PROYECTO.Publicacion 
				set Precio = @MontoOferta
				where PublId = @PubliId
			end
		end
	end
GO

--Alta de una visiblidad
CREATE PROCEDURE ROAD_TO_PROYECTO.Agregar_Visibilidad
	@Descripcion nvarchar(255),
	@ComiFijaString nvarchar(255),
	@ComiVariableString nvarchar(255),
	@ComiEnvioString nvarchar(255)
	as begin
		declare @VisiIdAnterior int, @VisiId int, @ComiFija numeric(18,2), @ComiVariable numeric(18,2),	@ComiEnvio numeric(18,2)
		set @ComiFija = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@ComiFijaString)
		set @ComiVariable = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@ComiVariableString)
		set @ComiEnvio = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@ComiEnvioString)
		select top 1 @VisiIdAnterior = VisiId from ROAD_TO_PROYECTO.Visibilidad order by VisiId desc
		set @VisiId = @VisiIdAnterior +1
		if not exists (select descripcion from ROAD_TO_PROYECTO.Visibilidad where Descripcion = @Descripcion)
		insert into ROAD_TO_PROYECTO.Visibilidad (VisiId, Descripcion, ComiFija, ComiVariable, ComiEnvio)
		values (@VisiId, @Descripcion, @ComiFija, @ComiVariable, @ComiEnvio)
	end
GO

--Baja de una visiblidad
CREATE PROCEDURE ROAD_TO_PROYECTO.Eliminar_Visibilidad
	@VisiId int
	as begin
		delete from Visibilidad where VisiId = @VisiId
	end
GO

--Modificacion de los atributos de una visiblidad
CREATE PROCEDURE ROAD_TO_PROYECTO.Modificacion_Visibilidad
 	@VisiId int,
 	@Descripcion nvarchar(255),
 	@ComiFijaString nvarchar(255),
 	@ComiVariableString nvarchar(255),
 	@ComiEnvioString nvarchar(255)
 	as begin
		declare	@ComiFija numeric(18,2), @ComiVariable numeric(18,2), @ComiEnvio numeric(18,2)
		set @ComiFija = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@ComiFijaString)
		set @ComiVariable = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@ComiVariableString)
		set @ComiEnvio = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@ComiEnvioString)
		update ROAD_TO_PROYECTO.Visibilidad 
 		set Descripcion = @Descripcion, ComiFija = @ComiFija, ComiVariable = @ComiVariable, ComiEnvio = @ComiEnvio
 		where VisiId = @VisiId
 	end
 GO

 --Busco visibilidad segun parámetros exactos y no exactos
CREATE PROCEDURE ROAD_TO_PROYECTO.Buscar_Visibilidad
	@Descripcion nvarchar(255),
 	@ComiFijaString nvarchar(255),
 	@ComiVariableString nvarchar(255),
 	@ComiEnvioString nvarchar(255)
	as begin
		declare	@ComiFija numeric(18,2), @ComiVariable numeric(18,2), @ComiEnvio numeric(18,2)
		if(@ComifijaString is not null) set @ComiFija = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@ComiFijaString)
		if(@ComiVariableString is not null) set @ComiVariable = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@ComiVariableString)
		if(@ComiEnvioString is not null) set @ComiEnvio = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@ComiEnvioString)
		select VisiId, Descripcion, ComiFija, ComiVariable, ComiEnvio 
		from ROAD_TO_PROYECTO.Visibilidad 
		where (Descripcion like '%' + @Descripcion + '%' or @Descripcion is null)
		and (ComiFija < @ComiFija or @ComiFija is null)
		and (ComiVariable < @ComiVariable or @ComiVariable is null)
		and (ComiEnvio < @ComiEnvio or @ComiEnvio is null)
	end
GO

--Finalizo las publicaciones cuya fecha de fin sea posterior a la fecha actual, les cambio el estado
CREATE PROCEDURE ROAD_TO_PROYECTO.Finalizar_Publicaciones_Vencidas
	@FechaActual datetime
	as begin
		declare @FinalizadoId int
		select @FinalizadoId = EstadoId from ROAD_TO_PROYECTO.Estado where Descripcion = 'Finalizada'

		update ROAD_TO_PROYECTO.Publicacion
		set Estado = @FinalizadoId
		where FechaFin < @FechaActual and Estado <> @FinalizadoId
	end
GO


--Muestro los datos relevantes a la transacción para que usuario pueda elegir sabiendo que va a calificar
CREATE PROCEDURE ROAD_TO_PROYECTO.Transacciones_Sin_Calificar
	@Usuario nvarchar(255)
	as begin
		select t.TranId, 'Oferta' , Fecha, p.Descipcion, p.Precio, p.UserId
		from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r,
		ROAD_TO_PROYECTO.Oferta o
		where t.PubliId = p.PublId
		and t.TranId = o.TranId 
		and o.Ganadora = 1
		and t.TranId not in (select TranId from ROAD_TO_PROYECTO.Calificacion)
		and rpu.UserId = @Usuario and rpu.RolId = r.RolId and r.Nombre = 'Cliente' and rpu.IdExterno = t.ClieId
		union
		select t.TranId, 'Compra' , Fecha, p.Descipcion, p.Precio, p.UserId
		from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r,
		ROAD_TO_PROYECTO.Compra c
		where t.PubliId = p.PublId
		and t.TranId = c.TranId
		and t.TranId not in (select TranId from ROAD_TO_PROYECTO.Calificacion)
		and rpu.UserId = @Usuario and rpu.RolId = r.RolId and r.Nombre = 'Cliente' and rpu.IdExterno = t.ClieId
	end
GO

--Califico una transaccion
CREATE PROCEDURE ROAD_TO_PROYECTO.Calificar_Transaccion
	@TranId int,
	@CantidadEstrellas numeric(18,0),
	@Descripcion nvarchar(255)
	as begin
		declare @CaliIdAnterior int, @CaliId int
		select @CaliIdAnterior = Max(caliId)
		from ROAD_TO_PROYECTO.Calificacion
		set @CaliId = @CaliIdAnterior + 1
		insert into ROAD_TO_PROYECTO.Calificacion (CaliId, TranId, CantEstrellas, Descipcion)
		values(@CaliId, @TranId, @CantidadEstrellas, @Descripcion)
	end
GO
-- VISTA DATOS CLIENTE
CREATE VIEW ROAD_TO_PROYECTO.DatosCliente
as
select u.Usuario,u.Contraseña,u.Mail, c.Nombres, c.Apellido, c.Tipodocumento, c.Nrodocumento, isnull(c.Telefono,0) as Telefono, c.Fechanacimiento, d.Calle, d.Numero,d.Piso,d.Depto, d.Codpostal,isnull(d.Localidad,'') as Localidad
from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.cliente c, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Domicilio d
where u.domicilio = d.domiid and u.usuario = rpu.userid and rpu.rolid = (select rolid from ROAD_TO_PROYECTO.Rol where nombre = 'Cliente') and rpu.idexterno = c.clieid
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.ObtenerDatosCliente
@IdUsuario nvarchar(255)
as begin
select Usuario, Contraseña, Mail, Nombres, Apellido, Tipodocumento,NroDocumento,Telefono,FechaNacimiento,Calle,Numero,Piso,Depto,CodPostal,Localidad
from ROAD_TO_PROYECTO.DatosCliente dc
where dc.Usuario = @IdUsuario 
end
GO

-- VISTA DATOS EMPRESA
CREATE VIEW ROAD_TO_PROYECTO.DatosEmpresa
as
select u.Usuario, u.Contraseña, u.Mail, e.RazonSocial, e.CUIT, e.FechaCreacion, e.NombreContacto, r.DescripLarga, isnull(e.Telefono,0) as Telefono, d.Calle, d.Numero, d.Piso, d.Depto, d.Codpostal, isnull(d.Localidad,'') as Localidad, isnull(d.Ciudad,'') as Ciudad
from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Empresa e, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Domicilio d, ROAD_TO_PROYECTO.Rubro r
where u.Usuario = rpu.UserId 
and rpu.RolId = (select rol.RolId from ROAD_TO_PROYECTO.Rol rol where nombre = 'Empresa') 
and rpu.IdExterno = e.EmprId
and u.Domicilio = d.DomiId 
and (e.Rubro = r.RubrId or e.Rubro is null)
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.ObtenerDatosEmpresa
@IdUsuario nvarchar(255)
as begin
select Usuario, Contraseña, Mail, RazonSocial, CUIT, FechaCreacion, NombreContacto, Telefono, DescripLarga, Calle, Numero, Piso, Depto, CodPostal, Localidad, Ciudad
from ROAD_TO_PROYECTO.DatosEmpresa de
where de.Usuario = @IdUsuario 
end
GO

--Consulta y filtrado de facturas hechas a un vendedor
CREATE PROCEDURE ROAD_TO_PROYECTO.Consulta_Facturas_Vendedor
	@FechaInicioIntervalo datetime,
	@FechaFinIntervalo datetime,
	@MontoInicioIntervaloString nvarchar(255),
	@MontoFinIntervaloString nvarchar(255),
	@Detalle nvarchar(255),
	@Usuario nvarchar(255)
	as begin
		declare	@ImporteMinimo numeric(18,2), @ImporteMaximo numeric(18,2)
		set @ImporteMinimo = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@MontoInicioIntervaloString)
		set @ImporteMaximo = ROAD_TO_PROYECTO.Punto_Por_Coma_Y_Convertir(@MontoFinIntervaloString)		
		select f.FactNro, f.PubliId, f.Fecha, f.Monto as Total, f.FormaPago, i.Cantidad, i.Detalle, i.Monto as Subtotal
		from ROAD_TO_PROYECTO.Factura f
		inner join ROAD_TO_PROYECTO.Item_Factura i on f.FactNro = i.FactNro
		inner join ROAD_TO_PROYECTO.Publicacion p on f.PubliId = p.PublId
		where (f.Monto between @ImporteMinimo and @ImporteMaximo)		
		and (f.Fecha between @FechaInicioIntervalo and @FechaFinIntervalo)
		and (i.Detalle like '%' + @Detalle + '%')
		and (p.UserId like '%' + @Usuario + '%')
	end
GO

--Filtrado inicial de publicaciones.
CREATE PROCEDURE ROAD_TO_PROYECTO.Buscar_Publicaciones
	@Parametros nvarchar(1000),
	@PubliDesc nvarchar(255)
	as begin
		IF OBJECT_ID('ROAD_TO_PROYECTO.#parametros') IS NOT NULL DROP TABLE ROAD_TO_PROYECTO.#parametros
		IF OBJECT_ID('ROAD_TO_PROYECTO.#temporalPublic') IS NOT NULL DROP TABLE ROAD_TO_PROYECTO.#temporalPublic
		IF(@Parametros = '' or @Parametros is null)
		begin
			select PublId, Descipcion, Stock, FechaInicio, FechaFin, Precio, (select DescripLarga from ROAD_TO_PROYECTO.Rubro where RubrId = Rubro) as 'Rubro', (select tp.Descripcion from ROAD_TO_PROYECTO.Tipo_Publicacion tp where tp.TipoPubliId = Tipo) as 'Tipo', UserId, EnvioHabilitado
			from ROAD_TO_PROYECTO.Publicacion
			where Estado = 2
		end
		ELSE
		begin
			--EXECUTE ROAD_TO_PROYECTO.RecibirParametros @Parametros = @Rubros

			CREATE TABLE ROAD_TO_PROYECTO.#parametros (RubrId int primary key, parametro varchar(1000))
			SET NOCOUNT ON
			--El separador de nuestros parametros sera una ,
			DECLARE @Posicion int
			--@Posicion es la posicion de cada uno de nuestros separadores
			DECLARE @Parametro varchar(1000)
			--@Parametro es cada uno de los valores obtenidos que almacenaremos en #parametros
			SET @Parametros = @Parametros + ','
			--Colocamos un separador al final de los parametros para que funcione bien nuestro codigo
			--Hacemos un bucle que se repite mientras haya separadores
			WHILE patindex('%,%' , @Parametros) <> 0
			--patindex busca un patron en una cadena y nos devuelve su posicion
			BEGIN
			  SELECT @Posicion =  patindex('%,%' , @Parametros)
			  --Buscamos la posicion de la primera ,
			  SELECT @Parametro = left(@Parametros, @Posicion - 1)
			  --Y cogemos los caracteres hasta esa posicion
			  INSERT INTO ROAD_TO_PROYECTO.#parametros values ((select RubrId from ROAD_TO_PROYECTO.Rubro where DescripLarga = @Parametro), @Parametro)
			  --y ese parámetro lo guardamos en la tabla temporal
			  --Reemplazamos lo procesado con nada con la funcion stuff
			  SELECT @Parametros = stuff(@Parametros, 1, @Posicion, '')
			END
			--Y cuando se han recorrido todos los parametros sacamos por pantalla el resultado
			--SELECT * FROM ROAD_TO_PROYECTO.##parametros
			SET NOCOUNT OFF

			create table ROAD_TO_PROYECTO.#temporalPublic(
			PublId int PRIMARY KEY,
			Descripcion nvarchar(255) NOT NULL,
			Stock numeric(18,0) NOT NULL,
			FechaInicio datetime NOT NULL,
			FechaFin datetime NOT NULL,
			Precio numeric(18,2) NOT NULL,
			Rubro nvarchar(255),
			Tipo nvarchar(255),
			UserId nvarchar(255),
			EnvioHabilitado int
			)

			declare @RubroId int, @param varchar(1000)
			declare c1 cursor for SELECT * FROM ROAD_TO_PROYECTO.#parametros
			open c1
			fetch from c1 into @RubroId, @param
			while @@FETCH_STATUS = 0
			begin
				insert into ROAD_TO_PROYECTO.#temporalPublic
				select p.PublId, Descipcion, Stock, FechaInicio, FechaFin, Precio, (select DescripLarga from ROAD_TO_PROYECTO.Rubro where RubrId = @RubroId) as 'Rubro', (select tp.Descripcion from ROAD_TO_PROYECTO.Tipo_Publicacion tp where tp.TipoPubliId = Tipo) as 'Tipo', p.UserId, p.EnvioHabilitado
				from ROAD_TO_PROYECTO.Publicacion p
				where Rubro = @RubroId and p.Estado = 2

				fetch from c1 into @RubroId, @param
			end
			select * from ROAD_TO_PROYECTO.#temporalPublic
			where Descripcion like '%' + @PubliDesc + '%'
			close  c1
			deallocate c1
		end
	end
GO

--Funcion para saber si la fecha especificada esta dentro del trimestre pedido
CREATE FUNCTION ROAD_TO_PROYECTO.DentroDelTrimestre(@Trimestre int, @FechaInicio datetime)
returns int
as begin
if ((@Trimestre*3) - month(@FechaInicio) = 0 or (@Trimestre*3) - month(@FechaInicio) = 1 or (@Trimestre*3) - month(@FechaInicio) = 2)
return 1
return 0
end
GO


--nombres de visibilidades
CREATE PROCEDURE ROAD_TO_PROYECTO.Ver_Visibilidades
as begin	
	select Descripcion
	from ROAD_TO_PROYECTO.Visibilidad
	order by Descripcion
end
GO

--SP para crear tabla temporal de parametros de visibilidad
CREATE PROCEDURE ROAD_TO_PROYECTO.CrearTemporalVisibilidades
	 @Parametros nvarchar(1000)
	 as begin
		IF OBJECT_ID('tempdb..##parametrosvisibilidad') IS NOT NULL 
		DROP TABLE ROAD_TO_PROYECTO.##parametrosvisibilidad
		
		   --EXECUTE ROAD_TO_PROYECTO.RecibirParametros @Parametros = @Rubros

			CREATE TABLE ROAD_TO_PROYECTO.##parametrosvisibilidad (VisiId int primary key, parametro varchar(255))
			IF (@Parametros = '' or @Parametros is null)
			insert into ROAD_TO_PROYECTO.##parametrosvisibilidad select visiid,descripcion from ROAD_TO_PROYECTO.Visibilidad
	      
		    else if (@Parametros <> '' or @Parametros is not null)
			begin
			SET NOCOUNT ON
			--El separador de nuestros parametros sera una ,
			DECLARE @Posicion int
			--@Posicion es la posicion de cada uno de nuestros separadores
			DECLARE @Parametro varchar(255)
			--@Parametro es cada uno de los valores obtenidos que almacenaremos en #parametros
			SET @Parametros = @Parametros + ','
			--Colocamos un separador al final de los parametros para que funcione bien nuestro codigo
			--Hacemos un bucle que se repite mientras haya separadores
			WHILE patindex('%,%' , @Parametros) <> 0
			--patindex busca un patron en una cadena y nos devuelve su posicion
			BEGIN
			  SELECT @Posicion =  patindex('%,%' , @Parametros)
			  --Buscamos la posicion de la primera ,
			  SELECT @Parametro = left(@Parametros, @Posicion - 1)
			  --Y cogemos los caracteres hasta esa posicion
			  INSERT INTO ROAD_TO_PROYECTO.##parametrosvisibilidad values ((select VisiId from ROAD_TO_PROYECTO.Visibilidad where Descripcion = @Parametro), @Parametro)
			  --y ese parámetro lo guardamos en la tabla temporal
			  --Reemplazamos lo procesado con nada con la funcion stuff
			  SELECT @Parametros = stuff(@Parametros, 1, @Posicion, '')
			END
			--Y cuando se han recorrido todos los parametros sacamos por pantalla el resultado
			SET NOCOUNT OFF
			end
	
	end
GO

--Funcion que devuelve el trimestre de un mes
CREATE FUNCTION ROAD_TO_PROYECTO.ObtenerTrimestre(@Mes int)
returns int
as begin
	if(@Mes<=3) return 1
	else if (@Mes<=6) return 2
	else if (@Mes<=9) return 3
	return 4
end
GO

CREATE FUNCTION ROAD_TO_PROYECTO.EstaActivaEnTrimestre(@FechaInicio datetime,@FechaFin datetime,@Trimestre int)
returns int
as begin
	if ((@Trimestre*3)-2 >= month(@FechaInicio) and  (@Trimestre*3)-2 <= month(@FechaFin))
	return 1
	return 0
end
GO

/*CREATE VIEW ROAD_TO_PROYECTO.CantidadFacturasPorUsuarioYTrimestre as
	select u.Usuario as Usuario,year(f.fecha) as Año,ROAD_TO_PROYECTO.ObtenerTrimestre (month(f.fecha)) as Trimestre, count(*) as CantFacturas
	from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Publicacion p,ROAD_TO_PROYECTO.Factura f
	where u.usuario = p.userid
	and f.PubliId = p.PublId
	group by u.usuario, year(f.fecha), ROAD_TO_PROYECTO.ObtenerTrimestre (month(f.fecha))
GO*/


--Top 5: listados estadísticos
--right('0000' + cast(year(fact_fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(fact_fecha) as varchar(2)), 2)
--Top 5 número 1:Vendedores con mayor cantidad de productos no vendidos. 

CREATE PROCEDURE ROAD_TO_PROYECTO.Vendedores_Productos_No_Vendidos_Old
	@Trimestre int,
	@Año int,
	@Parametros nvarchar(1000)
	as begin
	    exec ROAD_TO_PROYECTO.CrearTemporalVisibilidades @Parametros

		IF OBJECT_ID('ROAD_TO_PROYECTO.#consulta1') IS NOT NULL DROP TABLE ROAD_TO_PROYECTO.#consulta1
		create table ROAD_TO_PROYECTO.#consulta1(
		Usuario nvarchar(255),
		Detalle nvarchar(255),
		AñoMes nvarchar(255),
		Visibilidad int,
		Monto numeric(18,0)
		)
		insert into ROAD_TO_PROYECTO.#consulta1
		select u.Usuario, concat(c.Apellido, ' ' ,c.Nombres) , right('0000' + cast(year(p.FechaInicio) as varchar(4)), 4) + '-' + right('00' + cast(month(p.FechaInicio) as varchar(2)), 2) as 'Año-Mes', Visibilidad, count(*) as 'Cantidad Facturas'
		from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Cliente c, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu
		where u.Usuario = p.UserId
		and u.Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente' and rpu.IdExterno = c.ClieId 
		and (year(p.FechaInicio) = @Año or year(p.fechafin) = @Año)
		and ((@Trimestre*3)-2 between month(p.FechaInicio) and month(p.FechaFin) or (@Trimestre*3)-1 between month(p.FechaInicio) and month(p.FechaFin) or (@Trimestre*3) between month(p.FechaInicio) and month(p.FechaFin))
		and Visibilidad in (select visiid from ROAD_TO_PROYECTO.##parametrosvisibilidad)
		and p.PublId not in (select f.PubliId from ROAD_TO_PROYECTO.Factura f where year(f.Fecha) = @Año and ((@Trimestre*3) - month(f.Fecha) = 0 or (@Trimestre*3) - month(f.Fecha) = 1 or (@Trimestre*3) - month(f.Fecha) = 2))
		group by u.Usuario, c.Apellido, c.Nombres, right('0000' + cast(year(p.FechaInicio) as varchar(4)), 4) + '-' + right('00' + cast(month(p.FechaInicio) as varchar(2)), 2), Visibilidad
		union
		select u.Usuario, e.RazonSocial, right('0000' + cast(year(p.FechaInicio) as varchar(4)), 4) + '-' + right('00' + cast(month(p.FechaInicio) as varchar(2)), 2) as 'Año-Mes', Visibilidad, count(*) as 'Cantidad Facturas'
		from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Empresa e, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu
		where u.Usuario = p.UserId
		and u.Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Empresa' and rpu.IdExterno = e.EmprId 
		and (year(p.FechaInicio) = @Año or year(p.fechafin)=@Año)
		and ((@Trimestre*3)-2 between month(p.FechaInicio) and month(p.FechaFin) or (@Trimestre*3)-1 between month(p.FechaInicio) and month(p.FechaFin) or (@Trimestre*3) between month(p.FechaInicio) and month(p.FechaFin))
		and Visibilidad in (select visiid from ROAD_TO_PROYECTO.##parametrosvisibilidad)
		and p.PublId not in (select f.PubliId from ROAD_TO_PROYECTO.Factura f where year(f.Fecha) = @Año and ((@Trimestre*3) - month(f.Fecha) = 0 or (@Trimestre*3) - month(f.Fecha) = 1 or (@Trimestre*3) - month(f.Fecha) = 2))
		group by u.Usuario, e.RazonSocial, right('0000' + cast(year(p.FechaInicio) as varchar(4)), 4) + '-' + right('00' + cast(month(p.FechaInicio) as varchar(2)), 2), Visibilidad
		order by count(*) desc

		select top 5 Usuario, Detalle, AñoMes, (select Descripcion from ROAD_TO_PROYECTO.Visibilidad where VisiId = Visibilidad) as 'Visibilidad', Monto as 'Prods No Vendidos'
		from ROAD_TO_PROYECTO.#consulta1
		order by Monto desc, AñoMes desc, (select ComiFija from ROAD_TO_PROYECTO.Visibilidad where VisiId = Visibilidad) desc

	end
GO

--Top 5 número 2: Clientes con mayor cantidad de productos comprados
CREATE PROCEDURE ROAD_TO_PROYECTO.Clientes_Productos_Comprados
	@Trimestre int,
	@Año int,
	@RubroDesc nvarchar(255)
	as begin
		select top 5 u.Usuario, c.Apellido, c.Nombres, right('0000' + cast(year(t.Fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(t.Fecha) as varchar(2)), 2) as 'Año-Mes', sum(comp.Cantidad) as 'Cantidad Comprada'
		from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Cliente c, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, 
		ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Rubro rub, ROAD_TO_PROYECTO.Compra comp
		where u.Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente' and rpu.IdExterno = c.ClieId and t.ClieId = c.ClieId
		and t.PubliId = p.PublId and p.Rubro = rub.RubrId and rub.DescripLarga = @RubroDesc
		and year(t.Fecha) = @Año
		and ROAD_TO_PROYECTO.DentroDelTrimestre(@Trimestre, t.Fecha) = 1
		and t.TranId = comp.TranId
		group by u.Usuario, c.ClieId, c.Apellido, c.Nombres,  right('0000' + cast(year(t.Fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(t.Fecha) as varchar(2)), 2)
		order by sum(comp.Cantidad) desc
	end
GO

--Top 5 número 3: Vendedores con mayor cantidad de facturas
CREATE PROCEDURE ROAD_TO_PROYECTO.Cantidad_Facturas_Vendedores
	@Trimestre int,
	@Año int
	as begin
		IF OBJECT_ID('ROAD_TO_PROYECTO.#consulta3') IS NOT NULL DROP TABLE ROAD_TO_PROYECTO.#consulta3
		create table ROAD_TO_PROYECTO.#consulta3(
		Usuario nvarchar(255),
		Detalle nvarchar(255),
		AñoMes nvarchar(255),
		Monto numeric(18,0)
		)
		insert into ROAD_TO_PROYECTO.#consulta3
		select u.Usuario, concat(c.Apellido, ' ' ,c.Nombres), right('0000' + cast(year(f.Fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(f.Fecha) as varchar(2)), 2) as 'Año-Mes', count(*) as 'Cantidad Facturas'
		from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Factura f, ROAD_TO_PROYECTO.Cliente c, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu
		where u.Usuario = p.UserId and p.PublId = f.PubliId
		and u.Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente' and rpu.IdExterno = c.ClieId 
		and year(f.Fecha) = @Año
		and ROAD_TO_PROYECTO.DentroDelTrimestre(@Trimestre, f.Fecha) = 1
		group by u.Usuario, c.Apellido, c.Nombres, right('0000' + cast(year(f.Fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(f.Fecha) as varchar(2)), 2)
		union
		select u.Usuario, e.RazonSocial, right('0000' + cast(year(f.Fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(f.Fecha) as varchar(2)), 2) as 'Año-Mes', count(*) as 'Cantidad Facturas'
		from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Factura f, ROAD_TO_PROYECTO.Empresa e, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu
		where u.Usuario = p.UserId and p.PublId = f.PubliId
		and u.Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Empresa' and rpu.IdExterno = e.EmprId 
		and year(f.Fecha) = @Año
		and ROAD_TO_PROYECTO.DentroDelTrimestre(@Trimestre, f.Fecha) = 1
		group by u.Usuario, e.RazonSocial, right('0000' + cast(year(f.Fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(f.Fecha) as varchar(2)), 2)
		order by count(*) desc

		select top 5 Usuario, Detalle, AñoMes, Monto as 'Cantidad'
		from ROAD_TO_PROYECTO.#consulta3
		order by Monto desc
	end
GO

--Top 5 número 4: Vendedores con mayor monto facturado
CREATE PROCEDURE ROAD_TO_PROYECTO.Monto_Facturado_Vendedor
	@Trimestre int,
	@Año int
	as begin
		IF OBJECT_ID('ROAD_TO_PROYECTO.#consulta4') IS NOT NULL DROP TABLE ROAD_TO_PROYECTO.#consulta4
		create table ROAD_TO_PROYECTO.#consulta4(
		Usuario nvarchar(255),
		Detalle nvarchar(255),
		AñoMes nvarchar(255),
		Monto numeric(18,2)
		)
		insert into ROAD_TO_PROYECTO.#consulta4
		select u.Usuario, concat(c.Apellido, ' ' ,c.Nombres), right('0000' + cast(year(f.Fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(f.Fecha) as varchar(2)), 2) as 'Año-Mes', sum(f.Monto) as 'Monto Facturado'
		from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Factura f, ROAD_TO_PROYECTO.Cliente c, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu
		where u.Usuario = p.UserId and p.PublId = f.PubliId
		and u.Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente' and rpu.IdExterno = c.ClieId 
		and year(f.Fecha) = @Año
		and ROAD_TO_PROYECTO.DentroDelTrimestre(@Trimestre, f.Fecha) = 1
		group by u.Usuario, c.Apellido, c.Nombres, right('0000' + cast(year(f.Fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(f.Fecha) as varchar(2)), 2)
		union
		select u.Usuario, e.RazonSocial, right('0000' + cast(year(f.Fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(f.Fecha) as varchar(2)), 2) as 'Año-Mes', sum(f.Monto)  as 'Monto Facturado'
		from ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Factura f, ROAD_TO_PROYECTO.Empresa e, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu
		where u.Usuario = p.UserId and p.PublId = f.PubliId
		and u.Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Empresa' and rpu.IdExterno = e.EmprId 
		and year(f.Fecha) = @Año
		and ROAD_TO_PROYECTO.DentroDelTrimestre(@Trimestre, f.Fecha) = 1
		group by u.Usuario, e.RazonSocial, right('0000' + cast(year(f.Fecha) as varchar(4)), 4) + '-' + right('00' + cast(month(f.Fecha) as varchar(2)), 2)
		order by sum(f.Monto) desc

		select top 5 *
		from ROAD_TO_PROYECTO.#consulta4
		order by Monto desc
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Buscar_Factura
	@FactId int,
	@PubliId int
	as 
	begin
		declare @Usuario nvarchar(255)
		set @Usuario = (select UserId from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId)
		if (@Usuario in (select rpu.UserId
		from ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Empresa e
		where rpu.RolId = r.RolId and r.Nombre = 'Empresa'))
		begin
			select f.FactNro, f.Fecha, e.RazonSocial, e.CUIT, concat(d.Calle, ' ', d.Numero) as Domicilio, d.CodPostal, f.Monto, r.Nombre as Rol
			from ROAD_TO_PROYECTO.Factura f, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Empresa e, ROAD_TO_PROYECTO.Domicilio d
			where f.FactNro = @FactId and f.PubliId = p.PublId and p.UserId = u.Usuario
			and u.Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Empresa' and rpu.IdExterno = e.EmprId
			and u.Domicilio = d.DomiId
		end
		if (@Usuario in (select rpu.UserId
		from ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Empresa e
		where rpu.RolId = r.RolId and r.Nombre = 'Cliente'))
		begin
			select f.FactNro, f.Fecha, CONCAT(c.Nombres, ' ', c.Apellido) as Nombre, CONCAT(d.Calle, ' ', d.Numero) as Domicilio, d.CodPostal, c.NroDocumento, f.Monto, r.Nombre as Rol
			from ROAD_TO_PROYECTO.Factura f, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Usuario u, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Cliente c, ROAD_TO_PROYECTO.Domicilio d
			where f.FactNro = @FactId and f.PubliId = p.PublId and p.UserId = u.Usuario
			and u.Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente' and rpu.IdExterno = c.ClieId
			and u.Domicilio = d.DomiId
		end
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Obtener_Datos_Factura
@FactNro int
as begin
	select i.Cantidad, i.Detalle, i.Monto
	from ROAD_TO_PROYECTO.Factura f inner join ROAD_TO_PROYECTO.Item_Factura i on f.FactNro = i.FactNro
	where f.FactNro = @FactNro
end
GO


CREATE PROCEDURE ROAD_TO_PROYECTO.Historial_Cliente_Compras_Subastas
	@Usuario nvarchar(255)
	as begin
		declare @ClieId int
		set @ClieId = (select rpu.IdExterno from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r where @Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente')
		select t.TipoTransac, t.Fecha, o.Monto as 'Monto', p.Descipcion, p.UserId
		from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Oferta o
		where t.PubliId = p.PublId and t.ClieId = @ClieId and t.TranId = o.TranId
		union
		select t.TipoTransac, t.Fecha, p.Precio as 'Monto', p.Descipcion, p.UserId
		from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Compra c
		where t.PubliId = p.PublId and t.ClieId = @ClieId and t.TranId = c.TranId
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Cantidad_Compras_Subastas_Realizadas
	@Usuario nvarchar(255)
	as begin
		declare @ClieId int
		set @ClieId = (select rpu.IdExterno from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r where @Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente')
		select COUNT(*) - (select COUNT(*) from ROAD_TO_PROYECTO.Oferta o, ROAD_TO_PROYECTO.Transaccion t where t.ClieId = 1 and t.TranId = o.TranId and o.Ganadora = 0 group by t.ClieId) as cantPublis
		from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Publicacion p
		where t.PubliId = p.PublId and t.ClieId = @ClieId
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Cantidad_Compras_Subastas_Sin_Calificar
	@Usuario nvarchar(255)
	as begin
		select COUNT(*) + (select COUNT(*) 
							from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Oferta o
							where t.TranId = o.TranId
							and t.PubliId = p.PublId
							and o.Ganadora = 1
							and t.TranId not in (select TranId from ROAD_TO_PROYECTO.Calificacion)
							and rpu.UserId = @Usuario and rpu.RolId = r.RolId and r.Nombre = 'Cliente' and rpu.IdExterno = t.ClieId ) as cantPublis
		from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r, ROAD_TO_PROYECTO.Compra c
		where t.TranId = c.TranId
		and t.PubliId = p.PublId
		and t.TranId not in (select TranId from ROAD_TO_PROYECTO.Calificacion)
		and rpu.UserId = @Usuario and rpu.RolId = r.RolId and r.Nombre = 'Cliente' and rpu.IdExterno = t.ClieId
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Transacciones_Con_X_Estrellas
	@Usuario nvarchar(255),
	@CantEstrellas int
	as begin
		declare @ClieId int
		set @ClieId = (select rpu.IdExterno from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r where @Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente')
		select COUNT(*) as cantPublis
		from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Calificacion c
		where t.PubliId = p.PublId and t.ClieId = @ClieId and t.TranId = c.TranId and c.CantEstrellas = @CantEstrellas
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Ultimas_Cinco_Transacciones_Calificadas
	@Usuario nvarchar(255)
	as begin
		declare @ClieId int
		set @ClieId = (select rpu.IdExterno from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r where @Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente')
		select top 5 t.TipoTransac, t.Fecha, p.Precio as 'Monto', p.Descipcion, p.UserId, c.CantEstrellas
		from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Publicacion p, ROAD_TO_PROYECTO.Calificacion c
		where t.PubliId = p.PublId and t.ClieId = @ClieId and t.TranId = c.TranId
		order by t.Fecha desc
	end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Historial_Cliente_Acumulados
	@Usuario nvarchar(255)
	as begin
		declare @ClieId int
		set @ClieId = (select rpu.IdExterno from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu, ROAD_TO_PROYECTO.Rol r where @Usuario = rpu.UserId and rpu.RolId = r.RolId and r.Nombre = 'Cliente')
		select count (*) as 'Sin Calificar', ROAD_TO_PROYECTO.EstrellasPromedioCliente(@ClieId) as 'Promedio Estrellas', ROAD_TO_PROYECTO.EstrellasTotalesCliente(@ClieId) as 'Estrellas Totales'
		from ROAD_TO_PROYECTO.Transaccion t
		where t.ClieId = @ClieId and t.TranId not in (select c.TranId from ROAD_TO_PROYECTO.Calificacion c)
	end
GO

CREATE FUNCTION ROAD_TO_PROYECTO.EstrellasPromedioCliente(@ClieId int)
returns numeric(18,2)
as begin
declare @CantEstrellas numeric(18,2)
select @CantEstrellas = avg(c.CantEstrellas) from ROAD_TO_PROYECTO.Calificacion c, ROAD_TO_PROYECTO.Transaccion t where c.TranId = t.TranId and t.ClieId = @ClieId
return @CantEstrellas
end
GO

CREATE FUNCTION ROAD_TO_PROYECTO.EstrellasTotalesCliente(@ClieId int)
returns int
as begin
declare @CantEstrellas int
select @CantEstrellas = sum(c.CantEstrellas) from ROAD_TO_PROYECTO.Calificacion c, ROAD_TO_PROYECTO.Transaccion t where c.TranId = t.TranId and t.ClieId = @ClieId
return @CantEstrellas
end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.AsignarRolAUsuario 
@Usuario nvarchar(255),
@RolAsignado nvarchar(255)
as begin
if(@RolAsignado ='Cliente')
exec ROAD_TO_PROYECTO.Alta_Rol_Usuario @Usuario, @RolAsignado,AsignarUltimoIdCliente
else if(@RolAsignado = 'Empresa')
exec ROAD_TO_PROYECTO.Alta_Rol_Usuario @Usuario, @RolAsignado, AsignarUltimoIdEmpresa
else
if not exists(select rpu.UserId,rpu.RolId from ROAD_TO_PROYECTO.Roles_Por_Usuario rpu where rpu.UserId = @Usuario and rpu.RolId = (select RolId from ROAD_TO_PROYECTO.Rol r where r.Nombre = @RolAsignado))
insert into ROAD_TO_PROYECTO.Roles_Por_Usuario values (@Usuario,(select rolid from ROAD_TO_PROYECTO.Rol where nombre = @RolAsignado),NULL)
end
GO

CREATE FUNCTION ROAD_TO_PROYECTO.AsignarUltimoIdEmpresa()
returns int
as begin
return (select max(EmprId)+1 from ROAD_TO_PROYECTO.Empresa)
end
GO


CREATE FUNCTION ROAD_TO_PROYECTO.AsignarUltimoIdCliente()
returns int
as begin
return (select max(ClieId)+1 from ROAD_TO_PROYECTO.Cliente)
end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Lista_Estados
as begin
	select Descripcion from ROAD_TO_PROYECTO.Estado
end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Buscar_Publicacion
@PubliId int
as begin
	select p.Descipcion, p.Stock, p.FechaFin, p.Precio, v.Descripcion, r.DescripLarga, p.Tipo, p.EnvioHabilitado
	from ROAD_TO_PROYECTO.Publicacion p inner join ROAD_TO_PROYECTO.Visibilidad v on p.Visibilidad = v.VisiId
	inner join ROAD_TO_PROYECTO.Rubro r on p.Rubro = r.RubrId
	where p.PublId = @PubliId
end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Buscar_Publicacion_Estado
@Usuario nvarchar(255),
@Descripcion nvarchar(255),
@Estado nvarchar(255)
as begin
	declare @EstadoId int
	if(@Estado is not null) set @EstadoId = (select EstadoId from ROAD_TO_PROYECTO.Estado e where e.Descripcion = @Estado)
	select p.PublId, p.Descipcion, p.Precio, e.Descripcion
	from ROAD_TO_PROYECTO.Publicacion p inner join ROAD_TO_PROYECTO.Estado e on p.Estado = e.EstadoId
	where p.UserId = @Usuario and p.Descipcion like '%' + @Descripcion + '%' and (p.Estado = @EstadoId or @EstadoId is null)
end
GO

CREATE PROCEDURE ROAD_TO_PROYECTO.Buscar_Ultima_Factura
as begin
	select top 1 FactNro
	from ROAD_TO_PROYECTO.Factura
	order by FactNro desc
end
GO

----- Triggers -----
CREATE TRIGGER ROAD_TO_PROYECTO.Actualizar_Stock_y_Facturar on ROAD_TO_PROYECTO.Compra after insert
	as begin
		--Variables
		declare @Cantidad numeric(18,0), @TranId int, @Fecha datetime, @PubliId int, @ConEnvio bit, @UltimaFactura int, @FacturaActual int, @ComiVariable numeric(18,2), @ComiEnvio numeric(18,2)

		--Cursor con compras realizadas
		declare c1 cursor for select Cantidad, TranId from inserted
		open c1
		fetch next from c1 into @Cantidad, @TranId

		while @@FETCH_STATUS = 0
			begin
			begin transaction

				select @Fecha = Fecha, @PubliId = PubliId, @ConEnvio = ConEnvio
				from ROAD_TO_PROYECTO.Transaccion
				where TranId = @TranId

				--Actualizo stock de publicaciones involucradas
				update ROAD_TO_PROYECTO.Publicacion
				set Stock = (Stock - @Cantidad)
				where PublId = @PubliId
				--Si el stock es 0, finalizo
				if ((select Stock from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId) = 0)
				begin
					execute ROAD_TO_PROYECTO.Finalizar_Publicacion @PubliId = @PubliId
				end
				
				--Busco el último número de factura y determino el siguiente
				select top 1 @UltimaFactura = FactNro from ROAD_TO_PROYECTO.Factura order by FactNro desc
				set @FacturaActual = @UltimaFactura + 1

				--Creo nueva factura
				insert into ROAD_TO_PROYECTO.Factura (FactNro, PubliId, Fecha)--, Monto, FormaPago)
				values(@FacturaActual, @PubliId, @Fecha)

				--Busco la comisión por ventas de la publicación
				select @ComiVariable = ComiVariable 
				from ROAD_TO_PROYECTO.Visibilidad v, ROAD_TO_PROYECTO.Publicacion p
				where p.PublId = @PubliId and p.Visibilidad = v.VisiId

				--Creo los items de la factura
				insert into ROAD_TO_PROYECTO.Item_Factura (FactNro, Cantidad, Detalle, Monto)
				values(@FacturaActual, @Cantidad, 'Comisión por productos vendidos', @Cantidad * @ComiVariable * (select Precio from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId))
				
				--Verifico si corresponde comisiones por envío
				if(((select p.EnvioHabilitado from ROAD_TO_PROYECTO.Publicacion p where p.PublId = @PubliId) = 1) and @ConEnvio = 1)
					begin
						--Busco la comisión por envío de la publicación
						select @ComiEnvio = ComiEnvio 
						from ROAD_TO_PROYECTO.Visibilidad v, ROAD_TO_PROYECTO.Publicacion p
						where p.PublId = @PubliId and p.Tipo = v.VisiId

						--Creo los items de la factura
						insert into ROAD_TO_PROYECTO.Item_Factura (FactNro, Cantidad, Detalle, Monto)
						values(@FacturaActual, @Cantidad, 'Comisión por envío de producto', @Cantidad * @ComiEnvio * (select Precio from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId))
					end
				
				update ROAD_TO_PROYECTO.Factura
				set Monto = (select sum(Monto) from ROAD_TO_PROYECTO.Item_Factura where FactNro = @FacturaActual)
				where FactNro = @FacturaActual

				fetch next from c1 into @Cantidad, @TranId
				commit
			end
		close c1;
		deallocate c1;
	end
GO
 
CREATE TRIGGER ROAD_TO_PROYECTO.Determinar_Oferta_Ganadora_Y_Facturar_Finalizadas on ROAD_TO_PROYECTO.Publicacion after update
	as begin
		--Variables
		declare @PubliId int, @UltimaFactura int, @FacturaActual int, @ComiFija numeric(18,2), @ComiVariable numeric(18,2), @ComiEnvio numeric(18,2)
		--Cursor con subastas finalizadas 
		declare c2 cursor for select PublId from inserted 
		where Tipo = (select tp.TipoPubliId from ROAD_TO_PROYECTO.Tipo_Publicacion tp where tp.Descripcion = 'Subasta') 
		and Estado = (select EstadoId from ROAD_TO_PROYECTO.Estado where Descripcion = 'Finalizada')
		--Cursor con compras inmediatas finalizadas
		declare c3 cursor for select PublId from inserted 
		where Tipo = (select tp.TipoPubliId from ROAD_TO_PROYECTO.Tipo_Publicacion tp where tp.Descripcion = 'Compra Inmediata') 
		and Estado = (select EstadoId from ROAD_TO_PROYECTO.Estado where Descripcion = 'Finalizada')
		
		open c2
		fetch next from c2 into @PubliId
		
		while @@FETCH_STATUS = 0
			begin
			begin transaction
				update ROAD_TO_PROYECTO.Oferta
				set Ganadora = 1
				where TranId = (select top 1 t.TranId 
								 from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Oferta o
								 where PubliId = @PubliId and t.TranId = o.TranId
								 order by Monto desc)

				--Busco el último número de factura y determino el siguiente
				select top 1 @UltimaFactura = FactNro from ROAD_TO_PROYECTO.Factura order by FactNro desc
				set @FacturaActual = @UltimaFactura + 1

				--Creo nueva factura
				insert into ROAD_TO_PROYECTO.Factura (FactNro, PubliId, Fecha)--, Monto, FormaPago)
				values(@FacturaActual, @PubliId, (select FechaFin from ROAD_TO_PROYECTO.Publicacion where PublId = @PubliId))

				--Busco la comisión fija y la comisión por ventas de la publicación
				select @ComiFija = ComiFija 
				from ROAD_TO_PROYECTO.Visibilidad v, ROAD_TO_PROYECTO.Publicacion p 
				where p.PublId = @PubliId and p.Visibilidad = v.VisiId

				select @ComiVariable = ComiVariable 
				from ROAD_TO_PROYECTO.Visibilidad v, ROAD_TO_PROYECTO.Publicacion p
				where p.PublId = @PubliId and p.Visibilidad = v.VisiId

				--Creo los items de la factura
				insert into ROAD_TO_PROYECTO.Item_Factura (FactNro, Cantidad, Detalle, Monto) 
				values (@FacturaActual, 1, 'Precio por tipo publicación', @ComiFija)

				insert into ROAD_TO_PROYECTO.Item_Factura (FactNro, Cantidad, Detalle, Monto)
				values(@FacturaActual, 1, 'Comisión por productos vendidos', @ComiVariable * (select o.Monto from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Oferta o where t.TranId = o.TranId and o.Ganadora = 1 and PubliId = @PubliId))
				
				--Verifico si corresponde comisiones por envío
				if(((select p.EnvioHabilitado from ROAD_TO_PROYECTO.Publicacion p where p.PublId = @PubliId) = 1) and ((select ConEnvio from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Oferta o where t.TranId = o.TranId and o.Ganadora = 1 and PubliId = @PubliId) = 1))
					begin
						--Busco la comisión por envío de la publicación
						select @ComiEnvio = ComiEnvio 
						from ROAD_TO_PROYECTO.Visibilidad v, ROAD_TO_PROYECTO.Publicacion p
						where p.PublId = @PubliId and p.Visibilidad = v.VisiId

						--Creo los items de la factura
						insert into ROAD_TO_PROYECTO.Item_Factura (FactNro, Cantidad, Detalle, Monto)
						values(@FacturaActual, 1, 'Comisión por envío de producto', @ComiEnvio * (select o.Monto from ROAD_TO_PROYECTO.Transaccion t, ROAD_TO_PROYECTO.Oferta o where t.TranId = o.TranId and o.Ganadora = 1 and PubliId = @PubliId))
					end

				update ROAD_TO_PROYECTO.Factura
				set Monto = (select sum(Monto) from ROAD_TO_PROYECTO.Item_Factura where FactNro = @FacturaActual)
				where FactNro = @FacturaActual

			fetch next from c2 into @PubliId
			commit
		end
		close c2;
		deallocate c2;
		
		open c3
		fetch next from c3 into @PubliId
		
		while @@FETCH_STATUS = 0
			begin
			begin transaction
				execute ROAD_TO_PROYECTO.Facturar_Publicacion @PublId = @PubliId
			fetch next from c3 into @PubliId
			commit
		end
		close c3;
		deallocate c3;
	end
GO




--ATRODEN UN ROGER
insert into ROAD_TO_PROYECTO.Usuario (Usuario, Contraseña, Mail)
values('admin', SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('SHA2_256', 'w23e')), 3, 255), 'admin@mercadoEnvio.org')

insert into ROAD_TO_PROYECTO.Roles_Por_Usuario (UserId, RolId)
values('admin', (select RolId from ROAD_TO_PROYECTO.Rol where Nombre = 'Administrador'))
