using ModelODU.VoltageRegulation;
using System;
using System.Collections.Generic;
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

        List<VoltageControlPoints> voltageControlPoints = new List<VoltageControlPoints>()
        {
            
            new VoltageControlPoints("ПС 500 кВ Ново-Анжерская", 60690204,
                new VoltageRegulationMeans( "УШР-500 ПС 500 кВ Томская", "управляемые",  60690204 )),
            

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
