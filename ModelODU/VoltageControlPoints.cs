using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelODU
{
    public class VoltageControlPoints
    {
        /// <summary>
        /// Переменная для названия контрольного пункта
        /// </summary>
        private string _name;

        /// <summary>
        /// Переменная для номера узла контрольного пункта в Rastr
        /// </summary>
        private int _numberOfControlPoints;

        /// <summary>
        /// Переменная для номера узла средства регулирования напряжения в Rastr
        /// </summary>
        private int _numberOfVoltageRegulationMeans;

        /// <summary>
        /// Название контрольного пункта
        /// </summary>
        public string NameOfControlPoints
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
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
        /// Номер узла средства регулирования напряжения в Rastr
        /// </summary>
        public int NumberOfVoltageRegulationMeans
        {
            get
            {
                return _numberOfVoltageRegulationMeans;
            }
            set
            {
                _numberOfVoltageRegulationMeans = value;
            }
        }

        /// <summary>
        /// Констурктор
        /// </summary>
        /// <param name="name"></param>
        /// <param name="numberOfControlPoints"></param>
        /// <param name="numberOfVoltageRegulationMeans"></param>
        public VoltageControlPoints(string name, int numberOfControlPoints, int numberOfVoltageRegulationMeans)
        {
            _name = name;
            _numberOfControlPoints = numberOfControlPoints;
            _numberOfVoltageRegulationMeans = numberOfVoltageRegulationMeans;
        }   
    }
}
