CREATE PROCEDURE [MNT].[USP_PARAMETRO_VALOR_INS]
(
	@CODIGO_UNIDAD_NEGOCIO INT,
	@CODIGO_PARAMETRO int,
	@CODIGO_SECCION int,
	@CODIGO_VALOR int,
	@VALOR nvarchar(255),
	@ESTADO_REGISTRO char(1),
	@USUARIO_CREACION nvarchar(50),
	@TERMINAL_CREACION nvarchar(50) 
)
AS
/*******************************************************
-- Nombre: [MNT].[USP_PARAMETRO_VALOR_INS] 
-- Propósito: Inserta un registro en la tabla MNT.PARAMETRO_VALOR
-- Input: 
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO_SECCION:	Parámetro de entrada de tipo int, que representa codigo seccion.
		@CODIGO_VALOR:	Parámetro de entrada de tipo int, que representa codigo valor.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.

-- Output: 
-- Creado por: GMD
-- Create Creación: 20-08-2014
-- Fecha Actualización:
-- ******************************************************/
DECLARE @ESTADO_ACTIVO CHAR(1) ='1'
BEGIN
	INSERT INTO MNT.PARAMETRO_VALOR
	(
			CODIGO_UNIDAD_NEGOCIO ,
			CODIGO_PARAMETRO   ,
			CODIGO_SECCION ,
			CODIGO_VALOR   ,
			VALOR   ,
			ESTADO_REGISTRO ,
			USUARIO_CREACION  ,
			FECHA_CREACION   ,
			TERMINAL_CREACION			
	)
	VALUES
	(
			@CODIGO_UNIDAD_NEGOCIO,
			@CODIGO_PARAMETRO,
			@CODIGO_SECCION,
			@CODIGO_VALOR,
			@VALOR,
			@ESTADO_REGISTRO,
			@USUARIO_CREACION ,
			GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO),
			@TERMINAL_CREACION
	)
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[PARAMETRO_VALOR].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_INS';

