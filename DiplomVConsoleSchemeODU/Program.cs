﻿using ASTRALib;
using ModelODU;
using ModelODU.VoltageRegulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
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
            RastrСalculation rastr = new RastrСalculation();

            //rastr.Chart_Click();
           // rastr.Chart();

            
            Console.WriteLine("Добро пожаловать в программу " +
                "вычисления эффективности СРН!\n" +
                "Нажмите любую кнопку, чтобы начать...");
            Console.ReadKey();



            Console.WriteLine("Введите номер узла Контрольного пункта: ");
            var consoleKey1 = Console.ReadLine();
            
            Console.WriteLine("Введите номер узла СРН: ");
            var consoleKey2 = Console.ReadLine();
            Console.WriteLine("Выберите тип СРН: ");
            Console.WriteLine("1 - управляемый");
            Console.WriteLine("2 - коммутируемый");
            Console.WriteLine("3 - генератор");
            var consoleKey3 = Console.ReadLine();
            switch (consoleKey3)
            {
                case "1":
                    Console.WriteLine("Вы выбрали: управляемый");
                    rastr.CreateSet("1", consoleKey2, consoleKey1);
                    break;
                case "2":
                    Console.WriteLine("Вы выбрали: коммутируемый");
                    rastr.CreateSet("2", consoleKey2, consoleKey1);
                    break;
                case "3":
                    Console.WriteLine("Вы выбрали: генератор");
                    rastr.CreateSet("3", consoleKey2, consoleKey1);
                    break;
                default:
                    break;
            }
            
            /*
            while (true)
            {
                Console.WriteLine("Выберите Контрольный пункт:");
                Console.WriteLine("1 - ПС 500 кВ Ново-Анжерская");
                Console.WriteLine("2 - Беловская ГРЭС");
                Console.WriteLine("3 - ПС 500 кВ Юрга");               
                Console.WriteLine("4 - Выход из программы");
                var consoleKey = Console.ReadLine();
                switch (consoleKey)
                {
                    case "1":
                        {
                            Console.WriteLine("В качестве контрольного пункта вы выбрали " +
                                "ПС 500 кВ Ново-Анжерская.\nНажмте любую кнопку, чтобы перейти " +
                                "к выбору Средства регулирования напряжения для расчёта " +
                                "эффективности");
                            Console.ReadKey();
                            Console.WriteLine("Выберите СРН:");
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
                                        
                                        Console.WriteLine("Вы выбрали: УШР-500 ПС 500 кВ Томская");

                                        // rastr.SetNewValueGenerator("1");

                                        //rastr.CreateListRg("1");
                                        rastr.CreateSet("1");

                                       // rastr.SetNewValueGenerator("1");

                                        /*
                                        ControlledReactors controlledReactors = new ControlledReactors();
                                        List<int> List1 = new List<int> { 0, 1 };
                                       
                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        
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

                                        Console.WriteLine(a);
                                        

                                        break;
                                    }
                                case "2":
                                    {
                                        
                                        Console.WriteLine("СТК-1 ПС 500 кВ Заря");
                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetNewValueGenerator("2");
                                        
                                        ControlledReactors controlledReactors = new ControlledReactors();                                      

                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        controlledReactors.ReactivePowerFirst = rastr.GetReactivePowerFirst()[3];
                                        Console.WriteLine(controlledReactors.ReactivePowerFirst);
                                        controlledReactors.VoltageFirst = rastr.GetVoltageYFirst()[0];

                                        rastr.SetValueQ();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        controlledReactors.ReactivePowerSecond = rastr.GetPowerReacSecond()[3];
                                        Console.WriteLine(controlledReactors.ReactivePowerSecond);
                                        controlledReactors.VoltageSecond = rastr.GetVoltageYSecond()[0];

                                        double a = controlledReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));
                                       
                                        break;
                                    }
                                case "3":
                                    {
                                        Console.WriteLine("ШР-500 ПС 500 кВ Томская");
                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetNewValueGenerator("3");
                                        
                                        SwitchedReactors switchedReactors = new SwitchedReactors();                                      
                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        switchedReactors.ConditionReactorFirst = rastr.GetReacConditionFirst()[0];
                                        Console.WriteLine(switchedReactors.ConditionReactorFirst);
                                        switchedReactors.VoltageFirst = rastr.GetVoltageYFirst()[0];
                                        rastr.SetReacCondition();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры после изменения");
                                        switchedReactors.ConditionReactorSecond = rastr.GetReacConditionSecond()[0];
                                        switchedReactors.VoltageSecond = rastr.GetVoltageYSecond()[0];
                                        double a = switchedReactors.Effect();
                                        Console.WriteLine(Math.Abs(a));
                                        
                                        break;
                                    }
                                case "4":
                                    {
                                        Console.WriteLine("Р-532 ПС 500 кВ Заря");
                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetNewValueGenerator("4");

                                        
                                        SwitchedReactors switchedReactors = new SwitchedReactors();                                        
                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        switchedReactors.ConditionReactorFirst = rastr.GetReacConditionFirst()[3];
                                        Console.WriteLine(switchedReactors.ConditionReactorFirst);
                                        switchedReactors.VoltageFirst = rastr.GetVoltageYFirst()[0];
                                        rastr.SetReacCondition();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры после изменения");
                                        switchedReactors.ConditionReactorSecond = rastr.GetReacConditionSecond()[3];
                                        switchedReactors.VoltageSecond = rastr.GetVoltageYSecond()[0];
                                        double a = switchedReactors.Effect();
                                        Console.WriteLine(Math.Abs(a));
                                        
                                        break;
                                    }
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("В качестве контрольного пункта вы выбрали " +
                                "Беловскую ГРЭС.Нажмте любую кнопку, чтобы перейти " +
                                "к выбору Средства регулирования напряжения для расчёта " +
                                "эффективности");
                            Console.ReadKey();
                            Console.WriteLine("Выберите СРН");
                            Console.WriteLine($"1 - УШР-500 ПС 500 кВ Томская");
                            Console.WriteLine("2 - СТК-1 ПС 500 кВ Заря");
                            Console.WriteLine("3 - ШР-500 ПС 500 кВ Томская");
                            Console.WriteLine("4 - P-1 ПС 500 кВ Ново-Анжерская");
                            Console.WriteLine("5 - Хочу выбрать другой контрольный пункт");
                            var consoleKey1 = Console.ReadLine();
                            switch (consoleKey1)
                            {
                                case "1":
                                    {
                                        Console.WriteLine("УШР-500 ПС 500 кВ Томская");

                                        ControlledReactors controlledReactors = new ControlledReactors();
                                        

                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        controlledReactors.ReactivePowerFirst = rastr.GetReactivePowerFirst()[1];
                                        controlledReactors.VoltageFirst = rastr.GetVoltageYFirst()[1];

                                        Console.WriteLine(controlledReactors.VoltageFirst);
                                        Console.WriteLine(controlledReactors.ReactivePowerFirst);

                                        rastr.SetValueQ();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        controlledReactors.ReactivePowerSecond = rastr.GetPowerReacSecond()[1];
                                        controlledReactors.VoltageSecond = rastr.GetVoltageYSecond()[1];

                                        double a = controlledReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));

                                        break;
                                    }
                                case "2":
                                    {
                                        Console.WriteLine("СТК-1 ПС 500 кВ Заря");

                                        ControlledReactors controlledReactors = new ControlledReactors();
                                        

                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        controlledReactors.ReactivePowerFirst = rastr.GetReactivePowerFirst()[4];
                                        Console.WriteLine(controlledReactors.ReactivePowerFirst);
                                        controlledReactors.VoltageFirst = rastr.GetVoltageYFirst()[1];

                                        rastr.SetValueQ();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        controlledReactors.ReactivePowerSecond = rastr.GetPowerReacSecond()[4];
                                        Console.WriteLine(controlledReactors.ReactivePowerSecond);
                                        controlledReactors.VoltageSecond = rastr.GetVoltageYSecond()[1];

                                        double a = controlledReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));

                                        break;
                                    }
                                case "3":
                                    {
                                        Console.WriteLine("ШР-500 ПС 500 кВ Томская");
                                        SwitchedReactors switchedReactors = new SwitchedReactors();
                                        

                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        switchedReactors.ConditionReactorFirst= rastr.GetReacConditionFirst()[1];
                                        switchedReactors.VoltageFirst = rastr.GetVoltageYFirst()[1];

                                        rastr.SetReacCondition();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        switchedReactors.ConditionReactorSecond = rastr.GetReacConditionSecond()[1];                                      
                                        switchedReactors.VoltageSecond = rastr.GetVoltageYSecond()[1];

                                        double a = switchedReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));


                                        break;
                                    }
                                case "4":
                                    {
                                        Console.WriteLine("P-1 ПС 500 кВ Ново-Анжерская");

                                        SwitchedReactors switchedReactors = new SwitchedReactors();
                                       

                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        switchedReactors.ConditionReactorFirst = rastr.GetReacConditionFirst()[4];
                                        Console.WriteLine(switchedReactors.ConditionReactorFirst);
                                        switchedReactors.VoltageFirst = rastr.GetVoltageYFirst()[1];

                                        rastr.SetReacCondition();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        switchedReactors.ConditionReactorSecond = rastr.GetReacConditionSecond()[4];
                                        switchedReactors.VoltageSecond = rastr.GetVoltageYSecond()[1];

                                        double a = switchedReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));

                                        break;
                                    }
                            }
                            break;

                           
                        }
                    case "3":
                        {
                            Console.WriteLine("В качестве контрольного пункта вы выбрали " +
                                "ПС 500 кВ Юрга.Нажмте любую кнопку, чтобы перейти " +
                                "к выбору Средства регулирования напряжения для расчёта " +
                                "эффективности");
                            Console.ReadKey();
                            Console.WriteLine("Выберите СРН");
                            Console.WriteLine("1 - УШР-500 ПС 500 кВ Томская");
                            Console.WriteLine("2 - СТК-1 ПС 500 кВ Заря");
                            Console.WriteLine("3 - ШР-500 ПС 500 кВ Томская");
                            Console.WriteLine("4 - P-1 ПС 500 кВ Ново-Анжерская");
                            Console.WriteLine("5 - Хочу выбрать другой контрольный пункт");
                            var consoleKey1 = Console.ReadLine();
                            switch (consoleKey1)
                            {
                                case "1":
                                    {
                                        Console.WriteLine("УШР-500 ПС 500 кВ Томская");

                                        ControlledReactors controlledReactors = new ControlledReactors();
                                       

                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        controlledReactors.ReactivePowerFirst = rastr.GetReactivePowerFirst()[2];
                                        controlledReactors.VoltageFirst = rastr.GetVoltageYFirst()[2];

                                        Console.WriteLine(controlledReactors.VoltageFirst);
                                        Console.WriteLine(controlledReactors.ReactivePowerFirst);

                                        rastr.SetValueQ();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        controlledReactors.ReactivePowerSecond = rastr.GetPowerReacSecond()[2];
                                        controlledReactors.VoltageSecond = rastr.GetVoltageYSecond()[2];

                                        double a = controlledReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));

                                        break;
                                    }
                                case "2":
                                    {
                                        Console.WriteLine("СТК-1 ПС 500 кВ Заря");

                                        ControlledReactors controlledReactors = new ControlledReactors();
                                        
                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        controlledReactors.ReactivePowerFirst = rastr.GetReactivePowerFirst()[5];
                                        Console.WriteLine(controlledReactors.ReactivePowerFirst);
                                        controlledReactors.VoltageFirst = rastr.GetVoltageYFirst()[2];

                                        rastr.SetValueQ();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        controlledReactors.ReactivePowerSecond = rastr.GetPowerReacSecond()[5];
                                        Console.WriteLine(controlledReactors.ReactivePowerSecond);
                                        controlledReactors.VoltageSecond = rastr.GetVoltageYSecond()[2];

                                        double a = controlledReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));

                                        break;
                                    }
                                case "3":
                                    {
                                        Console.WriteLine("ШР-500 ПС 500 кВ Томская");
                                        SwitchedReactors switchedReactors = new SwitchedReactors();
                                        

                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        switchedReactors.ConditionReactorFirst = rastr.GetReacConditionFirst()[2];
                                        switchedReactors.VoltageFirst = rastr.GetVoltageYFirst()[2];

                                        rastr.SetReacCondition();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        switchedReactors.ConditionReactorSecond = rastr.GetReacConditionSecond()[2];
                                        switchedReactors.VoltageSecond = rastr.GetVoltageYSecond()[2];

                                        double a = switchedReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));


                                        break;
                                    }
                                case "4":
                                    {
                                        Console.WriteLine("P-1 ПС 500 кВ Ново-Анжерская");

                                        SwitchedReactors switchedReactors = new SwitchedReactors();
                                        

                                        rastr.LoadFile(rastr.pathFile, rastr.pathShablon);
                                        rastr.Regime();
                                        rastr.SetFix();
                                        rastr.Regime();
                                        Console.WriteLine("Параметры до изменения");
                                        switchedReactors.ConditionReactorFirst = rastr.GetReacConditionFirst()[5];
                                        Console.WriteLine(switchedReactors.ConditionReactorFirst);
                                        switchedReactors.VoltageFirst = rastr.GetVoltageYFirst()[2];

                                        rastr.SetReacCondition();
                                        rastr.Regime();

                                        Console.WriteLine("Параметры после изменения");
                                        switchedReactors.ConditionReactorSecond = rastr.GetReacConditionSecond()[5];
                                        switchedReactors.VoltageSecond = rastr.GetVoltageYSecond()[2];

                                        double a = switchedReactors.Effect();

                                        Console.WriteLine(Math.Abs(a));

                                        break;
                                    }
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
             */
        }

    }
}
