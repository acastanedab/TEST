using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Clase entidad lógica de Párametro Sección
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140715 <br />
    /// Modificación: 
    /// </remarks>
    public class ParameterSectionEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ParameterSectionEL()
        {
        }

        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int CodeParameter { get; set; }
        
        /// <summary>
        /// Nombre del Parámetro
        /// </summary>
        public string NameParameter { get; set; }

        /// <summary>
        /// Descripción del Parámetro
        /// </summary>
        public string DescriptionParameter { get; set; }

        /// <summary>
        /// Código de Parámetro Sección
        /// </summary>
        public int CodeSection { get; set; }

        /// <summary>
        /// Nombre de Parámetro Sección
        /// </summary>
        public string NameSection { get; set; }

        /// <summary>
        /// Indicador que determina si la Sección es Solo de Lectura
        /// </summary>
        public bool ReadOnlyIndicator { get; set; }       

        /// <summary>
        /// Indicador que determina si la Sección es un dato Obligatorio a Registrar
        /// </summary>
        public bool RequiredIndicator { get; set; }

        /// <summary>
        /// Indicador que determina si la Sección es un Valor Inicial o un Valor Final del Rango
        /// </summary>
        public string RangeIndicator { get; set; }        
        
        /// <summary>
        /// Indicador que determina si es una Sección creada automaticamente por el tipo de Parámetro
        /// </summary>
        public bool CreationIndicator { get; set; }       

        /// <summary>
        /// Tipo de Parametro Sección
        /// </summary>
        public string CodeParameterSectionType { get; set; }

        /// <summary>
        /// Descripción de Tipo de Parametro Sección
        /// </summary>
        public string DescriptionParameterSectionType { get; set; }
    }
}
