CREATE PROCEDURE [MNT].[USP_PARAMETRO_VALOR_UDP]
(
	@CODIGO_PARAMETRO int,
	@CODIGO_UNIDAD_NEGOCIO INT,
	@CODIGO_SECCION int,
	@CODIGO_VALOR int,
	@VALOR nvarchar(255),
	@ESTADO_REGISTRO char(1),
	@OBSERVACION nvarchar(255),
	@USUARIO_MODIFICACION nvarchar(50),
	@TERMINAL_MODIFICACION nvarchar(50)
)
AS 
/**********************************************
-- Nombre: [MNT].[USP_PARAMETRO_VALOR_UDP] 
-- Propósito: Actualiza el registro de la tabla MNT.PARAMETRO_VALOR
-- Input: 
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_SECCION:	Parámetro de entrada de tipo int, que representa codigo seccion.
		@CODIGO_VALOR:	Parámetro de entrada de tipo int, que representa codigo valor.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@OBSERVACION:	Parámetro de entrada de tipo nvarchar, que representa observacion.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
-- Output: 
-- Creado por: GMD
-- Create Creación: 20-08-2014
-- Fecha Actualización:
-- ***********************************************/
UPDATE MNT.PARAMETRO_VALOR		 
	SET VALOR					=  @VALOR,
		ESTADO_REGISTRO			=  @ESTADO_REGISTRO ,
		OBSERVACION				=  @OBSERVACION,
		USUARIO_MODIFICACION	=  @USUARIO_MODIFICACION,
		FECHA_MODIFICACION		=  GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO),
		TERMINAL_MODIFICACION	=  @TERMINAL_MODIFICACION
WHERE	CODIGO_UNIDAD_NEGOCIO	=  @CODIGO_UNIDAD_NEGOCIO AND 
		CODIGO_PARAMETRO		=  @CODIGO_PARAMETRO AND
		CODIGO_SECCION			=  @CODIGO_SECCION 	AND
		CODIGO_VALOR			=  @CODIGO_VALOR

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Actualiza el registro de la tabla [MNT].[PARAMETRO_VALOR].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_UDP';

