CREATE PROC [GRL].[USP_GET_NIVELES_SEL]
(
	@CODIGO_ZONA VARCHAR(50)
)
AS 
/* ================================================
-- Nombre: [IMP].[USP_GET_NIVELES_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla GRL.VW_PROVINCIA,GRL.VW_CIUDAD y GRL.VW_DISTRITO
-- Input:
		@CODIGO_ZONA:	Parámetro de entrada de tipo char, que representa el código de zona.

-- Output: 
-- Creado por:				GMD
-- Create Creación:			28-09-2017
-- Fecha Actualización:
-- =============================================*/
BEGIN
SELECT
	TOP 1
		PA.CODIGO_PAIS_ZONA AS CodigoPais,
		PV.CODIGO_PROVINCIA AS CodigoProvincia,
		CD.CODIGO_CIUDAD AS CodigoCiudad,
		DT.CODIGO_DISTRITO AS CodigoDistrito
FROM  MNT.PAIS PA INNER JOIN [GRL].[VW_PROVINCIA] PV ON PA.CODIGO_PAIS = PV.CODIGO_PAIS
	INNER JOIN [GRL].[VW_CIUDAD] CD ON PV.CODIGO_PROVINCIA = CD.CODIGO_PROVINCIA
	INNER JOIN [GRL].[VW_DISTRITO] DT ON CD.CODIGO_CIUDAD = DT.CODIGO_CIUDAD
WHERE
	(GRL.F_VALIDA_ZONA_GEOGRAFICA(@CODIGO_ZONA, DT.CODIGO_DISTRITO) = 1)
END
