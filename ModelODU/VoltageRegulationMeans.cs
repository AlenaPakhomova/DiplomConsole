using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelODU
{
    /// <summary>
    /// Класс для задания параметров средства регулирования напряжения
    /// </summary>
    public class VoltageRegulationMeans
    {
        /// <summary>
        /// Переменная для названия средства регулирования напряжения 
        /// </summary>
        private string _nameOfVoltageRegulationMeans;

        /// <summary>
        /// Переменная для типа средства регулирования напряжения
        /// </summary>
        private string _typeOfVoltageRegulationMeans;

        /// <summary>
        /// Переменная для номера контрольного пункта в Rastr
        /// </summary>
        private int _numberOfVoltageRegulationMeans;

        /// <summary>
        /// Название средства регулирования напряжения
        /// </summary>
        public string NameOfVoltageRegulationMeans
        {
            get
            {
                return _nameOfVoltageRegulationMeans;
            }
            set
            {
                _nameOfVoltageRegulationMeans = value;
            }
        }

        /// <summary>
        /// Тип средства регулирования напряжения
        /// </summary>
        public string TypeOfVoltageRegulationMeans
        {
            get
            {
                return _typeOfVoltageRegulationMeans;
            }
            set
            {
                _typeOfVoltageRegulationMeans = value;
            }
        }

        /// <summary>
        /// Номер контрольного пукта из Rastr
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

        
        public VoltageRegulationMeans(string _nameOfVoltageRegulationMeans, 
            string _typeOfVoltageRegulationMeans, int _numberOfVoltageRegulationMeans)
        {
            NameOfVoltageRegulationMeans = _nameOfVoltageRegulationMeans;
            TypeOfVoltageRegulationMeans = _typeOfVoltageRegulationMeans;
            NumberOfVoltageRegulationMeans = _numberOfVoltageRegulationMeans;
        }
        

    }
}
