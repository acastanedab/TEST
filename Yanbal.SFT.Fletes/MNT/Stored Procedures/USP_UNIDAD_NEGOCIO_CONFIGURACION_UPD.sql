CREATE PROCEDURE [MNT].[USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD]
(
	@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION	INT,
	@CODIGO_UNIDAD_NEGOCIO					INT,
	@CODIGO_CULTURA							CHAR(5),
	@CODIGO_ZONA_HORARIA					INT,
	@FORMA_VISUALIZACION_REPORTE			CHAR(1),
	@LOGO_COMPANIA							IMAGE,
	@LOGO_REPORTE							IMAGE,
	@FILAS_POR_PAGINA						TINYINT,
	@MINIMO_CARACTERES_GLOSA				TINYINT,
	@MINIMO_VOCALES_GLOSA					TINYINT,
	@INDICADOR_CONTRAER_MENU				BIT,
	@OBSERVACION							NVARCHAR(255),
	@ESTADO_REGISTRO						CHAR(1),
	@USUARIO_MODIFICACION					NVARCHAR(50),
	@TERMINAL_MODIFICACION					NVARCHAR(50),
	@CODIGO_UNIDAD_NEGOCIO_CONTEXTO			INT
)
AS
/*****************************************************
-- Nombre: [MNT].[USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD]
-- Propósito: Actualiza el registro de la tabla MNT.UNIDAD_NEGOCIO_CONFIGURACION
-- Input: 
		@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION:	Parámetro de entrada de tipo int, que representa codigo unidad negocio configuracion.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_CULTURA:	Parámetro de entrada de tipo char, que representa codigo cultura.
		@CODIGO_ZONA_HORARIA:	Parámetro de entrada de tipo int, que representa codigo zona horaria.
		@FORMA_VISUALIZACION_REPORTE:	Parámetro de entrada de tipo char, que representa forma visualizacion reporte.
		@LOGO_COMPANIA:	Parámetro de entrada de tipo image, que representa logo compania.
		@LOGO_REPORTE:	Parámetro de entrada de tipo image, que representa logo reporte.
		@FILAS_POR_PAGINA:	Parámetro de entrada de tipo tinyint, que representa filas por pagina.
		@MINIMO_CARACTERES_GLOSA:	Parámetro de entrada de tipo tinyint, que representa minimo caracteres glosa.
		@MINIMO_VOCALES_GLOSA:	Parámetro de entrada de tipo tinyint, que representa minimo vocales glosa.
		@INDICADOR_CONTRAER_MENU:	Parámetro de entrada de tipo bit, que representa indicador contraer menu.
		@OBSERVACION:	Parámetro de entrada de tipo nvarchar, que representa observacion.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
		@CODIGO_UNIDAD_NEGOCIO_CONTEXTO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.
-- Output: 

-- Creado por: GMD
-- Fecha de Creación: 2014-09-19
-- Fecha de Actualización:
-- ******************************************************/
BEGIN
UPDATE MNT.UNIDAD_NEGOCIO_CONFIGURACION
	SET CODIGO_UNIDAD_NEGOCIO		= @CODIGO_UNIDAD_NEGOCIO,
		CODIGO_CULTURA				= @CODIGO_CULTURA,
		CODIGO_ZONA_HORARIA			= @CODIGO_ZONA_HORARIA,
		FORMA_VISUALIZACION_REPORTE = @FORMA_VISUALIZACION_REPORTE,
		LOGO_COMPANIA = CASE WHEN @LOGO_COMPANIA IS NULL THEN LOGO_COMPANIA ELSE @LOGO_COMPANIA END,
		LOGO_REPORTE = CASE WHEN @LOGO_REPORTE IS NULL THEN LOGO_REPORTE ELSE @LOGO_REPORTE END,
		FILAS_POR_PAGINA			= @FILAS_POR_PAGINA,
		MINIMO_CARACTERES_GLOSA		= @MINIMO_CARACTERES_GLOSA,
		MINIMO_VOCALES_GLOSA		= @MINIMO_VOCALES_GLOSA,
		INDICADOR_CONTRAER_MENU		= @INDICADOR_CONTRAER_MENU,
		OBSERVACION					= @OBSERVACION,
		ESTADO_REGISTRO				= @ESTADO_REGISTRO,
		USUARIO_MODIFICACION		= @USUARIO_MODIFICACION,
		FECHA_MODIFICACION			= GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO_CONTEXTO),
		TERMINAL_MODIFICACION		= @TERMINAL_MODIFICACION
	WHERE	CODIGO_UNIDAD_NEGOCIO_CONFIGURACION = @CODIGO_UNIDAD_NEGOCIO_CONFIGURACION
	AND		CODIGO_UNIDAD_NEGOCIO = @CODIGO_UNIDAD_NEGOCIO
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Actualiza el registro de la tabla [MNT].[UNIDAD_NEGOCIO_CONFIGURACION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD';

