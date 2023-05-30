CREATE TABLE [MNT].[ZONA_HORARIA] (
    [CODIGO_ZONA_HORARIA]   INT            NOT NULL,
    [HORA_UTC]              SMALLINT       NOT NULL,
    [MINUTO_UTC]            SMALLINT       NOT NULL,
    [DESCRIPCION]           NVARCHAR (255) NOT NULL,
    [OBSERVACION]           NVARCHAR (255) NULL,
    [ESTADO_REGISTRO]       CHAR (1)       NOT NULL,
    [USUARIO_CREACION]      NVARCHAR (50)  NOT NULL,
    [FECHA_CREACION]        DATETIME       NOT NULL,
    [TERMINAL_CREACION]     NVARCHAR (50)  NOT NULL,
    [USUARIO_MODIFICACION]  NVARCHAR (50)  NULL,
    [FECHA_MODIFICACION]    DATETIME       NULL,
    [TERMINAL_MODIFICACION] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_ZONA_HORARIA] PRIMARY KEY CLUSTERED ([CODIGO_ZONA_HORARIA] ASC) WITH (FILLFACTOR = 25)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla de Zonas Horarias.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de zona horaria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'CODIGO_ZONA_HORARIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Hora de utc por zona horaria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'HORA_UTC';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Mínimo de utc por zona horaria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'MINUTO_UTC';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción de zona horaria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'DESCRIPCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de creación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'FECHA_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que realiza la última modificación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'FECHA_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'ZONA_HORARIA', @level2type = N'COLUMN', @level2name = N'TERMINAL_MODIFICACION';

