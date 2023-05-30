CREATE PROC [MNT].[USP_COMBINACION_SEL]
(	
	@CODIGO_UNIDAD_NEGOCIO				INT,
	@CODIGO_COMBINACION					INT,
	@IMPORTE_FLETE						DECIMAL(18, 4),
	@CODIGO_PARAMETRO					INT,
	@VALOR								NVARCHAR(255),
	@ESTADO_REGISTRO					CHAR(1),
	@PageNo								INT = 1,
	@PageSize							INT = -1,
	@SortColumn							NVARCHAR(100) = 'CODIGO_COMBINACION',
	@SortOrder							NVARCHAR(4)='ASC'
)
AS
/* ================================================
-- Nombre: [MNT].[USP_COMBINACION_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.COMBINACION
-- Input:
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_COMBINACION:	Parámetro de entrada de tipo int, que representa codigo combinacion.
		@IMPORTE_FLETE:	Parámetro de entrada de tipo decimal, que representa importe flete.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
		@SortColumn:	Parámetro de entrada de tipo nvarchar, que representa sortcolumn.
		@SortOrder:	Parámetro de entrada de tipo nvarchar, que representa sortorder.

-- Output: Lista de MNT.COMBINACION
-- Creado por: GMD
-- Create Creación: 01-09-2014
-- Fecha Actualización:
-- =============================================
*/
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
	    SELECT ROW_NUMBER() OVER (ORDER BY CM.[CODIGO_COMBINACION] ASC) AS RowNumber,
        Count(*) over () AS RowsTotal,
		Count(*) over () AS RowId
		,CM.CODIGO_COMBINACION													AS CodigoCombinacion
		,CM.CODIGO_UNIDAD_NEGOCIO												AS CodigoUnidadNegocio
		,CM.IMPORTE_FLETE														AS ImporteFlete
		,CM.ESTADO_REGISTRO														AS EstadoRegistro
		,MNT.F_OBTENER_COMBINACION(CM.CODIGO_COMBINACION,@CODIGO_UNIDAD_NEGOCIO)AS Combinacion
		,PVLER.VALOR															AS DescripcionEstadoRegistro
		,CM.OBSERVACION															AS Observacion
		,CM.USUARIO_CREACION													AS UsuarioCreacion
		,CM.FECHA_CREACION														AS FechaCreacion
		,CM.TERMINAL_CREACION													AS TerminalCreacion
		,CM.USUARIO_MODIFICACION												AS UsuarioModificacion
		,CM.FECHA_MODIFICACION													AS FechaModificacion
		,CM.TERMINAL_MODIFICACION												AS TerminalModificacion		
		FROM MNT.COMBINACION CM
		LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_ESTADO_REGISTRO,@V_ESTADO_REGISTRO_RELACION,2) PVLER ON PVLER.CODIGO = CM.ESTADO_REGISTRO

		WHERE (@CODIGO_UNIDAD_NEGOCIO IS NULL				OR CM.CODIGO_UNIDAD_NEGOCIO				= @CODIGO_UNIDAD_NEGOCIO)
		AND	  (@CODIGO_COMBINACION IS NULL					OR CM.CODIGO_COMBINACION				= @CODIGO_COMBINACION)
		AND   (@IMPORTE_FLETE IS NULL						OR CM.IMPORTE_FLETE						= @IMPORTE_FLETE)
		AND   (@ESTADO_REGISTRO IS NULL						OR CM.ESTADO_REGISTRO					= @ESTADO_REGISTRO)
		AND   (@ESTADO_REGISTRO IS NULL						OR CM.ESTADO_REGISTRO					= @ESTADO_REGISTRO)
		AND   ((@CODIGO_PARAMETRO IS NULL OR @CODIGO_PARAMETRO = '') OR @CODIGO_PARAMETRO			= ANY (SELECT CPA.CODIGO_PARAMETRO FROM MNT.COMBINACION_PARAMETRO CPA WHERE CPA.CODIGO_COMBINACION = CM.CODIGO_COMBINACION AND CPA.ESTADO_REGISTRO = @V_ESTADO_REGISTRO_RELACION))
		AND   ((@VALOR IS NULL OR @VALOR = '')						 OR @VALOR						= ANY (SELECT CPA.VALOR FROM MNT.COMBINACION_PARAMETRO CPA WHERE CPA.CODIGO_COMBINACION = CM.CODIGO_COMBINACION AND CPA.ESTADO_REGISTRO = @V_ESTADO_REGISTRO_RELACION))
		)
		SELECT * FROM CTE_Results
		WHERE @PageSize < 0 OR (RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
		ORDER BY RowNumber ASC;	
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[COMBINACION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL';

