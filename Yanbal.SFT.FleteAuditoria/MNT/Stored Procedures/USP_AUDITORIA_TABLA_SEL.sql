CREATE PROCEDURE [MNT].[USP_AUDITORIA_TABLA_SEL]
    (
      @ESTADO_REGISTRO CHAR(1)
    )
AS
/****************************************************************************
Nombre SP: [MNT].[USP_AUDITORIA_TABLA_SEL]
Propósito: Obtener el listado de la tabla de auditoría 
Input:
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
Output: 

Creado por: GMD
Fecha. Creación:		15-09-2014
Fecha. Actualización:
****************************************************************************/
SELECT  CODIGO_AUDITORIA_TABLA AS CodigoAuditoriaTabla,
        NOMBRE_TABLA				 AS NombreTabla
FROM    MNT.AUDITORIA_TABLA
WHERE   ESTADO_REGISTRO = @ESTADO_REGISTRO

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtener el listado de la tabla de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_AUDITORIA_TABLA_SEL';

