CREATE TABLE [MNT].[UNIDAD_NEGOCIO_CONFIGURACION] (
    [CODIGO_UNIDAD_NEGOCIO_CONFIGURACION] INT            NOT NULL,
    [CODIGO_UNIDAD_NEGOCIO]               INT            NOT NULL,
    [CODIGO_CULTURA]                      CHAR (5)       NOT NULL,
    [CODIGO_ZONA_HORARIA]                 INT            NOT NULL,
    [FORMA_VISUALIZACION_REPORTE]         CHAR (1)       NOT NULL,
    [LOGO_REPORTE]                        IMAGE          NULL,
    [LOGO_COMPANIA]                       IMAGE          NULL,
    [MAXIMO_FILAS_POR_CONSULTA]           INT            NULL,
    [FILAS_POR_PAGINA]                    TINYINT        NOT NULL,
    [MINIMO_CARACTERES_GLOSA]             TINYINT        NOT NULL,
    [MINIMO_VOCALES_GLOSA]                TINYINT        NOT NULL,
    [INDICADOR_CONTRAER_MENU]             BIT            NOT NULL,
    [OBSERVACION]                         NVARCHAR (255) NULL,
    [ESTADO_REGISTRO]                     CHAR (1)       NOT NULL,
    [USUARIO_CREACION]                    NVARCHAR (50)  NOT NULL,
    [FECHA_CREACION]                      DATETIME       NOT NULL,
    [TERMINAL_CREACION]                   NVARCHAR (50)  NOT NULL,
    [USUARIO_MODIFICACION]                NVARCHAR (50)  NULL,
    [FECHA_MODIFICACION]                  DATETIME       NULL,
    [TERMINAL_MODIFICACION]               NVARCHAR (50)  NULL,
    CONSTRAINT [PK_UNIDAD_NEGOCIO_CONFIGURACION] PRIMARY KEY CLUSTERED ([CODIGO_UNIDAD_NEGOCIO_CONFIGURACION] ASC) WITH (FILLFACTOR = 25),
    CONSTRAINT [FK_UNIDAD_NEGOCIO_CONFIGURACION_CULTURA] FOREIGN KEY ([CODIGO_CULTURA]) REFERENCES [MNT].[CULTURA] ([CODIGO_CULTURA]),
    CONSTRAINT [FK_UNIDAD_NEGOCIO_CONFIGURACION_ZONA_HORARIA] FOREIGN KEY ([CODIGO_ZONA_HORARIA]) REFERENCES [MNT].[ZONA_HORARIA] ([CODIGO_ZONA_HORARIA])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tabla de unidad de negocio de configuración.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de unidad de negocio de configuración.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'CODIGO_UNIDAD_NEGOCIO_CONFIGURACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de unidad de negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de cultura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'CODIGO_CULTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código de zona horaria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'CODIGO_ZONA_HORARIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Forma de visualización de reporte.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'FORMA_VISUALIZACION_REPORTE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Logo de reporte.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'LOGO_REPORTE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Logo de campaña.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'LOGO_COMPANIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Máximo de filas por consulta de negocio de configuración.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'MAXIMO_FILAS_POR_CONSULTA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Filas por página de negocio de configuración.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'FILAS_POR_PAGINA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Mínimo de caracteres por glosa.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'MINIMO_CARACTERES_GLOSA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Mínimo de vocales por menú.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'MINIMO_VOCALES_GLOSA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indicador que permite contraer el menú.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'INDICADOR_CONTRAER_MENU';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Observación por modificación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Estado del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha de creación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'FECHA_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se crea el registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que realiza la última modificación del registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'FECHA_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP del terminal desde donde se realizó la última modificación al registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'TABLE', @level1name = N'UNIDAD_NEGOCIO_CONFIGURACION', @level2type = N'COLUMN', @level2name = N'TERMINAL_MODIFICACION';

