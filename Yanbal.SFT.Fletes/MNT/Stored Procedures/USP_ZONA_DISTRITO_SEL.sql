CREATE PROCEDURE [MNT].[USP_ZONA_DISTRITO_SEL]
(
	@CODIGO_CIUDAD			VARCHAR(50),
	@CODIGO_DISTRITO		VARCHAR(50)
)
AS
/*********************************************
-- Nombre: [MNT].[USP_ZONA_DISTRITO_SEL]
-- Propósito: Obtiene el listado de los registros de la vista MNT.VW_DISTRITO
-- Input:
		@CODIGO_CIUDAD:	Parámetro de entrada de tipo varchar, que representa codigo ciudad.
		@CODIGO_DISTRITO:	Parámetro de entrada de tipo varchar, que representa codigo distrito.

-- Output: Lista de Ciudad
-- Creado por: GMD
-- Create Creación: 27-08-2014
-- Fecha Actualización:
-- ********************************************/
SELECT 
	VDT.CODIGO_CIUDAD				AS CodigoCiudad,
	VDT.CODIGO_DISTRITO				AS CodigoDistrito,
	VDT.NOMBRE_DISTRITO				AS NombreDistrito
FROM [GRL].[VW_DISTRITO] VDT
WHERE	(@CODIGO_CIUDAD IS NULL			OR (VDT.CODIGO_CIUDAD		= @CODIGO_CIUDAD))
AND		(@CODIGO_DISTRITO IS NULL		OR (VDT.CODIGO_DISTRITO		= @CODIGO_DISTRITO))
ORDER BY VDT.NOMBRE_DISTRITO ASC
