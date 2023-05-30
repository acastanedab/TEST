using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.FreightManagement.Common.File
{
    /// <summary>
    /// Clase que representa el utilitario de gestión de archivos
    /// </summary>
    /// <remarks>
    /// Creacion: GMD 20140919 <br />
    /// </remarks>
    public class CustomFileManager
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        protected CustomFileManager()
        {
        }

        /// <summary>
        /// Permite transformar un stream a arreglo de bytes
        /// </summary>
        /// <param name="input">Stream de entrada</param>
        /// <returns>Bytes de salida</returns>
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
