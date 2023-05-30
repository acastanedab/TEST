﻿CREATE FUNCTION [MNT].[F_PARAMETRO_VALOR_LISTA_PARAMETRO_SECCION] (
	@CODIGO_UNIDAD_NEGOCIO INT,
	@CODIGO_PARAMETRO INT,
	@ESTADO_REGISTRO CHAR(1),
	@CODIGO_SECCION INT = 2
)
RETURNS @TMP_VALOR TABLE(CODIGO NVARCHAR(MAX), VALOR NVARCHAR(MAX))
AS
BEGIN
    INSERT INTO @TMP_VALOR (CODIGO, VALOR)
    SELECT CODIGO, DESCRIPCION
	FROM (SELECT PV.CODIGO_VALOR, (CASE PV.CODIGO_SECCION WHEN 1 THEN 'CODIGO' ELSE 'DESCRIPCION' END) AS COLUMNA, PV.VALOR
	FROM MNT.PARAMETRO_VALOR PV INNER JOIN MNT.PARAMETRO PA ON PA.CODIGO_PARAMETRO = PV.CODIGO_PARAMETRO
	WHERE
	(PV.CODIGO_UNIDAD_NEGOCIO = @CODIGO_UNIDAD_NEGOCIO)
	AND PA.CODIGO_PARAMETRO = @CODIGO_PARAMETRO
	AND PV.CODIGO_SECCION IN (1, @CODIGO_SECCION)
	AND PV.ESTADO_REGISTRO = CASE WHEN (@ESTADO_REGISTRO IS NULL OR @ESTADO_REGISTRO='') THEN PV.ESTADO_REGISTRO ELSE @ESTADO_REGISTRO END) AS ORIGEN

    PIVOT (MAX(VALOR) FOR COLUMNA IN (CODIGO, DESCRIPCION)) AS TABLA_PIVOTE

RETURN
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Función que permite listar los parámetros segúnparámetro sección.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_PARAMETRO_VALOR_LISTA_PARAMETRO_SECCION';

