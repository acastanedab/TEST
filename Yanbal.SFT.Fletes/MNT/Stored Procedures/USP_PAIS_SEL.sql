CREATE PROCEDURE [MNT].[USP_PAIS_SEL]
(
	@CODIGO_PAIS		CHAR(2),
	@CODIGO_PAIS_ZONA	CHAR(3)
)
AS
/*****************************************************
-- Nombre: [MNT].[USP_PAIS_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.PAIS
-- Input:
		@CODIGO_PAIS:	Parámetro de entrada de tipo char, que representa codigo pais.
		@CODIGO_PAIS_ZONA:	Parámetro de entrada de tipo char, que representa codigo pais zona.

-- Output: Lista de MNT.PAIS
-- Creado por: GMD
-- Create Creación: 27-08-2014
-- Fecha Actualización:
--****************************************************/
SELECT 
	[CODIGO_PAIS]		AS CodigoPais
	,[CODIGO_PAIS_ZONA]	AS CodigoPaisZona
    ,[NOMBRE]			AS Nombre    
FROM MNT.PAIS PA
WHERE	(@CODIGO_PAIS IS NULL	OR (PA.CODIGO_PAIS	= @CODIGO_PAIS))
AND		(@CODIGO_PAIS_ZONA IS NULL OR (PA.CODIGO_PAIS_ZONA = @CODIGO_PAIS_ZONA))

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[PAIS].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PAIS_SEL';

