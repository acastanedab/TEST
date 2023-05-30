CREATE TABLE [MNT].[PAIS] (
    [CODIGO_PAIS]           CHAR (2)       NOT NULL,
    [NOMBRE]                NVARCHAR (50)  NOT NULL,
    [CODIGO_PAIS_ZONA]      CHAR (3)       NOT NULL,
    [OBSERVACION]           NVARCHAR (255) NOT NULL,
    [ESTADO_REGISTRO]       CHAR (1)       NOT NULL,
    [USUARIO_CREACION]      NVARCHAR (50)  NOT NULL,
    [FECHA_CREACION]        DATETIME       NOT NULL,
    [TERMINAL_CREACION]     NVARCHAR (50)  NOT NULL,
    [USUARIO_MODIFICACION]  NVARCHAR (50)  NULL,
    [FECHA_MODIFICACION]    DATETIME       NULL,
    [TERMINAL_MODIFICACION] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_PAIS] PRIMARY KEY CLUSTERED ([CODIGO_PAIS] ASC) WITH (FILLFACTOR = 25)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla donde se registran los países.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de país.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre de país.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código del país en el formato ISO 3166-1 alfa-2.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'CODIGO_PAIS_ZONA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de creación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'FECHA_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que realiza la última modificación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'FECHA_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'PAIS', @level2type = N'COLUMN', @level2name = N'TERMINAL_MODIFICACION';

