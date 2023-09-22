/*
DROP DATABASE IF EXISTS Distribuidora
create DataBase  Distribuidora
*/
Use Distribuidora
go 

if object_id('FK_Proveedor') is not null
	ALTER TABLE dbo.Tb_Productor
	DROP CONSTRAINT FK_Proveedor;
GO
go

if object_id('FK_TipoProducto') is not null
	ALTER TABLE dbo.Tb_TipoProducto
	DROP CONSTRAINT FK_TipoProducto;
GO
go


if object_id('Tb_TipoProducto') is not null
  drop table Tb_TipoProducto
go

create table Tb_TipoProducto(
  IdTipoProducto int Identity(1,1) primary key
  , Nombre nvarchar(50)
  , Descripcion nvarchar(150)
)

if object_id('Tb_Proveedor') is not null
  drop table Tb_Proveedor
go

create table Tb_Proveedor(
  IdProveedor int Identity(1,1) primary key
  , Nombre nvarchar(50)
  , Descripcion nvarchar(150)
)

if object_id('Tb_Productor') is not null
  drop table Tb_Productor
go

create table Tb_Productor(
IdProducto int Identity(1,1) primary key
, clave nvarchar(150) not null
, Nombre nvarchar(150) not null
, EsActivo bit default 0
, Precio decimal  default 0.0
, IdProveedor int 
, IdTipoProducto int
, CONSTRAINT FK_Proveedor FOREIGN KEY (IdProveedor) 
  REFERENCES Tb_Proveedor(IdProveedor)
, CONSTRAINT FK_TipoProducto FOREIGN KEY (IdTipoProducto) 
  REFERENCES Tb_TipoProducto(IdTipoProducto)
)