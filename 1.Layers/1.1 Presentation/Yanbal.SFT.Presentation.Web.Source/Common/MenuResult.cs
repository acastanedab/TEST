using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Presentation.Web.Source.Common
{
    /// <summary>
    /// Result que representa a Menú
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140920 <br />
    /// Modificación:                <br />
    /// </remarks>
    [Serializable]
    public class MenuResult
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public MenuResult()
        {
        }

        /// <summary>
        /// Código de Sistema
        /// </summary>
        public int SystemCode { get; set; }

        /// <summary>
        /// Cpodigo de Identificaciónd e Sistema
        /// </summary>
        public string IdentificationSystemCode { get; set; }

        /// <summary>
        /// Nombre de Sistema
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Descripción de Sistema
        /// </summary>
        public string SystemDescription { get; set; }

        /// <summary>
        /// Ruta de Sistema
        /// </summary>
        public string SystemPath { get; set; }

        /// <summary>
        /// Código de Módulo
        /// </summary>
        public int ModuleCode { get; set; }

        /// <summary>
        /// Código de Identificación de Módulo
        /// </summary>
        public string IdentificationModuleCode { get; set; }

        /// <summary>
        /// Nombre de Módulo
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Descripción de Módulo
        /// </summary>
        public string ModuleDescription { get; set; }

        /// <summary>
        /// Nombre de Clase de Ícono
        /// </summary>
        public string ModuleNameIcoClass { get; set; }

        /// <summary>
        /// Indicador de URL Externo
        /// </summary>
        public bool IndicatorUrlExternal { get; set; }

        /// <summary>
        /// Dirección de URL de Módulo
        /// </summary>
        public string ModuleUrlAddress { get; set; }

        /// <summary>
        /// Código de Opción
        /// </summary>
        public int OptionCode { get; set; }

        /// <summary>
        /// Código de Identificación de Opción
        /// </summary>
        public string IdentificationOptionCode { get; set; }

        /// <summary>
        /// Nombre de Opción
        /// </summary>
        public string OptionName { get; set; }

        /// <summary>
        /// Descripción de Opción
        /// </summary>
        public string OptionDescription { get; set; }

        /// <summary>
        /// Dirección URL de Opción
        /// </summary>
        public string OptionUrlDescription { get; set; }

        /// <summary>
        /// Código de Acción
        /// </summary>
        public int ActionCode { get; set; }

        /// <summary>
        /// Código de Identificación de Acción
        /// </summary>
        public string IdentificationActionCode { get; set; }

        /// <summary>
        /// Nombre de Acción
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Descripción de Acción
        /// </summary>
        public string ActionDescription { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }

        /// <summary>
        /// Código del Padre del Resultado
        /// </summary>
        public string ParentResultId { get; set; }

        /// <summary>
        /// Tipo de Resultado
        /// </summary>
        public string ResulType { get; set; }

        /// <summary>
        /// Resultado de Referencia
        /// </summary>
        public int ResultReferenceId { get; set; }

        /// <summary>
        /// Identificación de Resultado
        /// </summary>
        public string ResultId { get; set; }
    }
}
