CREATE PROCEDURE [MNT].[USP_TIPO_ZONA_UBIGEO_SEL]
(
	@CODIGO_TIPO_ZONA_UBIGEO	INT,
	@CODIGO_UNIDAD_NEGOCIO		INT,
	@CODIGO_ZONA				VARCHAR(50),
	@CODIGO_PAIS				VARCHAR(50),
	@CODIGO_NIVEL_1				VARCHAR(50),
	@NIVEL_1					NVARCHAR(150),
	@CODIGO_NIVEL_2				VARCHAR(50),
	@NIVEL_2					NVARCHAR(150),
	@CODIGO_NIVEL_3				VARCHAR(50),
	@NIVEL_3					NVARCHAR(150),
	@CODIGO_TIPO_ZONA			VARCHAR(50),
	@ESTADO_REGISTRO			CHAR(1),
	@PageNo						INT = 1,
	@PageSize					INT = -1,
	@SortColumn					NVARCHAR(100) = 'PVLTZ.CODIGO',
	@SortOrder					NVARCHAR(4)='ASC'
	)
AS
/****************************************************
-- Nombre: [MNT].[USP_TIPO_ZONA_UBIGEO_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.TIPO_ZONA_UBIGEO
-- Input:
		@CODIGO_TIPO_ZONA_UBIGEO:	Parámetro de entrada de tipo int, que representa codigo tipo zona ubigeo.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_ZONA:	Parámetro de entrada de tipo char, que representa codigo zona.
		@CODIGO_PAIS:	Parámetro de entrada de tipo char, que representa codigo pais.
		@CODIGO_NIVEL_1:	Parámetro de entrada de tipo char, que representa codigo nivel 1.
		@NIVEL_1:	Parámetro de entrada de tipo nvarchar, que representa nivel 1.
		@CODIGO_NIVEL_2:	Parámetro de entrada de tipo char, que representa codigo nivel 2.
		@NIVEL_2:	Parámetro de entrada de tipo nvarchar, que representa nivel 2.
		@CODIGO_NIVEL_3:	Parámetro de entrada de tipo char, que representa codigo nivel 3.
		@NIVEL_3:	Parámetro de entrada de tipo nvarchar, que representa nivel 3.
		@CODIGO_TIPO_ZONA:	Parámetro de entrada de tipo varchar, que representa codigo tipo zona.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
		@SortColumn:	Parámetro de entrada de tipo nvarchar, que representa sortcolumn.
		@SortOrder:	Parámetro de entrada de tipo nvarchar, que representa sortorder.

-- Output: Lista de MNT.TIPO_ZONA_UBIGEO
-- Creado por: GMD
-- Create Creación: 27-08-2014
-- Fecha Actualización:
-- *****************************************************/
DECLARE
@V_CODIGO_PARAMETRO_ESTADO_REGISTRO CHAR(3),
@V_CODIGO_PARAMETRO_TIPO_ZONA CHAR(3),
@V_ESTADO_REGISTRO_RELACION			CHAR(1)

SET @V_ESTADO_REGISTRO_RELACION = '1'
SET @V_CODIGO_PARAMETRO_TIPO_ZONA = 'TZN'
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
	    SELECT ROW_NUMBER() OVER (ORDER BY PVLTZ.CODIGO ASC) AS RowNumber,
        Count(*) over () AS RowsTotal,
		Count(*) over () AS RowId,
		TZU.CODIGO_TIPO_ZONA_UBIGEO		AS CodigoTipoZonaUbigeo,
		TZU.CODIGO_UNIDAD_NEGOCIO		AS CodigoUnidadNegocio,
		RTRIM(TZU.CODIGO_ZONA)					AS CodigoZona,
		RTRIM(TZU.CODIGO_PAIS)					AS CodigoPais,
		P.NOMBRE						AS DescripcionPais,
		RTRIM(TZU.CODIGO_NIVEL_1)				AS CodigoNivel1,
		TZU.NIVEL_1						AS Nivel1,
		RTRIM(TZU.CODIGO_NIVEL_2)				AS CodigoNivel2,
		TZU.NIVEL_2						AS Nivel2,
		RTRIM(TZU.CODIGO_NIVEL_3)				AS CodigoNivel3,
		TZU.NIVEL_3						AS Nivel3,
		PVLTZ.CODIGO					AS CodigoTipoZona,
		PVLTZ.VALOR						AS DescripcionTipoZona,
		TZU.OBSERVACION					AS Observacion,
		TZU.ESTADO_REGISTRO				AS EstadoRegistro,
		PVLER.VALOR						AS DescripcionEstadoRegistro,
		TZU.USUARIO_CREACION			AS UsuarioCreacion,
		TZU.FECHA_CREACION				AS FechaCreacion,
		TZU.TERMINAL_CREACION			AS TerminalCreacion,
		TZU.USUARIO_MODIFICACION		AS UsuarioModificacion,
		TZU.FECHA_MODIFICACION			AS FechaModificacion,
		TZU.TERMINAL_MODIFICACION		AS TerminalModificacion
		FROM MNT.TIPO_ZONA_UBIGEO TZU
		LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_ESTADO_REGISTRO,@V_ESTADO_REGISTRO_RELACION,2) PVLER ON PVLER.CODIGO = TZU.ESTADO_REGISTRO
		LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_TIPO_ZONA,@V_ESTADO_REGISTRO_RELACION,2) PVLTZ ON PVLTZ.CODIGO = TZU.CODIGO_TIPO_ZONA
		INNER JOIN MNT.PAIS P ON P.CODIGO_PAIS_ZONA = TZU.CODIGO_PAIS
		WHERE	(@CODIGO_TIPO_ZONA_UBIGEO	IS NULL OR (TZU.CODIGO_TIPO_ZONA_UBIGEO	= @CODIGO_TIPO_ZONA_UBIGEO))
		AND		(@CODIGO_UNIDAD_NEGOCIO		IS NULL OR (TZU.CODIGO_UNIDAD_NEGOCIO	= @CODIGO_UNIDAD_NEGOCIO))
		AND		(@CODIGO_ZONA				IS NULL OR (TZU.CODIGO_ZONA				= @CODIGO_ZONA))
		AND		(@CODIGO_PAIS				IS NULL OR (TZU.CODIGO_PAIS				= @CODIGO_PAIS))
		AND		(@CODIGO_NIVEL_1			IS NULL OR (TZU.CODIGO_NIVEL_1			= @CODIGO_NIVEL_1))
		AND		(@NIVEL_1					IS NULL OR (TZU.NIVEL_1					= @NIVEL_1))
		AND		(@CODIGO_NIVEL_2			IS NULL OR (TZU.CODIGO_NIVEL_2			= @CODIGO_NIVEL_2))
		AND		(@NIVEL_2					IS NULL OR (TZU.NIVEL_2					= @NIVEL_2))
		AND		(@CODIGO_NIVEL_3			IS NULL OR (TZU.CODIGO_NIVEL_3			= @CODIGO_NIVEL_3))
		AND		(@NIVEL_3					IS NULL OR (TZU.NIVEL_3					= @NIVEL_3))
		AND		(@CODIGO_TIPO_ZONA			IS NULL OR (TZU.CODIGO_TIPO_ZONA		= @CODIGO_TIPO_ZONA))
		AND		(@ESTADO_REGISTRO			IS NULL OR (TZU.ESTADO_REGISTRO			= @ESTADO_REGISTRO))
		)
		SELECT * FROM CTE_Results
		WHERE @PageSize < 0 OR (RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
		ORDER BY RowNumber ASC;
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[TIPO_ZONA_UBIGEO].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL';

