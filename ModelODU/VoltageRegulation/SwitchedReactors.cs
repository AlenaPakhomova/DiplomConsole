using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelODU.VoltageRegulation
{
    /// <summary>
    /// Класс для коммутируемых СРН
    /// </summary>
    public class SwitchedReactors : VoltageRegulationBase
    {
        /// <summary>
        /// Переменная длс состояния реактора до изменений 
        /// </summary>
        private double _conditionReactorFirst;

        /// <summary>
        /// Переменная длс состояния реактора после изменений 
        /// </summary>
        private double _conditionReactorSecond;

        /// <summary>
        /// Тип СРН
        /// </summary>
        public override string VoltageRegulationType => "Коммутируемые СРН";

        /// <summary>
        /// Состояние реактора до изменений 
        /// </summary>
        public double ConditionReactorFirst
        {
            get
            {
                return _conditionReactorFirst;
            }
            set
            {
                _conditionReactorFirst = value;
            }
        }

        /// <summary>
        /// Сосотояние реактора после изменений 
        /// </summary>
        public double ConditionReactorSecond    
        {
            get
            {
                return _conditionReactorSecond;
            }
            set
            {
                _conditionReactorSecond = value;
            }
        }

        /// <summary>
        /// Расчёт эффективности для коммутируемых СРН
        /// </summary>
        /// <returns></returns>
        public override double Effect()
        {
            return Math.Round((VoltageSecond - VoltageFirst), 3);
        }


    }
}
