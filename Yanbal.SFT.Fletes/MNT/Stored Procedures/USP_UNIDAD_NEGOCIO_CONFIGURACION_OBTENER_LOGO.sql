CREATE PROCEDURE [MNT].[USP_UNIDAD_NEGOCIO_CONFIGURACION_OBTENER_LOGO]
(
	@CODIGO_UNIDAD_NEGOCIO  INT,
	@INDICADOR_LOGO			CHAR(1)
)
AS
/****************************************************************************
Nombre SP: [MNT].[USP_UNIDAD_NEGOCIO_CONFIGURACION_OBTENER_LOGO]
Propósito: Obtener logos de Compañía o Reporte de Configuración de Unidad de Negocio
Input:
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@INDICADOR_LOGO:	Parámetro de entrada de tipo char, que representa indicador logo.
Output: 

Creado por: GMD
Fecha de Creación:		2014-09-19
Fecha de Actualización:
****************************************************************************/
SELECT 
		CASE @INDICADOR_LOGO WHEN 'C' THEN LOGO_COMPANIA ELSE LOGO_REPORTE END AS LOGO
FROM 
		MNT.UNIDAD_NEGOCIO_CONFIGURACION
WHERE	
		CODIGO_UNIDAD_NEGOCIO= @CODIGO_UNIDAD_NEGOCIO
AND		ESTADO_REGISTRO = '1'

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtener logos de Compañía o Reporte de Configuración de Unidad de Negocio].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_OBTENER_LOGO';

