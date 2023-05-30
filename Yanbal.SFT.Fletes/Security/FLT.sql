CREATE SCHEMA [FLT]
    AUTHORIZATION [dbo];


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Contiene los objetos del esquema de Fletes.', @level0type = N'SCHEMA', @level0name = N'FLT';

