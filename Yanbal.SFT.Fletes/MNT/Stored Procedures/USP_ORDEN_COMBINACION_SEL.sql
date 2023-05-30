 CREATE PROCEDURE [MNT].[USP_ORDEN_COMBINACION_SEL]
(
	@CODIGO_ORDEN_COMBINACION	INT,
	@CODIGO_UNIDAD_NEGOCIO		INT,
	@CODIGO_PARAMETRO			INT,
	@CODIGO						CHAR(3),
	@ORDEN						TINYINT,
	@ESTADO_REGISTRO			CHAR(1),
	@PageNo						INT = 1,
	@PageSize					INT = -1,
	@SortColumn					NVARCHAR(100) = 'CodigoOrdenCombinacion',
	@SortOrder					NVARCHAR(4)='ASC'
)
AS
/* ================================================
-- Nombre: [MNT].[USP_ORDEN_COMBINACION_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.ORDEN_COMBINACION
-- Input:
		@CODIGO_ORDEN_COMBINACION:	Parámetro de entrada de tipo int, que representa codigo orden combinacion.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO:	Parámetro de entrada de tipo char, que representa codigo.
		@ORDEN:	Parámetro de entrada de tipo tinyint, que representa orden.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
		@SortColumn:	Parámetro de entrada de tipo nvarchar, que representa sortcolumn.
		@SortOrder:	Parámetro de entrada de tipo nvarchar, que representa sortorder.

-- Output: 
-- Creado por: GMD
-- Create Creación: 23-09-2014
-- Fecha Actualización:
-- =============================================*/
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
	    SELECT ROW_NUMBER() OVER (ORDER BY OC.ORDEN ASC) AS RowNumber,
        Count(*) over () AS RowsTotal,
		Count(*) over () AS RowId,
		OC.[CODIGO_ORDEN_COMBINACION]			AS CodigoOrdenCombinacion
		,OC.[CODIGO_UNIDAD_NEGOCIO]				AS CodigoUnidadNegocio
		,OC.[CODIGO_PARAMETRO]					AS CodigoParametro
		,PA.CODIGO								AS Codigo
		,PA.NOMBRE								AS NombreParametro
		,OC.[ORDEN]								AS Orden
		,OC.[OBSERVACION]						AS Observacion
		,OC.[ESTADO_REGISTRO]					AS EstadoRegistro
		,PVLER.VALOR							AS DescripcionEstadoRegistro
		,OC.[USUARIO_CREACION]					AS UsuarioCreacion
		,OC.[FECHA_CREACION]					AS FechaCreacion
		,OC.[TERMINAL_CREACION]					AS TerminalCreacion
		,OC.[USUARIO_MODIFICACION]				AS UsuarioMoficacion
		,OC.[FECHA_MODIFICACION]				AS FechaModificacion
		,OC.[TERMINAL_MODIFICACION]				AS TerminalModificacion
	FROM [MNT].[ORDEN_COMBINACION] OC
	INNER JOIN MNT.PARAMETRO PA				ON PA.CODIGO_PARAMETRO			=	OC.CODIGO_PARAMETRO			AND PA.ESTADO_REGISTRO	=	@V_ESTADO_REGISTRO_RELACION
	INNER JOIN MNT.UNIDAD_NEGOCIO UN		ON UN.CODIGO_UNIDAD_NEGOCIO		=	OC.CODIGO_UNIDAD_NEGOCIO	AND UN.ESTADO_REGISTRO	=	@V_ESTADO_REGISTRO_RELACION	
	LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_ESTADO_REGISTRO,@V_ESTADO_REGISTRO_RELACION,2) PVLER ON PVLER.CODIGO = OC.ESTADO_REGISTRO
	WHERE	(@CODIGO_ORDEN_COMBINACION IS NULL	OR	OC.CODIGO_ORDEN_COMBINACION = @CODIGO_ORDEN_COMBINACION)
		AND (@CODIGO_UNIDAD_NEGOCIO IS NULL		OR	OC.CODIGO_UNIDAD_NEGOCIO	= @CODIGO_UNIDAD_NEGOCIO)	
		AND	(@CODIGO_PARAMETRO IS NULL			OR	OC.CODIGO_PARAMETRO			= @CODIGO_PARAMETRO)
		AND	(@CODIGO IS NULL					OR	PA.CODIGO					= @CODIGO)
		AND (@ORDEN	IS NULL						OR  OC.ORDEN					= @ORDEN)
		AND (@ESTADO_REGISTRO	IS NULL			OR  OC.ESTADO_REGISTRO			= @ESTADO_REGISTRO)
	)
	SELECT * FROM CTE_Results
	WHERE @PageSize < 0 OR (RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
	ORDER BY RowNumber ASC;	
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[ORDEN_COMBINACION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL';

