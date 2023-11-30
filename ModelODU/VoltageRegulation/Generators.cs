using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelODU.VoltageRegulation
{
    /// <summary>
    /// Класс для генераторов
    /// </summary>
    public class Generators : VoltageRegulationBase
    {
        /// <summary>
        /// Переменная для реактивной мощности до изменений 
        /// </summary>
        private double _reactivePowerFirst;

        /// <summary>
        /// Переменная для реактивной мощности после изменений 
        /// </summary>
        private double _reactivePowerSecond;

        /// <summary>
        /// Тип СРН
        /// </summary>
        public override string VoltageRegulationType => "Генераторы";

        /// <summary>
        /// Реактивная мощность до изменений 
        /// </summary>
        public double ReactivePowerFirst
        {
            get
            {
                return _reactivePowerFirst;
            }
            set
            {
                _reactivePowerFirst = value;
            }        
        }

        /// <summary>
        /// Реактивная мощность после изменений 
        /// </summary>
        public double ReactivePowerSecond
        {
            get
            {
                return _reactivePowerSecond;
            }
            set
            {
                _reactivePowerSecond = value;
            }
        }

        /// <summary>
        /// Расчёт эффективности для генераторов
        /// </summary>
        /// <returns></returns>
        public override double Effect()
        {
            return Math.Round((ReactivePowerSecond - ReactivePowerFirst) / (VoltageSecond - VoltageFirst), 2);
        }

    }
}
