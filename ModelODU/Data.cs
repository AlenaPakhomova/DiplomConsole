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
            new ParametersForChangingRegime("Берёзовская ГРЭС Блок1", 60523013, BerezovskayaGRES),
            new ParametersForChangingRegime("Саяно-Шушенская ГЭС_Г9", 61190059, SayanoShyshenskayaGES_G9),
            new ParametersForChangingRegime("Саяно-Шушенская ГЭС_Г7", 61190057, SayanoShyshenskayaGES_G7),
            new ParametersForChangingRegime("Беловская ГРЭС (220 кВ)_Блок 6", 60602015, BelovskayaGRES_Blok6),
            new ParametersForChangingRegime("Беловская ГРЭС (220 кВ)_Блок 5", 60602014, BelovskayaGRES_Blok5),
            new ParametersForChangingRegime("Назаровская ГРЭС (500 кВ)_Блок 7", 60524030, NazarovskayaGRES_Blok7),
            new ParametersForChangingRegime("Назаровская ГРЭС (500/220 кВ)_Блок 6", 60524029, NazarovskayaGRES_Blok6),
        };

        private static List<GeneratorParameters> BerezovskayaGRES = new List<GeneratorParameters>()
        {
            new GeneratorParameters(new DateTime(2022, 4, 18), 759.57),
            new GeneratorParameters(new DateTime(2022, 4, 19), 759.84),
            new GeneratorParameters(new DateTime(2022, 4, 20), 761.83),
            new GeneratorParameters(new DateTime(2022, 4, 21), 761.76),
            new GeneratorParameters(new DateTime(2022, 4, 22), 761.22),
            new GeneratorParameters(new DateTime(2022, 4, 23), 757.32),
            new GeneratorParameters(new DateTime(2022, 4, 24), 760.80),
            new GeneratorParameters(new DateTime(2022, 4, 25), 768.24),
            new GeneratorParameters(new DateTime(2022, 4, 26), 759.29),
            new GeneratorParameters(new DateTime(2022, 4, 27), 761.59),
        };

        private static List<GeneratorParameters> SayanoShyshenskayaGES_G9 = new List<GeneratorParameters>()
        {
            new GeneratorParameters(new DateTime(2022, 4, 18), 446.70),
            new GeneratorParameters(new DateTime(2022, 4, 19), 498.11),
            new GeneratorParameters(new DateTime(2022, 4, 20), 498.87),
            new GeneratorParameters(new DateTime(2022, 4, 21), 554.62),
            new GeneratorParameters(new DateTime(2022, 4, 22), 447.46),
            new GeneratorParameters(new DateTime(2022, 4, 23), 561.61),
            new GeneratorParameters(new DateTime(2022, 4, 24), 561.42),
            new GeneratorParameters(new DateTime(2022, 4, 25), 501.89),
            new GeneratorParameters(new DateTime(2022, 4, 26), 525.23),
            new GeneratorParameters(new DateTime(2022, 4, 27), 547.72),
        };

        private static List<GeneratorParameters> SayanoShyshenskayaGES_G7 = new List<GeneratorParameters>()
        {
            new GeneratorParameters(new DateTime(2022, 4, 18), 559.91),
            new GeneratorParameters(new DateTime(2022, 4, 19), 563.79),
            new GeneratorParameters(new DateTime(2022, 4, 20), 562.18),
            new GeneratorParameters(new DateTime(2022, 4, 21), 562.65),
            new GeneratorParameters(new DateTime(2022, 4, 22), 564.16),
            new GeneratorParameters(new DateTime(2022, 4, 23), 562.46),
            new GeneratorParameters(new DateTime(2022, 4, 24), 563.22),
            new GeneratorParameters(new DateTime(2022, 4, 25), 561.99),
            new GeneratorParameters(new DateTime(2022, 4, 26), 563.32),
            new GeneratorParameters(new DateTime(2022, 4, 27), 563.03),
        };

        private static List<GeneratorParameters> BelovskayaGRES_Blok6 = new List<GeneratorParameters>()
        {
            new GeneratorParameters(new DateTime(2022, 4, 18), 201.17),
            new GeneratorParameters(new DateTime(2022, 4, 19), 199.65),
            new GeneratorParameters(new DateTime(2022, 4, 20), 202.83),
            new GeneratorParameters(new DateTime(2022, 4, 21), 199.48),
            new GeneratorParameters(new DateTime(2022, 4, 22), 203.30),
            new GeneratorParameters(new DateTime(2022, 4, 23), 199.27),
            new GeneratorParameters(new DateTime(2022, 4, 24), 197.38),
            new GeneratorParameters(new DateTime(2022, 4, 25), 199.35),
            new GeneratorParameters(new DateTime(2022, 4, 26), 198.32),
            new GeneratorParameters(new DateTime(2022, 4, 27), 199.33),
        };

        private static List<GeneratorParameters> BelovskayaGRES_Blok5 = new List<GeneratorParameters>()
        {
            new GeneratorParameters(new DateTime(2022, 4, 18), 76.52),
            new GeneratorParameters(new DateTime(2022, 4, 19), 76.93),
            new GeneratorParameters(new DateTime(2022, 4, 20), 81.38),
            new GeneratorParameters(new DateTime(2022, 4, 21), 81.44),
            new GeneratorParameters(new DateTime(2022, 4, 22), 80.41),
            new GeneratorParameters(new DateTime(2022, 4, 23), 182.33),
            new GeneratorParameters(new DateTime(2022, 4, 24), 177.73),
            new GeneratorParameters(new DateTime(2022, 4, 25), 180.24),
            new GeneratorParameters(new DateTime(2022, 4, 26), 183.57),
            new GeneratorParameters(new DateTime(2022, 4, 27), 177.86),
        };

        private static List<GeneratorParameters> NazarovskayaGRES_Blok7 = new List<GeneratorParameters>()
        {
            new GeneratorParameters(new DateTime(2022, 4, 18), 197.03),
            new GeneratorParameters(new DateTime(2022, 4, 19), 192.92),
            new GeneratorParameters(new DateTime(2022, 4, 20), 187.68),
            new GeneratorParameters(new DateTime(2022, 4, 21), 193.67),
            new GeneratorParameters(new DateTime(2022, 4, 22), 190.67),
            new GeneratorParameters(new DateTime(2022, 4, 23), 197.53),
            new GeneratorParameters(new DateTime(2022, 4, 24), 199.28),
            new GeneratorParameters(new DateTime(2022, 4, 25), 193.17),
            new GeneratorParameters(new DateTime(2022, 4, 26), 179.57),
            new GeneratorParameters(new DateTime(2022, 4, 27), 162.99),
        };

        private static List<GeneratorParameters> NazarovskayaGRES_Blok6 = new List<GeneratorParameters>()
        {
            new GeneratorParameters(new DateTime(2022, 4, 18), 55.46),
            new GeneratorParameters(new DateTime(2022, 4, 19), 52.92),
            new GeneratorParameters(new DateTime(2022, 4, 20), 111.79),
            new GeneratorParameters(new DateTime(2022, 4, 21), 100.26),
            new GeneratorParameters(new DateTime(2022, 4, 22), 108.34),
            new GeneratorParameters(new DateTime(2022, 4, 23), 109.19),
            new GeneratorParameters(new DateTime(2022, 4, 24), 111.93),
            new GeneratorParameters(new DateTime(2022, 4, 25), 114.33),
            new GeneratorParameters(new DateTime(2022, 4, 26), 104.95),
            new GeneratorParameters(new DateTime(2022, 4, 27), 109.19),
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
