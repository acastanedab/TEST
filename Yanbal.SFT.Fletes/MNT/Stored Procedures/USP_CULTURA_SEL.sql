CREATE PROCEDURE [MNT].[USP_CULTURA_SEL]
(
    @CODIGO_UNIDAD_NEGOCIO INT ,
    @CODIGO_CULTURA CHAR(5) ,
    @CODIGO_IDIOMA CHAR(2) ,
    @CODIGO_PAIS CHAR(3) ,
    @CODIGO_FORMATO_FECHA_CORTA INT ,
	@CODIGO_FORMATO_FECHA_LARGA INT ,
	@CODIGO_FORMATO_HORA_CORTA INT ,
	@CODIGO_FORMATO_HORA_LARGA INT ,
    @CODIGO_FORMATO_NUMERO_ENTERO INT ,
    @CODIGO_FORMATO_NUMERO_DECIMAL INT ,
	@LIMITE_SUPERIOR_ANIO SMALLINT,
    @ESTADO_REGISTRO CHAR(1) ,
    @PageNo INT = 1 ,
    @PageSize INT = -1 ,
    @SortColumn NVARCHAR(100) = 'CODIGO_CULTURA' ,
    @SortOrder NVARCHAR(4) = 'ASC'
)
AS
/****************************************************************************
Nombre SP: [MNT].[USP_CULTURA_SEL]
Propósito: Obtiene el listado de los registros de la tabla MNT.CULTURA
Input:
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_CULTURA:	Parámetro de entrada de tipo char, que representa codigo cultura.
		@CODIGO_IDIOMA:	Parámetro de entrada de tipo char, que representa codigo idioma.
		@CODIGO_PAIS:	Parámetro de entrada de tipo char, que representa codigo pais.
		@CODIGO_FORMATO_FECHA_CORTA:	Parámetro de entrada de tipo int, que representa codigo formato fecha corta.
		@CODIGO_FORMATO_FECHA_LARGA:	Parámetro de entrada de tipo int, que representa codigo formato fecha larga.
		@CODIGO_FORMATO_HORA_CORTA:	Parámetro de entrada de tipo int, que representa codigo formato hora corta.
		@CODIGO_FORMATO_HORA_LARGA:	Parámetro de entrada de tipo int, que representa codigo formato hora larga.
		@CODIGO_FORMATO_NUMERO_ENTERO:	Parámetro de entrada de tipo int, que representa codigo formato numero entero.
		@CODIGO_FORMATO_NUMERO_DECIMAL:	Parámetro de entrada de tipo int, que representa codigo formato numero decimal.
		@LIMITE_SUPERIOR_ANIO:	Parámetro de entrada de tipo smallint, que representa limite superior anio.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
		@SortColumn:	Parámetro de entrada de tipo nvarchar, que representa sortcolumn.
		@SortOrder:	Parámetro de entrada de tipo nvarchar, que representa sortorder.
Output: 

Creado por: GMD
Fecha. Creación:		17-03-2014
Fecha. Actualización:
****************************************************************************/
DECLARE @V_CODIGO_PARAMETRO_ESTADO_REGISTRO CHAR(3), @V_ESTADO_REGISTRO_RELACION CHAR(1)
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
		SELECT ROW_NUMBER() OVER (ORDER BY PA.NOMBRE ASC
	    ) AS RowNumber,
		Count(*) over () AS RowsTotal,
		Count(*) over () AS RowId,
		CUL.CODIGO_CULTURA AS CodigoCultura ,
        CUL.CODIGO_IDIOMA AS CodigoIdioma ,
		IDI.NOMBRE AS NombreIdioma ,
        CUL.CODIGO_PAIS AS CodigoPais ,
		PA.NOMBRE AS NombrePais,
        CUL.CODIGO_FORMATO_FECHA_CORTA AS CodigoFormatoFechaCorta,
		FFC.FORMATO	AS DescripcionFormatoFechaCorta,
		CUL.CODIGO_FORMATO_FECHA_LARGA AS CodigoFormatoFechaLarga,
		FFL.FORMATO	AS DescripcionFormatoFechaLarga,
		CUL.CODIGO_FORMATO_HORA_CORTA AS CodigoFormatoHoraCorta,
		FHC.FORMATO	AS DescripcionFormatoHoraCorta,
		CUL.CODIGO_FORMATO_HORA_LARGA AS CodigoFormatoHoraLarga,
		FHL.FORMATO	AS DescripcionFormatoHoraLarga,
        CUL.CODIGO_FORMATO_NUMERO_ENTERO AS CodigoFormatoNumeroEntero ,
        FCE.FORMATO AS DescripcionFormatoNumeroEntero ,
        CUL.CODIGO_FORMATO_NUMERO_DECIMAL AS CodigoFormatoNumeroDecimal ,
        FCD.FORMATO AS DescripcionFormatoNumeroDecimal ,
		CUL.LIMITE_SUPERIOR_ANIO AS LimiteSuperiorAnio,
        CUL.OBSERVACION AS Observacion ,
        CUL.ESTADO_REGISTRO AS EstadoRegistro ,
        PVLER.VALOR AS DescripcionEstadoRegistro ,
        CUL.USUARIO_CREACION AS UsuarioCreacion ,
        CUL.FECHA_CREACION AS FechaCreacion ,
        CUL.TERMINAL_CREACION AS TerminalCreacion ,
        CUL.USUARIO_MODIFICACION AS UsuarioModificacion ,
        CUL.FECHA_MODIFICACION AS FechaModificacion ,
        CUL.TERMINAL_MODIFICACION AS TerminalModificacion
        
		FROM MNT.CULTURA CUL LEFT JOIN MNT.IDIOMA IDI ON CUL.CODIGO_IDIOMA = IDI.CODIGO_IDIOMA
							LEFT JOIN MNT.PAIS PA ON CUL.CODIGO_PAIS = PA.CODIGO_PAIS
                    		LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_ESTADO_REGISTRO,@V_ESTADO_REGISTRO_RELACION,2) PVLER ON PVLER.CODIGO = CUL.ESTADO_REGISTRO
							LEFT JOIN MNT.FORMATO_CADENA FFC ON FFC.CODIGO_FORMATO_CADENA = CUL.CODIGO_FORMATO_FECHA_CORTA
							LEFT JOIN MNT.FORMATO_CADENA FFL ON FFL.CODIGO_FORMATO_CADENA = CUL.CODIGO_FORMATO_FECHA_LARGA
							LEFT JOIN MNT.FORMATO_CADENA FHC ON FHC.CODIGO_FORMATO_CADENA = CUL.CODIGO_FORMATO_HORA_CORTA
							LEFT JOIN MNT.FORMATO_CADENA FHL ON FHL.CODIGO_FORMATO_CADENA = CUL.CODIGO_FORMATO_HORA_LARGA
							LEFT JOIN MNT.FORMATO_CADENA FCE ON FCE.CODIGO_FORMATO_CADENA = CUL.CODIGO_FORMATO_NUMERO_ENTERO
							LEFT JOIN MNT.FORMATO_CADENA FCD ON FCD.CODIGO_FORMATO_CADENA = CUL.CODIGO_FORMATO_NUMERO_DECIMAL
            WHERE (@CODIGO_CULTURA IS NULL			OR CUL.CODIGO_CULTURA = @CODIGO_CULTURA)
              AND (@CODIGO_IDIOMA IS NULL			OR CUL.CODIGO_IDIOMA = @CODIGO_IDIOMA)
              AND (@CODIGO_PAIS IS NULL				OR CUL.CODIGO_PAIS = @CODIGO_PAIS)
              AND (@ESTADO_REGISTRO IS NULL			OR CUL.ESTADO_REGISTRO = @ESTADO_REGISTRO)
		)
		SELECT * FROM CTE_Results
		WHERE @PageSize < 0 OR (RowNumber > @lFirstRec AND RowNumber < @lLAStRec)
		ORDER BY RowNumber ASC;	
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[CULTURA].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL';

