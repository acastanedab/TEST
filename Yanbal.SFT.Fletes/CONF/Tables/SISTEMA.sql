﻿CREATE TABLE [CONF].[SISTEMA] (
    [CODIGO_SISTEMA]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [LINEA_NEGOCIO]         VARCHAR (50)  NOT NULL,
    [NOMBRE_SISTEMA]        VARCHAR (50)  NOT NULL,
    [DESCRIPCION]           VARCHAR (200) NULL,
    [ESTADO_REGISTRO]       CHAR (1)      NOT NULL,
    [USUARIO_CREACION]      VARCHAR (100) NOT NULL,
    [FECHA_CREACION]        DATETIME      NOT NULL,
    [TERMINAL_CREACION]     VARCHAR (100) NOT NULL,
    [USUARIO_MODIFICACION]  VARCHAR (100) NULL,
    [FECHA_MODIFICACION]    DATETIME      NULL,
    [TERMINAL_MODIFICACION] VARCHAR (100) NULL,
    CONSTRAINT [PK_SISTEMA] PRIMARY KEY CLUSTERED ([CODIGO_SISTEMA] ASC)
);
