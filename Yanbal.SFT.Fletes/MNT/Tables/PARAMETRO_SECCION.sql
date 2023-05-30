CREATE TABLE [MNT].[PARAMETRO_SECCION] (
    [CODIGO_PARAMETRO]       INT            NOT NULL,
    [CODIGO_SECCION]         INT            NOT NULL,
    [NOMBRE]                 NVARCHAR (100) NOT NULL,
    [TIPO_SECCION]           CHAR (3)       NOT NULL,
    [INDICADOR_SOLO_LECTURA] BIT            NOT NULL,
    [INDICADOR_OBLIGATORIO]  BIT            NOT NULL,
    [INDICADOR_CREACION]     BIT            NOT NULL,
    [INDICADOR_RANGO]        CHAR (1)       NULL,
    [ESTADO_REGISTRO]        CHAR (1)       NOT NULL,
    [OBSERVACION]            NVARCHAR (255) NULL,
    [USUARIO_CREACION]       NVARCHAR (50)  NOT NULL,
    [FECHA_CREACION]         DATETIME       NOT NULL,
    [TERMINAL_CREACION]      NVARCHAR (50)  NOT NULL,
    [USUARIO_MODIFICACION]   NVARCHAR (50)  NULL,
    [FECHA_MODIFICACION]     DATETIME       NULL,
    [TERMINAL_MODIFICACION]  NVARCHAR (50)  NULL,
    CONSTRAINT [PK_PARAMETRO_SECCION] PRIMARY KEY CLUSTERED ([CODIGO_PARAMETRO] ASC, [CODIGO_SECCION] ASC) WITH (FILLFACTOR = 25),
    CONSTRAINT [FK_PARAMETRO_SECCION_PARAMETRO] FOREIGN KEY ([CODIGO_PARAMETRO]) REFERENCES [MNT].[PARAMETRO] ([CODIGO_PARAMETRO])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla de parámetro sección.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de parámetro de sección.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de sección.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'CODIGO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre de parámetro de sección.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tipo de sección.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'TIPO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indica que los valores de esta sección no se podrán modificar.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'INDICADOR_SOLO_LECTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indicador de obligación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'INDICADOR_OBLIGATORIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indicador de creación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'INDICADOR_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indicador de rango.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'INDICADOR_RANGO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de creación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'FECHA_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que realiza la última modificación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'FECHA_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PARAMETRO_SECCION', @level2type = N'COLUMN', @level2name = N'TERMINAL_MODIFICACION';

