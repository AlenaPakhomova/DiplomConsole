using ASTRALib;
using ModelODU;
using ModelODU.VoltageRegulation;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace DiplomVConsoleSmallScheme
{
    /// <summary>
    ///  Класс для тестирования библиотеки классов Model
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Параметры</param>
        public static void Main(string[] args)
        {

            Console.WriteLine("Добро пожаловать в программу " +
                "вычисления эффективности СРН!\n" +
                "Нажмите любую кнопку, чтобы начать...");
            Console.ReadKey();


            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Выберите Контрольный пункт:");
                Console.WriteLine("1 - ПС 500 кВ Ново-Анжерская");
                Console.WriteLine("2 - Беловская ГРЭС");
                Console.WriteLine("3 - ПС 500 кВ Юрга");
                Console.WriteLine("4 - ПС 500 кВ Барнаульская");
                Console.WriteLine("5 - ПС 500 кВ Новокузнецкая");
                Console.WriteLine("6 - Выход из программы");
                var consoleKey = Console.ReadLine();
                switch (consoleKey)
                {
                    case "1":
                        {
                            Console.WriteLine("В качестве контрольного пункта вы выбрали " +
                                "ПС 500 кВ Ново-Анжерская.Нажмте любую кнопку, чтобы перейти " +
                                "к выбору Средства регулирования напряжения для расчёта " +
                                "эффективности");
                            Console.ReadKey();
                            Console.WriteLine("Выберите СРН");
                            Console.WriteLine($"1 - УШР-500 ПС 500 кВ Томская");
                            Console.WriteLine("2 - СТК-1 ПС 500 кВ Заря");
                            Console.WriteLine("3 - ШР-500 ПС 500 кВ Томская");
                            Console.WriteLine("4 - Р-532 ПС 500 кВ Заря");
                            Console.WriteLine("5 - Хочу выбрать другой контрольный пункт");
                            var consoleKey1 = Console.ReadLine();
                            switch (consoleKey1)
                            {
                                case "1":
                                    {
                                        Console.WriteLine("УШР-500 ПС 500 кВ Томская");
         
                                        ControlledReactors controlledReactors = new ControlledReactors();
                                        RastrСalculation rastr = new RastrСalculation();
                                       
                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        controlledReactors.ReactivePowerFirst = rastr.GetReactivePowerFirst()[0];
                                        controlledReactors.VoltageFirst = rastr.GetVoltageYFirst()[0];

                                        Console.WriteLine(controlledReactors.VoltageFirst);
                                        Console.WriteLine(controlledReactors.ReactivePowerFirst);

                                        rastr.SetValueQ();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        controlledReactors.ReactivePowerSecond = rastr.GetPowerReacSecond()[0];
                                        controlledReactors.VoltageSecond = rastr.GetVoltageYSecond()[0];

                                        double a = controlledReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));

                                        break;
                                    }
                                case "2":
                                    {
                                        Console.WriteLine("СТК-1 ПС 500 кВ Заря");

                                        ControlledReactors controlledReactors = new ControlledReactors();
                                        RastrСalculation rastr = new RastrСalculation();

                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        controlledReactors.ReactivePowerFirst = rastr.GetReactivePowerFirst()[2];
                                        Console.WriteLine(controlledReactors.ReactivePowerFirst);
                                        controlledReactors.VoltageFirst = rastr.GetVoltageYFirst()[1];

                                        rastr.SetValueQ();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        controlledReactors.ReactivePowerSecond = rastr.GetPowerReacSecond()[2];
                                        Console.WriteLine(controlledReactors.ReactivePowerSecond);
                                        controlledReactors.VoltageSecond = rastr.GetVoltageYSecond()[1];

                                        double a = controlledReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));

                                        break;
                                    }
                                case "3":
                                    {
                                        Console.WriteLine("Беловская ГРЭС");
                                        break;
                                    }
                                case "4":
                                    {                                       
                                        break;
                                    }

                            }    


                           //Складываем значения эффективности 
                           List<double> listNew = new List<double>();

                            /*
                            ControlledReactors controlledReactors = new ControlledReactors();
                            RastrСalculation rastr = new RastrСalculation();
                            List<int> listCount = new List<int>() {0, 1, 2 };
                            foreach (var item in listCount)
                            {
                                rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                rastr.Regime();
                                rastr.SetFix();
                                rastr.Regime();
                                Console.WriteLine("Параметры до изменения");
                                controlledReactors.ReactivePowerFirst = rastr.GetReactivePowerFirst()[item];
                                controlledReactors.VoltageFirst = rastr.GetVoltageYFirst()[item];
                                rastr.SetValueQ();
                                rastr.Regime();
                                Console.WriteLine("Параметры после изменения");
                                controlledReactors.ReactivePowerSecond = rastr.GetPowerReacSecond()[item];
                                controlledReactors.VoltageSecond = rastr.GetVoltageYSecond()[item];
                                listNew.Add(controlledReactors.Effect());
                            }
                            
                            foreach (var item in listNew)
                            {
                                Console.WriteLine($"Значение эффективности: {Math.Abs(item)}");
                            }
                            */
                            break;
                        }
                    case "2":
                        {
                            /*
                            List<double> listNew = new List<double>();
                            SwitchedReactors switchedReactors = new SwitchedReactors();
                            RastrСalculation rastr = new RastrСalculation();
                            List<int> listCount = new List<int>() { 0, 1, 2 };
                            foreach (var item in listCount)
                            {
                                rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                rastr.Regime();
                                rastr.SetFix();
                                rastr.Regime();
                                Console.WriteLine("Параметры до изменения");
                                switchedReactors.ConditionReactorFirst = rastr.GetReacConditionFirst()[item];
                                switchedReactors.VoltageFirst = rastr.GetVoltageYFirst()[item];
                                rastr.SetReacCondition();
                                rastr.Regime();
                                Console.WriteLine("Параметры после изменения");
                                switchedReactors.ConditionReactorSecond = rastr.GetReacConditionSecond()[item];
                                switchedReactors.VoltageSecond = rastr.GetVoltageYSecond()[item];
                                listNew.Add(switchedReactors.Effect());
                            }

                            foreach (var item in listNew)
                            {
                                Console.WriteLine($"Значение эффективности: {Math.Abs(item)}");
                            }
                            */
                            break;
                        }
                    case "3":
                        {
                            /*
                            List<double> listNew = new List<double>();
                            Generators generators = new Generators();
                            RastrСalculation rastr = new RastrСalculation();
                            List<int> listCount = new List<int>() { 0, 1, 2 };
                            foreach (var item in listCount)
                            {
                                rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                rastr.Regime();
                                rastr.SetFix();
                                rastr.Regime();
                                Console.WriteLine("Параметры до изменения");
                                generators.ReactivePowerFirst = rastr.GetReactiveGenFirst()[item];
                                generators.VoltageFirst = rastr.GetVoltageYFirst()[item];
                                rastr.SetActivePower();
                                rastr.Regime();
                                Console.WriteLine("Параметры после изменения");
                                generators.ReactivePowerSecond = rastr.GetReactiveGenSecond()[item];
                                generators.VoltageSecond = rastr.GetVoltageYSecond()[item];
                                listNew.Add(generators.Effect());
                            }

                            foreach (var item in listNew)
                            {
                                Console.WriteLine($"Значение эффективности: {Math.Abs(item)}");
                            }
                            */
                            break;
                        }
                    case "4":
                        {

                            Console.WriteLine($"Значение эффективности:");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine($"Значение эффективности:");
                            break;
                        }
                    case "6":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Попробуйте ещё раз.");
                            break;
                        }
                }
            }
        }
        
       

        /*
        /// <summary>
        /// Получение информации об эффективности управляемого реактора
        /// </summary>
        public static void GetInfoControlledReactors()
        {
            var calcControlledReactors = new ControlledReactors();
            calcControlledReactors.RunControlReac();

        }*/

        /*
        /// <summary>
        /// Получение информации об эффективности шунтирующего реактора
        /// </summary>
        public static void GetInfoSwitchedReactors()
        {
            var calcSwitchedReactors = new SwitchedReactors();
            Console.WriteLine($"{calcSwitchedReactors.RunSwitchedReac()} кВ.");
        }

        /// <summary>
        /// Получение информации об эффективности генератора
        /// </summary>
        public static void GetInfoGenerator()
        {
            var calcGenerator = new Generators();
            Console.WriteLine($"{calcGenerator.RunGenerator()} Мвт/кВ.");
        }
        */
    }
}
