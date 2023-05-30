CREATE PROCEDURE [MNT].[USP_COMBINACION_UPD]
(
    @CODIGO_COMBINACION				INT,
	@CODIGO_UNIDAD_NEGOCIO			INT,
	@IMPORTE_FLETE					DECIMAL(18, 4),
	@ESTADO_REGISTRO				CHAR(1),
	@OBSERVACION					NVARCHAR(255),
	@USUARIO_MODIFICACION			NVARCHAR(50),
	@TERMINAL_MODIFICACION			NVARCHAR(50)
)
AS
/****************************************************
-- Nombre: [MNT].[USP_PARAMETRO_UPD] 
-- Propósito: Actualiza el registro de la tabla MNT.COMBINACION
-- Input:
		@CODIGO_COMBINACION:	Parámetro de entrada de tipo int, que representa codigo combinacion.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@IMPORTE_FLETE:	Parámetro de entrada de tipo decimal, que representa importe flete.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@OBSERVACION:	Parámetro de entrada de tipo nvarchar, que representa observacion.
		@USUARIO_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.
		@TERMINAL_MODIFICACION:	Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.
-- Output: 
-- Creado por: GMD
-- Create Creación: 01-09-2014
-- Fecha Actualización:
-- ***************************************************/
SET NOCOUNT OFF
UPDATE [MNT].[COMBINACION]
   SET [CODIGO_COMBINACION] = @CODIGO_COMBINACION
      ,[IMPORTE_FLETE] = @IMPORTE_FLETE
      ,[OBSERVACION] = @OBSERVACION
      ,[ESTADO_REGISTRO] = @ESTADO_REGISTRO
      ,[USUARIO_MODIFICACION] = @USUARIO_MODIFICACION
	  ,[FECHA_MODIFICACION] = GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO)
      ,[TERMINAL_MODIFICACION] = @TERMINAL_MODIFICACION
 WHERE [CODIGO_COMBINACION] = @CODIGO_COMBINACION	AND
       [CODIGO_UNIDAD_NEGOCIO] = @CODIGO_UNIDAD_NEGOCIO

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Actualiza el registro de la tabla [MNT].[COMBINACION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_UPD';

