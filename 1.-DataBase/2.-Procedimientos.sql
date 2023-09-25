use distribuidora
go

/*-------------------------------------------------------------*/

IF OBJECT_ID('dbo.Usp_Proveedor_Obt') IS NOT NULL
DROP PROCEDURE dbo.Usp_Proveedor_Obt
GO

Create procedure dbo.Usp_Proveedor_Obt
as
/*
exec dbo.Usp_Proveedor_Obt
*/

Select
  [IdProveedor]=Pro.IdProveedor
  , [Nombre]=Pro.Nombre
  , [Descripcion]=Pro.Descripcion
from
  dbo.Tb_Proveedor Pro

go

/*-------------------------------------------------------------*/

IF OBJECT_ID('dbo.Usp_Proveedor_Ins') IS NOT NULL
DROP PROCEDURE dbo.Usp_Proveedor_Ins
GO

Create procedure dbo.Usp_Proveedor_Ins
@Nombre nvarchar(50)
, @Descripcion nvarchar(150)
as
/*
exec dbo.Usp_Proveedor_Ins
@nombre='Juan'
,@Descripcion='Juan arquimides'
*/
begin try
	begin tran
	insert into  
	  dbo.Tb_Proveedor
	  (
		Nombre
		,  Descripcion
		)
	  Values
	  (
	  @Nombre
	  , @Descripcion
	  )

	SELECT  @@IDENTITY as [IdProducto]

	commit tran
end try
begin catch
	rollback tran
	select 0
end catch


go
/*-------------------------------------------------------------*/

IF OBJECT_ID('dbo.Usp_TipoProducto_Obt') IS NOT NULL
DROP PROCEDURE dbo.Usp_TipoProducto_Obt
GO

Create procedure dbo.Usp_TipoProducto_Obt
as
/*
exec dbo.Usp_TipoProducto_Obt
*/

Select
  [IdTipoProducto]=Tp.IdTipoProducto
  , [Nombre]=Tp.Nombre
  , [Descripcion]=Tp.Descripcion
from
  dbo.Tb_TipoProducto Tp

go

/*-------------------------------------------------------------*/

IF OBJECT_ID('dbo.Usp_Producto_Ins') IS NOT NULL
DROP PROCEDURE dbo.Usp_Producto_Ins
GO

Create procedure dbo.Usp_Producto_Ins
  @Clave			nvarchar(50)
  , @Nombre		    nvarchar(100) 
  , @Precio			decimal 
  , @IdProveedor	int
  , @IdTipoProducto	int 
  
as
/*
exec Usp_Producto_Ins
@Clave	='pinol01'
, @Nombre='Pinol 360ml'
, @Precio	=35
, @IdProveedor	=1
, @IdTipoProducto=1

*/

begin try
	begin tran
	Insert into 
	  dbo.Tb_Producto
	  (
	  clave
	  , Nombre
	  , EsActivo
	  , Precio
	  , IdProveedor
	  , IdTipoProducto
	  )
	values
	(
	@Clave
	,@Nombre
	,1
	,@Precio
	,@IdProveedor
	,@IdTipoProducto
	)

	SELECT  @@IDENTITY as [IdProducto]

	commit tran
end try
begin catch
	rollback tran
	select 0
end catch

go

/*-------------------------------------------------------------*/

IF OBJECT_ID('dbo.Usp_Producto_Obt') IS NOT NULL
DROP PROCEDURE dbo.Usp_Producto_Obt
GO

Create procedure dbo.Usp_Producto_Obt
as
/*
exec dbo.Usp_Producto_Obt
*/

Select
  [IdProducto]=Prod.IdProducto
  , [IdProveedor]=Prod.IdProveedor
  , [IdTipoProducto]=Prod.IdTipoProducto
  , [Nombre]=Prod.Nombre
  , [Clave]=Prod.clave
  , [EsActivo]=Prod.EsActivo
  , [Precio]=Prod.Precio
from
  dbo.Tb_Producto Prod

go

/*-------------------------------------------------------------*/

IF OBJECT_ID('dbo.Usp_Producto_ObtById') IS NOT NULL
DROP PROCEDURE dbo.Usp_Producto_ObtById
GO

Create procedure dbo.Usp_Producto_ObtById
@IdProducto int
as
/*
exec dbo.Usp_Producto_ObtById
@IdProducto=5
*/

Select
  [IdProducto]=Prod.IdProducto
  , [IdProveedor]=Prod.IdProveedor
  , [IdTipoProducto]=Prod.IdTipoProducto
  , [Nombre]=Prod.Nombre
  , [Clave]=Prod.clave
  , [EsActivo]=Prod.EsActivo
  , [Precio]=Prod.Precio
from
  dbo.Tb_Producto Prod
where
  Prod.IdProducto=@IdProducto

go


/*-------------------------------------------------------------*/

IF OBJECT_ID('dbo.Usp_Producto_Del') IS NOT NULL
DROP PROCEDURE dbo.Usp_Producto_Del
GO

Create procedure dbo.Usp_Producto_Del
@IdProducto int
as
/*
exec dbo.Usp_Producto_Del
@IdProducto=4
*/


begin try
	begin tran
	delete from
	  dbo.Tb_Producto 
	where 
		IdProducto=@IdProducto

	SELECT  @IdProducto as [IdProducto]

	commit tran
end try
begin catch
	rollback tran
	select 0
end catch
go

