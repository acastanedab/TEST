CREATE   PROCEDURE [MNT].[USP_PARAMETRO_VALOR_SEL]
(
	@CODIGO_UNIDAD_NEGOCIO	INT,
	@CODIGO_PARAMETRO		INT,
	@CODIGO					CHAR(3),
	@CODIGO_SECCION			INT,
	@CODIGO_VALOR			INT,
	@VALOR					NVARCHAR(255),
	@ESTADO_REGISTRO		CHAR(1)
)
AS
/***********************************************
-- Nombre: [MNT].[USP_PARAMETRO_VALOR_SEL]
-- Propósito: Obtiene el listado de los registros de la tabla MNT.USP_PARAMETRO_SECCION
-- Input:
		@CODIGO_UNIDAD_NEGOCIO:	Parámetro de entrada de tipo int, que representa codigo unidad negocio.
		@CODIGO_PARAMETRO:	Parámetro de entrada de tipo int, que representa codigo parametro.
		@CODIGO:	Parámetro de entrada de tipo char, que representa codigo.
		@CODIGO_SECCION:	Parámetro de entrada de tipo int, que representa codigo seccion.
		@CODIGO_VALOR:	Parámetro de entrada de tipo int, que representa codigo valor.
		@VALOR:	Parámetro de entrada de tipo nvarchar, que representa valor.
		@ESTADO_REGISTRO:	Parámetro de entrada de tipo char, que representa estado registro.

-- Output: Lista de MNT.USP_PARAMETRO_SECCION
AUDITORÍA
20/08/2014	CANVIA	Creación
28/09/2020	MMEZA	UNI-7916 Se agrega una nueva condición en la clausula where "PA.ESTADO_REGISTRO = @ESTADO_REGISTRO".
11/06/2021	DDURAND UNI-9161 Se quita la condición en la clausula where "PA.ESTADO_REGISTRO = @ESTADO_REGISTRO".
01/03/2023	MCASTRO	UNI-10690 Parametrizar los valores de archivo de configuración: Rutas, Endpoints, Llaves - FASE 3 (MSF)
-- **********************************************/
BEGIN
	DECLARE 
	@CODIGO_PARAMETRO_ESTADO_REGISTRO CHAR(3) = 'ETR',
	@ESTADO_REGISTRO_ACTIVO		CHAR(1) = '1';

	SELECT  PV.CODIGO_UNIDAD_NEGOCIO				AS CodigoUnidadNegocio,
			PV.CODIGO_PARAMETRO						AS CodigoParametro,
			PA.CODIGO								AS Codigo,
			PV.CODIGO_SECCION						AS CodigoSeccion,
			PV.CODIGO_VALOR							AS CodigoValor,
			PA.NOMBRE								AS NombreParametro,
			PS.NOMBRE								AS NombreSeccion,
			PS.TIPO_SECCION							AS TipoSeccion,
			PA.TIPO_PARAMETRO						AS TipoParametro,			
			PS.INDICADOR_RANGO						AS IndicadorRango,
			PS.INDICADOR_SOLO_LECTURA				AS IndicadorSoloLectura,
			PA.INDICADOR_PERMITE_AGREGAR_VALOR		AS IndicadorPermiteAgregarValor,
			PA.INDICADOR_PERMITE_MODIFICAR_VALOR	AS IndicadorPermiteModificarValor,
			PV.VALOR								AS Valor,
			PV.ESTADO_REGISTRO						AS EstadoRegistro,
			PVLER.VALOR								AS DescripcionEstadoRegistro,
			PV.OBSERVACION							AS Observacion,
			PV.USUARIO_CREACION						AS UsuarioCreacion,
			PV.FECHA_CREACION						AS FechaCreacion,
			PV.TERMINAL_CREACION					AS TerminalCreacion,
			PV.USUARIO_MODIFICACION					AS UsuarioModificacion,
			PV.FECHA_MODIFICACION					AS FechaModificacion,
			PV.USUARIO_MODIFICACION					AS UsuarioModificacion
	FROM MNT.PARAMETRO_VALOR PV
	INNER JOIN MNT.PARAMETRO PA ON PA.CODIGO_PARAMETRO = PV.CODIGO_PARAMETRO AND PA.ESTADO_REGISTRO = @ESTADO_REGISTRO_ACTIVO
	INNER JOIN MNT.PARAMETRO_SECCION PS ON PS.CODIGO_PARAMETRO = PV.CODIGO_PARAMETRO AND PS.ESTADO_REGISTRO	= @ESTADO_REGISTRO_ACTIVO	
	LEFT JOIN MNT.F_PARAMETRO_VALOR_LISTA_SECCION(@CODIGO_UNIDAD_NEGOCIO,@CODIGO_PARAMETRO_ESTADO_REGISTRO,@ESTADO_REGISTRO_ACTIVO,2) PVLER ON PVLER.CODIGO = PV.ESTADO_REGISTRO
	WHERE	(PV.CODIGO_SECCION = PS.CODIGO_SECCION)
		AND (PV.CODIGO_UNIDAD_NEGOCIO = @CODIGO_UNIDAD_NEGOCIO)
		AND	(@CODIGO_PARAMETRO IS NULL OR PA.CODIGO_PARAMETRO = @CODIGO_PARAMETRO)
		AND	(@CODIGO IS NULL	OR PA.CODIGO = @CODIGO)
		AND (@CODIGO_SECCION IS NULL	OR (PV.CODIGO_SECCION = @CODIGO_SECCION))
		AND (@CODIGO_VALOR IS NULL OR (PV.CODIGO_VALOR = @CODIGO_VALOR))
		AND (@VALOR	IS NULL OR (PV.VALOR = @VALOR))
		AND (@ESTADO_REGISTRO IS NULL OR (PV.ESTADO_REGISTRO = @ESTADO_REGISTRO AND PA.ESTADO_REGISTRO = @ESTADO_REGISTRO))
	ORDER BY PV.CODIGO_VALOR ASC, PV.CODIGO_SECCION ASC
END

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Obtiene el listado de los registros de la tabla [MNT].[USP_PARAMETRO_SECCION].', @level0type = N'SCHEMA', @level0name = N'MNT', @level1type = N'PROCEDURE', @level1name = N'USP_PARAMETRO_VALOR_SEL';

