CREATE PROCEDURE [MNT].[USP_PARAMETRO_SECCION_SEL]
(
	@CODIGO_UNIDAD_NEGOCIO	INT,
	@CODIGO_PARAMETRO		INT,
	@CODIGO_SECCION			INT,
	@NOMBRE					NVARCHAR(100),
	@INDICADOR_SOLO_LECTURA	BIT,
	@INDICADOR_OBLIGATORIO	BIT,
	@TIPO_SECCION			CHAR(3),
	@ESTADO_REGISTRO		CHAR(1),
	@PageNo					INT = 1,
	@PageSize				INT = -1,
	@SortColumn				NVARCHAR(100) = 'NOMBRE',
	@SortOrder				NVARCHAR(4) = 'ASC'
)
AS
/**************************************************
-- Nombre: [MNT].[USP_PARAMETRO_SECCION_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.USP_PARAMETRO_SECCION
-- Input:
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO_SECCION:	Parámetro de entrada de tipo int, que representa codigo seccion.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@INDICADOR_SOLO_LECTURA:	Parámetro de entrada de tipo bit, que representa indicador solo lectura.
		@INDICADOR_OBLIGATORIO:	Parámetro de entrada de tipo bit, que representa indicador obligatorio.
		@TIPO_SECCION:	Parámetro de entrada de tipo char, que representa tipo seccion.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
		@SortColumn:	Parámetro de entrada de tipo nvarchar, que representa sortcolumn.
		@SortOrder:	Parámetro de entrada de tipo nvarchar, que representa sortorder.

-- Output: Lista de MNT.USP_PARAMETRO_SECCION
-- Creado por: GMD
-- Create Creación: 20-08-2014
-- Fecha Actualización:
-- ***************************************************/
DECLARE
@V_CODIGO_PARAMETRO_ESTADO_REGISTRO CHAR(3),
@V_CODIGO_PARAMETRO_TIPO_SECCION CHAR(3),
@V_ESTADO_REGISTRO_RELACION			CHAR(1)

SET @V_ESTADO_REGISTRO_RELACION = '1'
SET @V_CODIGO_PARAMETRO_ESTADO_REGISTRO = 'ETR'
SET @V_CODIGO_PARAMETRO_TIPO_SECCION = 'TSC'
BEGIN
	SELECT	PS.CODIGO_PARAMETRO					AS CodigoParametro,
			PS.CODIGO_SECCION					AS CodigoSeccion,
			PS.NOMBRE							AS Nombre,
			PS.INDICADOR_SOLO_LECTURA			AS IndicadorSoloLectura,
			PS.INDICADOR_OBLIGATORIO			AS IndicadorObligatorio,
			PS.INDICADOR_CREACION				AS IndicadorCreacion,
			PS.INDICADOR_RANGO					AS IndicadorRango,
			PS.TIPO_SECCION						AS TipoSeccion,
			PVLTS.VALOR							AS DescripcionTipoSeccion,
			PS.ESTADO_REGISTRO					AS EstadoRegistro,
			PVLER.VALOR							AS DescripcionEstadoRegistro,
			PS.OBSERVACION						AS Observacion,
			PS.USUARIO_CREACION					AS UsuarioCreacion,
			PS.FECHA_CREACION					AS FechaCreacion,
			PS.TERMINAL_CREACION				AS TerminalCreacion,
			PS.USUARIO_MODIFICACION				AS UsuarioModificacion,
			PS.FECHA_MODIFICACION				AS FechaModificacion,
			PS.TERMINAL_MODIFICACION			AS TerminalModificacion
	FROM MNT.PARAMETRO_SECCION PS
	LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_ESTADO_REGISTRO,@V_ESTADO_REGISTRO_RELACION,2) PVLER ON PVLER.CODIGO = PS.ESTADO_REGISTRO
	LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_TIPO_SECCION,@V_ESTADO_REGISTRO_RELACION,2) PVLTS ON PVLTS.CODIGO = PS.TIPO_SECCION
	WHERE (@CODIGO_PARAMETRO IS NULL				OR (PS.CODIGO_PARAMETRO			= @CODIGO_PARAMETRO))
	AND   (@CODIGO_SECCION IS NULL					OR (PS.CODIGO_SECCION			= @CODIGO_SECCION))
	AND   (@NOMBRE IS NULL							OR (UPPER(PS.NOMBRE)			LIKE '%' + UPPER(@NOMBRE) + '%'))
	AND   (@INDICADOR_SOLO_LECTURA IS NULL			OR (PS.INDICADOR_SOLO_LECTURA	= @INDICADOR_SOLO_LECTURA))
	AND	  (@INDICADOR_OBLIGATORIO IS NULL			OR (PS.INDICADOR_OBLIGATORIO	= @INDICADOR_OBLIGATORIO))
	AND   (@TIPO_SECCION IS NULL					OR (PS.TIPO_SECCION)			= @TIPO_SECCION)
	AND   (@ESTADO_REGISTRO IS NULL					OR (PS.ESTADO_REGISTRO			= @ESTADO_REGISTRO))
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[USP_PARAMETRO_SECCION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL';

