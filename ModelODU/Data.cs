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
    /// Класс для исходных данных.
    /// </summary>
    public class Data
    {

        private static List<VoltageRegulationMeans> MeansOfSubstationNovoAngerskaya = new List<VoltageRegulationMeans>()
        {
            new VoltageRegulationMeans("УШР-500 ПС 500 кВ Томская", "управляемый", 60901160),
            new VoltageRegulationMeans("СТК-1 ПС 500 кВ Заря", "управляемый", 60700638),
            new VoltageRegulationMeans("ШР-500 ПС 500 кВ Томская", "коммутируемый", 60901161),
            new VoltageRegulationMeans("Р-532 ПС 500 кВ Заря", "коммутируемый", 60700130),
        };

        private static List<VoltageRegulationMeans> MeansOfBelovskayaGRES = new List<VoltageRegulationMeans>()
        {
            new VoltageRegulationMeans("УШР-500 ПС 500 кВ Томская", "управляемый", 60901160),
            new VoltageRegulationMeans("СТК-1 ПС 500 кВ Заря", "управляемый", 60700638),
            new VoltageRegulationMeans("ШР-500 ПС 500 кВ Томская", "коммутируемый", 60901161),
            new VoltageRegulationMeans("P-1 ПС 500 кВ Ново-Анжерская", "коммутируемый", 60690257),
        };

        private static List<VoltageRegulationMeans> MeansOfSubstationJurga = new List<VoltageRegulationMeans>()
        {
            new VoltageRegulationMeans("УШР-500 ПС 500 кВ Томская", "управляемый", 60901160),
            new VoltageRegulationMeans("СТК-1 ПС 500 кВ Заря", "управляемый", 60700638),
            new VoltageRegulationMeans("ШР-500 ПС 500 кВ Томская", "коммутируемый", 60901161),
            new VoltageRegulationMeans("P-1 ПС 500 кВ Ново-Анжерская", "коммутируемый", 60690257),
        };

        public List<VoltageControlPoints> VoltageControlPoints = new List<VoltageControlPoints>()
        {          
            new VoltageControlPoints("ПС 500 кВ Ново-Анжерская", 60690204, MeansOfSubstationNovoAngerskaya),
            new VoltageControlPoints("Беловская ГРЭС", 60602016, MeansOfBelovskayaGRES),
            new VoltageControlPoints("ПС 500 кВ Юрга", 60690352, MeansOfSubstationJurga)
        };






        /// <summary>
        /// Спискок, хранящий номера узлов с контрольными пунктами из файла режима
        /// ПС 500 кВ Ново-Анжерская, ПС 500 кВ Юрга, ПС 500 кВ Новокузнецкая
        /// </summary>
        public List<int> NumbersOfNodes = new List<int>()
        {
            60690204,
            60690352,
            60690215
        };

        /// <summary>
        /// Спискок, хранящий номера узлов с управляемыми реакторами из файла режима
        /// УШР-500 на ПС 500 кВ Томская, ПС 500 кВ Заря СТК-1, УШР-500 на ПС 500 кВ Томская
        /// </summary>
        public List<int> NumbersOfControlledReactors = new List<int>()
        {
            60901160,
            60700638,
            60901160,
        };

        /// <summary>
        /// Спискок, хранящий номера узлов с коммутируемыми реакторами из файла режима
        /// ШР-500 на ПС 500 кВ Томская, ПС 500 кВ Заря Р-532, ПС 500 кВ Абаканская
        /// </summary>
        public List<int> NumbersOfSwitchedReactorsFromRastr = new List<int>()
        {
            60901161,
            60700130,
            61111103
        };

        /// <summary>
        /// Список, хранящий номера узлов генераторов влияющих станций
        /// Берёзовская ГРЭС ТГ-1, Берёзовская ГРЭС ТГ-1, Берёзовская ГРЭС ТГ-1
        /// </summary>
        public List<int> ResearchingGeneratorsFromRastr = new List<int>()
        {
            61190059,
            61190059,
            61190059
        };

        /// <summary>
        /// Все строки с узлами в схеме для фисксации всех СРН
        /// </summary>
        public int[] arrNub = Enumerable.Range(0, 5771).ToArray();



        



    }
}
