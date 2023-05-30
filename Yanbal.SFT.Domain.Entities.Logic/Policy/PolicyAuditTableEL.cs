using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad de Lógica que representa la Auditoría de Tablas de Políticas
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140915 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class PolicyAuditTableEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public PolicyAuditTableEL()
        {
        }

        /// <summary>
        /// Código de Auditoría de Tabla
        /// </summary>
        public int? CodeTableAudit { get; set; }
        
        /// <summary>
        /// Nombre de Tabla
        /// </summary>
        public string TableName { get; set; }
        
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }
        
        /// <summary>
        /// Descripción de Estado de Registro
        /// </summary>
        public string DescriptionRegistrationStatus { get; set; }
        
        /// <summary>
        /// Código de Unidad de Negocio
        /// </summary>
        public int? BusinessUnitCode { get; set; }
        
        /// <summary>
        /// Descripción de Unidad de Negocio
        /// </summary>
        public string DescriptionBusinessUnit{ get; set; }
        
        /// <summary>
        /// Usuario de Auditoría
        /// </summary>
        public string UserAudit { get; set; }
        
        /// <summary>
        /// Terminal de Auditoría
        /// </summary>
        public string TerminalAudit { get; set; }
    }
}
