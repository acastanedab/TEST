using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Yanbal.SFT.Domain.Entities.Audit.Base
{
    /// <summary>
    /// Entidad de Negocio que representa la Consulta al repositorio
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20141509 <br />
    /// Modificación:          <br />
    /// </remarks>
    [DataContract(IsReference = true)]
    public abstract class Entity : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public Entity()
        {
        }

        #region Campos
 
        #endregion

        #region Properties
        /// <summary>
        /// Código de Tipo de Acción
        /// </summary>
        public int CodigoTipoAccion { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Usuario Histórico
        /// </summary>
        public string UsuarioHistorico { get; set; }

        /// <summary>
        /// Fecha Histórico
        /// </summary>
        public DateTime FechaHistorico { get; set; }

        /// <summary>
        /// Terminal Histórico
        /// </summary>
        public string TerminalHistorico { get; set; }

        #endregion

        #region Public Methods
        /// <summary>
        /// Método que permite clonar la Entidad
        /// </summary>
        /// <typeparam name="T">Variable de Tipo de Entidad</typeparam>
        /// <returns>Entidad</returns>
        public T Clone<T>()
        {
            T copia;
            var serializer = new DataContractSerializer(typeof(T));

            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, this);
                ms.Position = 0;
                copia = (T)serializer.ReadObject(ms);
            }

            return copia;
        }

        /// <summary>
        /// Método Enumerado de Caracteres
        /// </summary>
        /// <typeparam name="TValue">Tipo de Valor</typeparam>
        /// <param name="propertiesId">Id de Propiedad</param>
        /// <returns>Lista de Caracteres</returns>
        public static IEnumerable<string> GetPropertyName<TValue>(params Expression<Func<TValue, object>>[] propertiesId)
        {
            var result = propertiesId.Select(p => p.Body is UnaryExpression ? ((MemberExpression)((UnaryExpression)p.Body).Operand).Member.Name : ((MemberExpression)p.Body).Member.Name);
            return result;
        }
        #endregion

        #region Overrides Methods
        /// <summary>
        /// Método que permite comparar dos entidades
        /// </summary>
        /// <param name="left">Primer Entidad a Comparar</param>
        /// <param name="right">Segunda Entidad a Comparar</param>
        /// <returns>Indicador de Igualdad</returns>
        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        /// <summary>
        /// Método que permite comparar dos entidades
        /// </summary>
        /// <param name="left">Primer Entidad a Comparar</param>
        /// <param name="right">Segunda Entidad a Comparar</param>
        /// <returns>Indicador de Igualdad</returns>
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Propiedad de cambio
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifica Cambio de Propiedad
        /// </summary>
        /// <param name="propertyName">Nombre de Propiedad</param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
