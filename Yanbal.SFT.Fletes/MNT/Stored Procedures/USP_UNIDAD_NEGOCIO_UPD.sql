CREATE PROCEDURE [MNT].[USP_UNIDAD_NEGOCIO_UPD]
(
	@CODIGO_UNIDAD_NEGOCIO	INT,
	@NOMBRE					NVARCHAR(50),
	@CODIGO_PAIS			CHAR(2),
    @RAZON_SOCIAL_COMPANIA	NVARCHAR(255),
    @DIRECCION_COMPANIA		NVARCHAR(255),
    @OBSERVACION			NVARCHAR(255),
	@ESTADO_REGISTRO		CHAR(1),	
    @USUARIO_MODIFICACION	NVARCHAR(50),
    @TERMINAL_MODIFICACION	NVARCHAR(50),
	@CODIGO_UNIDAD_NEGOCIO_CONTEXTO INT
	)
AS
/*****************************************
-- Nombre: [MNT].[USP_UNIDAD_NEGOCIO_UPD]
-- Propósito: Actualiza el registro de la tabla MNT.UNIDAD_NEGOCIO
-- Input: 
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@CODIGO_PAIS:	Parámetro de entrada de tipo char, que representa codigo pais.
		@RAZON_SOCIAL_COMPANIA:	Parámetro de entrada de tipo nvarchar, que representa razon social compania.
		@DIRECCION_COMPANIA:	Parámetro de entrada de tipo nvarchar, que representa direccion compania.
		@OBSERVACION:	Parámetro de entrada de tipo nvarchar, que representa observacion.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
		@CODIGO_UNIDAD_NEGOCIO_CONTEXTO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.
-- Output: 

-- Creado por: GMD
-- Fecha de Creación: 2014-09-17
-- Fecha de Actualización:
-- ******************************************/
BEGIN
UPDATE  MNT.UNIDAD_NEGOCIO
		SET NOMBRE									= @NOMBRE,
			CODIGO_PAIS								= @CODIGO_PAIS,
			RAZON_SOCIAL_COMPANIA					= @RAZON_SOCIAL_COMPANIA,
			DIRECCION_COMPANIA						= @DIRECCION_COMPANIA,
			OBSERVACION								= @OBSERVACION,
			ESTADO_REGISTRO							= @ESTADO_REGISTRO,
			USUARIO_MODIFICACION					= @USUARIO_MODIFICACION,
			FECHA_MODIFICACION						= GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO_CONTEXTO),
			TERMINAL_MODIFICACION					= @TERMINAL_MODIFICACION
WHERE CODIGO_UNIDAD_NEGOCIO = @CODIGO_UNIDAD_NEGOCIO
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Actualiza el registro de la tabla [MNT].[UNIDAD_NEGOCIO].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD';

