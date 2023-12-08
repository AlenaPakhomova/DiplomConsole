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
            "\\РМ Rastra\\С фиксированными СКРМ\\Зима 18-00.rg2";

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

        
        /// <summary>
        /// Получение реактивной мощности реактора до изменений из Rastr
        /// </summary>
        /// <returns></returns>
        public List<double> GetReactivePowerFirst()
        {
            Data data = new Data();
            List<VoltageControlPoints> listQ1 = data.VoltageControlPoints;

            List<double> listNewQ1 = new List<double>();

            List<int> listEnumerationQ1 = new List<int> { 0, 1, 2, 3 };
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
                    Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
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
                    int Q = -130;
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

            List<int> listEnumerationQ2 = new List<int> { 0, 1, 2, 3 };
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
                    Console.WriteLine($"Значение реактивной мощности: {powerReacGen.Z[n]}. Имя УШР: {name.Z[n]}");
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
                Console.WriteLine($"Значение напряжения: {voltageRas.Z[n]}. Имя КП: {name.Z[n]}");
                listNewU1.Add(Convert.ToDouble(voltageRas.Z[n]));

            }
            return listNewU1;
        }
        
        /// <summary>
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
                Console.WriteLine($"Значение напряжения: {voltageRas.Z[n]}. Имя КП: {name.Z[n]}");
                listNewU2.Add(Convert.ToDouble(voltageRas.Z[n]));

            }
            return listNewU2;
        }
        

        /// <summary>
        /// Расчёт режима
        /// </summary>
        public void Regime()
        {
            _rastr.rgm("");
        }

        
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
                    Console.WriteLine($"Статус работы: {conditionReactor.Z[n]}. Имя КП: {name.Z[n]}");
                    listNewC1.Add(Convert.ToInt32(conditionReactor.Z[n]));
                }
            }           
            return listNewC1;          
        }


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
