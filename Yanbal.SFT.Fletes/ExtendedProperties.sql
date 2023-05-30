EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'FUNCTION', @level1name = N'F_OBTENER_FECHA_SERVIDOR', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'PROCEDURE', @level1name = N'USP_OBTENER_FECHA_UNIDAD_NEGOCIO', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'GRL', @level1type = N'PROCEDURE', @level1name = N'USP_OBTENER_FECHA_UNIDAD_NEGOCIO', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa de código de combinación.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_OBTENER_COMBINACION', @level2type = N'PARAMETER', @level2name = N'@CODIGO_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_OBTENER_COMBINACION', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_PARAMETRO_VALOR_LISTA_PARAMETRO_SECCION', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_PARAMETRO_VALOR_LISTA_PARAMETRO_SECCION', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_PARAMETRO_VALOR_LISTA_PARAMETRO_SECCION', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_PARAMETRO_VALOR_LISTA_PARAMETRO_SECCION', @level2type = N'PARAMETER', @level2name = N'@CODIGO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_PARAMETRO_VALOR_LISTA_SECCION', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_PARAMETRO_VALOR_LISTA_SECCION', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_PARAMETRO_VALOR_LISTA_SECCION', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'FUNCTION', @level1name = N'F_PARAMETRO_VALOR_LISTA_SECCION', @level2type = N'PARAMETER', @level2name = N'@CODIGO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo decimal, que representa importe flete.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@IMPORTE_FLETE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo combinacion parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_COMBINACION_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa orden combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@ORDEN_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo combinacion parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_COMBINACION_PARAMETRO';




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa orden combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@ORDEN_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa número de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@PageNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@PageSize';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortcolumn.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@SortColumn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortorder.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@SortOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo combinacion parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_COMBINACION_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa orden combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@ORDEN_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo decimal, que representa importe flete.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@IMPORTE_FLETE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa número de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@PageNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@PageSize';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortcolumn.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@SortColumn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortorder.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@SortOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo decimal, que representa importe flete.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@IMPORTE_FLETE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo cultura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_CULTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo idioma.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_IDIOMA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato fecha corta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_FECHA_CORTA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato fecha larga.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_FECHA_LARGA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato hora corta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_HORA_CORTA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato hora larga.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_HORA_LARGA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato numero entero.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_NUMERO_ENTERO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato numero decimal.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_NUMERO_DECIMAL';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo smallint, que representa limite superior anio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@LIMITE_SUPERIOR_ANIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONTEXTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo cultura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_CULTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo idioma.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_IDIOMA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato fecha corta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_FECHA_CORTA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato fecha larga.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_FECHA_LARGA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato hora corta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_HORA_CORTA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato hora larga.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_HORA_LARGA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato numero entero.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_NUMERO_ENTERO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato numero decimal.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_NUMERO_DECIMAL';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo smallint, que representa limite superior anio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@LIMITE_SUPERIOR_ANIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa número de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@PageNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@PageSize';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortcolumn.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@SortColumn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortorder.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_SEL', @level2type = N'PARAMETER', @level2name = N'@SortOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo cultura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_CULTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo idioma.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_IDIOMA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato fecha corta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_FECHA_CORTA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato fecha larga.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_FECHA_LARGA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato hora corta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_HORA_CORTA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato hora larga.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_HORA_LARGA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato numero entero.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_NUMERO_ENTERO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato numero decimal.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_NUMERO_DECIMAL';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo smallint, que representa limite superior anio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@LIMITE_SUPERIOR_ANIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_CULTURA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formato cadena.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMATO_CADENA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMATO_CADENA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa formato.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMATO_CADENA_SEL', @level2type = N'PARAMETER', @level2name = N'@FORMATO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa tipo formato.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMATO_CADENA_SEL', @level2type = N'PARAMETER', @level2name = N'@TIPO_FORMATO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa formato largo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMATO_CADENA_SEL', @level2type = N'PARAMETER', @level2name = N'@FORMATO_LARGO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMATO_CADENA_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formula.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMULA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS', @level2type = N'PARAMETER', @level2name = N'@VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa operacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS', @level2type = N'PARAMETER', @level2name = N'@OPERACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo decimal, que representa factor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS', @level2type = N'PARAMETER', @level2name = N'@FACTOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa tipo factor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS', @level2type = N'PARAMETER', @level2name = N'@TIPO_FACTOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formula.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMULA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa operacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@OPERACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo decimal, que representa factor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@FACTOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa tipo factor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@TIPO_FACTOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa número de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@PageNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@PageSize';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortcolumn.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@SortColumn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortorder.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_SEL', @level2type = N'PARAMETER', @level2name = N'@SortOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo formula.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_FORMULA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa operacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@OPERACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo decimal, que representa factor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@FACTOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa tipo factor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@TIPO_FACTOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa orden.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@ORDEN';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_FORMULA_UPD', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo idioma.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_IDIOMA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_IDIOMA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_IDIOMA_SEL', @level2type = N'PARAMETER', @level2name = N'@NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_IDIOMA_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo orden combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_ORDEN_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa orden.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@ORDEN';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo orden combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_ORDEN_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa orden.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@ORDEN';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa número de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@PageNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@PageSize';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortcolumn.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@SortColumn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortorder.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_SEL', @level2type = N'PARAMETER', @level2name = N'@SortOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo orden combinacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_ORDEN_COMBINACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ORDEN_COMBINACION_UPD', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PAIS_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais zona.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PAIS_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS_ZONA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa descripcion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@DESCRIPCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa tipo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@TIPO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador permite agregar valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_PERMITE_AGREGAR_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador permite modificar valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_PERMITE_MODIFICAR_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador solo lectura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_SOLO_LECTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador obligatorio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_OBLIGATORIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa indicador rango.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_RANGO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa tipo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@TIPO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador solo lectura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_SOLO_LECTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador obligatorio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_OBLIGATORIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa tipo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@TIPO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa número de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@PageNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@PageSize';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortcolumn.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@SortColumn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortorder.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_SEL', @level2type = N'PARAMETER', @level2name = N'@SortOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador solo lectura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_SOLO_LECTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador obligatorio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_OBLIGATORIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa tipo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@TIPO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SECCION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa codigo aproximado.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_APROXIMADO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa descripcion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@DESCRIPCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa tipo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@TIPO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador parametro sistema.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_PARAMETRO_SISTEMA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador permite agregar valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_PERMITE_AGREGAR_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador permite modificar valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_PERMITE_MODIFICAR_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa número de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@PageNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@PageSize';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortcolumn.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@SortColumn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortorder.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_SEL', @level2type = N'PARAMETER', @level2name = N'@SortOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa descripcion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@DESCRIPCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador permite agregar valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_PERMITE_AGREGAR_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador permite modificar valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_PERMITE_MODIFICAR_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_UPD', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_INS', @level2type = N'PARAMETER', @level2name = N'@VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_SEL', @level2type = N'PARAMETER', @level2name = N'@VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo parametro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_UDP', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PARAMETRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_UDP', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo seccion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_UDP', @level2type = N'PARAMETER', @level2name = N'@CODIGO_SECCION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_UDP', @level2type = N'PARAMETER', @level2name = N'@CODIGO_VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_UDP', @level2type = N'PARAMETER', @level2name = N'@VALOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_UDP', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_UDP', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_UDP', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_UDP', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo tipo zona ubigeo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_TIPO_ZONA_UBIGEO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo zona.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_ZONA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo nivel 1.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_NIVEL_1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nivel 1.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@NIVEL_1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo nivel 2.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_NIVEL_2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nivel 2.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@NIVEL_2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo nivel 3.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_NIVEL_3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nivel 3.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@NIVEL_3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo varchar, que representa codigo tipo zona.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_TIPO_ZONA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo tipo zona ubigeo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_TIPO_ZONA_UBIGEO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo zona.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_ZONA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo nivel 1.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_NIVEL_1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nivel 1.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@NIVEL_1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo nivel 2.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_NIVEL_2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nivel 2.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@NIVEL_2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo nivel 3.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_NIVEL_3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nivel 3.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@NIVEL_3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo varchar, que representa codigo tipo zona.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_TIPO_ZONA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa número de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@PageNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@PageSize';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortcolumn.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@SortColumn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortorder.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_SEL', @level2type = N'PARAMETER', @level2name = N'@SortOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo tipo zona ubigeo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_TIPO_ZONA_UBIGEO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo zona.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_ZONA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo nivel 1.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_NIVEL_1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nivel 1.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@NIVEL_1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo nivel 2.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_NIVEL_2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nivel 2.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@NIVEL_2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo nivel 3.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_NIVEL_3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nivel 3.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@NIVEL_3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo varchar, que representa codigo tipo zona.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_TIPO_ZONA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_TIPO_ZONA_UBIGEO_UPD', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio configuracion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo cultura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_CULTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo zona horaria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_ZONA_HORARIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa forma visualizacion reporte.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@FORMA_VISUALIZACION_REPORTE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo image, que representa logo compania.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@LOGO_COMPANIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo image, que representa logo reporte.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@LOGO_REPORTE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa filas por pagina.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@FILAS_POR_PAGINA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa minimo caracteres glosa.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@MINIMO_CARACTERES_GLOSA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa minimo vocales glosa.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@MINIMO_VOCALES_GLOSA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador contraer menu.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_CONTRAER_MENU';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONTEXTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio configuracion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_LOGO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_OBTENER_LOGO', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa indicador logo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_OBTENER_LOGO', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_LOGO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio configuracion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONTEXTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo cultura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_CULTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa número de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL', @level2type = N'PARAMETER', @level2name = N'@PageNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL', @level2type = N'PARAMETER', @level2name = N'@PageSize';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortcolumn.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL', @level2type = N'PARAMETER', @level2name = N'@SortColumn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortorder.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_SEL', @level2type = N'PARAMETER', @level2name = N'@SortOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio configuracion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONFIGURACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo cultura.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_CULTURA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo zona horaria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_ZONA_HORARIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa forma visualizacion reporte.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@FORMA_VISUALIZACION_REPORTE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo image, que representa logo compania.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@LOGO_COMPANIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo image, que representa logo reporte.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@LOGO_REPORTE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa filas por pagina.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@FILAS_POR_PAGINA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa minimo caracteres glosa.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@MINIMO_CARACTERES_GLOSA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo tinyint, que representa minimo vocales glosa.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@MINIMO_VOCALES_GLOSA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo bit, que representa indicador contraer menu.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@INDICADOR_CONTRAER_MENU';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_CONFIGURACION_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONTEXTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_INS', @level2type = N'PARAMETER', @level2name = N'@NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa razon social compania.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_INS', @level2type = N'PARAMETER', @level2name = N'@RAZON_SOCIAL_COMPANIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa direccion compania.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_INS', @level2type = N'PARAMETER', @level2name = N'@DIRECCION_COMPANIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_INS', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal creacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_CREACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONTEXTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONTEXTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL', @level2type = N'PARAMETER', @level2name = N'@NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa razon social compania.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL', @level2type = N'PARAMETER', @level2name = N'@RAZON_SOCIAL_COMPANIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa número de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL', @level2type = N'PARAMETER', @level2name = N'@PageNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL', @level2type = N'PARAMETER', @level2name = N'@PageSize';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortcolumn.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL', @level2type = N'PARAMETER', @level2name = N'@SortColumn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa sortorder.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_SEL', @level2type = N'PARAMETER', @level2name = N'@SortOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD', @level2type = N'PARAMETER', @level2name = N'@NOMBRE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa codigo pais.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PAIS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa razon social compania.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD', @level2type = N'PARAMETER', @level2name = N'@RAZON_SOCIAL_COMPANIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa direccion compania.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD', @level2type = N'PARAMETER', @level2name = N'@DIRECCION_COMPANIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa observacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD', @level2type = N'PARAMETER', @level2name = N'@OBSERVACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD', @level2type = N'PARAMETER', @level2name = N'@USUARIO_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal modificacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_MODIFICACION';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio contexto.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_UNIDAD_NEGOCIO_UPD', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO_CONTEXTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo varchar, que representa codigo provincia.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ZONA_CIUDAD_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_PROVINCIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo varchar, que representa codigo ciudad.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_ZONA_CIUDAD_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_CIUDAD';

