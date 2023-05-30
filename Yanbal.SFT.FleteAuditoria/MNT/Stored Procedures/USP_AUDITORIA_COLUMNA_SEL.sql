CREATE PROCEDURE [MNT].[USP_AUDITORIA_COLUMNA_SEL]
    (
      @CODIGO_AUDITORIA_TABLA INT,
      @ESTADO_REGISTRO CHAR(1)
    )
AS
/****************************************************************************
Nombre SP: [MNT].[USP_AUDITORIA_COLUMNA_SEL]
Propósito: Obtener el listado de las columnas de la tabla MNT.AUDITORIA_COLUMNA
Input:
		@CODIGO_AUDITORIA_TABLA:	Parámetro de entrada de tipo int, que representa codigo auditoria tabla.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Output: 

Creado por: GMD
Fecha. Creación:		15-09-2014
Fecha. Actualización:
****************************************************************************/
SELECT  CODIGO_AUDITORIA_COLUMNA  AS CodigoAuditoriaColumna ,
        NOMBRE_COLUMNA			  AS NombreColumna
FROM    MNT.AUDITORIA_COLUMNA
WHERE   CODIGO_AUDITORIA_TABLA = @CODIGO_AUDITORIA_TABLA
    AND ESTADO_REGISTRO = @ESTADO_REGISTRO

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtener el listado de las columnas de la tabla MNT.AUDITORIA_COLUMNA.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_AUDITORIA_COLUMNA_SEL';

