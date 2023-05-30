CREATE TYPE [dbo].[LISTA_PARAMETRO_VALOR_TYPE] AS TABLE (
    [CODIGO_PARAMETRO] INT            NULL,
    [VALOR]            NVARCHAR (255) NULL);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Permite convertir una lista a parámetro valor.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TYPE', @level1name = N'LISTA_PARAMETRO_VALOR_TYPE';

