using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelODU
{
    /// <summary>
    /// Класс для создания перменных, которые будут использоваться для
    /// изменения текущего режима
    /// </summary>
    public class ParametersForChangingRegime
    {
        /// <summary>
        /// Переменная для времени 
        /// </summary>
        private DateTime _timeInterval;

        /// <summary>
        /// Переменная для имени генератора 
        /// </summary>
        private string _generatorNames;

        /// <summary>
        /// Переменная для номер узла генератора в Rastr
        /// </summary>
        private int _numberOfGeneratorNode;

        /// <summary>
        /// Переменная для активнйо мощности генератора
        /// </summary>
        private double _activePowerOfGenerator;

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
        /// Имя генератора
        /// </summary>
        public string GeneratorNames
        {
            get
            {
                return _generatorNames;
            }
            set
            {
                _generatorNames = value;    
            }
        }

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
        /// Конструктор для параметров, которые изменяют режим
        /// </summary>
        /// <param name="_timeInterval"></param>
        /// <param name="_generatorNames"></param>
        /// <param name="_numberOfGeneratorNode"></param>
        /// <param name="_activePowerOfGenerator"></param>
        public ParametersForChangingRegime(DateTime _timeInterval,  string _generatorNames, 
           int _numberOfGeneratorNode, double _activePowerOfGenerator)
        {
            TimeInterval = _timeInterval;
            GeneratorNames = _generatorNames;
            NumberOfGeneratorNode= _numberOfGeneratorNode;
            ActivePowerOfGenerator= _activePowerOfGenerator;
        }
    }
}
