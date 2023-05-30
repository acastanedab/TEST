CREATE PROC [MNT].[USP_UNIDAD_NEGOCIO_CONFIGURACION_LOGO_SEL]
(
	@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION INT
)
AS
/****************************************************************************
Nombre SP: [MNT].[USP_UNIDAD_NEGOCIO_CONFIGURACION_LOGO_SEL]
Propósito: Obtiene el listado de los registros de la tabla MNT.UNIDAD_NEGOCIO_CONFIGURACION
Input:
	@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION:	Parámetro de entrada de tipo int, que representa codigo unidad negocio configuracion.
Output: 

Creado por: GMD
Fecha. Creación:		2014-09-19
Fecha. Actualización:
****************************************************************************/
BEGIN
	SELECT	UNC.LOGO_COMPANIA AS LogoCompania, 
			UNC.LOGO_REPORTE AS LogoReporte
	FROM MNT.UNIDAD_NEGOCIO_CONFIGURACION UNC
	WHERE	UNC.CODIGO_UNIDAD_NEGOCIO_CONFIGURACION = @CODIGO_UNIDAD_NEGOCIO_CONFIGURACION
END



GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[UNIDAD_NEGOCIO_CONFIGURACION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_LOGO_SEL';

