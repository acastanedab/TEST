CREATE PROCEDURE [MNT].[USP_CULTURA_INS]
    (
      @CODIGO_CULTURA				CHAR(5) ,
      @CODIGO_IDIOMA				CHAR(2) ,
      @CODIGO_PAIS					CHAR(2) ,
      @CODIGO_FORMATO_FECHA_CORTA	INT ,
      @CODIGO_FORMATO_FECHA_LARGA	INT ,
      @CODIGO_FORMATO_HORA_CORTA	INT ,
      @CODIGO_FORMATO_HORA_LARGA	INT ,
      @CODIGO_FORMATO_NUMERO_ENTERO INT ,
      @CODIGO_FORMATO_NUMERO_DECIMAL INT ,
      @LIMITE_SUPERIOR_ANIO			SMALLINT ,
      @ESTADO_REGISTRO				CHAR(1) ,
      @USUARIO_CREACION				NVARCHAR(50) ,
      @TERMINAL_CREACION			NVARCHAR(50),
	  @CODIGO_UNIDAD_NEGOCIO_CONTEXTO INT
    )
AS 
/***********************************************************
-- Nombre: [MNT].[USP_CULTURA_INS] 
-- Propósito: Inserta un registro en la tabla MNT.CULTURA
-- Input: 
		@CODIGO_CULTURA:	Parámetro de entrada de tipo char, que representa codigo cultura.
		@CODIGO_IDIOMA:	Parámetro de entrada de tipo char, que representa codigo idioma.
		@CODIGO_PAIS:	Parámetro de entrada de tipo char, que representa codigo pais.
		@CODIGO_FORMATO_FECHA_CORTA:	Parámetro de entrada de tipo int, que representa codigo formato fecha corta.
		@CODIGO_FORMATO_FECHA_LARGA:	Parámetro de entrada de tipo int, que representa codigo formato fecha larga.
		@CODIGO_FORMATO_HORA_CORTA:	Parámetro de entrada de tipo int, que representa codigo formato hora corta.
		@CODIGO_FORMATO_HORA_LARGA:	Parámetro de entrada de tipo int, que representa codigo formato hora larga.
		@CODIGO_FORMATO_NUMERO_ENTERO:	Parámetro de entrada de tipo int, que representa codigo formato numero entero.
		@CODIGO_FORMATO_NUMERO_DECIMAL:	Parámetro de entrada de tipo int, que representa codigo formato numero decimal.
		@LIMITE_SUPERIOR_ANIO:	Parámetro de entrada de tipo smallint, que representa limite superior anio.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@USUARIO_CREACION:	Parámetro de entrada de tipo nvarchar, que representa usuario creacion.
		@TERMINAL_CREACION:	Parámetro de entrada de tipo nvarchar, que representa terminal creacion.
		@CODIGO_UNIDAD_NEGOCIO_CONTEXTO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.

-- Output: 
-- Creado por: GMD
-- Fecha de Creación: 20-09-2014
-- Fecha de Actualización:
**************************************************************/
BEGIN
    INSERT  INTO [MNT].[CULTURA]
            ( [CODIGO_CULTURA] ,
                [CODIGO_IDIOMA] ,
                [CODIGO_PAIS] ,
				[CODIGO_FORMATO_FECHA_CORTA],
				[CODIGO_FORMATO_FECHA_LARGA],
				[CODIGO_FORMATO_HORA_CORTA],
				[CODIGO_FORMATO_HORA_LARGA],
                [CODIGO_FORMATO_NUMERO_ENTERO],
                [CODIGO_FORMATO_NUMERO_DECIMAL],
				[LIMITE_SUPERIOR_ANIO],
                [ESTADO_REGISTRO] ,
                [USUARIO_CREACION] ,
                [FECHA_CREACION] ,
                [TERMINAL_CREACION]
	        )
    VALUES  ( @CODIGO_CULTURA ,
                @CODIGO_IDIOMA ,
                @CODIGO_PAIS ,
				@CODIGO_FORMATO_FECHA_CORTA,
				@CODIGO_FORMATO_FECHA_LARGA,
				@CODIGO_FORMATO_HORA_CORTA,
				@CODIGO_FORMATO_HORA_LARGA,
                @CODIGO_FORMATO_NUMERO_ENTERO ,
                @CODIGO_FORMATO_NUMERO_DECIMAL ,
				@LIMITE_SUPERIOR_ANIO,
                @ESTADO_REGISTRO ,
                @USUARIO_CREACION ,
                GRL.F_OBTENER_FECHA_SERVIDOR(@CODIGO_UNIDAD_NEGOCIO_CONTEXTO),
                @TERMINAL_CREACION
	        )
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Inserta un registro en la tabla [MNT].[CULTURA].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS';

