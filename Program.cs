using ASTRALib;
using ModelODU;
using ModelODU.VoltageRegulation;

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
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Управляемый реактор");
                Console.WriteLine("2 - Шунтирующий реактор");
                Console.WriteLine("3 - Генератор");
                Console.WriteLine("4 - Выход из программы");
                var consoleKey = Console.ReadLine();
                switch (consoleKey)
                {
                    case "1":
                        {
                            List<double> listNew = new List<double>();
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

                            break;
                        }
                    case "2":
                        {
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

                            break;
                        }
                    case "3":
                        {
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

                            break;
                        }
                    case "4":
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
