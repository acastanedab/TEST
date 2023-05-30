using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Yanbal.SFT.FreightManagement.Common.Format;

namespace Yanbal.SFT.FreightManagement.Common.Custom
{
    /// <summary>
    ///  Clase de dominio común de Utilitario
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140710 <br />
    /// Modificación:       <br />
    /// </remarks>
    public static class Utility
    {

        /// <summary>
        /// Obtiene la Fecha y Hora Actual
        /// </summary>
        /// <returns>Fecha y Hora Actual de la Unidad de Negocio</returns>
        public static DateTime GetDateTimeNow()
        {
            return GetDateTimeNow(null);
        }

        /// <summary>
        /// Obtiene la Fecha y Hora Actual
        /// </summary>
        /// <param name="businessUnitCode">Unidad de Negocio</param>
        /// <returns>Fecha y Hora Actual de la Unidad de Negocio</returns>
        public static DateTime GetDateTimeNow(int? businessUnitCode)
        {
            return DateTime.Now.Date;
        }

        /// <summary>
        /// Permite convertir en formato fecha 
        /// </summary>
        /// <param name="formatDateApplication">Formato fecha aplicación</param>
        /// <returns>Fecha según formato</returns>
        public static string ConvertFormatDatePresentation(string formatDateApplication)
        {
            string format = formatDateApplication ?? "";

            format = format.Replace("yy", "y");
            format = format.Replace("MM", "mm");
            format = format.Replace("MMMM", "MM");
            return format;
        }

        /// <summary>
        /// Permite convertir de String a DateTime con su respectivo formato de fecha
        /// </summary>
        /// <returns>Retorna de Fecha</returns>
        public static DateTime? StringFormatDatetime(string value)
        {
            return StringFormatDatetime(value, "dd/MM/yyyy");
        }
        /// <summary>
        /// Permite convertir de String a DateTime con su respectivo formato de fecha
        /// </summary>
        /// <param name="value">Fecha</param>
        /// <param name="format">Formato</param>
        /// <returns>Retorna de Fecha</returns>
        public static DateTime? StringFormatDatetime(string value, string format)
        {
            try
            {
                return string.IsNullOrEmpty(value) ? (DateTime?)null : DateTime.ParseExact(value, format, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite convertir de String a Decimal con su respectivo formato de decimal
        /// </summary>
        /// <param name="value">Decimal</param>
        /// <returns>Retorna de Decimal</returns>
        public static decimal? StringFormatDecimal(string value)
        {
            return StringFormatDecimal(value, "{0:#,##0.00}", null);
        }

        /// <summary>
        /// Permite convertir de String a Decimal con su respectivo formato de decimal
        /// </summary>
        /// <param name="value">Decimal</param>
        /// <param name="format">Formato</param>
        /// <param name="numberFormat">Formato de Número</param>
        /// <returns>Retorna de Decimal</returns>
        public static decimal? StringFormatDecimal(string value, string format, NumberFormat numberFormat)
        {
            try
            {
                if (!format.Contains("{"))
                    format = "{0:" + format + "}";

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = numberFormat.NumberDecimalSeparator;
                numberFormatInfo.NumberGroupSeparator = numberFormat.NumberGroupSeparator;

                return string.IsNullOrEmpty(value) ? (decimal?)null : Decimal.Parse(value, numberFormatInfo);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite convertir de String a Int con su respectivo formato de entero
        /// </summary>
        /// <param name="value">Entero</param>
        /// <returns>Retorna de Entero</returns>
        public static int? StringFormatInt(string value)
        {
            return StringFormatInt(value, "{0:#,##0}", null);
        }

        /// <summary>
        /// Permite convertir de String a Int con su respectivo formato de entero
        /// </summary>
        /// <param name="value">Entero</param>
        /// <param name="format">Formato</param>
        /// <param name="numberFormat">Formato de Número</param>
        /// <returns>Retorna de Entero</returns>
        public static int? StringFormatInt(string value, string format, NumberFormat numberFormat)
        {
            try
            {
                if (!format.Contains("{"))
                {
                    format = "{0:" + format + "}";
                }
                return string.IsNullOrEmpty(value) ? (int?)null : int.Parse(value.Replace(numberFormat.NumberGroupSeparator, ""));
            }
            catch (FormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite convertir DateTime a String con su respectivo formato de fecha
        /// </summary>
        /// <param name="value">Fecha</param>
        /// <returns>Retorna la fecha formateada</returns>
        public static string DatetimeFormatString(DateTime? value )
        { 
            return DatetimeFormatString (value, "dd/MM/yyyy" );
        }

        /// <summary>
        /// Permite convertir DateTime a String con su respectivo formato de fecha
        /// </summary>
        /// <param name="value">Fecha</param>
        /// <param name="format">Formato</param>
        /// <returns>Retorna la fecha formateada</returns>
        public static string DatetimeFormatString(DateTime? value, string format)
        {
            if (value.HasValue)
            {
                return Convert.ToDateTime(value).ToString(format, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Permite convertir Decimal a String con su respectivo formato de decimal
        /// </summary>
        /// <param name="value">Decimal</param>
        /// <returns>Retorna el decimal formateado</returns>
        public static string DecimalFormatString(decimal? value)
        {
            return DecimalFormatString(value, "{0:#,##0.00}", null);
        }

        /// <summary>
        /// Permite convertir Decimal a String con su respectivo formato de decimal
        /// </summary>
        /// <param name="value">Decimal</param>
        /// <param name="format">Formato</param>
        /// <param name="numberFormat">Formato de Número</param>
        /// <returns>Retorna el decimal formateado</returns>
        public static string DecimalFormatString(decimal? value, string format, NumberFormat numberFormat)
        {
            if (value.HasValue)
            {
                if (!format.Contains("{"))
                    format = "{0:" + format + "}";

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = numberFormat.NumberDecimalSeparator;
                numberFormatInfo.NumberGroupSeparator = numberFormat.NumberGroupSeparator;

                format = format.Replace(numberFormat.NumberDecimalSeparator, "@");
                format = format.Replace(numberFormat.NumberGroupSeparator, ",");
                format = format.Replace("@", ".");

                return string.Format(numberFormatInfo, format, value);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Permite convertir Int a String con su respectivo formato de enteros
        /// </summary>
        /// <param name="value">Entero</param>
        /// <returns>Retorna el int formateado</returns>
        public static string IntFormatString(int? value)
        {
            return IntFormatString (value, "#,##0", null);
        }

        /// <summary>
        /// Permite convertir Int a String con su respectivo formato de enteros
        /// </summary>
        /// <param name="value">Entero</param>
        /// <param name="format">Formato</param>
        /// <param name="numberFormat">Formato de Número</param>
        /// <returns>Retorna el int formateado</returns>
        public static string IntFormatString(int? value, string format, NumberFormat numberFormat)
        {
            if (value.HasValue)
            {
                if (!format.Contains("{"))
                    format = "{0:" + format + "}";

                format = format.Replace(numberFormat.NumberGroupSeparator, ",");

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberGroupSeparator = numberFormat.NumberGroupSeparator;

                return string.Format(numberFormatInfo, format, value);
            }
            else
            {
                return string.Empty;
            }
        }
        
        /// <summary>
        /// Redondeo de Decimales
        /// </summary>
        /// <param name="number">Número de Decimales</param>
        /// <returns>Número redondeado</returns>
        public static decimal RoundUpDecimal(decimal number)
        {
            return RoundUpDecimal(number, 2);
        }

        /// <summary>
        /// Redondeo de Decimales
        /// </summary>
        /// <param name="number">Número de Decimales</param>
        /// <param name="quantityDecimal">Cantidad de Decimales</param>
        /// <returns>Número redondeado</returns>
        public static decimal RoundUpDecimal(decimal number, int quantityDecimal)
        {
            decimal numberRound = Math.Round(number, quantityDecimal, MidpointRounding.AwayFromZero);
            return numberRound;
        }

        /// <summary>
        /// Permite generar query
        /// </summary>
        /// <param name="listColumn">Lista de columna</param>
        /// <param name="listTable">Lista tabla</param>
        /// <returns>Retorna query</returns>
        public static string GenerateQuery(List<string> listColumn, List<string> listTable)
        {
            return GenerateQuery(listColumn, listTable, null, null);
        }

        /// <summary>
        /// Permite generar query
        /// </summary>
        /// <param name="listColumn">Lista de columna</param>
        /// <param name="listTable">Lista tabla</param>
        /// <param name="filter">Filtro</param>
        /// <param name="order">ordenamiento</param>
        /// <returns>Retorna query</returns>
        public static string GenerateQuery(List<string> listColumn, List<string> listTable, Dictionary<string, string> filter)
        {
            return GenerateQuery(listColumn, listTable, filter,null);
        }

        /// <summary>
        /// Permite generar query
        /// </summary>
        /// <param name="listColumn">Lista de columna</param>
        /// <param name="listTable">Lista tabla</param>
        /// <param name="filter">Filtro</param>
        /// <param name="order">ordenamiento</param>
        /// <returns>Retorna query</returns>
        public static string GenerateQuery(List<string> listColumn, List<string> listTable, Dictionary<string, string> filter, Dictionary<string, string> order )
        {
            string whereScript = "";
            string orderByScript = "";


            StringBuilder selectScriptn = new StringBuilder();
            StringBuilder fromScriptn = new StringBuilder();
            StringBuilder whereScriptn = new StringBuilder();
            StringBuilder orderByScriptn = new StringBuilder();

            foreach (var item in listColumn)
            {
                if (selectScriptn.Length != 0)
                {
                    selectScriptn.Append(",");
                    selectScriptn.Append(item);
                }
                else
                {
                    selectScriptn.Append(item);
                }
            }

            
            foreach (var item in listTable)
            {
                if (fromScriptn.Length != 0)
                {
                    fromScriptn.Append(",");
                    fromScriptn.Append(item);
                }
                else
                {
                    fromScriptn.Append(item);
                }
            }


            if (filter != null)
            {
                foreach (var item in filter)
                {
                    if (whereScriptn.Length != 0)
                    {
                        whereScriptn.Append(" AND ");
                        whereScriptn.Append(item.Key);
                        whereScriptn.Append(item.Value);
                    }
                    else
                    {
                        whereScriptn.Append(item.Key);
                        whereScriptn.Append(item.Value);
                    }
                }

                if (whereScriptn.Length != 0)
                {
                    whereScript = " WHERE " + whereScriptn.ToString();
                }
            }


            if (order != null)
            {
                foreach (var item in order)
                {
                    if (orderByScriptn.Length != 0)
                    {
                        orderByScriptn.Append(", ");
                        orderByScriptn.Append(item.Key);
                        orderByScriptn.Append(item.Value);
                    }
                    else
                    {
                        orderByScriptn.Append(item.Key);
                        orderByScriptn.Append(item.Value);
                    }
                }

                if (orderByScriptn.Length != 0)
                {
                    orderByScript = " ORDER BY " + orderByScriptn.ToString();
                }
            }

            string script = "SELECT " + selectScriptn.ToString() + " FROM " + fromScriptn.ToString() + whereScript + orderByScript;

            return script;
        }

        /// <summary>
        /// Permite validar columnas
        /// </summary>
        /// <param name="columnName">Nombre columna</param>
        /// <returns>Validación entre columnas</returns>
        public static int validateColumns(string columnName)
        {
            int result = 1;

            int flg_exist = columnName.IndexOf("Creacion", StringComparison.InvariantCulture);

            if (flg_exist < 0)
            {
                flg_exist = columnName.IndexOf("Modificacion", StringComparison.InvariantCulture);

                if (flg_exist < 0)
                {
                    flg_exist = columnName.IndexOf("Row", StringComparison.InvariantCulture);

                    if (flg_exist < 0)
                    {
                        flg_exist = columnName.IndexOf("String", StringComparison.InvariantCulture);

                        if (flg_exist < 0)
                        {
                            flg_exist = columnName.IndexOf("Observacion", StringComparison.InvariantCulture);

                            if (flg_exist < 0)
                            {
                                result = 0;
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Transforma un Objeto a XML
        /// </summary>
        /// <param name="obj">Objeto a transformar</param>
        /// <returns>XML en String</returns>
        public static string ToXML(Object obj)
        {
            string xml = string.Empty;
            try
            {
                if (obj != null)
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Encoding = new UnicodeEncoding(false, false);
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = true;

                    using (StringWriter textWriter = new StringWriter())
                    {
                        using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                        {
                            serializer.Serialize(xmlWriter, obj);
                        }
                        xml = textWriter.ToString();
                    }
                }
            }
            catch (Exception)
            {
                xml = string.Empty;
            }
            return xml;
        }

        /// <summary>
        /// Permite enviar el string sin convertir en caracteres extraños
        /// </summary>
        /// <param name="escaped">String a unescape</param>
        /// <returns></returns>
        public static string XmlUnescape(string escaped)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlNode node = doc.CreateElement("root");
            node.InnerXml = escaped;
            return node.InnerText;
        }
    }
}
