CREATE PROCEDURE [MNT].[USP_COMBINACION_PARAMETRO_UPD]
(
	@CODIGO_COMBINACION_PARAMETRO	INT,
	@CODIGO_COMBINACION				INT,
	@CODIGO_PARAMETRO				INT,
	@ORDEN_COMBINACION				TINYINT,
	@VALOR							NVARCHAR(255),
	@ESTADO_REGISTRO				CHAR(1),
	@OBSERVACION					NVARCHAR(255),	
	@USUARIO_MODIFICACION			NVARCHAR(50),
	@TERMINAL_MODIFICACION			NVARCHAR(50),
	@CODIGO_UNIDAD_NEGOCIO			INT
)
AS
/***********************************************
-- Nombre: MNT.USP_COMBINACION_PARAMETRO_UPD
-- Propósito: Actualiza el registro de la tabla MNT.COMBINACION_PARAMETRO
-- Input:
		@CODIGO_COMBINACION_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo combinacion parametro.
		@CODIGO_COMBINACION:	Parámetro de entrada de tipo int, que representa codigo combinacion.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@ORDEN_COMBINACION:	Parámetro de entrada de tipo tinyint, que representa orden combinacion.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@OBSERVACION:	Parámetro de entrada de tipo nvarchar, que representa observacion.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.

-- Output: Lista de MNT.COMBINACION_PARAMETRO
-- Creado por: GMD
-- Fecha de Creación: 04-09-2014
-- Fecha de Actualización:
-- ************************************************/
SET NOCOUNT OFF
UPDATE [MNT].[COMBINACION_PARAMETRO]
   SET CODIGO_COMBINACION = @CODIGO_COMBINACION
	  ,ORDEN_COMBINACION = ISNULL(@ORDEN_COMBINACION,ORDEN_COMBINACION)
	  ,VALOR = ISNULL(@VALOR,VALOR)
      ,OBSERVACION = @OBSERVACION
      ,ESTADO_REGISTRO = @ESTADO_REGISTRO
      ,USUARIO_MODIFICACION = @USUARIO_MODIFICACION
	  ,FECHA_MODIFICACION = GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO)
      ,TERMINAL_MODIFICACION = @TERMINAL_MODIFICACION
 WHERE CODIGO_COMBINACION = @CODIGO_COMBINACION
 AND   CODIGO_PARAMETRO = @CODIGO_PARAMETRO
 AND   (@CODIGO_COMBINACION_PARAMETRO IS NULL OR CODIGO_COMBINACION_PARAMETRO = @CODIGO_COMBINACION_PARAMETRO)

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Actualiza el registro de la tabla [MNT].[COMBINACION_PARAMETRO].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD';

