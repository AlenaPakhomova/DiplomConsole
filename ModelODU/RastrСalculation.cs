using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ASTRALib;
using ModelODU.VoltageRegulation;

namespace ModelODU
{
    /// <summary>
    /// Класс для обращения к RastrWin3
    /// </summary>
    public class RastrСalculation
    {
        /*
        public void Chart_Click()
        {
            List<int> number = new List<int> { 1, 2, 3, 2, 4, 1, 5, 4, 3 };

            Dictionary<int, int> Number = new Dictionary<int, int>();

            // Подсчитаем количество повторяющихся чисел в листе
            foreach (int item in number)
            {
                if (Number.ContainsKey(item))
                {
                    Number[item]++;
                }
                else
                {
                    Number[item] = 1;
                }

            }

            // Создаем двумерный массив
            int[,] array = new int[Number.Count, 2];
            int a = 0;
            foreach (KeyValuePair<int, int> par in Number)
            {
                // Уникальное значение
                array[a, 0] = par.Key;

                // Считать
                array[a, 1] = par.Value;

                a++;
            }

            // Распечатываем массив
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        */
        /*
        public void Chart()
        {
            List<double> number = new List<double> { 1.333, 2.5, 1.333, 3.75, 2.5, 1.333, 4.25, 4.25 };

            var duplicateNumbers = number.GroupBy(x => x).Where(g => g.Count() > 1).
                Select(g => new { Number = g.Key, Count = g.Count() }).ToList();

            // Создаем двумерный массив
            object[,] array = new object[duplicateNumbers.Count, 2];
            double[] arrayN = new double[duplicateNumbers.Count];
            int[] arrayC = new int[duplicateNumbers.Count];
            int a = 0;
            // Распечатываем массив
            for (int i = 0; i < duplicateNumbers.Count; i++)
            {
                arrayN[i] = duplicateNumbers[i].Number;
                arrayC[i] = duplicateNumbers[i].Count;               
            }

            /*
            Console.WriteLine($"Повторяющиеся числа:");
            for (int i = 0; i < duplicateNumbers.Count; i++)
            {
                Console.WriteLine($"Число: {array[i, 0]}, Count: {array[i, 1]}");
            }

            foreach (var item in arrayN)
            {
                Console.WriteLine($"Число: {item}");
            }

            foreach (var item1 in arrayC)
            {
                Console.WriteLine($"Count: {item1}");
            }


            /*
            // Создаем двумерный массив
            object[,] array = new object[duplicateNumbers.Count, 2];
            int a = 0;
            // Распечатываем массив
            for (int i = 0; i < duplicateNumbers.Count; i++)
            {
                array[i, 0] = duplicateNumbers[i].Number;
                array[i, 1] = duplicateNumbers[i].Count;
            }

            
            Console.WriteLine($"Повторяющиеся числа:");
            for (int i = 0; i < duplicateNumbers.Count; i++)
            {
                Console.WriteLine($"Число: {array[i, 0]}, Count: {array[i, 1]}");
            }
            */
        


        /// <summary>
        /// Загрузка файла режима RastrWin3 для расчётов
        /// </summary>
        public string pathFile = "C:\\Users\\Алена\\Desktop\\Диплом\\РМ для растра новая" +
            "\\РМ Rastra\\Зима2020\\18-00.rg2";

        /// <summary>
        /// Шаблон для RastrWin3
        /// </summary>
        public string pathShablon = "C:\\Program Files\\RastrWin3\\RastrWin3\\SHABLON\\режим.rg2";

        /// <summary>
        /// Создание указателя на экземпляр RastrWin и его запуск
        /// </summary>
        public static IRastr _rastr = new Rastr();


        /// <summary>
        /// Загрузка файла с данными 
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="pathShablon"></param>
        public void LoadFile(string pathFile, string pathShablon)
        {
            _rastr.Load(RG_KOD.RG_REPL, pathFile, pathShablon);
        }
        
        
        private static string dirName = "C:\\Users\\Алена\\Desktop\\Режимы для расчёта эффективности";      

        /*
        public List<double> CreateListRg(string consoleKey)      
        {
            List<double> listNewEff = new List<double>();
            List<string> listOfRg2 = new List<string>();
            if (Directory.Exists(dirName))
            {
                //возвращает имена файлов, соответсвующим указанным критериям
                string[] filesRg = Directory.GetFiles(dirName);
                foreach (string pathRegime in filesRg)
                {
                    listOfRg2.Add(pathRegime);                  
                }
            }

            foreach (var item in listOfRg2)
            {
                ControlledReactors controlledReactors = new ControlledReactors();
                _rastr.Load(RG_KOD.RG_REPL, item, pathShablon);
                switch (consoleKey)
                {
                    case "1":
                        Regime();
                        SetFix();
                        Console.WriteLine("Параметры до изменения");

                        controlledReactors.ReactivePowerFirst = GetReactivePowerFirst()[0];
                        controlledReactors.VoltageFirst = GetVoltageYFirst()[0];
                        SetValueQ();
                        Regime();
                        Console.WriteLine("Параметры после изменения");
                        controlledReactors.ReactivePowerSecond = GetPowerReacSecond()[0];
                        controlledReactors.VoltageSecond = GetVoltageYSecond()[0];

                        double a = controlledReactors.Effect();

                        listNewEff.Add(Math.Abs(a));

                        Console.WriteLine($"\nЗначение эффективности для текущего режима: {a}\n");
                        break;                    
                };
            }
            return listNewEff;
        }
        */


        private static string dirName1 = "C:\\Users\\Алена\\Desktop\\Режимы на диплом СМЗУ";

        /// Подбор срезов ТМ по характерному дню
        /// и количеству срезов
        /// </summary>
        /// <param name="TypicalDay"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public void CreateSet(string consoleKey1, string consoleKey2, string consoleKey3)
        {
            List<string> listOfSlices = new List<string>();
            DateTime time1;
            DateTime time2;
            Console.WriteLine("Введите начало интервала: ");
            Regex regex = new Regex(@"\d+[_]\d+");
            while (true)
            {

                string timeConsole1 = Console.ReadLine();

                while (!regex.IsMatch(timeConsole1))
                {
                    Console.WriteLine("Не удалось распознать время" +
                                       " отправления, введите снова!");
                }
                try
                {
                    // (год, месяц, день, час, минута, секунда)
                    time1 = new DateTime(int.Parse(Regex.Split(timeConsole1, "_")[0]),
                                        int.Parse(Regex.Split(timeConsole1, "_")[1]),
                                        int.Parse(Regex.Split(timeConsole1, "_")[2]));
                    break;
                }

                // Ловит, если аргумент функции имеет слишком большое или
                // слишком маленькое значение для данного типа
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Ошибка! Введите корректное время.");
                }
            }

            Console.WriteLine("Введите конец интервала: ");
            while (true)
            {
                string timeConsole2 = Console.ReadLine();
                while (!regex.IsMatch(timeConsole2))
                {
                    Console.WriteLine("Не удалось распознать время" +
                                       " отправления, введите снова!");
                }
                try
                {
                    // (год, месяц, день, час, минута, секунда)
                    time2 = new DateTime(int.Parse(Regex.Split(timeConsole2, "_")[0]),
                                        int.Parse(Regex.Split(timeConsole2, "_")[1]),
                                        int.Parse(Regex.Split(timeConsole2, "_")[2]));
                    break;
                }

                // Ловит, если аргумент функции имеет слишком большое или
                // слишком маленькое значение для данного типа
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Ошибка! Введите корректное время.");
                }

            }

            List<DateTime> dates = Enumerable.Range(0, ((time2 - time1).Days) + 1)
                .Select(n => time1.AddDays(n)).ToList();

            Console.WriteLine("Ввод количества срезов ");
            int count = Convert.ToInt32(Console.ReadLine());

            List<double> listNewEff = new List<double>();

            foreach (var data in dates)
            {
                Console.WriteLine(data.ToShortDateString());

                //содержание файла в директории
                if (Directory.Exists(dirName1))
                {
                    // имена подкаталогов в директории
                    string[] directoryes = Directory.GetDirectories(dirName1);

                    foreach (string directory in directoryes)
                    {
                        Regex regex1 = new Regex(@"\d{4}_\d{2}_\d{2}");
                        //вхождения регулярного выражения
                        MatchCollection days = regex1.Matches(directory);
                        if (days.Count > 0)
                        {
                            string dayMatch = days[0].ToString();

                            dayMatch = dayMatch.Replace("_", "-");

                            //преобразует в эквивалент времени 
                            DateTime day = DateTime.ParseExact(dayMatch, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                            //Console.WriteLine("\nДень:" + day.ToString("dd.MM.yyyy"));                     


                            //Совпадение характерного дня и дня в архиве СМЗУ
                            if (DateTime.Compare(data.Date, day.Date) == 0)
                            {
                                //Console.WriteLine(TypicalDay.Date.ToString("dd.MM.yyyy") + " = " + day.Date.ToString("dd.MM.yyyy"));

                                string[] slices = Directory.GetDirectories(directory);
                                // возвращает элементы из последовательности
                                foreach (string slice in slices.Take(count))
                                {
                                    //возвращает имена файлов, соответсвующим указанным критериям
                                    string[] files = Directory.GetFiles(slice);

                                    foreach (string pathRegime in files)
                                    {
                                        // возвращает имя файла в указанной строки пути без расширения
                                        string fileName = Path.GetFileNameWithoutExtension(pathRegime);
                                        if (fileName == "roc_debug_after_OC")
                                        {
                                            Regex regex2 = new Regex(@"\d{2}_\d{2}_\d{2}");
                                            MatchCollection docs = regex2.Matches(pathRegime);

                                            //Console.WriteLine("Срез:" + docs[1]);
                                            listOfSlices.Add(pathRegime);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // return listOfSlices;

                //List<double> listNewEff = new List<double>();
                foreach (var item in listOfSlices)
                {
                    ControlledReactors controlledReactors = new ControlledReactors();
                    SwitchedReactors switchedReactors = new SwitchedReactors();
                    Generators generators = new Generators();
                    _rastr.Load(RG_KOD.RG_REPL, item, pathShablon);

                    switch (consoleKey1)
                    {
                        case "1":
                            Regime();
                            Fixation();
                            Regime();
                            Console.WriteLine("Параметры до изменения");

                            double Vc = Convert.ToDouble(GetV(consoleKey2));
                            controlledReactors.ReactivePowerFirst = GetQ(consoleKey2);
                            controlledReactors.VoltageFirst = GetV(consoleKey3);
                            SetV(consoleKey2, Vc);
                            Regime();
                            Console.WriteLine("Параметры после изменения");
                            controlledReactors.ReactivePowerSecond = GetQ(consoleKey2);
                            controlledReactors.VoltageSecond = GetV(consoleKey3);
                            double EffCR = controlledReactors.Effect();
                            listNewEff.Add(Math.Abs(EffCR));
                            Console.WriteLine($"\nЗначение эффективности для текущего режима: {Math.Abs(EffCR)}\n");
                            break;

                        case "2":
                            Regime();
                            Fixation();
                            Regime();
                            Console.WriteLine("Параметры до изменения");
                            double Usr = Convert.ToDouble(GetV(consoleKey2));
                            switchedReactors.ConditionReactorFirst = GetConditionR(consoleKey2);
                            int condition = Convert.ToInt32(GetConditionR(consoleKey2));
                            switchedReactors.VoltageFirst = GetV(consoleKey3);
                            SetConditionR(consoleKey2, condition);
                            Regime();
                            Console.WriteLine("Параметры после изменения");
                            switchedReactors.ConditionReactorSecond = GetConditionR(consoleKey2);
                            switchedReactors.VoltageSecond = GetV(consoleKey3);
                            double EffSR = switchedReactors.Effect();
                            listNewEff.Add(Math.Abs(EffSR));
                            Console.WriteLine($"\nЗначение эффективности для текущего режима: {Math.Abs(EffSR)}\n");
                            break;

                        case "3":
                            Regime();
                            Fixation();
                            Regime();
                            Console.WriteLine("Параметры до изменения");

                            double Ug = Convert.ToDouble(GetV(consoleKey2));
                            generators.ReactivePowerFirst = GetQGen(consoleKey2);
                            generators.VoltageFirst = GetV(consoleKey3);
                            SetV(consoleKey2, Ug);

                            Regime();
                            Console.WriteLine("Параметры после изменения");
                            generators.ReactivePowerSecond = GetQGen(consoleKey2);
                            generators.VoltageSecond = GetV(consoleKey3);

                            double EffG = generators.Effect();
                            listNewEff.Add(Math.Abs(EffG));
                            Console.WriteLine($"\nЗначение эффективности для текущего режима: {Math.Abs(EffG)}\n");
                            break;
                    };
                }              
            }
            //return listNewEff;

            var duplicateNumbers = listNewEff.GroupBy(x => x).Where(g => g.Count() > 1).
                 Select(g => new { Number = g.Key, Count = g.Count() }).ToList();

            // Создаем двумерный массив
            object[,] array = new object[duplicateNumbers.Count, 2];
            double[] arrayN = new double[duplicateNumbers.Count];
            int[] arrayC = new int[duplicateNumbers.Count];
            int a = 0;
            // Распечатываем массив
            for (int i = 0; i < duplicateNumbers.Count; i++)
            {
                arrayN[i] = duplicateNumbers[i].Number;
                arrayC[i] = duplicateNumbers[i].Count;
            }

            foreach (var item in arrayN)
            {
                Console.WriteLine(item);
            }

            foreach (var item1 in arrayC)
            {
                Console.WriteLine(item1);
            }

        }




           /*

            //содержание файла в директории
            if (Directory.Exists(dirName1))
            {
                // имена подкаталогов в директории
                string[] directoryes = Directory.GetDirectories(dirName1);

                foreach (string directory in directoryes)
                {
                    Regex regex1 = new Regex(@"\d{4}_\d{2}_\d{2}");
                    //вхождения регулярного выражения
                    MatchCollection days = regex1.Matches(directory);
                    if (days.Count > 0)
                    {
                        string dayMatch = days[0].ToString();

                        dayMatch = dayMatch.Replace("_", "-");

                        //преобразует в эквивалент времени 
                        DateTime day = DateTime.ParseExact(dayMatch, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                        //Console.WriteLine("\nДень:" + day.ToString("dd.MM.yyyy"));                     
                        
                        
                        //Совпадение характерного дня и дня в архиве СМЗУ
                        if (DateTime.Compare(time1.Date, day.Date) == 0)
                        {
                            //Console.WriteLine(TypicalDay.Date.ToString("dd.MM.yyyy") + " = " + day.Date.ToString("dd.MM.yyyy"));

                            string[] slices = Directory.GetDirectories(directory);
                            // возвращает элементы из последовательности
                            foreach (string slice in slices.Take(count))
                            {
                                //возвращает имена файлов, соответсвующим указанным критериям
                                string[] files = Directory.GetFiles(slice);

                                foreach (string pathRegime in files)
                                {
                                    // возвращает имя файла в указанной строки пути без расширения
                                    string fileName = Path.GetFileNameWithoutExtension(pathRegime);
                                    if (fileName == "roc_debug_after_OC")
                                    {
                                        Regex regex2 = new Regex(@"\d{2}_\d{2}_\d{2}");
                                        MatchCollection docs = regex2.Matches(pathRegime);

                                        //Console.WriteLine("Срез:" + docs[1]);
                                        listOfSlices.Add(pathRegime);
                                    }
                                }
                            }
                        }
                    }
                }
            }
           // return listOfSlices;

            List<double> listNewEff = new List<double>();
            foreach (var item in listOfSlices)
            {
                ControlledReactors controlledReactors = new ControlledReactors();
                SwitchedReactors switchedReactors = new SwitchedReactors();
                Generators generators = new Generators();
                _rastr.Load(RG_KOD.RG_REPL, item, pathShablon);
                
                switch (consoleKey1)
                {
                    case "1":
                        Regime();
                        Fixation();
                        Regime();
                        Console.WriteLine("Параметры до изменения");

                        double Vc = Convert.ToDouble(GetV(consoleKey2));
                        controlledReactors.ReactivePowerFirst = GetQ(consoleKey2);
                        controlledReactors.VoltageFirst = GetV(consoleKey3);
                        SetV(consoleKey2, Vc);
                        Regime();
                        Console.WriteLine("Параметры после изменения");
                        controlledReactors.ReactivePowerSecond = GetQ(consoleKey2);
                        controlledReactors.VoltageSecond = GetV(consoleKey3);
                        double EffCR = controlledReactors.Effect();
                        listNewEff.Add(Math.Abs(EffCR));
                        Console.WriteLine($"\nЗначение эффективности для текущего режима: {Math.Abs(EffCR)}\n");                      
                        break;

                    case "2":
                        Regime();
                        Fixation();
                        Regime();
                        Console.WriteLine("Параметры до изменения");
                        double Usr = Convert.ToDouble(GetV(consoleKey2));
                        switchedReactors.ConditionReactorFirst = GetConditionR(consoleKey2);
                        int condition = Convert.ToInt32(GetConditionR(consoleKey2));
                        switchedReactors.VoltageFirst = GetV(consoleKey3);
                        SetConditionR(consoleKey2, condition);
                        Regime();
                        Console.WriteLine("Параметры после изменения");
                        switchedReactors.ConditionReactorSecond = GetConditionR(consoleKey2);
                        switchedReactors.VoltageSecond = GetV(consoleKey3);
                        double EffSR = switchedReactors.Effect();
                        listNewEff.Add(Math.Abs(EffSR));
                        Console.WriteLine($"\nЗначение эффективности для текущего режима: {Math.Abs(EffSR)}\n");
                        break;

                    case "3":
                        Regime();
                        Fixation();
                        Regime();
                        Console.WriteLine("Параметры до изменения");

                        double Ug = Convert.ToDouble(GetV(consoleKey2));
                        generators.ReactivePowerFirst = GetQGen(consoleKey2);
                        generators.VoltageFirst = GetV(consoleKey3);
                        SetV(consoleKey2, Ug);

                        Regime();
                        Console.WriteLine("Параметры после изменения");
                        generators.ReactivePowerSecond = GetQGen(consoleKey2);
                        generators.VoltageSecond = GetV(consoleKey3);

                        double EffG = generators.Effect();
                        listNewEff.Add(Math.Abs(EffG));
                        Console.WriteLine($"\nЗначение эффективности для текущего режима: {Math.Abs(EffG)}\n");
                        break;
                };
            }
            return listNewEff;
        }
           */

        public double GetQGen(string consoleKey)
        {
            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol activePowerGen = (ICol)Node.Cols.Item("pg");
            ICol powerReacGen = (ICol)Node.Cols.Item("qg");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            Node.SetSel($"ny = {consoleKey}");
            int n = Node.FindNextSel[-1];
            Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
            Console.WriteLine($"Значение активной мощности: {activePowerGen.Z[n]}. Имя УШР: {name.Z[n]}");
            double a = Convert.ToDouble(powerReacGen.Z[n]);

            return a;
        }

        public int GetConditionR(string consoleKey)
        {
            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol conditionReactor = (ICol)Node.Cols.Item("sta");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            Node.SetSel($"ny = {consoleKey}");
            int n = Node.FindNextSel[-1];
            Console.WriteLine($"Статус работы: {conditionReactor.Z[n]}. Имя КП: {name.Z[n]}");
            int a = Convert.ToInt32(conditionReactor.Z[n]);
            return a;
        }
        
        public void SetConditionR(string consoleKey, int condition)
        {
            ITable Node = (ITable)_rastr.Tables.Item("node");
            ITable Vetv = (ITable)_rastr.Tables.Item("vetv");
            ICol conditionReactorY = (ICol)Node.Cols.Item("sta");
            ICol conditionReactorV = (ICol)Vetv.Cols.Item("sta");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol NumberNfirst = (ICol)Vetv.Cols.Item("ip");
            ICol NumberNsecond = (ICol)Vetv.Cols.Item("iq");
            ICol nameY = (ICol)Node.Cols.Item("name");
            ICol nameV = (ICol)Vetv.Cols.Item("name");

            if (condition == 1)
            {
                int reacConditionY = 0;
                int reacConditionV = 0;
                Node.SetSel($"ny = {consoleKey}");
                int ny = Node.FindNextSel[-1];
                Console.WriteLine($"Статус работы: {conditionReactorY.Z[ny]}. Имя КП: {nameY.Z[ny]}");
                conditionReactorY.set_ZN(ny, reacConditionY);
                Console.WriteLine($"Статус работы: {conditionReactorY.Z[ny]}. Имя КП: {nameY.Z[ny]}");

                Vetv.SetSel($"ip = {consoleKey}");
                int nvp = Vetv.FindNextSel[-1];
                Console.WriteLine($"Статус работы начала ветви: {conditionReactorV.Z[nvp]}. Имя КП: {nameV.Z[nvp]}");
                conditionReactorV.set_ZN(nvp, reacConditionV);
                Console.WriteLine($"Статус работы начала ветви: {conditionReactorV.Z[nvp]}. Имя КП: {nameV.Z[nvp]}");


                Vetv.SetSel($"iq = {consoleKey}");
                int nvq = Vetv.FindNextSel[-1];              
                Console.WriteLine($"Статус работы конца ветви: {conditionReactorV.Z[nvq]}. Имя КП: {nameV.Z[nvq]}");              
                conditionReactorV.set_ZN(nvq, reacConditionV);
                Console.WriteLine($"Статус работы конца ветви: {conditionReactorV.Z[nvq]}. Имя КП: {nameV.Z[nvq]}");
                
            }
            else
            {
                int reacConditionY = 1;
                int reacConditionV = 1;
                Node.SetSel($"ny = {consoleKey}");
                int ny = Node.FindNextSel[-1];
                Console.WriteLine($"Статус работы: {conditionReactorY.Z[ny]}. Имя КП: {nameY.Z[ny]}");
                conditionReactorY.set_ZN(ny, reacConditionY);
                Console.WriteLine($"Статус работы: {conditionReactorY.Z[ny]}. Имя КП: {nameY.Z[ny]}");


                Vetv.SetSel($"ny = {consoleKey}");
                int nvp = Vetv.FindNextSel[-1];
                Console.WriteLine($"Статус работы начала ветви: {conditionReactorV.Z[nvp]}. Имя КП: {nameV.Z[nvp]}");
                conditionReactorV.set_ZN(nvp, reacConditionV);
                Console.WriteLine($"Статус работы начала ветви: {conditionReactorV.Z[nvp]}. Имя КП: {nameV.Z[nvp]}");


                Vetv.SetSel($"iq = {consoleKey}");
                int nvq = Vetv.FindNextSel[-1];
                Console.WriteLine($"Статус работы конца ветви: {conditionReactorV.Z[nvq]}. Имя КП: {nameV.Z[nvq]}");
                conditionReactorV.set_ZN(nvq, reacConditionV);
                Console.WriteLine($"Статус работы конца ветви: {conditionReactorV.Z[nvq]}. Имя КП: {nameV.Z[nvq]}");
                
            }
        }

        

        public void SetV(string consoleKey, double a)
        {
            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol powerReacGen = (ICol)Node.Cols.Item("qg");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");
            ICol voltageRas = (ICol)Node.Cols.Item("vras");
            ICol voltageZd = (ICol)Node.Cols.Item("vzd");

            Node.SetSel($"ny = {consoleKey}");
            int n = Node.FindNextSel[-1];
            Console.WriteLine($"Значение напряжения: {voltageZd.Z[n]}. Имя КП: {name.Z[n]}");
            voltageZd.set_ZN(n, a);          
           
            Console.WriteLine($"Значение напряжения: {voltageZd.Z[n]}. Имя КП: {name.Z[n]}");
        }

        public double GetQ(string consoleKey)
        {
            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol powerReacGen = (ICol)Node.Cols.Item("qg");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            Node.SetSel($"ny = {consoleKey}");
            int n = Node.FindNextSel[-1];
            Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
            double a = Convert.ToDouble(powerReacGen.get_ZN(n));
            return a;
        }
        

        public double GetV(string consoleKey)
        {          
            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol voltageRas = (ICol)Node.Cols.Item("vras");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            Node.SetSel($"ny = {consoleKey}");
            int n = Node.FindNextSel[-1];
            Console.WriteLine($"Значение напряжения: {voltageRas.Z[n]}. Имя КП: {name.Z[n]}");
            double a = Convert.ToDouble(voltageRas.get_ZN(n));
            return a;
        }

        public void Fixation()
        {
            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");
            ICol tip = (ICol)Node.Cols.Item("tip");
            ICol voltageZd = (ICol)Node.Cols.Item("vzd");
            List<int> ListFix = new List<int>();

            //лист со списком номеров узлов
            for (int i = 0; i < Node.Count; i++)
            {
               // Console.WriteLine(NumberNode.Z[i]);
                ListFix.Add(Convert.ToInt32(NumberNode.Z[i]));                   
            }

            foreach (var item in ListFix)
            {
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                //Console.WriteLine($"Имя КП: {name.Z[n]} тип узла {tip.Z[n]}");

                if (Convert.ToInt32(tip.Z[n]) == 2)
                {
                   // Console.WriteLine($"Имя КП: {name.Z[n]}, напряжение до изменения {voltageZd.Z[n]}");
                    int voltage = 0;
                    voltageZd.set_ZN(n, voltage);
                   // Console.WriteLine($"напряжение после изменения {voltageZd.Z[n]}");
                }
            }          
        }






        /*
        /// <summary>
        /// Фиксация всех средств регулирования напряжения
        /// </summary>
        /// <param name="arr"></param>
        public void SetFix()
        {
            Data data = new Data();
            List<int> ListFix = data.NodesForFixing;
            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol voltageZd = (ICol)Node.Cols.Item("vzd");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");
            foreach (var item in ListFix)
            {
                int voltage = 0;
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                voltageZd.set_ZN(n, voltage);
            }
        }
        */

        /*
          public List<double> SetNewValueGenerator(string consoleKey)
          {

              DateTime time1;
              DateTime time2;
              Console.WriteLine("Введите временной интервал.");
              Console.WriteLine("Начало интервала (ГГ:ММ:ДД): ");
              Regex regex = new Regex(@"\d+[:]\d+");
              while (true)
              {

                  string timeConsole1 = Console.ReadLine();

                  while (!regex.IsMatch(timeConsole1))
                  {
                      Console.WriteLine("Не удалось распознать время" +
                                         " отправления, введите снова!");
                  }
                  try
                  {
                      // (год, месяц, день, час, минута, секунда)
                      time1 = new DateTime(int.Parse(Regex.Split(timeConsole1, ":")[0]),
                                          int.Parse(Regex.Split(timeConsole1, ":")[1]),
                                          int.Parse(Regex.Split(timeConsole1, ":")[2]));
                      break;
                  }

                  // Ловит, если аргумент функции имеет слишком большое или
                  // слишком маленькое значение для данного типа
                  catch (ArgumentOutOfRangeException)
                  {
                      Console.WriteLine("Ошибка! Введите корректное время.");
                  }
              }

              Console.WriteLine("Конец интервала (Г:М:Д): ");
              while (true)
              {
                  string timeConsole2 = Console.ReadLine();
                  while (!regex.IsMatch(timeConsole2))
                  {
                      Console.WriteLine("Не удалось распознать время" +
                                         " отправления, введите снова!");
                  }
                  try
                  {
                      // (год, месяц, день, час, минута, секунда)
                      time2 = new DateTime(int.Parse(Regex.Split(timeConsole2, ":")[0]),
                                          int.Parse(Regex.Split(timeConsole2, ":")[1]),
                                          int.Parse(Regex.Split(timeConsole2, ":")[2]));
                      break;
                  }

                  // Ловит, если аргумент функции имеет слишком большое или
                  // слишком маленькое значение для данного типа
                  catch (ArgumentOutOfRangeException)
                  {
                      Console.WriteLine("Ошибка! Введите корректное время.");
                  }

              }

              List<double> listNewQGen = new List<double>();

              Data data = new Data();
              List<ParametersForChangingRegime> listQGen = data.ParametersForChangingRegimes;
              List<int> listEnQGen = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
              ControlledReactors controlledReactors = new ControlledReactors();
              SwitchedReactors switchedReactors = new SwitchedReactors();

              foreach (var itemEnQGen in listEnQGen)
              {
                  Console.WriteLine($"\nПеречень параметров генераторов для текущего режима.\n");

                  List<ParametersForChangingRegime> subLictQGen = listQGen.Where((QGen) =>  
                  QGen.ParametersOfGenerator[itemEnQGen].TimeInterval >= time1
                  && 

                  QGen.ParametersOfGenerator[itemEnQGen].TimeInterval <= time2).ToList();

                  LoadFile(pathFile, pathShablon);

                  ITable Generator = (ITable)_rastr.Tables.Item("Generator");
                  ICol powerActiveLoad = (ICol)Generator.Cols.Item("P");
                  ICol NumberGen = (ICol)Generator.Cols.Item("Num");
                  ICol nameBus = (ICol)Generator.Cols.Item("Name");

                  foreach (var itemQGen in subLictQGen)
                  {
                      Generator.SetSel($"Num = {itemQGen.ParametersOfGenerator[itemEnQGen].NumberOfGeneratorNode}");
                      int n = Generator.FindNextSel[-1];
                      Console.WriteLine($"Имя Генератора: {nameBus.Z[n]}");
                      powerActiveLoad.set_ZN(n, itemQGen.ParametersOfGenerator[itemEnQGen].ActivePowerOfGenerator);
                      Console.WriteLine($"Значение реактивной мощности: {powerActiveLoad.Z[n]}. Имя УШР: {nameBus.Z[n]}");

                      listNewQGen.Add(Convert.ToDouble(powerActiveLoad.Z[n]));                   
                      //Console.WriteLine("+");
                  }


                  switch(consoleKey)
                  {
                      case "1":

                          Regime();
                          SetFix();
                         // Console.WriteLine("Параметры до изменения");

                          controlledReactors.ReactivePowerFirst = GetReactivePowerFirst()[0];
                          controlledReactors.VoltageFirst = GetVoltageYFirst()[0];
                          SetValueQ();
                          Regime();
                         // Console.WriteLine("Параметры после изменения");
                          controlledReactors.ReactivePowerSecond = GetPowerReacSecond()[0];
                          controlledReactors.VoltageSecond = GetVoltageYSecond()[0];

                          double a = controlledReactors.Effect();

                          //listNewQGen.Add(Math.Abs(a));

                          Console.WriteLine($"\nЗначение эффективности для текущего режима: {a}\n");
                          break;


                      case "2":                                           
                          Regime();
                          Console.WriteLine("Параметры до изменения");
                          controlledReactors.ReactivePowerFirst = GetReactivePowerFirst()[3];
                          Console.WriteLine(controlledReactors.ReactivePowerFirst);
                          controlledReactors.VoltageFirst = GetVoltageYFirst()[0];

                          SetValueQ();
                          Regime();

                          Console.WriteLine("Параметры после изменения");
                          controlledReactors.ReactivePowerSecond = GetPowerReacSecond()[3];
                          Console.WriteLine(controlledReactors.ReactivePowerSecond);
                          controlledReactors.VoltageSecond = GetVoltageYSecond()[0];

                          double b = controlledReactors.Effect();
                          listNewQGen.Add(Math.Abs(b));
                          Console.WriteLine(Math.Abs(b));
                          break;

                      case "3":
                          Regime();
                          Console.WriteLine("Параметры до изменения");
                          switchedReactors.ConditionReactorFirst = GetReacConditionFirst()[0];
                          Console.WriteLine(switchedReactors.ConditionReactorFirst);
                          switchedReactors.VoltageFirst = GetVoltageYFirst()[0];
                          SetReacCondition();
                          Regime();
                          Console.WriteLine("Параметры после изменения");
                          switchedReactors.ConditionReactorSecond = GetReacConditionSecond()[0];
                          switchedReactors.VoltageSecond = GetVoltageYSecond()[0];
                          double c = switchedReactors.Effect();
                          listNewQGen.Add(Math.Abs(c));
                          Console.WriteLine(Math.Abs(c));
                          break;

                      case "4":
                          Regime();
                          //SetFix();
                          Console.WriteLine("Параметры до изменения");
                          switchedReactors.ConditionReactorFirst = GetReacConditionFirst()[3];
                          Console.WriteLine(switchedReactors.ConditionReactorFirst);
                          switchedReactors.VoltageFirst = GetVoltageYFirst()[0];
                          SetReacCondition();
                          Regime();
                          Console.WriteLine("Параметры после изменения");
                          switchedReactors.ConditionReactorSecond = GetReacConditionSecond()[3];
                          switchedReactors.VoltageSecond = GetVoltageYSecond()[0];
                          double d = switchedReactors.Effect();
                          listNewQGen.Add(Math.Abs(d));
                          Console.WriteLine(Math.Abs(d));
                          break;


                  };


              }
              return listNewQGen;         
          }
        */

        /*
        /// <summary>
        /// Получение реактивной мощности реактора до изменений из Rastr
        /// </summary>
        /// <returns></returns>
        public List<double> GetReactivePowerFirst()
        {
            Data data = new Data();
            List<VoltageControlPoints> listQ1 = data.VoltageControlPoints;

            List<double> listNewQ1 = new List<double>();

            List<int> listEnumerationQ1 = new List<int> { 0, 1 };
            foreach (var itemEnQ1 in listEnumerationQ1)
            {
                List<VoltageControlPoints> subListQ1 = listQ1.Where((Q1) =>
                Q1.ParametersOfVoltageRegulationMeans[itemEnQ1].TypeOfVoltageRegulationMeans == "управляемый").ToList();

                ITable Node = (ITable)_rastr.Tables.Item("node");
                ICol powerReacGen = (ICol)Node.Cols.Item("qg");
                ICol NumberNode = (ICol)Node.Cols.Item("ny");
                ICol name = (ICol)Node.Cols.Item("name");

                foreach (var itemQ1 in subListQ1)
                {
                    Node.SetSel($"ny = {itemQ1.ParametersOfVoltageRegulationMeans[itemEnQ1].NumberOfVoltageRegulationMeans}");
                    int n = Node.FindNextSel[-1];
                    // Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
                    listNewQ1.Add(Convert.ToDouble(powerReacGen.Z[n]));
                }
                
            }                                 
            return listNewQ1;        
        }
        

        
        /// <summary>
        ///  Запись значений в ячейку с реактивной мощностью на реакторе в Rastr
        /// </summary>
        public void SetValueQ()
        {
            Data data = new Data();
            List<VoltageControlPoints> listQSet = data.VoltageControlPoints;
          

            List<int> listEnumerationQSet = new List<int> { 0, 1, 2, 3 };

            foreach (var itemEnQSet in listEnumerationQSet)
            {
                List<VoltageControlPoints> subListQSet = listQSet.Where((Q1) =>
                Q1.ParametersOfVoltageRegulationMeans[itemEnQSet].TypeOfVoltageRegulationMeans == "управляемый").ToList();

                ITable Node = (ITable)_rastr.Tables.Item("node");
                ICol powerReacGen = (ICol)Node.Cols.Item("qg");
                ICol NumberNode = (ICol)Node.Cols.Item("ny");
                ICol name = (ICol)Node.Cols.Item("name");

                foreach (var itemQSet in subListQSet)
                {
                    int Q = -80;
                    Node.SetSel($"ny = {itemQSet.ParametersOfVoltageRegulationMeans[itemEnQSet].NumberOfVoltageRegulationMeans}");
                    int n = Node.FindNextSel[-1];
                   // Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя КП: {name.Z[n]}");
                    powerReacGen.set_ZN(n, Q);
                }
            }
        }
        

        
        /// <summary>
        /// Получение реактивной мощности на реакторе из Rastr после изменений
        /// </summary>
        /// <returns></returns>
        public List<double> GetPowerReacSecond()
        {
            Data data = new Data();
            List<VoltageControlPoints> listQ2 = data.VoltageControlPoints;

            List<double> listNewQ2 = new List<double>();

            List<int> listEnumerationQ2 = new List<int> { 0, 1 };
            foreach (var itemEnQ2 in listEnumerationQ2)
            {
                List<VoltageControlPoints> subListQ2 = listQ2.Where((Q1) =>
                Q1.ParametersOfVoltageRegulationMeans[itemEnQ2].TypeOfVoltageRegulationMeans == "управляемый").ToList();

                ITable Node = (ITable)_rastr.Tables.Item("node");
                ICol powerReacGen = (ICol)Node.Cols.Item("qg");
                ICol NumberNode = (ICol)Node.Cols.Item("ny");
                ICol name = (ICol)Node.Cols.Item("name");

                foreach (var itemQ1 in subListQ2)
                {
                    Node.SetSel($"ny = {itemQ1.ParametersOfVoltageRegulationMeans[itemEnQ2].NumberOfVoltageRegulationMeans}");
                    int n = Node.FindNextSel[-1];
                   // Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
                    listNewQ2.Add(Convert.ToDouble(powerReacGen.Z[n]));
                }
            }
            return listNewQ2;
        }


        
        /// <summary>
        /// Получение напряжения в КП до изменений из Rastr 
        /// </summary>
        /// <returns></returns>
        public List<double> GetVoltageYFirst()
        {
            Data data = new Data();
            List<VoltageControlPoints> listU1 = data.VoltageControlPoints;
            List<double> listNewU1 = new List<double>();
            List<VoltageControlPoints> subListU1 = listU1.Where((U1) => U1.NumberOfControlPoints > 0).ToList();

            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol voltageRas = (ICol)Node.Cols.Item("vras");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            foreach (var item in subListU1)
            {
                Node.SetSel($"ny = {item.NumberOfControlPoints}");
                int n = Node.FindNextSel[-1];
               // Console.WriteLine($"Значение напряжения: {voltageRas.Z[n]}. Имя КП: {name.Z[n]}");
                listNewU1.Add(Convert.ToDouble(voltageRas.Z[n]));

            }
            return listNewU1;
        }
        
        /// <summary>
        /// 
        /// Получение напряжения в КП из Rastr после изменений
        /// </summary>
        /// <returns></returns>
        public List<double> GetVoltageYSecond()
        {
            Data data = new Data();
            List<VoltageControlPoints> listU2 = data.VoltageControlPoints;
            List<double> listNewU2 = new List<double>();
            List<VoltageControlPoints> subListU2 = listU2.Where((U2) => U2.NumberOfControlPoints > 0).ToList();

            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol voltageRas = (ICol)Node.Cols.Item("vras");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            foreach (var item in subListU2)
            {
                Node.SetSel($"ny = {item.NumberOfControlPoints}");
                int n = Node.FindNextSel[-1];
               // Console.WriteLine($"Значение напряжения: {voltageRas.Z[n]}. Имя КП: {name.Z[n]}");
                listNewU2.Add(Convert.ToDouble(voltageRas.Z[n]));

            }
            return listNewU2;
        }
        
        */
        /// <summary>
        /// Расчёт режима
        /// </summary>
        public void Regime()
        {
            _rastr.rgm("");
        }

        /*
        /// <summary>
        /// Получение начального состояния шунтирующего реактора из Rastr 
        /// </summary>
        /// <returns></returns>
        public List<int> GetReacConditionFirst()
        {
            Data data = new Data();
            List<VoltageControlPoints> listC1 = data.VoltageControlPoints;
            List<int> listNewC1 = new List<int>();

            List<int> listEnumerationC1 = new List<int> { 0, 1, 2, 3 };
            foreach (var itemEnC1 in listEnumerationC1)
            {
                List<VoltageControlPoints> subListC1 = listC1.Where((C1) =>               
                C1.ParametersOfVoltageRegulationMeans[itemEnC1].TypeOfVoltageRegulationMeans == "коммутируемый").ToList();

                ITable Node = (ITable)_rastr.Tables.Item("node");
                ICol conditionReactor = (ICol)Node.Cols.Item("sta");
                ICol NumberNode = (ICol)Node.Cols.Item("ny");
                ICol name = (ICol)Node.Cols.Item("name");

                foreach (var itemC1 in subListC1)
                {
                    Node.SetSel($"ny = {itemC1.ParametersOfVoltageRegulationMeans[itemEnC1].NumberOfVoltageRegulationMeans}");
                    int n = Node.FindNextSel[-1];
                    //Console.WriteLine($"Статус работы: {conditionReactor.Z[n]}. Имя КП: {name.Z[n]}");
                    listNewC1.Add(Convert.ToInt32(conditionReactor.Z[n]));
                }
            }           
            return listNewC1;          
        }
        */
        
        /*
        /// <summary>
        /// Запись нового состояния шунтирующего реактора в Rastr 
        /// </summary>
        public void SetReacCondition()
        {
            Data data = new Data();
            List<VoltageControlPoints> listCSet = data.VoltageControlPoints;
            List<int> listEnumerationCSet = new List<int> { 0, 1, 2, 3 };

            foreach (var itemEnCSet in listEnumerationCSet)
            {
                List<VoltageControlPoints> subListCSet = listCSet.Where((C1) =>
                C1.ParametersOfVoltageRegulationMeans[itemEnCSet].TypeOfVoltageRegulationMeans == "коммутируемый").ToList();

                ITable Node = (ITable)_rastr.Tables.Item("node");
                ITable Vetv = (ITable)_rastr.Tables.Item("vetv");
                ICol conditionReactorY = (ICol)Node.Cols.Item("sta");
                ICol conditionReactorV = (ICol)Vetv.Cols.Item("sta");
                ICol NumberNode = (ICol)Node.Cols.Item("ny");
                ICol name = (ICol)Node.Cols.Item("name");

                foreach (var itemCSet in subListCSet)
                {
                    int reacConditionY = 1;
                    int reacConditionV = 1;
                    Node.SetSel($"ny = {itemCSet.ParametersOfVoltageRegulationMeans[itemEnCSet].NumberOfVoltageRegulationMeans}");
                    int n = Node.FindNextSel[-1];
                    Console.WriteLine($"Статус работы: {conditionReactorY.Z[n]}. Имя КП: {name.Z[n]}");
                    Console.WriteLine($"Статус работы: {conditionReactorV.Z[n]}. Имя КП: {name.Z[n]}");
                    conditionReactorY.set_ZN(n, reacConditionY);
                    conditionReactorV.set_ZN(n, reacConditionV);
                }
            }

        }
        
        /// <summary>
        /// Получение нового состояния шунтирующего реактора из Rastr 
        /// </summary>
        /// <returns></returns>
        public List<int> GetReacConditionSecond()
        {
            Data data = new Data();
            List<VoltageControlPoints> listC2 = data.VoltageControlPoints;
            List<int> listNewC2 = new List<int>();

            List<int> listEnumerationC2 = new List<int> { 0, 1, 2, 3 };
            foreach (var itemEnC2 in listEnumerationC2)
            {
                List<VoltageControlPoints> subListC2 = listC2.Where((C2) =>
                C2.ParametersOfVoltageRegulationMeans[itemEnC2].TypeOfVoltageRegulationMeans == "коммутируемый").ToList();

                ITable Node = (ITable)_rastr.Tables.Item("node");
                ICol conditionReactor = (ICol)Node.Cols.Item("sta");
                ICol NumberNode = (ICol)Node.Cols.Item("ny");
                ICol name = (ICol)Node.Cols.Item("name");

                foreach (var itemC2 in subListC2)
                {
                    Node.SetSel($"ny = {itemC2.ParametersOfVoltageRegulationMeans[itemEnC2].NumberOfVoltageRegulationMeans}");
                    int n = Node.FindNextSel[-1];
                    Console.WriteLine($"Статус работы: {conditionReactor.Z[n]}. Имя КП: {name.Z[n]}");
                    listNewC2.Add(Convert.ToInt32(conditionReactor.Z[n]));
                }
            }
            return listNewC2;
        }
        */

        /*
        /// <summary>
        /// Получение активной и реактивной мощности генератора до изменений из Rastr
        /// </summary>
        /// <returns></returns>
        public List<double> GetReactiveGenFirst()
        {
            Data data = new Data();
            List<int> list = data.ResearchingGeneratorsFromRastr;
            List<double> listNew = new List<double>();

            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol activePowerGen = (ICol)Node.Cols.Item("pg");
            ICol powerReacGen = (ICol)Node.Cols.Item("qg");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            foreach (var item in list)
            {
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
                Console.WriteLine($"Значение активной мощности: {activePowerGen.Z[n]}. Имя УШР: {name.Z[n]}");
                listNew.Add(Convert.ToDouble(powerReacGen.Z[n]));
            }
            return listNew;
        }

        /// <summary>
        /// Запись нового значения активной мощности в Генератор в Rastr
        /// </summary>
        public void SetActivePower()
        {
            Data data = new Data();
            List<int> list = data.NumbersOfControlledReactors;
            
            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol activePowerGen = (ICol)Node.Cols.Item("pg");
            ICol powerReacGen = (ICol)Node.Cols.Item("qg");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            foreach (var item in list)
            {
                int P = 550;
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
                Console.WriteLine($"Значение активной мощности: {activePowerGen.Z[n]}. Имя УШР: {name.Z[n]}");
                activePowerGen.set_ZN(n, P);
            }
        }

        /// <summary>
        /// Получение активной и реактивной мощности генератора после изменений из Rastr
        /// </summary>
        /// <returns></returns>
        public List<double> GetReactiveGenSecond()
        {
            Data data = new Data();
            List<int> list = data.ResearchingGeneratorsFromRastr;
            List<double> listNew = new List<double>();

            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol activePowerGen = (ICol)Node.Cols.Item("pg");
            ICol powerReacGen = (ICol)Node.Cols.Item("qg");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            foreach (var item in list)
            {
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
                Console.WriteLine($"Значение активной мощности: {activePowerGen.Z[n]}. Имя УШР: {name.Z[n]}");
                listNew.Add(Convert.ToDouble(powerReacGen.Z[n]));
            }
            return listNew;
        }
        
        */

        
    }
}
