CREATE FUNCTION [GRL].[F_VALIDA_ZONA_GEOGRAFICA] (
	@CODIGO_ZONA NVARCHAR(50),
	@CODIGO_ZONA_FILTRO	NVARCHAR(50)
)
RETURNS BIT
AS
BEGIN
/*****************************************************************
Nombre Función: POL.F_OBTENER_POSICIONES_NIVELES_GEOGRAFICOS
Propósito: Función que permite validar si la zona geografica pertenece al filtro ingresado
Input:
	@CODIGO_ZONA:			Parámetro de entrada que representa el Código de Zona a Validar
	@CODIGO_ZONA_FILTRO:	Parámetro de entrada que representa el Código de Nivel de Zona
Output: Estado de Igualdad
Creado por: GMD
Fecha. Creación: 2017/09/22
Fecha. Actualización: 
*****************************************************************/
	IF(SUBSTRING(@CODIGO_ZONA, 1, LEN(@CODIGO_ZONA_FILTRO)) = @CODIGO_ZONA_FILTRO)
	BEGIN
		RETURN 1
	END

	RETURN 0
END
