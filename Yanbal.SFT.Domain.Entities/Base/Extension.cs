using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Yanbal.SFT.Domain.Entities.Base
{
    /// <summary>
    /// Entidad de Negocio que representa la clase estatica Extension
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Método que permite convertir una lista T a un DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns>DataTable</returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {

            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                Type type = Nullable.GetUnderlyingType(prop.PropertyType);
                type = (type == null) ? prop.PropertyType : type;
                table.Columns.Add(prop.Name, type);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            return table;
        }
    }
}