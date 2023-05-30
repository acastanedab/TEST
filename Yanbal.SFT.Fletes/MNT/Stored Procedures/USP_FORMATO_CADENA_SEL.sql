CREATE PROCEDURE [MNT].[USP_FORMATO_CADENA_SEL]
    (
      @CODIGO_FORMATO_CADENA	INT,
      @FORMATO					NVARCHAR(50) ,
      @TIPO_FORMATO 			CHAR(1),
	  @FORMATO_LARGO			BIT,
	  @ESTADO_REGISTRO			CHAR(1)
    )
AS 
/************************************************
-- Nombre: [MNT].[USP_FORMATO_CADENA_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.FORMATO_CADENA
-- Input:
		@CODIGO_FORMATO_CADENA:	Parámetro de entrada de tipo int, que representa codigo formato cadena.
		@FORMATO:	Parámetro de entrada de tipo nvarchar, que representa formato.
		@TIPO_FORMATO:	Parámetro de entrada de tipo char, que representa tipo formato.
		@FORMATO_LARGO:	Parámetro de entrada de tipo bit, que representa formato largo.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.

-- Output: Lista de MNT.FORMATO_CADENA
-- Creado por: GMD
-- Create Creación: 23-09-2014
-- Fecha Actualización:
-- ***********************************************/
SELECT  [CODIGO_FORMATO_CADENA] AS CodigoFormatoCadena,
        [FORMATO] AS Formato,
        [TIPO_FORMATO] AS TipoFormato,
		[FORMATO_LARGO] AS FormatoLargo,
		[ESTADO_REGISTRO] AS EstadoRegistro
FROM    MNT.FORMATO_CADENA
WHERE   (@CODIGO_FORMATO_CADENA IS NULL OR CODIGO_FORMATO_CADENA = @CODIGO_FORMATO_CADENA)
AND		(@FORMATO IS NULL OR FORMATO = @FORMATO)
AND		(@TIPO_FORMATO IS NULL OR TIPO_FORMATO = @TIPO_FORMATO)
AND		(@FORMATO_LARGO IS NULL OR FORMATO_LARGO = @FORMATO_LARGO)
AND		(@ESTADO_REGISTRO IS NULL OR  ESTADO_REGISTRO = @ESTADO_REGISTRO)



GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[FORMATO_CADENA].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMATO_CADENA_SEL';

