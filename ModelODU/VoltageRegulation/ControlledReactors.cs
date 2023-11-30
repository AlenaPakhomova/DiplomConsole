using ASTRALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelODU;


namespace ModelODU.VoltageRegulation
{
    /// <summary>
    /// Класс для управляемых СРН
    /// </summary>
    public class ControlledReactors : VoltageRegulationBase
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
        public override string VoltageRegulationType => "Регулируемые СРН";

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
        /// Реактивная мощности после изменений
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
        /// Расчёт эффективности для упраляемых СРН
        /// </summary>
        /// <returns></returns>
        public override double Effect()
        {
            return Math.Round( (ReactivePowerSecond - ReactivePowerFirst) /(VoltageSecond - VoltageFirst), 2);
        }
    }
}
