using EngineTest.src.Factorys;
using EngineTest.src.TestStands;
using EngineTest.src.utils;
using System;
using System.Collections.Generic;

namespace EngineTest.src.SISController
{

    internal class SISController
    {
        private readonly EngineFactory Factory;

        private readonly Dictionary<int, EnginesTypes> Engines;

        public SISController()
        {
            Engines = new Dictionary<int, EnginesTypes>()
            {
                { 1, EnginesTypes.InternalCombustionEngine }
            };

            Factory = new EngineFactory();
        }

        public void StartWork()
        {
            while (true)
            {
                Console.WriteLine("Для запуска работы приложения введите -> START\nДля завершения работы приложение введите -> EXIT");
                var userChoice = Console.ReadLine();

                if (userChoice.Equals("START")){
                    TestEngine();
                }
                else if (userChoice.Equals("EXIT"))
                {
                    Console.WriteLine("Всего доброго!");
                    return;
                }
                else
                {
                    Console.WriteLine("Введенный ответ некорректен, пожалуйста сделайте одно из предложенных действий");
                }
            }
        }

        private void TestEngine()
        {
            var engineType = ChooseEngine();
            var temperature = SetAmbientTemperature();

            IEngine engine = Factory.CreateEngine(engineType, temperature);

            var testStands = new List<ITestStand>
            {
                new HeatingTestStand(),
                new MaximumPowerTestStand(),
            };


            foreach(var testStand in testStands)
            {
                testStand.SetEngine(engine);
                testStand.Test(temperature);
            }

        }

        private int SetAmbientTemperature()
        {
            Console.WriteLine("Введитe температуру окружающей среды в градусах по Цельсию");

            int temperature;

            while (true)
            {
                if (CheckUserTempChoice(Console.ReadLine(), out temperature))
                {
                    break;
                }
            }

            return temperature;
        }

        private EnginesTypes ChooseEngine()
        {
            Console.WriteLine("Введите тип двигателя - целове число, который хотите протестировать:");

            int engineKey;

            while (true)
            {
                foreach (var engine in Engines)
                {
                    Console.WriteLine($"{engine.Key} -> {engine.Value}");
                }

                if (CheckUserEngineChoice(Console.ReadLine(), out engineKey))
                {
                    break;
                }
            }

            return Engines[engineKey];
        }

        private bool CheckUserEngineChoice(string userInput, out int engineKey)
        {
            engineKey = 0;

            if (!int.TryParse(userInput, out var value))
            {
                Console.WriteLine("Некорректные данные, иcпользуйте целое число. \nВведите тип двигателя, который хотите протестировать еще раз:");
                return false;
            }

            if (!Engines.ContainsKey(value))
            {
                Console.WriteLine("Выбранного двигателя нет в спирске. \nВведите тип двигателя, который хотите протестировать еще раз:");
                return false;
            }

            engineKey = value;
            return true;
        }

        private bool CheckUserTempChoice(string userInput, out int temperature)
        {
            temperature = 0;

            if (!int.TryParse(userInput, out var value))
            {
                Console.WriteLine("Некорректные данные, иcпользуйте целое число. \nВведитe температуру окружающей среды в гррадусах по Цельсию еще раз.");
                return false;
            }

            temperature = value;
            return true;
        }
    }
}
