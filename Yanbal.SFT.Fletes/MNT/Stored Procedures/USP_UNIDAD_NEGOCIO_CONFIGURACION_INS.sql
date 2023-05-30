CREATE PROCEDURE [MNT].[USP_UNIDAD_NEGOCIO_CONFIGURACION_INS]
(
	@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION INT,
	@CODIGO_UNIDAD_NEGOCIO INT,
	@CODIGO_CULTURA CHAR(5),
	@CODIGO_ZONA_HORARIA INT,
	@FORMA_VISUALIZACION_REPORTE CHAR(1),
	@LOGO_COMPANIA IMAGE,
	@LOGO_REPORTE IMAGE,
	@FILAS_POR_PAGINA TINYINT,
	@MINIMO_CARACTERES_GLOSA TINYINT,
	@MINIMO_VOCALES_GLOSA TINYINT,
	@INDICADOR_CONTRAER_MENU BIT,
	@ESTADO_REGISTRO CHAR(1),
	@USUARIO_CREACION NVARCHAR(50),
	@TERMINAL_CREACION NVARCHAR(50),
	@CODIGO_UNIDAD_NEGOCIO_CONTEXTO INT
)
AS
/******************************************************
-- Nombre: [MNT].[USP_UNIDAD_NEGOCIO_CONFIGURACION_INS]
-- Propósito: Inserta un registro en la tabla MNT.UNIDAD_NEGOCIO_CONFIGURACION
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
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
		@CODIGO_UNIDAD_NEGOCIO_CONTEXTO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.
-- Output: 

-- Creado por: GMD
-- Fecha de Creación: 2014-09-19
-- Fecha de Actualización:
-- *******************************************************/
BEGIN
INSERT INTO MNT.UNIDAD_NEGOCIO_CONFIGURACION(
							CODIGO_UNIDAD_NEGOCIO_CONFIGURACION,
							CODIGO_UNIDAD_NEGOCIO,
							CODIGO_CULTURA,
							CODIGO_ZONA_HORARIA,
							FORMA_VISUALIZACION_REPORTE,
							LOGO_COMPANIA,
							LOGO_REPORTE,
							FILAS_POR_PAGINA,
							MINIMO_CARACTERES_GLOSA,
							MINIMO_VOCALES_GLOSA,
							INDICADOR_CONTRAER_MENU,
							ESTADO_REGISTRO,
							USUARIO_CREACION,
							FECHA_CREACION,
							TERMINAL_CREACION
							)
VALUES(	 @CODIGO_UNIDAD_NEGOCIO_CONFIGURACION
		,@CODIGO_UNIDAD_NEGOCIO
		,@CODIGO_CULTURA
		,@CODIGO_ZONA_HORARIA
		,@FORMA_VISUALIZACION_REPORTE
		,@LOGO_COMPANIA
		,@LOGO_REPORTE
		,@FILAS_POR_PAGINA
		,@MINIMO_CARACTERES_GLOSA
		,@MINIMO_VOCALES_GLOSA
		,@INDICADOR_CONTRAER_MENU
		,@ESTADO_REGISTRO
		,@USUARIO_CREACION
		,GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO_CONTEXTO)
		,@TERMINAL_CREACION)
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[UNIDAD_NEGOCIO_CONFIGURACION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS';

