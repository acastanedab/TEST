CREATE TABLE [MNT].[CULTURA] (
    [CODIGO_CULTURA]                CHAR (5)       NOT NULL,
    [CODIGO_IDIOMA]                 CHAR (2)       NOT NULL,
    [CODIGO_PAIS]                   CHAR (2)       NOT NULL,
    [CODIGO_FORMATO_FECHA_CORTA]    INT            NOT NULL,
    [CODIGO_FORMATO_FECHA_LARGA]    INT            NULL,
    [CODIGO_FORMATO_HORA_CORTA]     INT            NULL,
    [CODIGO_FORMATO_HORA_LARGA]     INT            NULL,
    [CODIGO_FORMATO_NUMERO_ENTERO]  INT            NOT NULL,
    [CODIGO_FORMATO_NUMERO_DECIMAL] INT            NOT NULL,
    [LIMITE_SUPERIOR_ANIO]          SMALLINT       NULL,
    [OBSERVACION]                   NVARCHAR (255) NULL,
    [ESTADO_REGISTRO]               CHAR (1)       NOT NULL,
    [USUARIO_CREACION]              NVARCHAR (50)  NOT NULL,
    [FECHA_CREACION]                DATETIME       NOT NULL,
    [TERMINAL_CREACION]             NVARCHAR (50)  NOT NULL,
    [USUARIO_MODIFICACION]          NVARCHAR (50)  NULL,
    [FECHA_MODIFICACION]            DATETIME       NULL,
    [TERMINAL_MODIFICACION]         NVARCHAR (50)  NULL,
    CONSTRAINT [PK_CULTURA] PRIMARY KEY CLUSTERED ([CODIGO_CULTURA] ASC) WITH (FILLFACTOR = 25),
    CONSTRAINT [FK_CULTURA_PAIS] FOREIGN KEY ([CODIGO_PAIS]) REFERENCES [MNT].[PAIS] ([CODIGO_PAIS])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla donde se registran las monedas de los países.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de cultura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'CODIGO_CULTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de idioma.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'CODIGO_IDIOMA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de país.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de formato de fecha corta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'CODIGO_FORMATO_FECHA_CORTA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de formato de fecha larga.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'CODIGO_FORMATO_FECHA_LARGA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de formato de hora corta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'CODIGO_FORMATO_HORA_CORTA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de formato de hora larga.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'CODIGO_FORMATO_HORA_LARGA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de formato de número entero.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'CODIGO_FORMATO_NUMERO_ENTERO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de formato de número decimal.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'CODIGO_FORMATO_NUMERO_DECIMAL';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Límite superior año.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'LIMITE_SUPERIOR_ANIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de creación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'FECHA_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que realiza la última modificación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'FECHA_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'CULTURA', @level2type = N'COLUMN', @level2name = N'TERMINAL_MODIFICACION';

