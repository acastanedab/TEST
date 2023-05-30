CREATE TABLE [MNT].[PARAMETRO_VALOR] (
    [CODIGO_UNIDAD_NEGOCIO] INT            NOT NULL,
    [CODIGO_PARAMETRO]      INT            NOT NULL,
    [CODIGO_SECCION]        INT            NOT NULL,
    [CODIGO_VALOR]          INT            NOT NULL,
    [VALOR]                 NVARCHAR (255) NULL,
    [ESTADO_REGISTRO]       CHAR (1)       NOT NULL,
    [OBSERVACION]           NVARCHAR (255) NULL,
    [USUARIO_CREACION]      NVARCHAR (50)  NOT NULL,
    [FECHA_CREACION]        DATETIME       NOT NULL,
    [TERMINAL_CREACION]     NVARCHAR (50)  NOT NULL,
    [USUARIO_MODIFICACION]  NVARCHAR (50)  NULL,
    [FECHA_MODIFICACION]    DATETIME       NULL,
    [TERMINAL_MODIFICACION] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_PARAMETRO_VALOR] PRIMARY KEY CLUSTERED ([CODIGO_UNIDAD_NEGOCIO] ASC, [CODIGO_PARAMETRO] ASC, [CODIGO_VALOR] ASC, [CODIGO_SECCION] ASC) WITH (FILLFACTOR = 25),
    CONSTRAINT [FK_PARAMETRO_VALOR_PARAMETRO_SECCION] FOREIGN KEY ([CODIGO_PARAMETRO], [CODIGO_SECCION]) REFERENCES [MNT].[PARAMETRO_SECCION] ([CODIGO_PARAMETRO], [CODIGO_SECCION]),
    CONSTRAINT [FK_PARAMETRO_VALOR_UNIDAD_NEGOCIO] FOREIGN KEY ([CODIGO_UNIDAD_NEGOCIO]) REFERENCES [MNT].[UNIDAD_NEGOCIO] ([CODIGO_UNIDAD_NEGOCIO])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla de parámetro valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de unidad de negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de parámetro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de sección.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'CODIGO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código del valor del parámetro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'CODIGO_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción del  valor del parámetro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de creación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'FECHA_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que realiza la última modificación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'FECHA_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_VALOR', @level2type = N'COLUMN', @level2name = N'TERMINAL_MODIFICACION';

