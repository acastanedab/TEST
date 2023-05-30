﻿CREATE TYPE [CONF].[LISTA_COMPONENTE_VERSION] AS TABLE (
    [NOMBRE_COMPONENTE]    VARCHAR (100)  NULL,
    [CODIGO_REQUERIMIENTO] VARCHAR (100)  NULL,
    [NOMBRE_TAGS]          VARCHAR (100)  NULL,
    [REPOSITORIO]          NVARCHAR (250) NULL,
    [CANTIDAD_ITERACIONES] INT            NULL);
