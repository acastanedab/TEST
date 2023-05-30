CREATE PROCEDURE [MNT].[USP_PARAMETRO_UPD]
(
    @CODIGO_UNIDAD_NEGOCIO				INT,
	@CODIGO_PARAMETRO					INT,
	@NOMBRE								NVARCHAR(100),
	@DESCRIPCION						NVARCHAR(255),
	@INDICADOR_PERMITE_AGREGAR_VALOR	BIT,
	@INDICADOR_PERMITE_MODIFICAR_VALOR	BIT,
	@ESTADO_REGISTRO					CHAR(1),
	@OBSERVACION						NVARCHAR(255),
	@USUARIO_MODIFICACION				NVARCHAR(50),
	@TERMINAL_MODIFICACION				NVARCHAR(50)
)
AS
/* ================================================
-- Nombre: [MNT].[USP_PARAMETRO_UPD] 
-- Propósito: Actualiza un registro de la Tabla MNT.PARAMETRO
-- Input:
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@NOMBRE:	Parámetro de entrada de tipo nvarchar, que representa nombre.
		@DESCRIPCION:	Parámetro de entrada de tipo nvarchar, que representa descripcion.
		@INDICADOR_PERMITE_AGREGAR_VALOR:	Parámetro de entrada de tipo bit, que representa indicador permite agregar valor.
		@INDICADOR_PERMITE_MODIFICAR_VALOR:	Parámetro de entrada de tipo bit, que representa indicador permite modificar valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@OBSERVACION:	Parámetro de entrada de tipo nvarchar, que representa observacion.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
-- Output: 
-- Creado por: GMD
-- Create Creación: 20-08-2014
-- Fecha Actualización:
-- ================================================
*/
SET NOCOUNT OFF
UPDATE MNT.PARAMETRO
	SET NOMBRE								=	@NOMBRE,
		DESCRIPCION							=	@DESCRIPCION,
		INDICADOR_PERMITE_AGREGAR_VALOR		=	@INDICADOR_PERMITE_AGREGAR_VALOR,
		INDICADOR_PERMITE_MODIFICAR_VALOR	=	@INDICADOR_PERMITE_MODIFICAR_VALOR,
		ESTADO_REGISTRO						=	@ESTADO_REGISTRO,
		OBSERVACION							=	@OBSERVACION,
		USUARIO_MODIFICACION				=	@USUARIO_MODIFICACION,
		FECHA_MODIFICACION					=	GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO),
		TERMINAL_MODIFICACION				=	@TERMINAL_MODIFICACION
WHERE CODIGO_UNIDAD_NEGOCIO	=	@CODIGO_UNIDAD_NEGOCIO
AND CODIGO_PARAMETRO		=	@CODIGO_PARAMETRO

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Actualiza un registro de la Tabla [MNT].[PARAMETRO].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD';

