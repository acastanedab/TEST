CREATE PROCEDURE [MNT].[AUDITORIA_DETALLE_LIST_INS]
    (
      @NOMBRE_TABLA NVARCHAR(255),
      @LISTA_COLUMNAS NVARCHAR(MAX),	--Nombres de Columnas
      @CODIGO_UNIDAD_NEGOCIO INT,
      @DESCRIPCION_UNIDAD_NEGOCIO NVARCHAR(255),
	  @CODIGO_REGISTRO_TABLA VARCHAR(255),
      @VALORES_ANTERIORES NVARCHAR(MAX),	--Valores Anteriores
      @VALORES_NUEVOS NVARCHAR(MAX),	--Valores Nuevos
      @SEPARADOR NVARCHAR(10),
      @GLOSA NVARCHAR(255),
      @USUARIO_AUDITORIA NVARCHAR(50),
      @TERMINAL_AUDITORIA NVARCHAR(50)
    )
AS 
/****************************************************************************
Nombre SP: [MNT].[AUDITORIA_DETALLE_LIST_INS]
Propósito: Permite el registro del detalle de la Auditoría
Input:
		@NOMBRE_TABLA:	Parámetro de entrada de tipo nvarchar, que representa nombre tabla.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@DESCRIPCION_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo nvarchar, que representa descripcion unidad negocio.
		@CODIGO_REGISTRO_TABLA:	Parámetro de entrada de tipo varchar, que representa codigo registro tabla.
		@VALORES_ANTERIORES:	Parámetro de entrada de tipo nvarchar, que representa valores anteriores.
		@VALORES_NUEVOS:	Parámetro de entrada de tipo nvarchar, que representa valores nuevos.
		@SEPARADOR:	Parámetro de entrada de tipo nvarchar, que representa separador.
		@GLOSA:	Parámetro de entrada de tipo nvarchar, que representa glosa.
		@USUARIO_AUDITORIA:	Parámetro de entrada de tipo nvarchar, que representa usuario auditoria.
		@TERMINAL_AUDITORIA:	Parámetro de entrada de tipo nvarchar, que representa terminal auditoria.
Output: 

Creado por: GMD
Fecha. Creación: 15-09-2014
Fecha. Actualización:
****************************************************************************/
BEGIN
    DECLARE @CODIGO_TABLA INT
    SELECT  @CODIGO_TABLA = ATB.CODIGO_AUDITORIA_TABLA
    FROM    MNT.AUDITORIA_TABLA ATB
    WHERE   ATB.NOMBRE_TABLA = @NOMBRE_TABLA
	
    INSERT  INTO MNT.AUDITORIA_DETALLE
            (   CODIGO_AUDITORIA_TABLA ,
                CODIGO_AUDITORIA_COLUMNA ,
                CODIGO_UNIDAD_NEGOCIO ,
                DESCRIPCION_UNIDAD_NEGOCIO ,
				CODIGO_REGISTRO_TABLA,
                VALOR_ANTERIOR ,
                VALOR_NUEVO ,
                GLOSA ,
                USUARIO_AUDITORIA ,
                FECHA_AUDITORIA ,
                TERMINAL_AUDITORIA 
            )
            SELECT  @CODIGO_TABLA ,
                    C.CODIGO_AUDITORIA_COLUMNA ,
                    @CODIGO_UNIDAD_NEGOCIO ,
                    @DESCRIPCION_UNIDAD_NEGOCIO ,
					@CODIGO_REGISTRO_TABLA,
                    VA.VALOR ,
                    VN.VALOR ,
                    @GLOSA ,
                    @USUARIO_AUDITORIA ,
                    GETDATE() ,
                    @TERMINAL_AUDITORIA
            FROM    MNT.AUDITORIA_COLUMNA C
                    INNER JOIN MNT.FN_CONVERTIR_A_TABLA(@LISTA_COLUMNAS,
                                                        @SEPARADOR) NC ON NC.VALOR = C.NOMBRE_COLUMNA
                    INNER JOIN MNT.FN_CONVERTIR_A_TABLA(@VALORES_ANTERIORES,
                                                        @SEPARADOR) VA ON VA.ID = NC.ID
                    INNER JOIN MNT.FN_CONVERTIR_A_TABLA(@VALORES_NUEVOS,
                                                        @SEPARADOR) VN ON VN.ID = VA.ID

END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Permite el registro del detalle de la Auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS';

