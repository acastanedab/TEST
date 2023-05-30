CREATE PROCEDURE [MNT].[USP_REPORTE_AUDITORIA]
    (
      @CODIGO_UNIDAD_NEGOCIO INT,
      @CODIGO_TABLA INT,
      @CODIGO_ATRIBUTO INT,
      @FECHA_REGISTRO_DESDE NVARCHAR(50),
      @FECHA_REGISTRO_HASTA NVARCHAR(50),
      @USUARIO_OPERACION NVARCHAR(50)
    )
AS
/****************************************************************************
Nombre SP: [MNT].[USP_REPORTE_AUDITORIA]
Propósito: Obtener el reporte de auditoria de fletes
Input:
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_TABLA:	Parámetro de entrada de tipo int, que representa codigo tabla.
		@CODIGO_ATRIBUTO:	Parámetro de entrada de tipo int, que representa codigo atributo.
		@FECHA_REGISTRO_DESDE:	Parámetro de entrada de tipo nvarchar, que representa fecha registro desde.
		@FECHA_REGISTRO_HASTA:	Parámetro de entrada de tipo nvarchar, que representa fecha registro hasta.
		@USUARIO_OPERACION:	Parámetro de entrada de tipo nvarchar, que representa usuario operacion.
Output: 

Creado por: GMD
Fecha. Creación:		15-09-2014
Fecha. Actualización:
****************************************************************************/
SELECT  FAT.CODIGO_AUDITORIA_TABLA		AS CodigoTabla,
        FAT.NOMBRE_TABLA				AS NombreTabla,
        FAC.CODIGO_AUDITORIA_COLUMNA	AS CodigoAtributo,
		FAD.CODIGO_REGISTRO_TABLA		AS CodigoRegistroTabla,
        FAC.NOMBRE_COLUMNA				AS NombreAtributo,
        FAD.VALOR_ANTERIOR				AS ValorOriginal,
        FAD.VALOR_NUEVO					AS ValorModificado,
        FAD.GLOSA						AS MotivoModificacion,
        FAD.FECHA_AUDITORIA				AS FechaOperacion,
        FAD.USUARIO_AUDITORIA			AS UsuarioOperacion
FROM    MNT.AUDITORIA_DETALLE FAD
        INNER JOIN MNT.AUDITORIA_COLUMNA FAC ON FAC.CODIGO_AUDITORIA_COLUMNA = FAD.CODIGO_AUDITORIA_COLUMNA
                                                            AND FAD.CODIGO_AUDITORIA_TABLA = FAC.CODIGO_AUDITORIA_TABLA
        INNER JOIN MNT.AUDITORIA_TABLA FAT ON FAT.CODIGO_AUDITORIA_TABLA = FAC.CODIGO_AUDITORIA_TABLA
WHERE   (@CODIGO_UNIDAD_NEGOCIO IS NULL OR FAD.CODIGO_UNIDAD_NEGOCIO = @CODIGO_UNIDAD_NEGOCIO )
        AND ( FAT.CODIGO_AUDITORIA_TABLA = @CODIGO_TABLA
                OR ISNULL(CONVERT(VARCHAR(20), @CODIGO_TABLA), '') = ''
            )
        AND ( FAC.CODIGO_AUDITORIA_COLUMNA = @CODIGO_ATRIBUTO
                OR ISNULL(CONVERT(VARCHAR(20), @CODIGO_ATRIBUTO), '') = ''
            )
        AND ( ISNULL(@FECHA_REGISTRO_DESDE, '') = ''
                OR CONVERT(DATETIME, @FECHA_REGISTRO_DESDE, 103) <= CONVERT(DATETIME, CONVERT(VARCHAR, FAD.FECHA_AUDITORIA, 103), 103)
            )
        AND ( ISNULL(@FECHA_REGISTRO_HASTA, '') = ''
                OR CONVERT(DATETIME, @FECHA_REGISTRO_HASTA, 103) >= CONVERT(DATETIME, CONVERT(VARCHAR, FAD.FECHA_AUDITORIA, 103), 103)
            )
        AND ( FAD.USUARIO_AUDITORIA LIKE '%' + ISNULL(@USUARIO_OPERACION,
                                                        '') + '%'
                OR ISNULL(@USUARIO_OPERACION, '') = ''
            )
ORDER BY FAD.FECHA_AUDITORIA DESC

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtener el reporte de auditoria de fletes.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_REPORTE_AUDITORIA';

