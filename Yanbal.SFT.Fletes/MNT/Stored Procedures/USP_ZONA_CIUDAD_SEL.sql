CREATE PROCEDURE [MNT].[USP_ZONA_CIUDAD_SEL]
(
	@CODIGO_PROVINCIA	VARCHAR(50),
	@CODIGO_CIUDAD		VARCHAR(50)
)
AS
/*******************************************
-- Nombre: [MNT].[USP_ZONA_CIUDAD_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.VW_CIUDAD
-- Input:
		@CODIGO_PROVINCIA:	Parámetro de entrada de tipo varchar, que representa codigo provincia.
		@CODIGO_CIUDAD:	Parámetro de entrada de tipo varchar, que representa codigo ciudad.

-- Output: Lista de Ciudad
-- Creado por: GMD
-- Create Creación: 27-08-2014
-- Fecha Actualización: 03/10/17 Cambio del tipo de dato
-- ********************************************/
SELECT 
	VCD.CODIGO_PROVINCIA			AS CodigoProvincia,
	VCD.CODIGO_CIUDAD				AS CodigoCiudad,
	VCD.NOMBRE_CIUDAD				AS NombreCiudad
FROM [GRL].[VW_CIUDAD] VCD
WHERE	(@CODIGO_PROVINCIA IS NULL	OR (VCD.CODIGO_PROVINCIA	= @CODIGO_PROVINCIA))
AND		(@CODIGO_CIUDAD IS NULL		OR (VCD.CODIGO_CIUDAD		= @CODIGO_CIUDAD))
ORDER BY VCD.NOMBRE_CIUDAD ASC

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[VW_CIUDAD].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ZONA_CIUDAD_SEL';

