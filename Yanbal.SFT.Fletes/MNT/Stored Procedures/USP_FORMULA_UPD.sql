CREATE PROCEDURE [MNT].[USP_FORMULA_UPD]
(
	@CODIGO_FORMULA			INT,
	@CODIGO_UNIDAD_NEGOCIO	INT,
	@CODIGO_PARAMETRO		INT,
	@VALOR					NVARCHAR(255),
	@OPERACION				CHAR(1),
	@FACTOR					DECIMAL(18,4),
	@TIPO_FACTOR			CHAR(1),
	@ORDEN					TINYINT,
	@OBSERVACION			NVARCHAR(255),
	@VALOR_TIPO_ENVIO		NVARCHAR(255),
	@ESTADO_REGISTRO		CHAR(1),
	@USUARIO_MODIFICACION	NVARCHAR(50),
	@TERMINAL_MODIFICACION	NVARCHAR(50)
)
AS
/* ================================================
-- Nombre: [MNT].[USP_FORMULA_UPD] 
-- Propósito: Actualiza el registro de la tabla MNT.FORMULA
-- Input: 
		@CODIGO_FORMULA:	Parámetro de entrada de tipo int, que representa codigo formula.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@OPERACION:	Parámetro de entrada de tipo char, que representa operacion.
		@FACTOR:	Parámetro de entrada de tipo decimal, que representa factor.
		@TIPO_FACTOR:	Parámetro de entrada de tipo bit, que representa tipo factor.
		@ORDEN:	Parámetro de entrada de tipo tinyint, que representa orden.
		@OBSERVACION:	Parámetro de entrada de tipo nvarchar, que representa observacion.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
-- Output: 
-- Creado por: GMD
-- Fecha de Creación: 11-09-2014
-- Fecha de Actualización: 27/07/2018
20/07/2018	RESTRADA	UNI-43 - 08. PRY 2987 I01 - GAP PYF Colombia: Iteración 02
-- =============================================
*/
BEGIN
	UPDATE MNT.FORMULA
	SET  CODIGO_PARAMETRO		= (CASE WHEN @CODIGO_PARAMETRO  IS NULL THEN CODIGO_PARAMETRO	ELSE @CODIGO_PARAMETRO END)
		,VALOR					= (CASE WHEN @VALOR  IS NULL			THEN VALOR				ELSE @VALOR END)
		,OPERACION				= (CASE WHEN @OPERACION  IS NULL		THEN OPERACION			ELSE @OPERACION END)
		,FACTOR					= (CASE WHEN @FACTOR  IS NULL			THEN FACTOR				ELSE @FACTOR END)
		,TIPO_FACTOR			= (CASE WHEN @TIPO_FACTOR  IS NULL		THEN TIPO_FACTOR		ELSE @TIPO_FACTOR END)
		,ORDEN					= (CASE WHEN @ORDEN  IS NULL			THEN ORDEN				ELSE @ORDEN END)
		,VALOR_TIPO_ENVIO		= @VALOR_TIPO_ENVIO
		,OBSERVACION			= @OBSERVACION
		,ESTADO_REGISTRO		= @ESTADO_REGISTRO
		,USUARIO_MODIFICACION	= @USUARIO_MODIFICACION
		,FECHA_MODIFICACION		= GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO)
		,TERMINAL_MODIFICACION	= @TERMINAL_MODIFICACION
	WHERE	CODIGO_FORMULA			= @CODIGO_FORMULA
	AND		CODIGO_UNIDAD_NEGOCIO	= @CODIGO_UNIDAD_NEGOCIO
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Actualiza el registro de la tabla [MNT].[FORMULA].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD';

