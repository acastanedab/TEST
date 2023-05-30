CREATE PROCEDURE [MNT].[USP_TIPO_ZONA_UBIGEO_INS]
(
	@CODIGO_TIPO_ZONA_UBIGEO	INT,
	@CODIGO_UNIDAD_NEGOCIO		INT,
	@CODIGO_ZONA				CHAR(50) ,
	@CODIGO_PAIS				CHAR(50) ,
	@CODIGO_NIVEL_1				CHAR(50),
	@NIVEL_1					NVARCHAR(150),
	@CODIGO_NIVEL_2				CHAR(50),
	@NIVEL_2					NVARCHAR(150),
	@CODIGO_NIVEL_3				CHAR(50),
	@NIVEL_3					NVARCHAR(150),
	@CODIGO_TIPO_ZONA			VARCHAR(50),
	@ESTADO_REGISTRO			CHAR(1),
	@USUARIO_CREACION			NVARCHAR(50),
	@TERMINAL_CREACION			NVARCHAR(50)
)
AS
/*******************************************************
-- Nombre: [MNT].[UPS_TIPO_ZONA_UBIGEO_INS]
-- Propósito: Inserta un registro en la tabla MNT.TIPO_ZONA_UBIGEO
-- Input: 
		@CODIGO_TIPO_ZONA_UBIGEO:	Parámetro de entrada de tipo int, que representa codigo tipo zona ubigeo.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_ZONA:	Parámetro de entrada de tipo char, que representa codigo zona.
		@CODIGO_PAIS:	Parámetro de entrada de tipo char, que representa codigo pais.
		@CODIGO_NIVEL_1:	Parámetro de entrada de tipo char, que representa codigo nivel 1.
		@NIVEL_1:	Parámetro de entrada de tipo nvarchar, que representa nivel 1.
		@CODIGO_NIVEL_2:	Parámetro de entrada de tipo char, que representa codigo nivel 2.
		@NIVEL_2:	Parámetro de entrada de tipo nvarchar, que representa nivel 2.
		@CODIGO_NIVEL_3:	Parámetro de entrada de tipo char, que representa codigo nivel 3.
		@NIVEL_3:	Parámetro de entrada de tipo nvarchar, que representa nivel 3.
		@CODIGO_TIPO_ZONA:	Parámetro de entrada de tipo varchar, que representa codigo tipo zona.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
Creado por: GMD
-- Output: 
-- Creado por: GMD
-- Fecha de Creación: 28-08-2014
-- Fecha de Actualización:
-- *******************************************************/
BEGIN
	INSERT INTO MNT.TIPO_ZONA_UBIGEO
	(
		CODIGO_TIPO_ZONA_UBIGEO,
		CODIGO_UNIDAD_NEGOCIO,
		CODIGO_ZONA,
		CODIGO_PAIS,
		CODIGO_NIVEL_1,
		NIVEL_1,
		CODIGO_NIVEL_2,
		NIVEL_2,
		CODIGO_NIVEL_3,
		NIVEL_3,
		CODIGO_TIPO_ZONA,
		ESTADO_REGISTRO,
		USUARIO_CREACION,
		FECHA_CREACION,
		TERMINAL_CREACION
	)
	VALUES
	(
		@CODIGO_TIPO_ZONA_UBIGEO,
		@CODIGO_UNIDAD_NEGOCIO,
		@CODIGO_ZONA,
		@CODIGO_PAIS,
		@CODIGO_NIVEL_1,
		@NIVEL_1,
		@CODIGO_NIVEL_2,
		@NIVEL_2,
		@CODIGO_NIVEL_3,
		@NIVEL_3,
		@CODIGO_TIPO_ZONA,
		@ESTADO_REGISTRO,
		@USUARIO_CREACION,
		GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO),
		@TERMINAL_CREACION
	)
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[TIPO_ZONA_UBIGEO].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS';

