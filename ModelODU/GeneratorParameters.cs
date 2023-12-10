using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelODU
{
    public class GeneratorParameters
    {
        /// <summary>
        /// Переменная для времени 
        /// </summary>
        private DateTime _timeInterval;

        /// <summary>
        /// Переменная для активнйо мощности генератора
        /// </summary>
        private double _activePowerOfGenerator;


        /// <summary>
        /// Активная мощность генератора 
        /// </summary>
        public double ActivePowerOfGenerator
        {
            get
            {
                return _activePowerOfGenerator;
            }
            set
            {
                _activePowerOfGenerator = value;
            }
        }

        /// <summary>
        /// Время 
        /// </summary>
        public DateTime TimeInterval
        {
            get
            {
                return _timeInterval;
            }
            set
            {
                _timeInterval = value;
            }
        }

        /// <summary>
        /// Конструктор для параметров генератора
        /// </summary>
        /// <param name="_timeInterval"></param>
        /// <param name="_activePowerOfGenerator"></param>
        public GeneratorParameters(DateTime _timeInterval, double _activePowerOfGenerator)
        {
            TimeInterval = _timeInterval;
            ActivePowerOfGenerator = _activePowerOfGenerator;
        }
    }
}
