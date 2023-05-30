CREATE TABLE [MNT].[AUDITORIA_COLUMNA] (
    [CODIGO_AUDITORIA_TABLA]   INT          NOT NULL,
    [CODIGO_AUDITORIA_COLUMNA] INT          NOT NULL,
    [NOMBRE_COLUMNA]           VARCHAR (50) NULL,
    [ESTADO_REGISTRO]          CHAR (1)     NOT NULL,
    CONSTRAINT [PK_AUDITORIA_COLUMNA] PRIMARY KEY CLUSTERED ([CODIGO_AUDITORIA_COLUMNA] ASC, [CODIGO_AUDITORIA_TABLA] ASC) WITH (FILLFACTOR = 25),
    CONSTRAINT [FK_AUDITORIA_COLUMNA_AUDITORIA_TABLA] FOREIGN KEY ([CODIGO_AUDITORIA_TABLA]) REFERENCES [MNT].[AUDITORIA_TABLA] ([CODIGO_AUDITORIA_TABLA])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla que contiene las columnas para las tablas de auditoria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_COLUMNA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de tabla de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_COLUMNA', @level2type = N'COLUMN', @level2name = N'CODIGO_AUDITORIA_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de columna de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_COLUMNA', @level2type = N'COLUMN', @level2name = N'CODIGO_AUDITORIA_COLUMNA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre de columna.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_COLUMNA', @level2type = N'COLUMN', @level2name = N'NOMBRE_COLUMNA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_COLUMNA', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';

