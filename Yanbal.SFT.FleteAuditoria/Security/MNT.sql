CREATE SCHEMA [MNT]
    AUTHORIZATION [dbo];


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Contiene los objetos del esquema de Mantenimiento.', @level0type = N'SCHEMA', @level0name = N'MNT';

