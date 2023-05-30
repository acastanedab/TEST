using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Yanbal.SFT.Domain.Entities.Log.Base
{
    /// <summary>
    /// Entidad de Negocio que representa la clase Base LogEntity
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140310 <br />
    /// Modificación:                <br />
    /// </remarks>
  public  class LogEntity: INotifyPropertyChanged
  {

      #region Properties
      /// <summary>
      /// Fecha de Creación
      /// </summary>
      public DateTime FechaCreacion { get; set; }
      #endregion
                 
      #region INotifyPropertyChanged Members

      public event PropertyChangedEventHandler PropertyChanged;
      /// <summary>
      /// Notifica cambio en la propiedad
      /// </summary>
      /// <param name="propertyName">Nombre de la propiedad</param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
      #endregion

  }
}
