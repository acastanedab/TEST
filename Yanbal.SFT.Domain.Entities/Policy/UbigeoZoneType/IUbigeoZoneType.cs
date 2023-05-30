using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yanbal.SFT.Domain.Entities.Policy.UbigeoZoneType
{
    /// <summary>
    /// Interfaz que Define la Entidad de Negocio de Tipo de Zona de Ubigeo
    /// </summary>
    /// <remarks>
    /// Creación: GMD  20140805 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IUbigeoZoneType : IDisposable
    {
        /// <summary>
        /// UbigeoZoneTypeSearch
        /// </summary>
        List<UbigeoZoneTypeEN> UbigeoZoneTypeSearch(int? codeTypeZoneUbigeo,
                                                    int? businessUnitCode,
                                                    string codeZone,
                                                    string codeCountry,
                                                    string codeLevel1,
                                                    string level1,
                                                    string codeLevel2,
                                                    string level2,
                                                    string codeLevel3,
                                                    string level3,
                                                    string codeTypeZone,
                                                    string status);
        /// <summary>
        /// UbigeoZoneTypeSearch
        /// </summary>
        List<UbigeoZoneTypeEN> UbigeoZoneTypeSearch(int? codeTypeZoneUbigeo,
                                                    int? businessUnitCode,
                                                    string codeZone,
                                                    string codeCountry,
                                                    string codeLevel1,
                                                    string level1,
                                                    string codeLevel2,
                                                    string level2,
                                                    string codeLevel3,
                                                    string level3,
                                                    string codeTypeZone,
                                                    string status,
                                                    int? pageNo,
                                                    int? pageSize);
        /// <summary>
        /// UbigeoZoneTypeRegister
        /// </summary>
        int UbigeoZoneTypeRegister(UbigeoZoneTypeEN ubigeoZoneType);
        /// <summary>
        /// UbigeoZoneTypeUpdate
        /// </summary>
        int UbigeoZoneTypeUpdate(UbigeoZoneTypeEN ubigeoZoneType);
    }
}
