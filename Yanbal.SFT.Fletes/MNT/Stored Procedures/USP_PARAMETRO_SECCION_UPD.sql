CREATE PROCEDURE [MNT].[USP_PARAMETRO_SECCION_UPD]
(
	@CODIGO_PARAMETRO					INT,
	@CODIGO_SECCION						INT,
	@NOMBRE								NVARCHAR(100),
	@INDICADOR_SOLO_LECTURA				BIT,
	@INDICADOR_OBLIGATORIO				BIT,
	@TIPO_SECCION						CHAR(3),
	@ESTADO_REGISTRO					CHAR(1),
	@OBSERVACION						NVARCHAR(255),
	@USUARIO_MODIFICACION				NVARCHAR(50),
	@TERMINAL_MODIFICACION				NVARCHAR(50),
	@CODIGO_UNIDAD_NEGOCIO				INT
)
AS
/************************************************
-- Nombre: [MNT].[USP_PARAMETRO_SECCION_UPD] 
-- Propósito: Actualiza el registro de la tabla MNT.PARAMETRO_SECCION
-- Input: 
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO_SECCION:	Parámetro de entrada de tipo int, que representa codigo seccion.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@INDICADOR_SOLO_LECTURA:	Parámetro de entrada de tipo bit, que representa indicador solo lectura.
		@INDICADOR_OBLIGATORIO:	Parámetro de entrada de tipo bit, que representa indicador obligatorio.
		@TIPO_SECCION:	Parámetro de entrada de tipo char, que representa tipo seccion.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@OBSERVACION:	Parámetro de entrada de tipo nvarchar, que representa observacion.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
-- Output: 
-- Creado por: GMD
-- Create Creación: 20-08-2014
-- Fecha Actualización:
-- ***********************************************/
BEGIN
	UPDATE MNT.PARAMETRO_SECCION
		SET CODIGO_PARAMETRO		= @CODIGO_PARAMETRO,
			CODIGO_SECCION			= @CODIGO_SECCION,
			NOMBRE					= @NOMBRE,
			INDICADOR_SOLO_LECTURA	= @INDICADOR_SOLO_LECTURA,
			INDICADOR_OBLIGATORIO	= @INDICADOR_OBLIGATORIO,
			TIPO_SECCION			= @TIPO_SECCION,
			ESTADO_REGISTRO			= @ESTADO_REGISTRO,
			OBSERVACION				= @OBSERVACION,
			USUARIO_MODIFICACION	= @USUARIO_MODIFICACION,
			FECHA_MODIFICACION		= GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO),
			TERMINAL_MODIFICACION   = @TERMINAL_MODIFICACION
	WHERE CODIGO_PARAMETRO		=	@CODIGO_PARAMETRO
	AND CODIGO_SECCION			=	@CODIGO_SECCION
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Actualiza el registro de la tabla [MNT].[PARAMETRO_SECCION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD';

