using ASTRALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelODU
{
    /// <summary>
    /// Класс для обращения к средствам регулирования напряжения
    /// </summary>
    public abstract class VoltageRegulationBase
    {
        /// <summary>
        /// Переменная для напряжения до изменений 
        /// </summary>
        private double _voltageFirst;

        /// <summary>
        /// Значений напряжения после изменений 
        /// </summary>
        private double _voltageSecond;

        /// <summary>
        /// Тип средства регулирования напряжения
        /// </summary>
        public abstract string VoltageRegulationType { get; }

        /// <summary>
        /// Напряжение до изменений
        /// </summary>
        public double VoltageFirst
        {
            get
            {
                return _voltageFirst;   
            }
            set 
            {
                _voltageFirst = CheckingNumber(value);
            
            }
        }

        /// <summary>
        /// Напряжение после изменений 
        /// </summary>
        public double VoltageSecond 
        {
            get
            {
                return _voltageSecond;
            }
            set
            {
                _voltageSecond = CheckingNumber(value);
            }
        }

        public VoltageRegulationBase()
        {

        }

        /// <summary>
        /// Проверка на отрицательные числа
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static double CheckingNumber(double number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Величина должна " +
                    "быть положительным числом!");
            }
            else
            {
                return number;
            }
        }

        /// <summary>
        /// Расчёт эффективности СРН
        /// </summary>
        /// <returns></returns>
        public abstract double Effect();


    }
}
