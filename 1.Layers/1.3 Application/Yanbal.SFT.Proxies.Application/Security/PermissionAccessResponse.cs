using System;
using System.Collections.Generic;

namespace Yanbal.SFT.Proxies.Application.Security
{
    /// <summary>
    /// Request que representa Permiso de Acceo
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140715 <br />
    /// Modificacion: 
    /// </remarks>
    [Serializable]
    public class PermissionAccessResponse
    {
        /// <summary>
        /// Tipo de Permiso
        /// </summary>
        public List<PermissionAccess> MyPermissionType { get; set; }
        
        /// <summary>
        /// Manejador de Tipo de Error
        /// </summary>
        public ErrorManagerType ErrorManagerType { get; set; }
    }

    /// <summary>
    /// Clase de Acceso de Permiso
    /// </summary>
    [Serializable]
    public class PermissionAccess
    {
        /// <summary>
        /// Código del Sistema
        /// </summary>
        public int SystemCode { get; set; }

        /// <summary>
        /// Código de Identificación del Sistem
        /// </summary>
        public string SystemIdentificationCode { get; set; }

        /// <summary>
        /// Nombre del Sistema
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Descripción del Sistema
        /// </summary>
        public string SystemDescription { get; set; }

        /// <summary>
        /// URL del Sistema
        /// </summary>
        public string SystemURL { get; set; }

        /// <summary>
        /// Código de Modulo
        /// </summary>
        public int ModuleCode { get; set; }

        /// <summary>
        /// Código de Identificación de Modulo
        /// </summary>
        public string ModuleIdentificationCode { get; set; }

        /// <summary>
        /// Nombre del Modulo
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Modulo de  Descripción
        /// </summary>
        public string ModuleDescription { get; set; }

        /// <summary>
        /// Nombre de Modulo con Clase
        /// </summary>
        public string ModuleIconClassName { get; set; }

        /// <summary>
        /// URL de Modulo
        /// </summary>
        public string ModuleURL { get; set; }

        /// <summary>
        /// Código de Opción
        /// </summary>
        public int OptionCode { get; set; }

        /// <summary>
        /// Código de Opción de Identificación 
        /// </summary>
        public string OptionIdentificationCode { get; set; }

        /// <summary>
        /// Nombre de Opción
        /// </summary>
        public string OptionName { get; set; }

        /// <summary>
        /// Descripción de Opción
        /// </summary>
        public string OptionDescription { get; set; }

        /// <summary>
        /// URL de Opción
        /// </summary>
        public string OptionURL { get; set; }

        /// <summary>
        /// Código de Acción
        /// </summary>
        public int ActionCode { get; set; }

        /// <summary>
        /// Código de Identificación de Acción
        /// </summary>
        public string ActionIdentificationCode { get; set; }

        /// <summary>
        /// Nombre de Acción
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Descripcion de Acción
        /// </summary>
        public string ActionDescription { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string Estate { get; set; }

        /// <summary>
        /// Id de Resultado de Parametro
        /// </summary>
        public string ParentResultId { get; set; }

        /// <summary>
        /// Tipo de Resultado
        /// </summary>
        public string ResultType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ReferenceResultId { get; set; }

        /// <summary>
        /// Id de Resultado
        /// </summary>
        public string ResultId { get; set; }

        /// <summary>
        /// Indicador de URL externo
        /// </summary>
        public bool ExternalUrlIndicator { get; set; }

    }

    
}
