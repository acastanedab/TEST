using Yanbal.SFT.Domain.Entities.Logic.Base;

namespace Yanbal.SFT.Domain.Entities.Logic.Policy
{
    /// <summary>
    /// Entidad de Negocio que representa la Auditoría de Columnas de Políticas
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20140915 <br />
    /// Modificación:          <br />
    /// </remarks>
    public class PolicyAuditColumnEL : BaseEL
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public PolicyAuditColumnEL()
        {
        }

        /// <summary>
        /// Código de Auditoría de Columna
        /// </summary>
        public int? CodeColumnAudit { get; set; }
        /// <summary>
        /// Código de Auditoría de Tabla
        /// </summary>
        public int? CodeTableAudit { get; set; }
        /// <summary>
        /// Nombre de Columna
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string RegistrationStatus { get; set; }
        /// <summary>
        /// Descripcion de Estado de Registro
        /// </summary>
        public string DescriptionRegistrationStatus { get; set; }
    }
}
