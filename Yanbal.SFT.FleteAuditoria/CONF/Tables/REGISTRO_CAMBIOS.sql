﻿CREATE TABLE [CONF].[REGISTRO_CAMBIOS] (
    [CODIGO_VERSION]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [NUMERO]                 VARCHAR (255) NOT NULL,
    [TAG]                    VARCHAR (255) NOT NULL,
    [HASHKEY]                VARCHAR (255) NOT NULL,
    [SISTEMA]                VARCHAR (255) NOT NULL,
    [RETROCESO]              VARCHAR (1)   NOT NULL,
    [USUARIO_CREACION]       VARCHAR (50)  NOT NULL,
    [FECHA_CREACION]         DATETIME      NOT NULL,
    [TERMINAL_CREACION]      VARCHAR (50)  NOT NULL,
    [USUARIO_ACTUALIZACION]  VARCHAR (50)  NULL,
    [FECHA_ACTUALIZACION]    DATETIME      NULL,
    [TERMINAL_ACTUALIZACION] VARCHAR (50)  NULL
);

