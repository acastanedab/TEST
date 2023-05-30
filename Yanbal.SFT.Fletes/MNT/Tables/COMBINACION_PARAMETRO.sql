CREATE TABLE [MNT].[COMBINACION_PARAMETRO] (
    [CODIGO_COMBINACION_PARAMETRO] INT            NOT NULL,
    [CODIGO_COMBINACION]           INT            NOT NULL,
    [CODIGO_PARAMETRO]             INT            NOT NULL,
    [ORDEN_COMBINACION]            TINYINT        NOT NULL,
    [VALOR]                        NVARCHAR (255) NOT NULL,
    [OBSERVACION]                  NVARCHAR (255) NULL,
    [ESTADO_REGISTRO]              CHAR (1)       NOT NULL,
    [USUARIO_CREACION]             NVARCHAR (50)  NOT NULL,
    [FECHA_CREACION]               DATETIME       NOT NULL,
    [TERMINAL_CREACION]            NVARCHAR (50)  NOT NULL,
    [USUARIO_MODIFICACION]         NVARCHAR (50)  NULL,
    [FECHA_MODIFICACION]           DATETIME       NULL,
    [TERMINAL_MODIFICACION]        NVARCHAR (50)  NULL,
    CONSTRAINT [PK_COMBINACION_PARAMETRO] PRIMARY KEY CLUSTERED ([CODIGO_COMBINACION_PARAMETRO] ASC) WITH (FILLFACTOR = 25),
    CONSTRAINT [FK_COMBINACION_PARAMETRO_COMBINACION] FOREIGN KEY ([CODIGO_COMBINACION]) REFERENCES [MNT].[COMBINACION] ([CODIGO_COMBINACION]),
    CONSTRAINT [FK_COMBINACION_PARAMETRO_PARAMETRO] FOREIGN KEY ([CODIGO_PARAMETRO]) REFERENCES [MNT].[PARAMETRO] ([CODIGO_PARAMETRO])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla de combinación de parámetro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de combinación por parámetro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'CODIGO_COMBINACION_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de combinación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'CODIGO_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de parámetro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Orden de combinación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'ORDEN_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Valor del parámetro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de creación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'FECHA_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'FECHA_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'COMBINACION_PARAMETRO', @level2type = N'COLUMN', @level2name = N'TERMINAL_MODIFICACION';

