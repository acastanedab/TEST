CREATE TABLE [GRL].[VW_DISTRITO] (
    [CODIGO_CIUDAD]   NVARCHAR (10)  NOT NULL,
    [CODIGO_DISTRITO] NVARCHAR (20)  NOT NULL,
    [NOMBRE_DISTRITO] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_VW_DISTRITO] PRIMARY KEY CLUSTERED ([CODIGO_CIUDAD] ASC, [CODIGO_DISTRITO] ASC) WITH (FILLFACTOR = 25)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla Vista Distrito.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_DISTRITO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de Ciudad.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_DISTRITO', @level2type = N'COLUMN', @level2name = N'CODIGO_CIUDAD';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de Distrito.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_DISTRITO', @level2type = N'COLUMN', @level2name = N'CODIGO_DISTRITO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre de Distrito.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_DISTRITO', @level2type = N'COLUMN', @level2name = N'NOMBRE_DISTRITO';

