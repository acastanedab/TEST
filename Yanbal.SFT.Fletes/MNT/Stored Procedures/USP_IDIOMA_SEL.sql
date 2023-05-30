CREATE PROCEDURE [MNT].[USP_IDIOMA_SEL]
    (
      @CODIGO_IDIOMA	CHAR(2) ,
      @NOMBRE			NVARCHAR(50) ,
      @ESTADO_REGISTRO	CHAR(1)
    )
AS 
/****************************************************
-- Nombre: [MNT].[USP_IDIOMA_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.IDIOMA
-- Input:
		@CODIGO_IDIOMA:	Parámetro de entrada de tipo char, que representa codigo idioma.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.

-- Output: Lista de MNT.IDIOMA
-- Creado por: GMD
-- Create Creación: 23-09-2014
-- Fecha Actualización:
-- ****************************************************/
SELECT  [CODIGO_IDIOMA] AS CodigoIdioma ,
        [NOMBRE] AS Nombre ,
        [ESTADO_REGISTRO] AS EstadodeRegistro
FROM    MNT.IDIOMA
WHERE   @CODIGO_IDIOMA IS NULL OR  CODIGO_IDIOMA = @CODIGO_IDIOMA
AND		@NOMBRE IS NULL OR NOMBRE = @NOMBRE
AND		@ESTADO_REGISTRO IS NULL OR  ESTADO_REGISTRO = @ESTADO_REGISTRO

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[IDIOMA].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_IDIOMA_SEL';

