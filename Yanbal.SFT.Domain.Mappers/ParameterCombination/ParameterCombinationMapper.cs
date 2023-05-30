using System;
using System.Collections.Generic;
using System.Linq;
using Yanbal.SFT.Domain.Entities.Logic.Policy;
using Yanbal.SFT.Domain.Entities.Policy.Combination;
using Yanbal.SFT.Domain.Entities.Policy.ParameterCombination;

namespace Yanbal.SFT.Domain.Mappers.ParameterCombination
{
    public static class ParameterCombinationMapper
    {
        public static List<ParameterCombinationEL> ToParameterCombinationEL(this List<ParameterCombinationEN> input)
        {
            List<ParameterCombinationEL> listParameterCombinationEL = new List<ParameterCombinationEL>();
            foreach (var item in input)
            {
                var parameterCombinationEl = new ParameterCombinationEL();
                parameterCombinationEl.CodeParameterCombination = Convert.ToInt32(item.CodigoCombinacionParametro);
                parameterCombinationEl.CodeCombination = item.CodigoCombinacion;
                parameterCombinationEl.CodeParameter = item.CodigoParametro;
                parameterCombinationEl.Code = item.Codigo;
                parameterCombinationEl.ParameterName = item.NombreParametro;
                parameterCombinationEl.ParameterType = item.TipoParametro;
                parameterCombinationEl.CombinationOrder = item.OrdenCombinacion;
                parameterCombinationEl.Value = item.Valor;
                parameterCombinationEl.DescriptionValue = item.DescripcionValor;
                parameterCombinationEl.AmountFreight = item.ImporteFlete;
                parameterCombinationEl.RowId = item.RowId;
                parameterCombinationEl.RowNumber = item.RowNumber;
                parameterCombinationEl.RowsTotal = item.RowsTotal;

                listParameterCombinationEL.Add(parameterCombinationEl);
            }

            return listParameterCombinationEL;
        }

        public static List<ParameterCombinationEL> ToParameterCombinationELUnpage(this List<ParameterCombinationEN> input)
        {
            List<ParameterCombinationEL> listParameterCombinationEL = new List<ParameterCombinationEL>();
            foreach (var item in input)
            {
                var parameterCombinationEl = new ParameterCombinationEL();
                parameterCombinationEl.CodeParameterCombination = Convert.ToInt32(item.CodigoCombinacionParametro);
                parameterCombinationEl.CodeCombination = item.CodigoCombinacion;
                parameterCombinationEl.CodeParameter = item.CodigoParametro;
                parameterCombinationEl.Code = item.Codigo;
                parameterCombinationEl.ParameterName = item.NombreParametro;
                parameterCombinationEl.ParameterType = item.TipoParametro;
                parameterCombinationEl.CombinationOrder = item.OrdenCombinacion;
                parameterCombinationEl.Value = item.Valor;
                parameterCombinationEl.DescriptionValue = item.DescripcionValor;
                parameterCombinationEl.AmountFreight = item.ImporteFlete;

                listParameterCombinationEL.Add(parameterCombinationEl);
            }

            return listParameterCombinationEL;
        }

        public static List<ParameterCombinationEL> FilterAndRemoveCombinations(this List<ParameterCombinationEL> input, int codigoCombinacion)
        {
            List<ParameterCombinationEL> output = new List<ParameterCombinationEL>();

            if (input != null && input.Count > 0)
            {
                output = input.Where(x => x.CodeCombination == codigoCombinacion).ToList();

                foreach (var deleteItem in output)
                {
                    input.Remove(deleteItem);
                }
            }

            return output;
        }

        public static List<CombinationTableEN> ToNonNullable(this List<ParameterCombinationEN> filter, List<CombinationTableEN> list, int? CodeCombination)
        {
            if (list == null)
            {
                list = new List<CombinationTableEN>();
                list.Add(new CombinationTableEN { CodigoCombinacion = CodeCombination });
            }

            return list;
        }
    }
}
