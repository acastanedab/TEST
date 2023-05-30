CREATE PROCEDURE [MNT].[USP_FORMULA_INS]
(
	@CODIGO_FORMULA			INT,
	@CODIGO_UNIDAD_NEGOCIO	INT,
	@CODIGO_PARAMETRO		INT,
	@VALOR					NVARCHAR(255),
	@OPERACION				CHAR(1),
	@FACTOR					DECIMAL(18,4),
	@TIPO_FACTOR			NCHAR(1),
	@VALOR_TIPO_ENVIO		NVARCHAR(255),
	@ESTADO_REGISTRO		CHAR(1),
	@USUARIO_CREACION		NVARCHAR(50),
	@TERMINAL_CREACION		NVARCHAR(50)
)
AS
/* ================================================
-- Nombre: [MNT].[USP_FORMULA_INS] 
-- Propósito: Inserta un registro en la tabla MNT.FORMULA
-- Input: 
		@CODIGO_FORMULA:	Parámetro de entrada de tipo int, que representa codigo formula.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@OPERACION:	Parámetro de entrada de tipo char, que representa operacion.
		@FACTOR:	Parámetro de entrada de tipo decimal, que representa factor.
		@TIPO_FACTOR:	Parámetro de entrada de tipo bit, que representa tipo factor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.

-- Output: 
-- Creado por: GMD
-- Fecha de Creación: 11-09-2014
-- Fecha de Actualización: 27/07/2018
20/07/2018	RESTRADA	UNI-43 - 08. PRY 2987 I01 - GAP PYF Colombia: Iteración 02
-- =============================================
*/
BEGIN
	INSERT INTO [MNT].[FORMULA]
	(
		 [CODIGO_FORMULA]
		,[CODIGO_UNIDAD_NEGOCIO]
		,[CODIGO_PARAMETRO]
		,[VALOR]
		,[OPERACION]
		,[FACTOR]
		,[TIPO_FACTOR]
		,[VALOR_TIPO_ENVIO]
		,[ESTADO_REGISTRO]
		,[USUARIO_CREACION]
		,[FECHA_CREACION]
		,[TERMINAL_CREACION]
	)
    VALUES
	(
		 @CODIGO_FORMULA
        ,@CODIGO_UNIDAD_NEGOCIO
		,@CODIGO_PARAMETRO
		,@VALOR
		,@OPERACION
		,@FACTOR
		,@TIPO_FACTOR
		,@VALOR_TIPO_ENVIO
        ,@ESTADO_REGISTRO
        ,@USUARIO_CREACION
        ,GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO)
        ,@TERMINAL_CREACION
	)
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[FORMULA].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS';

