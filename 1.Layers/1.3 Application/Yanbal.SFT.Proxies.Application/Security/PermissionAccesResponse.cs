using System.Collections.Generic;

namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Clase que representa la respuesta a la solicitud los permisos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140310 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class PermissionAccesResponse
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public PermissionAccesResponse()
        {
        }

        /// <summary>
        /// Indicador de Cultura
        /// </summary>
        public bool IndicadorCultura { get; set; }
        /// <summary>
        /// Lista de Permisos
        /// </summary>
        public List<PermissionAcces> MyPermissionType { get; set; }
        /// <summary>
        /// Error Manager Type
        /// </summary>
        public ErrorManagerType ErrorManagerType { get; set; }
    }
    /// <summary>
    /// Clase que representa los permisos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140310 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class PermissionAcces
    {        
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public PermissionAcces()
        {
        }

        /// <summary>
        /// Codigo de Sistema
        /// </summary>
        public int CODIGO_SISTEMA { get; set; }
        /// <summary>
        /// Codigo de Identificacion de Sistema
        /// </summary>
        public string CodigoIdentificacionSistema { get; set; }
        /// <summary>
        /// Nombre de Sistema
        /// </summary>
        public string NombreSistema { get; set; }
        /// <summary>
        /// Descripcion de sistema
        /// </summary>
        public string DescripcionSistema { get; set; }
        /// <summary>
        /// Ruta de Sistema
        /// </summary>
        public string RutaSistema { get; set; }
        /// <summary>
        /// Codigo de Modulo
        /// </summary>
        public int CodigoModulo { get; set; }
        /// <summary>
        /// Codigo de Identificacion de Modulo
        /// </summary>
        public string CodigoIdentificacionModulo { get; set; }
        /// <summary>
        /// Nombre de Modulo
        /// </summary>
        public string NombreModulo { get; set; }
        /// <summary>
        /// Descripcion de Modulo
        /// </summary>
        public string DescripcionModulo { get; set; }
        /// <summary>
        /// Nombre de clase de icono de modulo
        /// </summary>
        public string NombreClaseIconoModulo { get; set; }
        /// <summary>
        /// Indicador URL Externo
        /// </summary>
        public bool IndicadorUrlExterno { get; set; }
        /// <summary>
        /// Direccion URL Modulo
        /// </summary>
        public string DireccionUrlModulo { get; set; }
        /// <summary>
        /// Codigo Opcion
        /// </summary>
        public int CodigoOpcion { get; set; }
        /// <summary>
        /// Codigo Identificacion de Opcion
        /// </summary>
        public string CodigoIdentificacionOpcion { get; set; }
        /// <summary>
        /// Nombre de Opcion
        /// </summary>
        public string NombreOpcion { get; set; }
        /// <summary>
        /// Descripcion de Opcion
        /// </summary>
        public string DescripcionOpcion { get; set; }
        /// <summary>
        /// Direccion URL de Opcion
        /// </summary>
        public string DireccionUrlOpcion { get; set; }
        /// <summary>
        /// Codigo de Accion
        /// </summary>
        public int CodigoAccion { get; set; }
        /// <summary>
        /// Codigo de Identificacion de Accion
        /// </summary>
        public string CodigoIdentificacionAccion { get; set; }
        /// <summary>
        /// Nombre de Accion
        /// </summary>
        public string NombreAccion { get; set; }
        /// <summary>
        /// Descripcion de Accion
        /// </summary>
        public string DescripcionAccion { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Id Resultado
        /// </summary>
        public string SIdParentResult { get; set; }
        /// <summary>
        /// Tipo de Resultado
        /// </summary>
        public string STipoResult { get; set; }
        /// <summary>
        /// Id de Referencia de Resultado
        /// </summary>
        public int NIdReferenceResult { get; set; }
        /// <summary>
        /// Cadena Id Resultado
        /// </summary>
        public string SIdResult { get; set; }
    }    
}
