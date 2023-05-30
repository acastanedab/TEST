CREATE PROCEDURE [MNT].[USP_ZONA_HORARIA_SEL]
AS
/**********************************************
-- Nombre: [MNT].[USP_ZONA_HORARIA_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.ZONA_HORARIA
-- Input: 
		
-- Output: 

-- Creado por: GMD
-- Fecha de Creación: 2014-09-22
-- Fecha de Actualización:
-- ***********************************************/
SELECT CODIGO_ZONA_HORARIA AS 'CodigoZonaHoraria',
		HORA_UTC AS 'HoraUTC', MINUTO_UTC AS 'MinutoUTC',DESCRIPCION AS 'Descripcion',
		(RIGHT(CASE WHEN HORA_UTC > 0 AND HORA_UTC <= 9 THEN '(+0'
					WHEN HORA_UTC > 9 THEN '(+' 
					 WHEN HORA_UTC = 0 THEN '(0' 
					 WHEN HORA_UTC < 0 AND HORA_UTC >= -9THEN '(-0'
					 WHEN HORA_UTC < -9 THEN '(-'
				END
		+CAST(CASE WHEN HORA_UTC < 0 THEN ABS(HORA_UTC)
				   ELSE HORA_UTC END AS varchar(4)), 4 )+':'
		+RIGHT( '00' + CAST( MINUTO_UTC AS varchar(2)), 2 )+') '+DESCRIPCION) AS 'DescripcionCompleta'
FROM MNT.ZONA_HORARIA

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[ZONA_HORARIA].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ZONA_HORARIA_SEL';

