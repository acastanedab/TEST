﻿CREATE   PROCEDURE [CONF].[USP_UPDATEVERSION_COMPONENTE_SEL]
(
	@NOMBRE_SISTEMA VARCHAR(100),
    @NOMBRE_COMPONENTE VARCHAR(100)
)
AS
BEGIN
/**************************************************************
Nombre SP: [CONF].[USP_UPDATEVERSION_COMPONENTE_SEL]
Propósito: Listar Versionamiento por Componente.
Input:
		@@NOMBRE_SISTEMA:	Nombre del Sistema.	
		@NOMBRE_COMPONENTE:	Nombre del Componente.	

AUDITORÍA
29/01/2023	DDURAND	UNI-9103 Mejora/Rediseño en el registro de Versionamiento de las aplicaciones de los pases.
EXEC [CONF].[USP_UPDATEVERSION_COMPONENTE_SEL] 'SFC','srvSFCCollect'
***************************************************************/
SET NOCOUNT ON

SELECT TOP(1)
ST.LINEA_NEGOCIO,
ST.CODIGO_SISTEMA,
ST.NOMBRE_SISTEMA,
STV.NOMBRE_VERSION
INTO #TEMPORAL_SISTEMA
FROM CONF.SISTEMA ST WITH(NOLOCK)
LEFT JOIN CONF.SISTEMA_VERSION STV WITH(NOLOCK) ON ST.CODIGO_SISTEMA = STV.CODIGO_SISTEMA
WHERE ST.NOMBRE_SISTEMA = @NOMBRE_SISTEMA AND ST.ESTADO_REGISTRO = '1' AND STV.ESTADO_REGISTRO = '1'
ORDER BY STV.CODIGO_SISTEMA_VERSION DESC

SELECT TOP(1)
TST.LINEA_NEGOCIO AS LineaNegocio,
TST.NOMBRE_SISTEMA AS NombreSistema,
TST.NOMBRE_VERSION AS NombreVersion,
CP.CODIGO_COMPONENTE AS CodigoComponente,
CP.NOMBRE_COMPONENTE AS NombreComponente,
CPV.NOMBRE_TAGS AS NombreTags
FROM CONF.COMPONENTE CP WITH(NOLOCK)
LEFT JOIN CONF.COMPONENTE_VERSION CPV WITH(NOLOCK) ON CP.CODIGO_COMPONENTE = CPV.CODIGO_COMPONENTE
LEFT JOIN #TEMPORAL_SISTEMA TST ON CP.CODIGO_SISTEMA = TST.CODIGO_SISTEMA
WHERE CP.NOMBRE_COMPONENTE = @NOMBRE_COMPONENTE
ORDER BY CPV.CODIGO_COMPONENTE_VERSION DESC
END