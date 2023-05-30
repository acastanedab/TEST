CREATE TABLE [MNT].[FORMULA] (
    [CODIGO_FORMULA]        INT             NOT NULL,
    [CODIGO_UNIDAD_NEGOCIO] INT             NOT NULL,
    [CODIGO_PARAMETRO]      INT             NOT NULL,
    [VALOR]                 NVARCHAR (255)  NOT NULL,
    [OPERACION]             CHAR (1)        NOT NULL,
    [FACTOR]                DECIMAL (18, 4) NOT NULL,
    [TIPO_FACTOR]           NCHAR (1)       NOT NULL,
    [OBSERVACION]           NVARCHAR (255)  NULL,
    [ESTADO_REGISTRO]       CHAR (1)        NOT NULL,
    [USUARIO_CREACION]      NVARCHAR (50)   NOT NULL,
    [FECHA_CREACION]        DATETIME        NOT NULL,
    [TERMINAL_CREACION]     NVARCHAR (50)   NOT NULL,
    [USUARIO_MODIFICACION]  NVARCHAR (50)   NULL,
    [FECHA_MODIFICACION]    DATETIME        NULL,
    [TERMINAL_MODIFICACION] NVARCHAR (50)   NULL,
    [ORDEN]                 TINYINT         NULL,
    [VALOR_TIPO_ENVIO]      NVARCHAR (255)  NULL,
    CONSTRAINT [PK_FORMULA] PRIMARY KEY CLUSTERED ([CODIGO_FORMULA] ASC) WITH (FILLFACTOR = 25),
    CONSTRAINT [FK_FORMULA_PARAMETRO] FOREIGN KEY ([CODIGO_PARAMETRO]) REFERENCES [MNT].[PARAMETRO] ([CODIGO_PARAMETRO]),
    CONSTRAINT [FK_FORMULA_UNIDAD_NEGOCIO] FOREIGN KEY ([CODIGO_UNIDAD_NEGOCIO]) REFERENCES [MNT].[UNIDAD_NEGOCIO] ([CODIGO_UNIDAD_NEGOCIO])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla de fórmula.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de fórmula.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'CODIGO_FORMULA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de unidad de negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de parámetro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Operación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'OPERACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Factor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'FACTOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tipo de factor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'TIPO_FACTOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de creación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'FECHA_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que realiza la última modificación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'FECHA_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Orden.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'ORDEN';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indicador que valida si se van ha incluir pagos procesados', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMULA', @level2type = N'COLUMN', @level2name = N'VALOR_TIPO_ENVIO';

