CREATE   PROCEDURE [MNT].[USP_PARAMETRO_SEL]
(	
	@CODIGO_UNIDAD_NEGOCIO				INT,
	@CODIGO_PARAMETRO					INT,
	@CODIGO								CHAR(3),
	@CODIGO_APROXIMADO					NVARCHAR(3),
	@NOMBRE								NVARCHAR(100),
	@DESCRIPCION						NVARCHAR(255),
	@TIPO_PARAMETRO						CHAR(3),
	@INDICADOR_PARAMETRO_SISTEMA		BIT,
	@INDICADOR_PERMITE_AGREGAR_VALOR	BIT,
	@INDICADOR_PERMITE_MODIFICAR_VALOR	BIT,
	@ESTADO_REGISTRO					CHAR(1),
	@PageNo								INT = 1,
	@PageSize							INT = -1,
	@SortColumn							NVARCHAR(100) = 'NOMBRE',
	@SortOrder							NVARCHAR(4)='ASC'
)
AS
/******************************************************
-- Nombre: [MNT].[USP_PARAMETRO_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.PARAMETRO
-- Input:
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO:	Parámetro de entrada de tipo char, que representa codigo.
		@CODIGO_APROXIMADO:	Parámetro de entrada de tipo nvarchar, que representa codigo aproximado.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@TIPO_PARAMETRO:	Parámetro de entrada de tipo char, que representa tipo parametro.
		@INDICADOR_PARAMETRO_SISTEMA:	Parámetro de entrada de tipo bit, que representa indicador parametro sistema.
		@INDICADOR_PERMITE_AGREGAR_VALOR:	Parámetro de entrada de tipo bit, que representa indicador permite agregar valor.
		@INDICADOR_PERMITE_MODIFICAR_VALOR:	Parámetro de entrada de tipo bit, que representa indicador permite modificar valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
		@SortColumn:	Parámetro de entrada de tipo nvarchar, que representa sortcolumn.
		@SortOrder:	Parámetro de entrada de tipo nvarchar, que representa sortorder.

-- Output: Lista de MNT.PARAMETRO
-- Creado por: GMD
-- Create Creación: 19-08-2014
-- Fecha Actualización:
-- *******************************************************/
DECLARE
@V_CODIGO_PARAMETRO_ESTADO_REGISTRO CHAR(3),
@V_CODIGO_PARAMETRO_TIPO_PARAMETRO CHAR(3),
@V_ESTADO_REGISTRO_RELACION			CHAR(1)

SET @V_ESTADO_REGISTRO_RELACION = '1'
SET @V_CODIGO_PARAMETRO_ESTADO_REGISTRO = 'ETR'
SET @V_CODIGO_PARAMETRO_TIPO_PARAMETRO = 'TPT'
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
	    SELECT ROW_NUMBER() OVER (ORDER BY PA.NOMBRE ASC) AS RowNumber,
        Count(*) over () AS RowsTotal,
		Count(*) over () AS RowId,
		PA.CODIGO_UNIDAD_NEGOCIO												AS CodigoUnidadNegocio
		,PA.CODIGO_PARAMETRO													AS CodigoParametro
		,PA.CODIGO																AS Codigo
		,PA.NOMBRE																AS Nombre
		,PA.DESCRIPCION															AS Descripcion
		,PA.TIPO_PARAMETRO														AS TipoParametro
		,PVLTP.VALOR															AS DescripcionTipoParametro
		,PA.INDICADOR_PARAMETRO_SISTEMA											AS IndicadorParametroSistema
		,PA.INDICADOR_PERMITE_AGREGAR_VALOR										AS IndicadorPermiteAgregarValor
		,PA.INDICADOR_PERMITE_MODIFICAR_VALOR									AS IndicadorPermiteModificarValor
		,PA.ESTADO_REGISTRO														AS EstadoRegistro
		,PVLER.VALOR															AS DescripcionEstadoRegistro
		,PA.OBSERVACION															AS Observacion
		,PA.USUARIO_CREACION													AS UsuarioCreacion
		,PA.FECHA_CREACION														AS FechaCreacion
		,PA.TERMINAL_CREACION													AS TerminalCreacion
		,PA.USUARIO_MODIFICACION												AS UsuarioModificacion
		,PA.FECHA_MODIFICACION													AS FechaModificacion
		,PA.TERMINAL_MODIFICACION												AS TerminalModificacion
		FROM MNT.PARAMETRO PA
		LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_ESTADO_REGISTRO,@V_ESTADO_REGISTRO_RELACION,2) PVLER ON PVLER.CODIGO = PA.ESTADO_REGISTRO
		LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_TIPO_PARAMETRO,@V_ESTADO_REGISTRO_RELACION,2) PVLTP ON PVLTP.CODIGO = PA.TIPO_PARAMETRO
		WHERE (@CODIGO_UNIDAD_NEGOCIO IS NULL				OR (PA.CODIGO_UNIDAD_NEGOCIO				= @CODIGO_UNIDAD_NEGOCIO))
		AND	  (@CODIGO_PARAMETRO IS NULL					OR (PA.CODIGO_PARAMETRO						= @CODIGO_PARAMETRO))
		AND	  (@CODIGO IS NULL								OR (PA.CODIGO								= @CODIGO))
		AND   (@CODIGO_APROXIMADO IS NULL					OR (UPPER(PA.CODIGO)						LIKE UPPER(@CODIGO_APROXIMADO) + '%'))
		AND   (@NOMBRE IS NULL								OR (UPPER(PA.NOMBRE)						LIKE '%' + UPPER(@NOMBRE) + '%'))
		AND   (@DESCRIPCION IS NULL							OR (UPPER(PA.DESCRIPCION)					LIKE '%' + UPPER(@DESCRIPCION) + '%'))
		AND   (@TIPO_PARAMETRO IS NULL						OR (PA.TIPO_PARAMETRO						= @TIPO_PARAMETRO))
		AND	  (@INDICADOR_PARAMETRO_SISTEMA IS NULL			OR (PA.INDICADOR_PARAMETRO_SISTEMA			= @INDICADOR_PARAMETRO_SISTEMA))
		AND	  (@INDICADOR_PERMITE_AGREGAR_VALOR IS NULL		OR (PA.INDICADOR_PERMITE_AGREGAR_VALOR		= @INDICADOR_PERMITE_AGREGAR_VALOR))
		AND	  (@INDICADOR_PERMITE_MODIFICAR_VALOR IS NULL	OR (PA.INDICADOR_PERMITE_MODIFICAR_VALOR	= @INDICADOR_PERMITE_MODIFICAR_VALOR))
		AND   (@ESTADO_REGISTRO IS NULL						OR (PA.ESTADO_REGISTRO						= @ESTADO_REGISTRO))
		)
		SELECT * FROM CTE_Results
		WHERE @PageSize < 0 OR (RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
		ORDER BY RowNumber ASC;	
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[PARAMETRO].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL';

