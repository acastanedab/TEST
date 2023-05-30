CREATE PROCEDURE [MNT].[USP_COMBINACION_INS]
(
	@CODIGO_COMBINACION				INT,
	@CODIGO_UNIDAD_NEGOCIO			INT,
	@IMPORTE_FLETE					DECIMAL(18, 4),
	@ESTADO_REGISTRO				CHAR(1),
	@USUARIO_CREACION				NVARCHAR(50),
	@TERMINAL_CREACION				NVARCHAR(50)
)
AS
/*****************************************************
-- Nombre: [MNT].[USP_COMBINACION_INS] 
-- Propósito: Inserta un registro en la tabla MNT.COMBINACION
-- Input: 
		@CODIGO_COMBINACION:	Parámetro de entrada de tipo int, que representa codigo combinacion.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@IMPORTE_FLETE:	Parámetro de entrada de tipo decimal, que representa importe flete.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
-- Output: 
-- Creado por: GMD
-- Create Creación: 01-09-2014
-- Fecha Actualización:
-- ***************************************************/
BEGIN
	INSERT INTO [MNT].[COMBINACION]
           ([CODIGO_COMBINACION]
           ,[CODIGO_UNIDAD_NEGOCIO]
           ,[IMPORTE_FLETE]
           ,[ESTADO_REGISTRO]
           ,[USUARIO_CREACION]
           ,[FECHA_CREACION]
           ,[TERMINAL_CREACION])
     VALUES
           (@CODIGO_COMBINACION
           ,@CODIGO_UNIDAD_NEGOCIO
           ,@IMPORTE_FLETE
           ,@ESTADO_REGISTRO
           ,@USUARIO_CREACION
           ,GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO)
           ,@TERMINAL_CREACION
	)
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[COMBINACION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_INS';

