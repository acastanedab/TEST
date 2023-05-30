using System.Collections.Generic;
using Yanbal.SFT.Domain.Entities.Policy.Combination;

namespace Yanbal.SFT.Domain.Mappers.Combination
{
    public static class CombinationMapper
    {
        public static List<CombinationTableEN> ToCombinationTable(this List<CombinationEN> resultCombinationEn)
        {
            List<CombinationTableEN> tableList = new List<CombinationTableEN>();

            if (resultCombinationEn != null)
            {
                foreach (var combination in resultCombinationEn)
                {
                    var combinationTableEN = new CombinationTableEN
                    {
                        CodigoCombinacion = combination.CodigoCombinacion,
                        Valor = combination.Combinacion,
                    };

                    tableList.Add(combinationTableEN);
                }
            }

            return tableList;
        }
    }
}
