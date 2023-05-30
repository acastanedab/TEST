CREATE PROCEDURE [MNT].[AUDITORIA_DETALLE_INS]
    (
      @NOMBRE_TABLA NVARCHAR(255) ,
      @NOMBRE_COLUMNA NVARCHAR(255) ,
      @CODIGO_UNIDAD_NEGOCIO INT ,
      @DESCRIPCION_UNIDAD_NEGOCIO NVARCHAR(255) ,
	  @CODIGO_REGISTRO_TABLA VARCHAR(255),
      @VALOR_ANTERIOR NVARCHAR(255) ,
      @VALOR_NUEVO NVARCHAR(255) ,
      @GLOSA NVARCHAR(255) ,
      @USUARIO_AUDITORIA NVARCHAR(50) ,
      @TERMINAL_AUDITORIA NVARCHAR(50)
    )
AS 
/****************************************************************************
Nombre SP: [MNT].[AUDITORIA_DETALLE_INS]
Propósito: Permite el registro del Detalle de la Auditoría
Input:
		@NOMBRE_TABLA:	Parámetro de entrada de tipo nvarchar, que representa nombre tabla.
		@NOMBRE_COLUMNA:	Parámetro de entrada de tipo nvarchar, que representa nombre columna.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@DESCRIPCION_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo nvarchar, que representa descripcion unidad negocio.
		@CODIGO_REGISTRO_TABLA:	Parámetro de entrada de tipo varchar, que representa codigo registro tabla.
		@VALOR_ANTERIOR:	Parámetro de entrada de tipo nvarchar, que representa valor anterior.
		@VALOR_NUEVO:	Parámetro de entrada de tipo nvarchar, que representa valor nuevo.
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

    DECLARE @CODIGO_COLUMNA INT
    SELECT  @CODIGO_COLUMNA = ACL.CODIGO_AUDITORIA_COLUMNA
    FROM    MNT.AUDITORIA_COLUMNA ACL
    WHERE   ACL.CODIGO_AUDITORIA_TABLA = @CODIGO_TABLA
            AND UPPER(REPLACE(ACL.NOMBRE_COLUMNA, '_', '')) = UPPER(@NOMBRE_COLUMNA)

    IF ( ISNULL(@CODIGO_COLUMNA, 0) = 0 ) 
        BEGIN
            DECLARE @CODIGO_AUDITORIA_COLUMNA BIGINT
            SET @CODIGO_AUDITORIA_COLUMNA = ISNULL(( SELECT
                                                            MAX(CODIGO_AUDITORIA_COLUMNA)
                                                            FROM
                                                            MNT.AUDITORIA_COLUMNA
                                                            WHERE
                                                            CODIGO_AUDITORIA_TABLA = @CODIGO_TABLA
                                                            ), 0) + 1
		
            INSERT  MNT.AUDITORIA_COLUMNA
                    ( CODIGO_AUDITORIA_TABLA ,
                        CODIGO_AUDITORIA_COLUMNA ,
                        NOMBRE_COLUMNA ,
                        ESTADO_REGISTRO
		            )
            VALUES  ( @CODIGO_TABLA ,
                        @CODIGO_AUDITORIA_COLUMNA ,
                        UPPER(@NOMBRE_COLUMNA) ,
                        '1'
		            );

            SET @CODIGO_COLUMNA = @CODIGO_AUDITORIA_COLUMNA;
        END
	  
    DECLARE @CODIGO_AUDITORIA_DETALLE BIGINT
    SET @CODIGO_AUDITORIA_DETALLE = ISNULL(( SELECT
                                                            MAX(CODIGO_AUDITORIA_DETALLE)
                                                        FROM
                                                            MNT.AUDITORIA_DETALLE
                                                    ), 0) + 1

    INSERT  INTO MNT.AUDITORIA_DETALLE
            ( CODIGO_AUDITORIA_DETALLE,
                CODIGO_AUDITORIA_TABLA,
                CODIGO_AUDITORIA_COLUMNA,
                CODIGO_UNIDAD_NEGOCIO,
                DESCRIPCION_UNIDAD_NEGOCIO,
				CODIGO_REGISTRO_TABLA,
                VALOR_ANTERIOR,
                VALOR_NUEVO,
                GLOSA,
                USUARIO_AUDITORIA,
                FECHA_AUDITORIA,
                TERMINAL_AUDITORIA
			)
    VALUES  ( @CODIGO_AUDITORIA_DETALLE,
                @CODIGO_TABLA,
                @CODIGO_COLUMNA,
                @CODIGO_UNIDAD_NEGOCIO,
                @DESCRIPCION_UNIDAD_NEGOCIO,
				@CODIGO_REGISTRO_TABLA,
                @VALOR_ANTERIOR,
                @VALOR_NUEVO,
                @GLOSA,
                @USUARIO_AUDITORIA,
                GETDATE(),
                @TERMINAL_AUDITORIA
			)
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Permite el registro del Detalle de la Auditoría.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS';

