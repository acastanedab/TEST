CREATE TABLE [MNT].[AUDITORIA_DETALLE] (
    [CODIGO_AUDITORIA_DETALLE]   BIGINT         NOT NULL,
    [CODIGO_AUDITORIA_TABLA]     INT            NOT NULL,
    [CODIGO_AUDITORIA_COLUMNA]   INT            NOT NULL,
    [CODIGO_UNIDAD_NEGOCIO]      INT            NULL,
    [DESCRIPCION_UNIDAD_NEGOCIO] NVARCHAR (255) NULL,
    [CODIGO_REGISTRO_TABLA]      VARCHAR (255)  NULL,
    [VALOR_ANTERIOR]             NVARCHAR (255) NULL,
    [VALOR_NUEVO]                NVARCHAR (255) NULL,
    [GLOSA]                      NVARCHAR (255) NULL,
    [USUARIO_AUDITORIA]          NVARCHAR (50)  NOT NULL,
    [FECHA_AUDITORIA]            DATETIME       NOT NULL,
    [TERMINAL_AUDITORIA]         NVARCHAR (50)  NULL,
    CONSTRAINT [PK_AUDITORIA_DETALLE_1] PRIMARY KEY CLUSTERED ([CODIGO_AUDITORIA_DETALLE] ASC) WITH (FILLFACTOR = 25),
    CONSTRAINT [FK_AUDITORIA_DETALLE_AUDITORIA_COLUMNA] FOREIGN KEY ([CODIGO_AUDITORIA_COLUMNA], [CODIGO_AUDITORIA_TABLA]) REFERENCES [MNT].[AUDITORIA_COLUMNA] ([CODIGO_AUDITORIA_COLUMNA], [CODIGO_AUDITORIA_TABLA])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla que contiene el detalle de la auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de detalle de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'CODIGO_AUDITORIA_DETALLE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de tabla de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'CODIGO_AUDITORIA_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de columna de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'CODIGO_AUDITORIA_COLUMNA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de unidad de negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción de unidad de negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'DESCRIPCION_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de registro de tabla.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'CODIGO_REGISTRO_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Valor anterior.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'VALOR_ANTERIOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Valor nuevo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'VALOR_NUEVO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'GLOSA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'USUARIO_AUDITORIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'FECHA_AUDITORIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Terminal de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_DETALLE', @level2type = N'COLUMN', @level2name = N'TERMINAL_AUDITORIA';

