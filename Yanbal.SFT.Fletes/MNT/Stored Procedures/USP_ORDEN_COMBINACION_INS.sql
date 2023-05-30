CREATE PROCEDURE [MNT].[USP_ORDEN_COMBINACION_INS]
(
	@CODIGO_ORDEN_COMBINACION	INT,
	@CODIGO_UNIDAD_NEGOCIO		INT,
	@CODIGO_PARAMETRO			INT,
	@ORDEN						TINYINT,
	@ESTADO_REGISTRO			CHAR(1),
	@USUARIO_CREACION			NVARCHAR(50),
	@TERMINAL_CREACION			NVARCHAR(50)
)
AS
/**************************************************
-- Nombre: [MNT].[USP_ORDEN_COMBINACION_INS]
-- Propósito: Inserta un registro en la tabla MNT.ORDEN_COMBINACION
-- Input: 
		@CODIGO_ORDEN_COMBINACION:	Parámetro de entrada de tipo int, que representa codigo orden combinacion.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@ORDEN:	Parámetro de entrada de tipo tinyint, que representa orden.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.

-- Output: 
-- Creado por: GMD
-- Fecha de Creación: 10-09-2014
-- Fecha de Actualización:
-- **************************************************/
BEGIN
	INSERT INTO MNT.ORDEN_COMBINACION
	(
		CODIGO_ORDEN_COMBINACION,
		CODIGO_UNIDAD_NEGOCIO,
		CODIGO_PARAMETRO,
		ORDEN,
		ESTADO_REGISTRO,
		USUARIO_CREACION,
		FECHA_CREACION,
		TERMINAL_CREACION
	)
	VALUES
	(
		@CODIGO_ORDEN_COMBINACION,
		@CODIGO_UNIDAD_NEGOCIO,
		@CODIGO_PARAMETRO,
		@ORDEN,
		@ESTADO_REGISTRO,
		@USUARIO_CREACION,
		GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO),
		@TERMINAL_CREACION
	)
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[ORDEN_COMBINACION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_INS';

