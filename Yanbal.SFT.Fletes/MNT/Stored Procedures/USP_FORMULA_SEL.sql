CREATE PROC [MNT].[USP_FORMULA_SEL]
(	
	@CODIGO_FORMULA			INT,
	@CODIGO_UNIDAD_NEGOCIO	INT,
	@CODIGO_PARAMETRO		INT,
	@VALOR					NVARCHAR(255),
	@OPERACION				CHAR(1),
	@FACTOR					DECIMAL(18,4),
	@TIPO_FACTOR			NCHAR(1),
	@ESTADO_REGISTRO		CHAR(1),
	@PageNo					INT = 1,
	@PageSize				INT = -1,
	@SortColumn				NVARCHAR(100) = 'CODIGO_FORMULA',
	@SortOrder				NVARCHAR(4)='ASC'
)
AS
/******************************************************
-- Nombre: [MNT].[USP_FORMULA_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.FORMULA
-- Input:
		@CODIGO_FORMULA:	Parámetro de entrada de tipo int, que representa codigo formula.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@OPERACION:	Parámetro de entrada de tipo char, que representa operacion.
		@FACTOR:	Parámetro de entrada de tipo decimal, que representa factor.
		@TIPO_FACTOR:	Parámetro de entrada de tipo nchar, que representa tipo factor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
		@SortColumn:	Parámetro de entrada de tipo nvarchar, que representa sortcolumn.
		@SortOrder:	Parámetro de entrada de tipo nvarchar, que representa sortorder.

-- Output: Lista de MNT.FORMULA
-- Creado por: GMD
-- Fecha de Creación: 10-09-2014
-- Fecha de Actualización:
20/07/2018	RESTRADA	UNI-43 - 08. PRY 2987 I01 - GAP PYF Colombia: Iteración 02
-- ******************************************************/
DECLARE
@V_CODIGO_PARAMETRO_ESTADO_REGISTRO CHAR(3),
@V_ESTADO_REGISTRO_RELACION			CHAR(1)

SET @V_ESTADO_REGISTRO_RELACION = '1'
SET @V_CODIGO_PARAMETRO_ESTADO_REGISTRO = 'ETR'
BEGIN
DECLARE @lPageNbr INT,
		@lPageSize INT,
		@lSortCol NVARCHAR(20),
		@lFirstRec INT,
		@lLAStRec INT

		SET @lPageNbr = @PageNo
		SET @lPageSize = @PageSize
		SET @lSortCol = LTRIM(RTRIM(@SortColumn))

		SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
		SET @lLAStRec = ( @lPageNbr * @lPageSize + 1 );
	
		WITH CTE_Results
		AS (
	    SELECT ROW_NUMBER() OVER (ORDER BY FRM.CODIGO_FORMULA ASC) AS RowNumber,
        Count(*) over () AS RowsTotal,
		Count(*) over () AS RowId
		,FRM.CODIGO_FORMULA					AS CodigoFormula
		,FRM.CODIGO_UNIDAD_NEGOCIO			AS CodigoUnidadNegocio
		,FRM.CODIGO_PARAMETRO				AS CodigoParametro
		,PMR.CODIGO							AS Codigo
		,PMR.NOMBRE							AS DescripcionParametro
		,FRM.VALOR							AS Valor
		,(SELECT PVV.VALOR
		FROM MNT.F_PARAMETRO_VALOR_LISTA_PARAMETRO_SECCION(FRM.CODIGO_UNIDAD_NEGOCIO,FRM.CODIGO_PARAMETRO,@V_ESTADO_REGISTRO_RELACION,2) PVV
		WHERE PVV.CODIGO = FRM.VALOR)		AS DescripcionValor
		,FRM.OPERACION						AS Operacion
		,FRM.FACTOR							AS Factor
		,FRM.TIPO_FACTOR					AS TipoFactor
		,FRM.ORDEN							AS Orden
		,FRM.ESTADO_REGISTRO				AS EstadoRegistro
		,PVE.VALOR							AS DescripcionEstadoRegistro
		,FRM.OBSERVACION					AS Observacion
		,FRM.VALOR_TIPO_ENVIO				AS ValorTipoEnvio
		,(SELECT PVV.VALOR
		FROM MNT.F_PARAMETRO_VALOR_LISTA_PARAMETRO_SECCION(FRM.CODIGO_UNIDAD_NEGOCIO,9,'1',2) PVV
		WHERE PVV.CODIGO = FRM.VALOR_TIPO_ENVIO)		AS DescripcionTipoEnvio
		,FRM.USUARIO_CREACION				AS UsuarioCreacion
		,FRM.FECHA_CREACION					AS FechaCreacion
		,FRM.TERMINAL_CREACION				AS TerminalCreacion
		,FRM.USUARIO_MODIFICACION			AS UsuarioModificacion
		,FRM.FECHA_MODIFICACION				AS FechaModificacion
		,FRM.TERMINAL_MODIFICACION			AS TerminalModificacion
		FROM MNT.FORMULA FRM
		LEFT JOIN MNT.PARAMETRO PMR ON PMR.CODIGO_PARAMETRO = FRM.CODIGO_PARAMETRO
		LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_ESTADO_REGISTRO,@V_ESTADO_REGISTRO_RELACION,2) PVE ON PVE.CODIGO = FRM.ESTADO_REGISTRO
		WHERE	(@CODIGO_FORMULA IS NULL			OR FRM.CODIGO_FORMULA			= @CODIGO_FORMULA)
		AND		(@CODIGO_UNIDAD_NEGOCIO IS NULL		OR FRM.CODIGO_UNIDAD_NEGOCIO	= @CODIGO_UNIDAD_NEGOCIO)
		AND		(@CODIGO_PARAMETRO IS NULL			OR FRM.CODIGO_PARAMETRO			= @CODIGO_PARAMETRO)
		AND		(@VALOR IS NULL						OR FRM.VALOR					= @VALOR)
		AND		(@OPERACION IS NULL					OR FRM.OPERACION				= @OPERACION)
		AND		(@FACTOR IS NULL					OR FRM.FACTOR					= @FACTOR)
		AND		(@TIPO_FACTOR IS NULL				OR FRM.TIPO_FACTOR				= @TIPO_FACTOR)
		AND		(@ESTADO_REGISTRO IS NULL			OR FRM.ESTADO_REGISTRO			= @ESTADO_REGISTRO)
		)
		SELECT * FROM CTE_Results
		WHERE @PageSize < 0 OR (RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
		ORDER BY RowNumber ASC;	
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[FORMULA].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL';

