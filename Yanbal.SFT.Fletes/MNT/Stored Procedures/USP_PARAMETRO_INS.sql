CREATE PROCEDURE [MNT].[USP_PARAMETRO_INS]
(
	@CODIGO_UNIDAD_NEGOCIO				INT,
	@CODIGO_PARAMETRO					INT,
	@CODIGO								CHAR(3),
	@NOMBRE								NVARCHAR(100),
	@DESCRIPCION						NVARCHAR(255),
	@TIPO_PARAMETRO						CHAR(3),
	@INDICADOR_PERMITE_AGREGAR_VALOR	BIT,
	@INDICADOR_PERMITE_MODIFICAR_VALOR	BIT,
	@ESTADO_REGISTRO					CHAR(1),
	@USUARIO_CREACION					NVARCHAR(50),
	@TERMINAL_CREACION					NVARCHAR(50)
)
AS
/**********************************************************
-- Nombre: [MNT].[USP_PARAMETRO_INS] 
-- Propósito: Inserta un registro en la tabla MNT.PARAMETRO
-- Input: 
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO:	Parámetro de entrada de tipo char, que representa codigo.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@TIPO_PARAMETRO:	Parámetro de entrada de tipo char, que representa tipo parametro.
		@INDICADOR_PERMITE_AGREGAR_VALOR:	Parámetro de entrada de tipo bit, que representa indicador permite agregar valor.
		@INDICADOR_PERMITE_MODIFICAR_VALOR:	Parámetro de entrada de tipo bit, que representa indicador permite modificar valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.

-- Output: 
-- Creado por: GMD
-- Create Creación: 20-08-2014
-- Fecha Actualización:
-- **********************************************************/
DECLARE @ESTADO_ACTIVO CHAR(1) ='1'
BEGIN
	INSERT INTO MNT.PARAMETRO
	(
		[CODIGO_UNIDAD_NEGOCIO],
		[CODIGO_PARAMETRO],
		[CODIGO],
		[NOMBRE],
		[DESCRIPCION],
		[TIPO_PARAMETRO],
		[INDICADOR_PARAMETRO_SISTEMA],
		[INDICADOR_PERMITE_AGREGAR_VALOR],
		[INDICADOR_PERMITE_MODIFICAR_VALOR],
		[ESTADO_REGISTRO],
		[USUARIO_CREACION],
		[FECHA_CREACION],
		[TERMINAL_CREACION]
	)
	VALUES
	(
		@CODIGO_UNIDAD_NEGOCIO,
		@CODIGO_PARAMETRO,
		@CODIGO,
		@NOMBRE,
		@DESCRIPCION,		
		@TIPO_PARAMETRO,
		0,
		@INDICADOR_PERMITE_AGREGAR_VALOR, 
		@INDICADOR_PERMITE_MODIFICAR_VALOR,
		@ESTADO_REGISTRO,
		@USUARIO_CREACION,
		GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO),
		@TERMINAL_CREACION
	)
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[PARAMETRO].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS';

