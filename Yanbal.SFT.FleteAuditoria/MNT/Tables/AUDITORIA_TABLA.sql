CREATE TABLE [MNT].[AUDITORIA_TABLA] (
    [CODIGO_AUDITORIA_TABLA]      INT            IDENTITY (1, 1) NOT NULL,
    [NOMBRE_TABLA]                NVARCHAR (50)  NOT NULL,
    [ESTADO_REGISTRO]             CHAR (1)       NOT NULL,
    [DESCRIPCION_ESTADO_REGISTRO] NVARCHAR (255) NULL,
    [USUARIO_AUDITORIA]           NVARCHAR (50)  NOT NULL,
    [FECHA_AUDITORIA]             DATETIME       NOT NULL,
    [TERMINAL_AUDITORIA]          NVARCHAR (50)  NULL,
    CONSTRAINT [PK_AUDITORIA_TABLA] PRIMARY KEY CLUSTERED ([CODIGO_AUDITORIA_TABLA] ASC) WITH (FILLFACTOR = 25)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla que contiene las tablas de la auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de tabla de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_TABLA', @level2type = N'COLUMN', @level2name = N'CODIGO_AUDITORIA_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre de tabla.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_TABLA', @level2type = N'COLUMN', @level2name = N'NOMBRE_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_TABLA', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción del estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_TABLA', @level2type = N'COLUMN', @level2name = N'DESCRIPCION_ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_TABLA', @level2type = N'COLUMN', @level2name = N'USUARIO_AUDITORIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_TABLA', @level2type = N'COLUMN', @level2name = N'FECHA_AUDITORIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Terminal de auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'AUDITORIA_TABLA', @level2type = N'COLUMN', @level2name = N'TERMINAL_AUDITORIA';

