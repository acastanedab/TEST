using System;
using System.Collections.Generic;

namespace Yanbal.SFT.Presentation.Web.Source.Models.Base
{
    /// <summary>
    /// Modelo que representa la base de datos de los modelos
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140717 <br />
    /// Modificacion: 
    /// </remarks>
    public class BaseModel 
    {
        /// <summary>
        /// Constructor de implementación de la clase
        /// </summary>
        public BaseModel()
        {
            this.Error = new ErrorModel();
        }
        /// <summary>
        /// Lista de estado de registro
        /// </summary>
        public List<SelectType> ListRegistrationStatus { get; set; }
        /// <summary>
        /// Estado Registro
        /// </summary>
        public string LabelRegistrationStatus { get; set; }
        /// <summary>
        /// Error
        /// </summary>
        public ErrorModel Error { get; set; }
    }
    /// <summary>
    /// Clase que representa a los errores base
    /// </summary>
    public class ErrorModel {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ErrorModel()
        {
        }

        /// <summary>
        /// Código
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// Clase abstracta de control
    /// </summary>
    public abstract class Control
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public Control()
        {
        }

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Texto
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Visible
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// Activado
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Nombre de Clase
        /// </summary>
        public string ClassName { get; set; }
    }

    /// <summary>
    /// Clase control de botón
    /// </summary>
    public class ButtonControl : Control
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ButtonControl()
        {
        }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// Clase de Link de control
    /// </summary>
    public class LinkControl : Control
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public LinkControl()
        {
        }
    }
    /// <summary>
    /// Clase control de Caja de texto
    /// </summary>
    public class TextBoxControl : Control
    { 
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public TextBoxControl()
        {
        }
    }
    /// <summary>
    /// Clase de selectType
    /// </summary>
    [Serializable]
    public class SelectType
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public SelectType()
        {
        }

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Tipo
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Description { get; set; } 
    }
    /// <summary>
    /// Clase de SelectDisplay
    /// </summary>
    public class SelectDisplay : Base.SelectType
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public SelectDisplay()
        {
        }

        /// <summary>
        /// Mostrar
        /// </summary>
        public string Display { get; set; }
    }

    /// <summary>
    /// Clase de control de imagen
    /// </summary>
    public class ImageControl : Control
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public ImageControl()
        {
        }
    }
}