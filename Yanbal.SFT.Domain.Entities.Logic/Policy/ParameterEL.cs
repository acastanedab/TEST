using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Clase entidad lógica de Párametro 
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140715 <br />
    /// Modificación: 
    /// </remarks>
    public class ParameterEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterEL()
        {
        }

        /// <summary>
        /// Código de Párametro
        /// </summary>
        public int CodeParameter { get; set; }

        /// <summary>
        /// Código de Parametro Manual 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Nombre de párametro
        /// </summary>
        public string NameParameter { get; set; }
        /// <summary>
        /// Descripción de párametro
        /// </summary>
        public string DescriptionParameter { get; set; }
        /// <summary>
        /// Código de tipo párametro
        /// </summary>
        public string CodeParameterType { get; set; }
        /// <summary>
        /// Descripción de tipo párametro
        /// </summary>
        public string DescriptionParameterType { get; set; }

        /// <summary>
        /// Indicador de Parámetro de Sistema
        /// </summary>
        public bool ParameterSystemIndicator { get; set; }

        /// <summary>
        /// Indicador de añadir párametro permitido
        /// </summary>
        public bool AllowAddValueIndicator { get; set; }

        /// <summary>
        /// Indicador de añadir párametro valor permitdo
        /// </summary>
        public bool AllowModifyValueIndicator { get; set; }

    }
}
