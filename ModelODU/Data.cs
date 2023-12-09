using ModelODU.VoltageRegulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelODU
{
    /// <summary>
    /// Класс для исходных данных
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Список для СРН на ПС 500 кВ Ново-Анжерская
        /// </summary>
        private static List<VoltageRegulationMeans> MeansOfSubstationNovoAngerskaya = new List<VoltageRegulationMeans>()
        {
            new VoltageRegulationMeans("УШР-500 ПС 500 кВ Томская", "управляемый", 60901160),
            new VoltageRegulationMeans("СТК-1 ПС 500 кВ Заря", "управляемый", 60700638),
            new VoltageRegulationMeans("ШР-500 ПС 500 кВ Томская", "коммутируемый", 60901161),
            new VoltageRegulationMeans("Р-532 ПС 500 кВ Заря", "коммутируемый", 60700130),
        };

        /// <summary>
        /// Список СРН на Беловской ГРЭС
        /// </summary>
        private static List<VoltageRegulationMeans> MeansOfBelovskayaGRES = new List<VoltageRegulationMeans>()
        {
            new VoltageRegulationMeans("УШР-500 ПС 500 кВ Томская", "управляемый", 60901160),
            new VoltageRegulationMeans("СТК-1 ПС 500 кВ Заря", "управляемый", 60700638),
            new VoltageRegulationMeans("ШР-500 ПС 500 кВ Томская", "коммутируемый", 60901161),
            new VoltageRegulationMeans("P-1 ПС 500 кВ Ново-Анжерская", "коммутируемый", 60690257),
        };

        /// <summary>
        /// Список СРН на ПС 500 кВ Юрга
        /// </summary>
        private static List<VoltageRegulationMeans> MeansOfSubstationJurga = new List<VoltageRegulationMeans>()
        {
            new VoltageRegulationMeans("УШР-500 ПС 500 кВ Томская", "управляемый", 60901160),
            new VoltageRegulationMeans("СТК-1 ПС 500 кВ Заря", "управляемый", 60700638),
            new VoltageRegulationMeans("ШР-500 ПС 500 кВ Томская", "коммутируемый", 60901161),
            new VoltageRegulationMeans("P-1 ПС 500 кВ Ново-Анжерская", "коммутируемый", 60690257),
        };

        /// <summary>
        /// Список контрольных пунктов
        /// </summary>
        public List<VoltageControlPoints> VoltageControlPoints = new List<VoltageControlPoints>()
        {          
            new VoltageControlPoints("ПС 500 кВ Ново-Анжерская", 60690204, MeansOfSubstationNovoAngerskaya),
            new VoltageControlPoints("Беловская ГРЭС", 60602016, MeansOfBelovskayaGRES),
            new VoltageControlPoints("ПС 500 кВ Юрга", 60690352, MeansOfSubstationJurga)
        };

        public List<ParametersForChangingRegime> ParametersForChangingRegimes = new List<ParametersForChangingRegime>()
        {
            new ParametersForChangingRegime(),
            new ParametersForChangingRegime(),
            new ParametersForChangingRegime(),
            new ParametersForChangingRegime(),
            new ParametersForChangingRegime(),
            new ParametersForChangingRegime(),
        };


        /// <summary>
        /// Список узлов для фиксации
        /// </summary>
        public List<int> NodesForFixing = new List<int>()
        {
            70606220,
            60304047,
            60301172,
            60301169,
            60304045,
            10910599,
            10904080,
            10904078,
            10904057,
            10904052,
            10904050,
            81306470,
            81306471,
            81306472,
            81306474,
            81303058,
            60802220,
            60802298,
            60103033,
            60103032,
            60101757,
            60101656,
            60102130,
            60102131,
            60700638,
            60700045,
            60901160,
            60901404,
            60901412,
            60902071,
            60512157,
            60512054,
            60512156,
            60512155,
            60526043,
            60526031,
            60526044,
            60526032,
            61000056,
            61000057,
            61000055,
            60526118,
            60513106,
            60526117,
            10900514,
            60402939,
            60402938,
            60402915,
            60401186,
            60403256,
            60403254,
            60403252,
            60403258,
            60403257,
            60404061,
            60403251,
            60403249,
            60401188,
            60401187,
            70606226,
            70606225,
            60211250,
            60211253,
            60208007,
            60208003,
            60208102,
            60211249,
            60211252,
        };


    }
}
