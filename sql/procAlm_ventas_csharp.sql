--procedimiento mostrar_categoria (antes use [ventas-csharp])
use [ventas-csharp]
create proc spmostrar_categoria
as
select top 200 * from categoria
order by idcategoria desc
go

--procedimiento buscar_categoria
create proc spbuscar_categoria
@textobuscar varchar(50)
as
select * from categoria
where nombre like @textobuscar +'%' --concatena lo que envio con cualquier otro caracter
go

--procedimiento insertar_categoria
create proc spinsertar_categoria
@idcategoria int output,	--la var es auntogenerada no es de entrada sino de salida
@nombre varchar(50),
@descripcion varchar(256)
as
insert into categoria(nombre,descripcion)
values(@nombre,@descripcion)
go

--procedimiento editar_categoria
create proc speditar_categoria
@idcategoria int,
@nombre varchar(50),
@descripcion varchar(256)
as
update categoria set nombre=@nombre,descripcion=@descripcion
where idcategoria=@idcategoria
go

--procedimiento eliminar_categoria
create proc speliminar_categoria
@idcategoria int
as
delete from categoria
where idcategoria=@idcategoria
go


--==========================================================

use [ventas-csharp]
go
--mostrar presentaciones
create proc spmostrar_presentacion
as 
select top 100 * from presentacion
order by idpresentacion desc
go
--buscar presentacion
create proc spbuscar_presentacion
@textobuscar varchar(50)
as
select * from presentacion
where nombre like @textobuscar + '%'
go
--insertar presentacion
create proc spinsertar_presentacion
@idpresentacion int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into presentacion(nombre,descripcion)
values(@nombre,@descripcion)
go
--editar presentacion
create proc speditar_presentacion
@idpresentacion int,
@nombre varchar(50),
@descripcion varchar(256)
as
update presentacion set nombre=@nombre,@descripcion=@descripcion
where idpresentacion=@idpresentacion
go
--eliminar presentacion
create proc speliminar_presentacion
@idpresentacion int
as
delete from presentacion
where idpresentacion=@idpresentacion
go

--=======================================================
--mostrar articulo
create proc spmostrar_articulo
as
SELECT   top 100     dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre, dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria, dbo.categoria.nombre AS categoria, dbo.articulo.idpresentacion, 
                         dbo.presentacion.nombre AS presentacion
FROM            dbo.articulo INNER JOIN
                         dbo.categoria ON dbo.articulo.idcategoria = dbo.categoria.idcategoria INNER JOIN
                         dbo.presentacion ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
order by dbo.articulo.idarticulo desc
go

--buscar articulo por el nombre
create proc spbuscar_articulo
@textobuscar varchar(50)
as
SELECT        dbo.articulo.idarticulo, dbo.articulo.codigo, dbo.articulo.nombre, dbo.articulo.descripcion, dbo.articulo.imagen, dbo.articulo.idcategoria, dbo.categoria.nombre AS Expr1, dbo.articulo.idpresentacion, 
                         dbo.presentacion.nombre AS Expr2
FROM            dbo.articulo INNER JOIN
                         dbo.categoria ON dbo.articulo.idcategoria = dbo.categoria.idcategoria INNER JOIN
                         dbo.presentacion ON dbo.articulo.idpresentacion = dbo.presentacion.idpresentacion
where dbo.articulo.nombre like @textobuscar + '%'
order by dbo.articulo.idarticulo desc
go
--insertar articulo
create proc spinsertar_articulo
@idarticulo int output,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int
as
insert into articulo(codigo,nombre,descripcion,imagen,idcategoria,idpresentacion)
values(@codigo,@nombre,@descripcion,@imagen,@idcategoria,@idpresentacion)
go

--editar articulo
create proc speditar_articulo
@idarticulo int,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int
as
update articulo set codigo=@codigo,nombre=@nombre,descripcion=@descripcion,imagen=@imagen,
					idcategoria=@idcategoria,idpresentacion=@idpresentacion
where idarticulo=@idarticulo
go

--eliminar articulo
create proc speliminar_articulo
@idarticulo int
as
delete from articulo
where idarticulo=@idarticulo
go

--=======================================================
use [ventas-csharp]
go
--mostrar proveedor
create proc spmostrar_proveedor
as
select top 200 * from proveedor
order by razon_social asc
go

--buscar razon social
create proc spbuscar_proveedor_razon_social
@textobuscar varchar(50)
as
select * from proveedor
where razon_social like @textobuscar +'%' --concatena lo que envio con cualquier otro caracter
go

--buscar numero de documento
create proc spbuscar_proveedor_num_documento
@textobuscar varchar(11)
as
select * from proveedor
where num_documento like @textobuscar +'%' --concatena lo que envio con cualquier otro caracter
go

--insertar proveedor
create proc spinsertar_proveedor
@idproveedor int output,	--la var es auntogenerada no es de entrada sino de salida
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(100)
as
insert into proveedor(razon_social,sector_comercial,tipo_documento,num_documento,direccion,telefono,email,url)
values(@razon_social,@sector_comercial,@tipo_documento,@num_documento,@direccion,@telefono,@email,@url)
go

--editar proveedor
create proc speditar_proveedor
@idproveedor int,	--la var es de salida en editar
@razon_social varchar(150),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(100)
as
update proveedor set razon_social=@razon_social,sector_comercial=@sector_comercial,tipo_documento=@tipo_documento,
					 num_documento=@num_documento,direccion=@direccion,telefono=@telefono,email=@email,url=@url
where idproveedor=@idproveedor
go

--eliminar proveedor
create proc speliminar_proveedor
@idproveedor int
as
delete from proveedor
where idproveedor=@idproveedor
go


--=======================================================
use [ventas-csharp]
go

--mostrar cliente
create proc spmostrar_cliente
as
select top 200 * from cliente
order by apellidos asc
go

--buscar apellidos
create proc spbuscar_apellidos
@textobuscar varchar(50)
as
select * from cliente
where apellidos like @textobuscar +'%' --concatena lo que envio con cualquier otro caracter
go

--buscar numero documento
create proc spbuscar_num_documento
@textobuscar varchar(50)
as
select * from cliente
where num_documento like @textobuscar +'%' --concatena lo que envio con cualquier otro caracter
go

--insertar cliente
create proc spinsertar_cliente
@idcliente int output,	--la var es auntogenerada no es de entrada sino de salida
@nombre varchar(50),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50)
as
insert into cliente(nombre,apellidos,sexo,fecha_nacimiento,tipo_documento,num_documento,direccion,telefono,email)
values(@nombre,@apellidos,@sexo,@fecha_nacimiento,@tipo_documento,@num_documento,@direccion,@telefono,@email)
go

--editar cliente
create proc speditar_cliente
@idcliente int,	--la var es auntogenerada no es de entrada sino de salida
@nombre varchar(50),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50)
as
update cliente set nombre=@nombre,apellidos=@apellidos,sexo=@sexo,fecha_nacimiento=@fecha_nacimiento,
tipo_documento=@tipo_documento,num_documento=@num_documento,direccion=@direccion,telefono=@telefono,email=@email
where idcliente=@idcliente
go

--eliminar cliente
create proc speliminar_cliente
@idcliente int
as
delete from cliente
where idcliente=@idcliente
go

--=======================================================
use [ventas-csharp]
go

--mostrar trabajadores
create proc spmostrar_trabajador
as
select top 200 * from trabajador
order by apellidos asc
go

--buscar apellidos de trabajadores
create proc spbuscar_trabajador_apellidos
@textobuscar varchar(50)
as
select * from trabajador
where apellidos like @textobuscar +'%' --concatena lo que envio con cualquier otro caracter
go

--buscar numero de documento de trabajadores
create proc spbuscar_trabajador_num_documento
@textobuscar varchar(50)
as
select * from trabajador
where num_documento like @textobuscar +'%' --concatena lo que envio con cualquier otro caracter
go

--insertar trabajador
create proc spinsertar_trabajador
@idtrabajador int output,--la var es auntogenerada no es de entrada sino de salida	
@nombre varchar(20),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@num_documento varchar(8),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar(20),
@usuario varchar(20),
@password varchar(20)
as
insert into trabajador(nombre,apellidos,sexo,fecha_nacimiento,num_documento,direccion,telefono,email,acceso,usuario,password)
values(@nombre,@apellidos,@sexo,@fecha_nacimiento,@num_documento,@direccion,@telefono,@email,@acceso,@usuario,@password)
go

--editar trabajador
create proc speditar_trabajador
@idtrabajador int,	--en editar es de entrada no de salida como en insertar
@nombre varchar(20),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nacimiento date,
@num_documento varchar(8),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar(20),
@usuario varchar(20),
@password varchar(20)
as
update trabajador set nombre=@nombre,apellidos=@apellidos,sexo=@sexo,fecha_nacimiento=@fecha_nacimiento,
num_documento=@num_documento,direccion=@direccion,telefono=@telefono,email=@email,
acceso=@acceso,usuario=@usuario,password=@password
where idtrabajador=@idtrabajador
go

--eliminar trabajador
create proc speliminar_trabajador
@idtrabajador int
as
delete from trabajador
where idtrabajador=@idtrabajador
go

--==========================================================
use [ventas-csharp]
go
--login
create proc splogin
@usuario as varchar(20),
@password varchar(20)
as 
select idtrabajador,apellidos,nombre,acceso 
from trabajador
where usuario=@usuario and password=@password
go

--==========================================================
--AGREGAR COLUMNA ESTADO A LA TABLA INGRESO
use [ventas-csharp]
go

alter table ingreso
add estado varchar(7) not null
go

--mostrar ingreso create proc spmostrar_ingreso
alter proc spmostrar_ingreso
as 
select top 100 i.idingreso,(t.nombre+' '+t.apellidos) as trabajador,
		p.razon_social as proveedor,i.fecha,i.tipo_comprobante,i.serie,
		i.correlativo,i.estado,sum(d.precio_compra*d.stock_inicial) as total 
from detalle_ingreso d inner join ingreso i
on d.idingreso=i.idingreso
inner join proveedor p
on i.idproveedor=p.idproveedor
inner join trabajador t
on i.idtrabajador=t.idtrabajador
group by 
i.idingreso,t.nombre+' '+t.apellidos,
		p.razon_social,i.fecha,i.tipo_comprobante,i.serie,
		i.correlativo,i.estado
order by i.idingreso desc
go

--mostrar ingreso entre fechas
create proc spbuscar_ingreso_fecha
@textobuscar varchar(20),
@textobuscar2 varchar(20)
as
select  i.idingreso,(t.nombre+' '+t.apellidos) as trabajador,
		p.razon_social as proveedor,i.fecha,i.tipo_comprobante,i.serie,
		i.correlativo,i.estado,sum(d.precio_compra*d.stock_inicial) as total 
from detalle_ingreso d inner join ingreso i
on d.idingreso=i.idingreso
inner join proveedor p
on i.idproveedor=p.idproveedor
inner join trabajador t
on i.idtrabajador=t.idtrabajador
group by 
i.idingreso,t.nombre+' '+t.apellidos,
		p.razon_social,i.fecha,i.tipo_comprobante,i.serie,
		i.correlativo,i.estado
having i.fecha>=@textobuscar and i.fecha<=@textobuscar2
go
use [ventas-csharp]
go
--insertar ingreso
create proc insertar_ingreso
@idingreso int=null output,--valor inicial nulo
@idtrabajador int,
@idproveedor int,
@fecha date,
@tipo_comprobante varchar(20),
@serie varchar(4),
@correlativo varchar(7),
@igv decimal(4,2),
@estado varchar(7)
as
insert into ingreso(idtrabajador,idproveedor,fecha,tipo_comprobante,serie,correlativo,igv,estado)
values(@idtrabajador,@idproveedor,@fecha,@tipo_comprobante,@serie,@correlativo,@igv,@estado)
--obtener codigo autogenerado para insertar ese codigo en mis detalles de ingreso
set @idingreso=@@IDENTITY --creo porque al inicio le puse null al idingreso
go

--anular ingreso(no se eliminan simplemente se anulan)
create proc spanular_ingreso
@idingreso int
as
update ingreso set estado='Anulado'
where idingreso=@idingreso
go

--insertar detalle de ingreso
create proc spinsertar_detalle_ingreso
@iddetalle_ingreso int output,
@idingreso int,
@idarticulo int,
@precio_compra money,
@precio_venta money,
@stock_inicial int,
@stock_actual int,
@fecha_produccion date,
@fecha_vencimiento date
as
insert into detalle_ingreso(idingreso,idarticulo,precio_compra,precio_venta,stock_inicial,stock_actual,fecha_produccion,fecha_vencimiento)
values(@idingreso,@idarticulo,@precio_compra,@precio_venta,@stock_inicial,@stock_actual,@fecha_produccion,@fecha_vencimiento)
go
use [ventas-csharp]
go
--mostrar detalle de ingreso
create proc spmostrar_detalle_ingreso
@textobuscar int
as
select d.idarticulo,a.nombre as articulo,d.precio_compra,d.precio_venta,
d.stock_inicial,d.fecha_produccion,d.fecha_vencimiento,(d.stock_inicial*d.precio_compra)as subtotal
from detalle_ingreso d inner join articulo a
on d.idarticulo=a.idarticulo
where d.idingreso=@textobuscar
go


