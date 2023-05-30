CREATE TABLE [GRL].[VW_PROVINCIA] (
    [CODIGO_PAIS]      CHAR (2)       NOT NULL,
    [CODIGO_PROVINCIA] NVARCHAR (255) NOT NULL,
    [NOMBRE_PROVINCIA] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_VW_PROVINCIA] PRIMARY KEY CLUSTERED ([CODIGO_PAIS] ASC, [CODIGO_PROVINCIA] ASC) WITH (FILLFACTOR = 25)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla Vista Provincia.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_PROVINCIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de País.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_PROVINCIA', @level2type = N'COLUMN', @level2name = N'CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de Provincia.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_PROVINCIA', @level2type = N'COLUMN', @level2name = N'CODIGO_PROVINCIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre de Provincia.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'TABLE', @level1name = N'VW_PROVINCIA', @level2type = N'COLUMN', @level2name = N'NOMBRE_PROVINCIA';

