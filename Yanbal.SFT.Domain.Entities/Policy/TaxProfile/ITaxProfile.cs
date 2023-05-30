using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Freight.TaxProfile
{
    public interface ITaxProfile : IDisposable
    {
        List<TaxProfileEN> TaxProfileSearch(int? businessUnitCode,
                                            string directorCode,
                                            string directorName,
                                            string status,
                                            string affected);
        List<TaxProfileEN> TaxProfileSearch(int? businessUnitCode,
                                            string directorCode,
                                            string directorName,
                                            string status,
                                            string affected,
                                            int pageNo,
                                            int pageSize);
        int TaxProfileRegister(TaxProfileEN taxProfile);
        int TaxProfileUpdate(TaxProfileEN taxProfile);

       
    }
}
