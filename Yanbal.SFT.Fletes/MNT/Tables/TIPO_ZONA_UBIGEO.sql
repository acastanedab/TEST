CREATE TABLE [MNT].[TIPO_ZONA_UBIGEO] (
    [CODIGO_TIPO_ZONA_UBIGEO] INT            NOT NULL,
    [CODIGO_UNIDAD_NEGOCIO]   INT            NOT NULL,
    [CODIGO_ZONA]             CHAR (50)      NOT NULL,
    [CODIGO_PAIS]             CHAR (50)      NOT NULL,
    [CODIGO_NIVEL_1]          CHAR (50)      NULL,
    [NIVEL_1]                 NVARCHAR (150) NULL,
    [CODIGO_NIVEL_2]          CHAR (50)      NULL,
    [NIVEL_2]                 NVARCHAR (150) NULL,
    [CODIGO_NIVEL_3]          CHAR (50)      NULL,
    [NIVEL_3]                 NVARCHAR (150) NULL,
    [CODIGO_TIPO_ZONA]        NVARCHAR (255) NOT NULL,
    [OBSERVACION]             NVARCHAR (255) NULL,
    [ESTADO_REGISTRO]         CHAR (1)       NOT NULL,
    [USUARIO_CREACION]        NVARCHAR (50)  NOT NULL,
    [FECHA_CREACION]          DATETIME       NOT NULL,
    [TERMINAL_CREACION]       NVARCHAR (50)  NOT NULL,
    [USUARIO_MODIFICACION]    NVARCHAR (50)  NULL,
    [FECHA_MODIFICACION]      DATETIME       NULL,
    [TERMINAL_MODIFICACION]   NVARCHAR (50)  NULL,
    CONSTRAINT [PK_TIPO_ZONA_UBIGEO] PRIMARY KEY CLUSTERED ([CODIGO_TIPO_ZONA_UBIGEO] ASC) WITH (FILLFACTOR = 25),
    CONSTRAINT [PK_TIPO_ZONA_UBIGEO_UNIDAD_NEGOCIO] FOREIGN KEY ([CODIGO_UNIDAD_NEGOCIO]) REFERENCES [MNT].[UNIDAD_NEGOCIO] ([CODIGO_UNIDAD_NEGOCIO])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla de tipo de zona por ubigeo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de tipo de zona ubigeo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'CODIGO_TIPO_ZONA_UBIGEO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de unidad de negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de zona.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'CODIGO_ZONA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de país.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de nivel 1.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'CODIGO_NIVEL_1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción del nivel 1.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'NIVEL_1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de nivel 2.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'CODIGO_NIVEL_2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción del nivel 2.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'NIVEL_2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de nivel 3.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'CODIGO_NIVEL_3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción del nivel 3.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'NIVEL_3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de tipo de zona.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'CODIGO_TIPO_ZONA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de creación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'FECHA_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que realiza la última modificación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'FECHA_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'TIPO_ZONA_UBIGEO', @level2type = N'COLUMN', @level2name = N'TERMINAL_MODIFICACION';

