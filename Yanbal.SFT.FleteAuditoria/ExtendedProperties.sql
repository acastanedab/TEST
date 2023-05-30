EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre tabla.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS', @level2type = N'PARAMETER', @level2name = N'@NOMBRE_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre columna.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS', @level2type = N'PARAMETER', @level2name = N'@NOMBRE_COLUMNA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa descripcion unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS', @level2type = N'PARAMETER', @level2name = N'@DESCRIPCION_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo varchar, que representa codigo registro tabla.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_REGISTRO_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor anterior.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS', @level2type = N'PARAMETER', @level2name = N'@VALOR_ANTERIOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valor nuevo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS', @level2type = N'PARAMETER', @level2name = N'@VALOR_NUEVO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa glosa.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS', @level2type = N'PARAMETER', @level2name = N'@GLOSA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario auditoria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_AUDITORIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal auditoria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_AUDITORIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa nombre tabla.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@NOMBRE_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa lista columnas.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@LISTA_COLUMNAS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa descripcion unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@DESCRIPCION_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo varchar, que representa codigo registro tabla.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@CODIGO_REGISTRO_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valores anteriores.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@VALORES_ANTERIORES';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa valores nuevos.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@VALORES_NUEVOS';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa separador.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@SEPARADOR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa glosa.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@GLOSA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario auditoria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@USUARIO_AUDITORIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa terminal auditoria.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'AUDITORIA_DETALLE_LIST_INS', @level2type = N'PARAMETER', @level2name = N'@TERMINAL_AUDITORIA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo auditoria tabla.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_AUDITORIA_COLUMNA_SEL', @level2type = N'PARAMETER', @level2name = N'@CODIGO_AUDITORIA_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_AUDITORIA_COLUMNA_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo char, que representa estado registro.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_AUDITORIA_TABLA_SEL', @level2type = N'PARAMETER', @level2name = N'@ESTADO_REGISTRO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo unidad negocio.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_REPORTE_AUDITORIA', @level2type = N'PARAMETER', @level2name = N'@CODIGO_UNIDAD_NEGOCIO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo tabla.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_REPORTE_AUDITORIA', @level2type = N'PARAMETER', @level2name = N'@CODIGO_TABLA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo int, que representa codigo atributo.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_REPORTE_AUDITORIA', @level2type = N'PARAMETER', @level2name = N'@CODIGO_ATRIBUTO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa fecha registro desde.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_REPORTE_AUDITORIA', @level2type = N'PARAMETER', @level2name = N'@FECHA_REGISTRO_DESDE';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa fecha registro hasta.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_REPORTE_AUDITORIA', @level2type = N'PARAMETER', @level2name = N'@FECHA_REGISTRO_HASTA';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Parámetro de entrada de tipo nvarchar, que representa usuario operacion.', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_REPORTE_AUDITORIA', @level2type = N'PARAMETER', @level2name = N'@USUARIO_OPERACION';

