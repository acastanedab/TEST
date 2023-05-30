CREATE PROCEDURE [MNT].[USP_COMBINACION_PARAMETRO_INS]
(
	@CODIGO_COMBINACION_PARAMETRO	INT,
	@CODIGO_COMBINACION				INT,
	@CODIGO_PARAMETRO				INT,
	@ORDEN_COMBINACION				TINYINT,
	@VALOR							NVARCHAR(255),
	@ESTADO_REGISTRO				CHAR(1),
	@USUARIO_CREACION				NVARCHAR(50),
	@TERMINAL_CREACION				NVARCHAR(50),
	@CODIGO_UNIDAD_NEGOCIO			INT
)
AS
/*********************************************************
-- Nombre: [MNT].[USP_COMBINACION_PARAMETRO_INS] 
-- Propósito: Inserta un registro en la tabla MNT.COMBINACION_PARAMETRO
-- Input: 
		@CODIGO_COMBINACION_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo combinacion parametro.
		@CODIGO_COMBINACION:	Parámetro de entrada de tipo int, que representa codigo combinacion.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@ORDEN_COMBINACION:	Parámetro de entrada de tipo tinyint, que representa orden combinacion.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.

-- Output: 
-- Creado por: GMD
-- Fecha de Creación: 04-09-2014
-- Fecha de Actualización:
-- ******************************************************/
BEGIN
	INSERT INTO [MNT].[COMBINACION_PARAMETRO]
           ([CODIGO_COMBINACION_PARAMETRO]
           ,[CODIGO_COMBINACION]
		   ,[CODIGO_PARAMETRO]
           ,[ORDEN_COMBINACION]
		   ,[VALOR]
           ,[ESTADO_REGISTRO]
           ,[USUARIO_CREACION]
           ,[FECHA_CREACION]
           ,[TERMINAL_CREACION])
     VALUES
           (@CODIGO_COMBINACION_PARAMETRO
		   ,@CODIGO_COMBINACION
		   ,@CODIGO_PARAMETRO
           ,@ORDEN_COMBINACION
		   ,@VALOR
           ,@ESTADO_REGISTRO
           ,@USUARIO_CREACION
           ,GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO)
           ,@TERMINAL_CREACION
	)
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[COMBINACION_PARAMETRO].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_INS';

