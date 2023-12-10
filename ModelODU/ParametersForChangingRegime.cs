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
        /// Переменная для имени генератора 
        /// </summary>
        private string _generatorNames;

        /// <summary>
        /// Переменная для номер узла генератора в Rastr
        /// </summary>
        private int _numberOfGeneratorNode;

        /// <summary>
        /// Переменная для параметров генератора
        /// </summary>
        private List<GeneratorParameters> _parametersOfGenerator;


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
        /// Параметры генератора
        /// </summary>
        public List<GeneratorParameters> ParametersOfGenerator
        {
            get
            {

                return _parametersOfGenerator;
            }
            set
            {
                _parametersOfGenerator = value;
            }
        }

        /// <summary>
        /// Конструктор для параметров, которые изменяют режим
        /// </summary>
        /// <param name="_generatorNames"></param>
        /// <param name="_numberOfGeneratorNode"></param>
        /// <param name="_parametersOfGenerator"></param>
        public ParametersForChangingRegime( string _generatorNames, 
           int _numberOfGeneratorNode, List<GeneratorParameters> _parametersOfGenerator)
        {           
            GeneratorNames = _generatorNames;
            NumberOfGeneratorNode = _numberOfGeneratorNode;
            ParametersOfGenerator = _parametersOfGenerator;
        }
    }
}
