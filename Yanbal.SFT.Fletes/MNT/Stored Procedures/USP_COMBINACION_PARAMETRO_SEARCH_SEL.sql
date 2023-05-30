CREATE   PROCEDURE [MNT].[USP_COMBINACION_PARAMETRO_SEARCH_SEL]
(
	@CODIGO_COMBINACION_LIST dbo.LISTA_PARAMETRO_VALOR_TYPE READONLY,
	@CODIGO_COMBINACION_PARAMETRO	INT,
	@CODIGO_UNIDAD_NEGOCIO			INT,
	@CODIGO_PARAMETRO				INT,
	@ORDEN_COMBINACION				TINYINT,
	@VALOR							NVARCHAR(255),
	@ESTADO_REGISTRO				CHAR(1),
	@ESTADO_REGISTRO_COMBINACION	CHAR(1)
)
AS
/*******************************************************
-- Nombre: MNT.USP_COMBINACION_PARAMETRO_SEARCH_SEL
-- Propósito: Obtiene el listado de los registros de la tabla MNT.COMBINACION_PARAMETRO
-- Input:
		@CODIGO_COMBINACION_LIST:	Parámetro de entrada de tipo tabla, que representa una lista de codigos de combinacion.
		@CODIGO_COMBINACION_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo combinacion parametro.
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@ORDEN_COMBINACION:	Parámetro de entrada de tipo tinyint, que representa orden combinacion.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.
		@ESTADO_REGISTRO_COMBINACION:	Parámetro de entrada de tipo char, que representa estado registro combinacion.
		@PageNo:	Parámetro de entrada de tipo int, que representa número de página de la consulta.
		@PageSize:	Parámetro de entrada de tipo int, que representa tamaño de página de la consulta.
		@SortColumn:	Parámetro de entrada de tipo nvarchar, que representa sortcolumn.
		@SortOrder:	Parámetro de entrada de tipo nvarchar, que representa sortorder.

-- Output: Lista de MNT.COMBINACION_PARAMETRO
-- Creado por: CANVIA
-- Fecha de Creación: 15-11-2019
-- Fecha de Actualización: 
-- ******************************************************/
BEGIN 
		DECLARE @V_CODIGO_PARAMETRO_ESTADO_REGISTRO CHAR(3),
			@V_ESTADO_REGISTRO_RELACION			CHAR(1)
		SET @V_ESTADO_REGISTRO_RELACION = '1';
		SET @V_CODIGO_PARAMETRO_ESTADO_REGISTRO = 'ETR';

			WITH CTE_Results
			AS (
				SELECT CP.CODIGO_COMBINACION_PARAMETRO	AS CodigoCombinacionParametro
				,CP.CODIGO_COMBINACION				AS CodigoCombinacion
				,CM.CODIGO_UNIDAD_NEGOCIO			AS CodigoUnidadNegocio
				,CP.CODIGO_PARAMETRO				AS CodigoParametro
				,PA.CODIGO							AS Codigo
				,PA.NOMBRE							AS NombreParametro
				,PA.TIPO_PARAMETRO					AS TipoParametro
				,CP.ORDEN_COMBINACION				AS OrdenCombinacion
				,CM.IMPORTE_FLETE					AS ImporteFlete

				,(	SELECT PVLVL.CODIGO
					FROM MNT.F_PARAMETRO_VALOR_LISTA_PARAMETRO_SECCION(CM.CODIGO_UNIDAD_NEGOCIO,CP.CODIGO_PARAMETRO,@V_ESTADO_REGISTRO_RELACION,2) PVLVL
					WHERE PVLVL.CODIGO = CP.VALOR)	AS Valor
				,(	SELECT PVLVL.VALOR 
					FROM MNT.F_PARAMETRO_VALOR_LISTA_PARAMETRO_SECCION(CM.CODIGO_UNIDAD_NEGOCIO,CP.CODIGO_PARAMETRO,@V_ESTADO_REGISTRO_RELACION,2) PVLVL 
					WHERE PVLVL.CODIGO = CP.VALOR)	AS DescripcionValor

				,CP.ESTADO_REGISTRO					AS EstadoRegistro
				,PVLER.VALOR						AS DescripcionEstadoRegistro
				,CP.OBSERVACION						AS Observacion
				,CP.USUARIO_CREACION				AS UsuarioCreacion
				,CP.FECHA_CREACION					AS FechaCreacion
				,CP.TERMINAL_CREACION				AS TerminalCreacion
				,CP.USUARIO_MODIFICACION			AS UsuarioModificacion
				,CP.FECHA_MODIFICACION				AS FechaModificacion
				,CP.TERMINAL_MODIFICACION			AS TerminalModificacion
				FROM MNT.COMBINACION_PARAMETRO CP
				INNER JOIN MNT.PARAMETRO PA ON PA.CODIGO_PARAMETRO = CP.CODIGO_PARAMETRO
				INNER JOIN MNT.COMBINACION CM ON CM.CODIGO_COMBINACION = CP.CODIGO_COMBINACION
				LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@V_CODIGO_PARAMETRO_ESTADO_REGISTRO,@V_ESTADO_REGISTRO_RELACION,2) PVLER 
				ON PVLER.CODIGO = CP.ESTADO_REGISTRO
				INNER JOIN @CODIGO_COMBINACION_LIST CL ON CL.CODIGO_PARAMETRO = CP.CODIGO_COMBINACION
				WHERE (@CODIGO_COMBINACION_PARAMETRO IS NULL	OR (CP.CODIGO_COMBINACION_PARAMETRO		= @CODIGO_COMBINACION_PARAMETRO))
				AND	  (@CODIGO_PARAMETRO IS NULL				OR (CP.CODIGO_PARAMETRO					= @CODIGO_PARAMETRO))
				AND   (@ORDEN_COMBINACION IS NULL				OR (CP.ORDEN_COMBINACION				= @ORDEN_COMBINACION))
				AND   (@VALOR IS NULL							OR (CP.VALOR							= @VALOR))
				AND   (@CODIGO_UNIDAD_NEGOCIO IS NULL			OR (CM.CODIGO_UNIDAD_NEGOCIO			= @CODIGO_UNIDAD_NEGOCIO))
				AND   (@ESTADO_REGISTRO IS NULL					OR (CP.ESTADO_REGISTRO					= @ESTADO_REGISTRO))
				AND   (@ESTADO_REGISTRO_COMBINACION IS NULL		OR (CM.ESTADO_REGISTRO					= @ESTADO_REGISTRO_COMBINACION))
			)

			SELECT CodigoCombinacionParametro, CodigoCombinacion, CodigoUnidadNegocio, CodigoParametro, Codigo, NombreParametro, TipoParametro,
				OrdenCombinacion, ImporteFlete, Valor, DescripcionValor, EstadoRegistro, DescripcionEstadoRegistro, Observacion
			FROM CTE_Results
END

GO
