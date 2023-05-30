CREATE PROC [MNT].[USP_UNIDAD_NEGOCIO_SEL]
(
    @CODIGO_UNIDAD_NEGOCIO			INT ,
    @CODIGO_UNIDAD_NEGOCIO_CONTEXTO INT ,
    @NOMBRE							NVARCHAR(50),
	@RAZON_SOCIAL_COMPANIA			NVARCHAR(255),
    @CODIGO_PAIS					CHAR(2),
    @ESTADO_REGISTRO				CHAR(1) ,
    @PageNo							INT = 1 ,
    @PageSize						INT = -1 ,
    @SortColumn						NVARCHAR(100) = 'NOMBRE' ,
    @SortOrder						NVARCHAR(4) = 'ASC'
)
AS
/****************************************************************************
Nombre SP: [POL].[USP_UNIDAD_NEGOCIO_SEL]
Propósito: Obtiene el listado de los registros de la tabla MNT.UNIDAD_NEGOCIO
Input:
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_UNIDAD_NEGOCIO_CONTEXTO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@RAZON_SOCIAL_COMPANIA:	Parámetro de entrada de tipo nvarchar, que representa razon social compania.
		@CODIGO_PAIS:	Parámetro de entrada de tipo char, que representa codigo pais.
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
BEGIN
    DECLARE @V_ESTADO_REGISTRO_RELACION CHAR(1) , @V_CODIGO_PARAMETRO_ESTADO_REGISTRO CHAR(3)

    SET @V_ESTADO_REGISTRO_RELACION = '1'
	SET @V_CODIGO_PARAMETRO_ESTADO_REGISTRO = 'ETR'

    DECLARE @lPageNbr INT ,
        @lPageSize INT ,
        @lSortCol NVARCHAR(20) ,
        @lFirstRec INT ,
        @lLAStRec INT
  
    SET @lPageNbr = @PageNo
    SET @lPageSize = @PageSize
    SET @lSortCol = LTRIM(RTRIM(@SortColumn))
    SET @lFirstRec = ( @lPageNbr - 1 ) * @lPageSize
    SET @lLAStRec = ( @lPageNbr * @lPageSize + 1 );

    WITH    CTE_Results
              AS ( SELECT ROW_NUMBER() OVER (ORDER BY UN.NOMBRE ASC) AS RowNumber,
                    Count(*) over () AS RowsTotal,
					Count(*) over () AS RowId,
                            UN.CODIGO_UNIDAD_NEGOCIO AS CodigoUnidadNegocio ,
                            UN.NOMBRE AS Nombre ,
                            PA.CODIGO_PAIS AS CodigoPais,
							PA.CODIGO_PAIS_ZONA AS CodigoPaisZona,
                            PA.NOMBRE AS NombrePais ,
                            UN.RAZON_SOCIAL_COMPANIA AS RazonSocialCompania ,
                            UN.DIRECCION_COMPANIA AS DireccionCompania ,
                            UN.DOCUMENTO_COMPANIA AS DocumentoCompania ,
                            UN.OBSERVACION AS Observacion ,
                            UN.ESTADO_REGISTRO AS EstadoRegistro ,
                            PVLER.VALOR AS DescripcionEstadoRegistro ,
                            UN.USUARIO_CREACION AS UsuarioCreacion ,
                            UN.FECHA_CREACION AS FechaCreacion ,
                            UN.TERMINAL_CREACION AS TerminalCreacion ,
                            UN.USUARIO_MODIFICACION AS UsuarioModificacion ,
                            UN.FECHA_MODIFICACION AS FechaModificacion ,
                            UN.TERMINAL_MODIFICACION AS TerminalModificacion
                   FROM     MNT.UNIDAD_NEGOCIO UN
                            LEFT JOIN MNT.PAIS PA ON UN.CODIGO_PAIS = PA.CODIGO_PAIS
                            LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO_CONTEXTO,@V_CODIGO_PARAMETRO_ESTADO_REGISTRO,@V_ESTADO_REGISTRO_RELACION,2) PVLER ON PVLER.CODIGO = UN.ESTADO_REGISTRO
                   WHERE    (@CODIGO_UNIDAD_NEGOCIO IS NULL			OR UN.CODIGO_UNIDAD_NEGOCIO = @CODIGO_UNIDAD_NEGOCIO)
                            AND (@NOMBRE IS NULL					OR UPPER(UN.NOMBRE) LIKE '%'+ UPPER(@NOMBRE) + '%')
                            AND (@RAZON_SOCIAL_COMPANIA IS NULL		OR UPPER(UN.RAZON_SOCIAL_COMPANIA) LIKE '%' + UPPER(@RAZON_SOCIAL_COMPANIA) + '%')
							AND (@CODIGO_PAIS IS NULL				OR PA.CODIGO_PAIS = @CODIGO_PAIS)
                            AND (@ESTADO_REGISTRO  IS NULL			OR UN.ESTADO_REGISTRO = @ESTADO_REGISTRO)
							AND PA.ESTADO_REGISTRO = @V_ESTADO_REGISTRO_RELACION							
                 )
        SELECT  *
        FROM    CTE_Results
        WHERE   @PageSize < 0
                OR ( RowNumber > @lFirstRec
                     AND RowNumber < @lLAStRec
                   )
        ORDER BY RowNumber ASC;
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[UNIDAD_NEGOCIO].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL';

