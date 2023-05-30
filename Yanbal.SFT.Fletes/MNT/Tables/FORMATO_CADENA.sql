CREATE TABLE [MNT].[FORMATO_CADENA] (
    [CODIGO_FORMATO_CADENA] INT            NOT NULL,
    [FORMATO]               NVARCHAR (50)  NULL,
    [TIPO_FORMATO]          CHAR (1)       NULL,
    [FORMATO_LARGO]         BIT            NULL,
    [OBSERVACION]           NVARCHAR (255) NULL,
    [ESTADO_REGISTRO]       CHAR (1)       NULL,
    [USUARIO_CREACION]      NVARCHAR (50)  NULL,
    [FECHA_CREACION]        DATETIME       NULL,
    [TERMINAL_CREACION]     NVARCHAR (50)  NULL,
    [USUARIO_MODIFICACION]  NVARCHAR (50)  NULL,
    [FECHA_MODIFICACION]    DATETIME       NULL,
    [TERMINAL_MODIFICACION] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_FORMATO_CADENA] PRIMARY KEY CLUSTERED ([CODIGO_FORMATO_CADENA] ASC) WITH (FILLFACTOR = 25)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla donde se registran las monedas de los países.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de formato en cadena.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'CODIGO_FORMATO_CADENA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Formato de cadena.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'FORMATO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'F: Fecha / H: Hora / E: Número Entero / D: Número Decimal.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'TIPO_FORMATO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Formato largo de cadena.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'FORMATO_LARGO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de creación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'FECHA_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que realiza la última modificación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'FECHA_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'FORMATO_CADENA', @level2type = N'COLUMN', @level2name = N'TERMINAL_MODIFICACION';

