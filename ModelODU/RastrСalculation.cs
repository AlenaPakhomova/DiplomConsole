using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ASTRALib;


namespace ModelODU
{
    /// <summary>
    /// Класс для обращения к RastrWin3
    /// </summary>
    public class RastrСalculation
    {
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

        /// <summary>
        /// Фиксация всех средств регулирования напряжения
        /// </summary>
        /// <param name="arr"></param>
        public void SetFix()
        {
            Data data = new Data();
            int[] arr = data.arrNub;
            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol voltageZd = (ICol)Node.Cols.Item("vzd");
            foreach (var item in arr)
            {
                int voltage = 0;
                voltageZd.set_ZN(item, voltage);
            }
        }

        
        /// <summary>
        /// Получение реактивной мощности реактора до изменений из Rastr
        /// </summary>
        /// <returns></returns>
        public List<double> GetReactivePowerFirst()
        {
            Data data = new Data();
            List<VoltageControlPoints> list = data.VoltageControlPoints;
            List<VoltageRegulationMeans> voltage = new List<VoltageRegulationMeans>();
            List<VoltageControlPoints> subList = list.Where((L) => L.ParametersOfVoltageRegulationMeans == voltage).ToList();
            voltage.GetRange(0, subList.Count);                    

            List<double> listNew = new List<double>();
    
            List<int> listCount = new List<int>() { 0, 1, 2 };
            foreach (var item in listCount)
            {
                List<VoltageControlPoints> subList1 = list.Where((L) =>
                L.ParametersOfVoltageRegulationMeans[item].TypeOfVoltageRegulationMeans == "управляемый").ToList();

                ITable Node = (ITable)_rastr.Tables.Item("node");
                ICol powerReacGen = (ICol)Node.Cols.Item("qg");
                ICol NumberNode = (ICol)Node.Cols.Item("ny");
                ICol name = (ICol)Node.Cols.Item("name");


                foreach (var item in list)
                {
                    Node.SetSel($"ny = {item}");
                    int n = Node.FindNextSel[-1];
                    Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
                    listNew.Add(Convert.ToDouble(powerReacGen.Z[n]));
                }

            }
            return listNew;
          
        }
        

        /*
        /// <summary>
        ///  Запись значений в ячейку с реактивной мощностью на реакторе в Rastr
        /// </summary>
        public void SetValueQ()
        {
            Data data = new Data();
            List<int> list = data.NumbersOfControlledReactors;

            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol powerReacGen = (ICol)Node.Cols.Item("qg");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            foreach (var item in list)
            {
                int Q = -120;
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя КП: {name.Z[n]}");
                powerReacGen.set_ZN(n, Q);
            }
        }
        */

        /*
        /// <summary>
        /// Получение реактивной мощности на реакторе из Rastr после изменений
        /// </summary>
        /// <returns></returns>
        public List<double> GetPowerReacSecond()
        {
            Data data = new Data();
            List<int> list = data.NumbersOfControlledReactors;
            List<double> listNew = new List<double>();

            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol powerReacGen = (ICol)Node.Cols.Item("qg");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            foreach (var item in list)
            {
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
                listNew.Add(Convert.ToDouble(powerReacGen.Z[n]));
            }
            return listNew;
        }
        */

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
                Console.WriteLine($"Значение напряжения: {voltageRas.Z[n]}. Имя КП: {name.Z[n]}");
                listNewU1.Add(Convert.ToDouble(voltageRas.Z[n]));

            }
            return listNewU1;

        }



        /*
        /// <summary>
        /// Получение напряжения в КП из Rastr после изменений
        /// </summary>
        /// <returns></returns>
        public List<double> GetVoltageYSecond()
        {
            Data data = new Data();
            List<int> list = data.NumbersOfNodes;
            List<double> listNew = new List<double>();

            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol voltageRas = (ICol)Node.Cols.Item("vras");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            foreach (var item in list)
            {
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                Console.WriteLine($"Значение напряжения: {voltageRas.Z[n]}. Имя КП: {name.Z[n]}");
                listNew.Add(Convert.ToDouble(voltageRas.Z[n]));
            }
            return listNew;
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
            List<int> list = data.NumbersOfSwitchedReactorsFromRastr;
            List<int> listNew = new List<int>();

            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol conditionReactor = (ICol)Node.Cols.Item("sta");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");       

            foreach (var item in list)
            {
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                Console.WriteLine($"Статус работы: {conditionReactor.Z[n]}. Имя КП: {name.Z[n]}");
                listNew.Add(Convert.ToInt32(conditionReactor.Z[n]));
            }
            return listNew;
        }


        /// <summary>
        /// Запись нового состояния шунтирующего реактора в Rastr 
        /// </summary>
        public void SetReacCondition()
        {
            Data data = new Data();
            List<int> list = data.NumbersOfSwitchedReactorsFromRastr;

            ITable Node = (ITable)_rastr.Tables.Item("node");
            ITable Vetv = (ITable)_rastr.Tables.Item("vetv");
            ICol conditionReactorY = (ICol)Node.Cols.Item("sta");
            ICol conditionReactorV = (ICol)Vetv.Cols.Item("sta");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            foreach (var item in list)
            {
                int reacConditionY = 1;
                int reacConditionV = 1;
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                Console.WriteLine($"Статус работы: {conditionReactorY.Z[n]}. Имя КП: {name.Z[n]}");
                Console.WriteLine($"Статус работы: {conditionReactorV.Z[n]}. Имя КП: {name.Z[n]}");
                conditionReactorY.set_ZN(n, reacConditionY);
                conditionReactorV.set_ZN(n, reacConditionV);
            }

           
        }

        /// <summary>
        /// Получение нового состояния шунтирующего реактора из Rastr 
        /// </summary>
        /// <returns></returns>
        public List<int> GetReacConditionSecond()
        {
            Data data = new Data();
            List<int> list = data.NumbersOfSwitchedReactorsFromRastr;
            List<int> listNew = new List<int>();

            ITable Node = (ITable)_rastr.Tables.Item("node");
            ICol conditionReactor = (ICol)Node.Cols.Item("sta");
            ICol NumberNode = (ICol)Node.Cols.Item("ny");
            ICol name = (ICol)Node.Cols.Item("name");

            foreach (var item in list)
            {
                Node.SetSel($"ny = {item}");
                int n = Node.FindNextSel[-1];
                Console.WriteLine($"Статус работы: {conditionReactor.Z[n]}. Имя КП: {name.Z[n]}");
                listNew.Add(Convert.ToInt32(conditionReactor.Z[n]));
            }
            return listNew;
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
