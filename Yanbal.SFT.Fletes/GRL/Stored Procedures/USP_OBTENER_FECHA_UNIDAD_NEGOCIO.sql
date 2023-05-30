CREATE PROCEDURE [GRL].[USP_OBTENER_FECHA_UNIDAD_NEGOCIO]
(
    @CODIGO_UNIDAD_NEGOCIO INT,
	@CODIGO_PAIS CHAR(2)  
)
AS
/****************************************************************************
Nombre SP: [POL].[USP_OBTENER_FECHA_SERVIDOR]
Propósito: Obtener Fecha del Servidor de BD
Input:
	@CODIGO_UNIDAD_NEGOCIO - Código de Unidad de Negocio
	@CODIGO_PAIS			- Código de País
Output: 

Creado por: GMD
Fecha. Creación:		17-03-2014
Fecha. Actualización:
****************************************************************************/
BEGIN 
	IF @CODIGO_PAIS IS NOT NULL
	BEGIN
		  SELECT TOP 1 @CODIGO_UNIDAD_NEGOCIO = UN.CODIGO_UNIDAD_NEGOCIO  FROM MNT.UNIDAD_NEGOCIO UN WHERE UN.CODIGO_PAIS = @CODIGO_PAIS AND UN.ESTADO_REGISTRO = '1'
	END  
	SELECT GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO) AS FechaUnidadNegocio
END



GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtener Fecha del Servidor de BD].', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'PROCEDURE', @level1name = N'USP_OBTENER_FECHA_UNIDAD_NEGOCIO';

