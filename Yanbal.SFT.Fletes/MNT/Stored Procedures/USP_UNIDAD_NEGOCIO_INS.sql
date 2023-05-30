CREATE PROCEDURE [MNT].[USP_UNIDAD_NEGOCIO_INS]
(
	@CODIGO_UNIDAD_NEGOCIO INT,
	@NOMBRE NVARCHAR(50),
	@CODIGO_PAIS CHAR(3),
    @RAZON_SOCIAL_COMPANIA NVARCHAR(255),
    @DIRECCION_COMPANIA NVARCHAR(255),
    @ESTADO_REGISTRO CHAR(1),
    @USUARIO_CREACION NVARCHAR(50),
    @TERMINAL_CREACION NVARCHAR(50),
	@CODIGO_UNIDAD_NEGOCIO_CONTEXTO INT
)
AS
/*****************************************
-- Nombre: [MNT].[USP_UNIDAD_NEGOCIO_INS]
-- Propósito: Inserta un registro en la tabla MNT.UNIDAD_NEGOCIO
-- Input: 
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@CODIGO_PAIS:	Parámetro de entrada de tipo char, que representa codigo pais.
		@RAZON_SOCIAL_COMPANIA:	Parámetro de entrada de tipo nvarchar, que representa razon social compania.
		@DIRECCION_COMPANIA:	Parámetro de entrada de tipo nvarchar, que representa direccion compania.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
		@CODIGO_UNIDAD_NEGOCIO_CONTEXTO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.
-- Output: 

-- Creado por: GMD
-- Fecha de Creación: 2014-09-17
-- Fecha de Actualización:
-- *****************************************/
INSERT MNT.UNIDAD_NEGOCIO (	CODIGO_UNIDAD_NEGOCIO, 
							NOMBRE,
							CODIGO_PAIS,
							RAZON_SOCIAL_COMPANIA,
							DIRECCION_COMPANIA,
							ESTADO_REGISTRO,
							USUARIO_CREACION,
							FECHA_CREACION,
							TERMINAL_CREACION)
VALUES					   (@CODIGO_UNIDAD_NEGOCIO,
							@NOMBRE,
							@CODIGO_PAIS,
							@RAZON_SOCIAL_COMPANIA,
							@DIRECCION_COMPANIA,
							@ESTADO_REGISTRO,
							@USUARIO_CREACION,
							GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO_CONTEXTO),
							@TERMINAL_CREACION)

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[UNIDAD_NEGOCIO].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_INS';

