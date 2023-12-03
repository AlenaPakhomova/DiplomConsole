using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelODU
{
    /// <summary>
    /// Класс для задания параметров контрольного пункта
    /// </summary>
    public class VoltageControlPoints
    {
        /// <summary>
        /// Переменная для названия контрольного пункта
        /// </summary>
        private string _nameOfControlPoints;

        /// <summary>
        /// Переменная для номера узла контрольного пункта в Rastr
        /// </summary>
        private int _numberOfControlPoints;

        /// <summary>
        /// Переменная для названия средства регулирования напряжения
        /// </summary>
        private List<VoltageRegulationMeans> _parametersOfVoltageRegulationMeans;

        /// <summary>
        /// Название контрольного пункта
        /// </summary>
        public string NameOfControlPoints
        {
            get
            {
                return _nameOfControlPoints;
            }
            set
            {
                _nameOfControlPoints = value;
            }
        }

        /// <summary>
        /// Номер узла контрольного пунтка в Rastr
        /// </summary>
        public int NumberOfControlPoints
        {
            get
            {
                return _numberOfControlPoints;
            }
            set
            {
                _numberOfControlPoints = value;
            }
        }

        /// <summary>
        /// Название средства регулирования напряжения
        /// </summary>
        public List<VoltageRegulationMeans> ParametersOfVoltageRegulationMeans
        {
            get
            {
                return _parametersOfVoltageRegulationMeans;
            }
            set
            {
                _parametersOfVoltageRegulationMeans = value;
            }
        }

        

        /// <summary>
        /// Констурктор
        /// </summary>
        /// <param name="name"></param>
        /// <param name="numberOfControlPoints"></param>
        /// <param name="numberOfVoltageRegulationMeans"></param>
        public VoltageControlPoints(string nameOfControlPoints, int numberOfControlPoints,
            List<VoltageRegulationMeans> parametersOfVoltageRegulationMeans, List<VoltageRegulationMeans> _nameOfVoltageRegulationMeans,
            List<VoltageRegulationMeans> _typeOfVoltageRegulationMeans, List<VoltageRegulationMeans> _numberOfVoltageRegulationMeans)
        {
            VoltageRegulationMeans voltageRegulationMeans = new VoltageRegulationMeans();
            NameOfControlPoints = nameOfControlPoints;
            NumberOfControlPoints = numberOfControlPoints;
            ParametersOfVoltageRegulationMeans.Add(voltageRegulationMeans);


        }   
    }
}
