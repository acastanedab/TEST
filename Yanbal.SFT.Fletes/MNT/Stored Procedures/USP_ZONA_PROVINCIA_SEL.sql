CREATE PROCEDURE [MNT].[USP_ZONA_PROVINCIA_SEL]
(
	@CODIGO_PAIS VARCHAR(50),
	@CODIGO_PROVINCIA VARCHAR(50)
)
AS
/*******************************************************
-- Nombre: [MNT].[USP_ZONA_PROVINCIA_SEL]
-- Propósito: Obtiene el listado de los registros de la vista MNT.VW_PROVINCIA
-- Input:
		@CODIGO_PAIS:	Parámetro de entrada de tipo varchar, que representa codigo pais.
		@CODIGO_PROVINCIA:	Parámetro de entrada de tipo varchar, que representa codigo provincia.

-- Output: Lista de MNT.UBIGEO
-- Creado por: GMD
-- Create Creación: 27-08-2014
-- Fecha Actualización:
-- *****************************************************/
SELECT 
	VPR.CODIGO_PAIS			AS CodigoPais,
	VPR.CODIGO_PROVINCIA	AS CodigoProvincia,
	VPR.NOMBRE_PROVINCIA	AS NombreProvincia
FROM [GRL].[VW_PROVINCIA] VPR
WHERE	(@CODIGO_PAIS IS NULL			OR (VPR.CODIGO_PAIS			= @CODIGO_PAIS))
AND		(@CODIGO_PROVINCIA IS NULL		OR (VPR.CODIGO_PROVINCIA	= @CODIGO_PROVINCIA))
ORDER BY VPR.NOMBRE_PROVINCIA ASC
