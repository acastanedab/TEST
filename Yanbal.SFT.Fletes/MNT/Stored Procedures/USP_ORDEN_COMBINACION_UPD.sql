CREATE PROCEDURE [MNT].[USP_ORDEN_COMBINACION_UPD]
(
	@CODIGO_ORDEN_COMBINACION	INT,
	@CODIGO_UNIDAD_NEGOCIO		INT,
	@OBSERVACION				NVARCHAR(255),
	@ESTADO_REGISTRO			CHAR(1),
	@USUARIO_MODIFICACION		NVARCHAR(50),
	@TERMINAL_MODIFICACION		NVARCHAR(50)
)
AS
/* ================================================
-- Nombre: [MNT].[USP_ORDEN_COMBINACION_UPD]
-- Propósito: Actualiza el registro de la tabla MNT.ORDEN_COMBINACION
-- Input: 
		@CODIGO_ORDEN_COMBINACION:	Parámetro de entrada de tipo int, que representa codigo orden combinacion.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@OBSERVACION:	Parámetro de entrada de tipo nvarchar, que representa observacion.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.

-- Output: 
-- Creado por: GMD
-- Fecha de Creación: 10-09-2014
-- Fecha de Actualización:
-- =============================================
*/
BEGIN
	UPDATE MNT.ORDEN_COMBINACION
	SET ESTADO_REGISTRO			= @ESTADO_REGISTRO,
		USUARIO_MODIFICACION	= @USUARIO_MODIFICACION,
		FECHA_MODIFICACION		= GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO),
		TERMINAL_MODIFICACION	= @TERMINAL_MODIFICACION
	WHERE CODIGO_ORDEN_COMBINACION  = @CODIGO_ORDEN_COMBINACION
	AND	  CODIGO_UNIDAD_NEGOCIO		= @CODIGO_UNIDAD_NEGOCIO
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Actualiza el registro de la tabla [MNT].[ORDEN_COMBINACION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_UPD';

