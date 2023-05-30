CREATE TABLE [GRL].[VW_CIUDAD] (
    [CODIGO_PROVINCIA] NVARCHAR (10)  NOT NULL,
    [CODIGO_CIUDAD]    NVARCHAR (20)  NOT NULL,
    [NOMBRE_CIUDAD]    NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_VW_CIUDAD] PRIMARY KEY CLUSTERED ([CODIGO_PROVINCIA] ASC, [CODIGO_CIUDAD] ASC) WITH (FILLFACTOR = 25)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla Vista Ciudad.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_CIUDAD';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de Provincia.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_CIUDAD', @level2type = N'COLUMN', @level2name = N'CODIGO_PROVINCIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de Ciudad.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_CIUDAD', @level2type = N'COLUMN', @level2name = N'CODIGO_CIUDAD';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre de Ciudad.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_CIUDAD', @level2type = N'COLUMN', @level2name = N'NOMBRE_CIUDAD';

