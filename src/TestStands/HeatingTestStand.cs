using EngineTest.src.Engines;
using System;
using System.Text;

namespace EngineTest.src.TestStands
{
    internal class HeatingTestStand : ITestStand
    {
        private InternalCombustionEngine engine;

        public void SetEngine(IEngine engine)
        {
            this.engine = (InternalCombustionEngine)engine;
        }

        public void Test(double ambientTemperature)
        {
            double time = 0;
            //уменьшение dt увеличивает точность
            double dt = 0.01;
            double prevTemperature;
            engine.TurnOn(ambientTemperature);
            while (true)
            {
                //если у нас изменения температуры крайне малы, то такой подход будет не совсем верен, но можно сравнивать температуры, к примеру, раз в секунду
                prevTemperature = engine.CurentTemperature;
                
                engine.Simulate(dt);

                if(prevTemperature == engine.CurentTemperature)
                {
                    Console.WriteLine($"Двигатель не перегреется при такой изначальной температуре окружающей среды и такими параметрами двигателя");
                    return;
                }

                if (engine.CurentTemperature > engine.SuperheatTemperature)
                {
                    Console.WriteLine($"Перегрев насутпил спустя {time} секунд");
                    return;
                }

                time += dt;


            }
        }
    }
}
