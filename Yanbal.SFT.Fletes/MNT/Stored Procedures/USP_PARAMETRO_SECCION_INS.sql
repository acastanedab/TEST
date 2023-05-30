CREATE PROCEDURE [MNT].[USP_PARAMETRO_SECCION_INS]
(
	@CODIGO_PARAMETRO					INT,
	@CODIGO_SECCION						INT,
	@NOMBRE								NVARCHAR(100),
	@INDICADOR_SOLO_LECTURA				BIT,
	@INDICADOR_OBLIGATORIO				BIT,
	@INDICADOR_RANGO					char(1),
	@INDICADOR_CREACION					BIT,
	@TIPO_SECCION						CHAR(3),
	@ESTADO_REGISTRO					CHAR(1),
	@USUARIO_CREACION					NVARCHAR(50),
	@TERMINAL_CREACION					NVARCHAR(50),
	@CODIGO_UNIDAD_NEGOCIO				INT
)
AS
/**********************************************
-- Nombre: [MNT].[USP_PARAMETRO_SECCION_INS] 
-- Propósito: Inserta un registro en la tabla MNT.PARAMETRO_SECCION
-- Input: 
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO_SECCION:	Parámetro de entrada de tipo int, que representa codigo seccion.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@INDICADOR_SOLO_LECTURA:	Parámetro de entrada de tipo bit, que representa indicador solo lectura.
		@INDICADOR_OBLIGATORIO:	Parámetro de entrada de tipo bit, que representa indicador obligatorio.
		@INDICADOR_RANGO:	Parámetro de entrada de tipo char, que representa indicador rango.
		@INDICADOR_CREACION:	Parámetro de entrada de tipo bit, que representa indicador creacion.
		@TIPO_SECCION:	Parámetro de entrada de tipo char, que representa tipo seccion.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.

-- Output: 
-- Creado por: GMD
-- Create Creación: 20-08-2014
-- Fecha Actualización:
-- **********************************************/
BEGIN
	INSERT INTO MNT.PARAMETRO_SECCION
	(
		[CODIGO_PARAMETRO],
		[CODIGO_SECCION],
		[NOMBRE],
		[INDICADOR_SOLO_LECTURA],
		[INDICADOR_OBLIGATORIO],
		[INDICADOR_RANGO],
		[INDICADOR_CREACION],
		[TIPO_SECCION],
		[ESTADO_REGISTRO],
		[USUARIO_CREACION],
		[FECHA_CREACION],
		[TERMINAL_CREACION]
	)
	VALUES
	(
		@CODIGO_PARAMETRO,
		@CODIGO_SECCION,
		@NOMBRE,
		@INDICADOR_SOLO_LECTURA,
		@INDICADOR_OBLIGATORIO,
		@INDICADOR_RANGO,
		@INDICADOR_CREACION,
		@TIPO_SECCION,
		@ESTADO_REGISTRO,
		@USUARIO_CREACION,
		GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO),
		@TERMINAL_CREACION
	)
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[PARAMETRO_SECCION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS';

