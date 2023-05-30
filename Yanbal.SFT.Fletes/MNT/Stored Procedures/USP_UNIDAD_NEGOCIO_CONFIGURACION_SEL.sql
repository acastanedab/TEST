CREATE PROCEDURE [MNT].[USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL]
(
    @CODIGO_UNIDAD_NEGOCIO INT ,
    @CODIGO_UNIDAD_NEGOCIO_CONFIGURACION INT ,
    @CODIGO_UNIDAD_NEGOCIO_CONTEXTO INT ,
    @CODIGO_CULTURA CHAR(5) ,
    @ESTADO_REGISTRO CHAR(1) ,
    @PageNo INT = 1 ,
    @PageSize INT = -1 ,
    @SortColumn NVARCHAR(100) = 'NOMBRE_UNIDAD_NEGOCIO' ,
    @SortOrder NVARCHAR(4) = 'ASC'
)
AS
/****************************************************************************
Nombre SP: [POL].[USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL]
Propósito: Obtiene el listado de los registros de la tabla MNT.UNIDAD_NEGOCIO_CONFIGURACION
Input:
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION:	Parámetro de entrada de tipo int, que representa codigo unidad negocio configuracion.
		@CODIGO_UNIDAD_NEGOCIO_CONTEXTO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.
		@CODIGO_CULTURA:	Parámetro de entrada de tipo char, que representa codigo cultura.
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
    DECLARE @V_ESTADO_REGISTRO_RELACION CHAR(1) ,
        @V_CODIGO_PARAMETRO_ESTADO_REGISTRO CHAR(3),
		@V_CODIGO_PARAMETRO_FORMA_VISUALIZACION_REPORTE CHAR(3)
    SET @V_ESTADO_REGISTRO_RELACION = '1'
	SET @V_CODIGO_PARAMETRO_ESTADO_REGISTRO = 'ETR'
	SET	@V_CODIGO_PARAMETRO_FORMA_VISUALIZACION_REPORTE = 'FVR'

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
                    UNC.CODIGO_UNIDAD_NEGOCIO_CONFIGURACION		AS CodigoUnidadNegocioConfiguracion,
                    UNC.CODIGO_UNIDAD_NEGOCIO					AS CodigoUnidadNegocio,
                    UN.NOMBRE									AS NombreUnidadNegocio,
                    CUL.CODIGO_CULTURA							AS CodigoCultura,
					ZH.CODIGO_ZONA_HORARIA						AS CodigoZonaHoraria,
					(RIGHT(CASE WHEN ZH.HORA_UTC > 0 AND ZH.HORA_UTC <= 9 THEN '(+0'
					WHEN ZH.HORA_UTC > 9 THEN '(+' 
					 WHEN ZH.HORA_UTC = 0 THEN '(0' 
					 WHEN ZH.HORA_UTC < 0 AND ZH.HORA_UTC >= -9THEN '(-0'
					 WHEN ZH.HORA_UTC < -9 THEN '(-'
					END
					+CAST(CASE WHEN ZH.HORA_UTC < 0 THEN ABS(ZH.HORA_UTC)
					ELSE ZH.HORA_UTC END AS varchar(4)), 4 )+':'
					+RIGHT( '00' + CAST( ZH.MINUTO_UTC AS varchar(2)), 2 )+') '+ZH.DESCRIPCION) AS DescripcionZonaHoraria,
					UNC.FORMA_VISUALIZACION_REPORTE				AS FormaVisualizacionReporte,
					PVLFVR.VALOR								AS DescripcionFormaVisualizacionReporte,
					UNC.LOGO_REPORTE							AS LogoReporte,
					UNC.LOGO_COMPANIA							AS LogoCompania,
					--UNC.MAXIMO_FILAS_POR_CONSULTA				AS MaximoFilasPorConsulta,
                    UNC.FILAS_POR_PAGINA						AS FilasPorPagina,					
                    UNC.MINIMO_CARACTERES_GLOSA					AS MinimoCaracteresGlosa,
                    UNC.MINIMO_VOCALES_GLOSA					AS MinimoVocalesGlosa,
                    ISNULL(INDICADOR_CONTRAER_MENU, 0)			AS IndicadorContraerMenu,
                    UNC.OBSERVACION								AS Observacion,
                    UNC.ESTADO_REGISTRO							AS EstadoRegistro,
                    PVLER.VALOR									AS DescripcionEstadoRegistro,
                    UNC.USUARIO_CREACION						AS UsuarioCreacion,
                    UNC.FECHA_CREACION							AS FechaCreacion,
                    UNC.TERMINAL_CREACION						AS TerminalCreacion,	
                    UNC.USUARIO_MODIFICACION					AS UsuarioModificacion,
                    UNC.FECHA_MODIFICACION						AS FechaModificacion,
                    UNC.TERMINAL_MODIFICACION					AS TerminalModificacion
            FROM    MNT.UNIDAD_NEGOCIO_CONFIGURACION UNC
                    INNER JOIN MNT.UNIDAD_NEGOCIO UN ON UN.CODIGO_UNIDAD_NEGOCIO = UNC.CODIGO_UNIDAD_NEGOCIO
					LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO_CONTEXTO,@V_CODIGO_PARAMETRO_ESTADO_REGISTRO,@V_ESTADO_REGISTRO_RELACION,2) PVLER ON PVLER.CODIGO = UNC.ESTADO_REGISTRO
                    LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO_CONTEXTO,@V_CODIGO_PARAMETRO_FORMA_VISUALIZACION_REPORTE,@V_ESTADO_REGISTRO_RELACION,2) PVLFVR ON PVLFVR.CODIGO = UNC.FORMA_VISUALIZACION_REPORTE
					LEFT JOIN MNT.CULTURA CUL ON CUL.CODIGO_CULTURA = UNC.CODIGO_CULTURA
                    LEFT JOIN MNT.ZONA_HORARIA ZH ON ZH.CODIGO_ZONA_HORARIA = UNC.CODIGO_ZONA_HORARIA
            WHERE   (@CODIGO_UNIDAD_NEGOCIO IS NULL						OR UNC.CODIGO_UNIDAD_NEGOCIO = @CODIGO_UNIDAD_NEGOCIO)
                    AND (@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION IS NULL	OR UNC.CODIGO_UNIDAD_NEGOCIO_CONFIGURACION = @CODIGO_UNIDAD_NEGOCIO_CONFIGURACION)
                    AND (@CODIGO_CULTURA IS NULL                        OR UNC.CODIGO_CULTURA = @CODIGO_CULTURA)
                    AND (@ESTADO_REGISTRO IS NULL						OR UNC.ESTADO_REGISTRO = @ESTADO_REGISTRO)
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
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[UNIDAD_NEGOCIO_CONFIGURACION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL';

