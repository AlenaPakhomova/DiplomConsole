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
        /// Переменная для номер узла генератора в Rastr
        /// </summary>
        private int _numberOfGeneratorNode;

        /// <summary>
        /// Переменная для времени 
        /// </summary>
        private DateTime _timeInterval;

        /// <summary>
        /// Переменная для активнйо мощности генератора
        /// </summary>
        private double _activePowerOfGenerator;

        /// <summary>
        /// Номер узла генератора в Rastr
        /// </summary>
        public int NumberOfGeneratorNode
        {
            get
            {
                return _numberOfGeneratorNode;
            }
            set
            {
                _numberOfGeneratorNode = value;
            }
        }


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
        public GeneratorParameters(DateTime _timeInterval, int _numberOfGeneratorNode, double _activePowerOfGenerator)
        {
            TimeInterval = _timeInterval;
            NumberOfGeneratorNode = _numberOfGeneratorNode;
            ActivePowerOfGenerator = _activePowerOfGenerator;           
        }
    }
}
