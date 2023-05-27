using EngineTest.src.Engines;
using System;

namespace EngineTest.src.TestStands
{
    internal class MaximumPowerTestStand : ITestStand
    {
        private int[] M = { 20, 75, 100, 105, 75, 0 };
        private int[] V = { 0, 75, 150, 200, 250, 300 };

        private InternalCombustionEngine engine;

        public void SetEngine(IEngine engine)
        {
            this.engine = (InternalCombustionEngine)engine;
        }

        public void Test(double ambientTemperature)
        {
            double time = 0;
            //уменьшение dt увеличивает точность
            double dt = 0.1;
            double N = 0;
            engine.TurnOn(ambientTemperature);


            while ((engine.GetLastVValue() - engine.GetV()) > 0.00000000001)
            {
                engine.Simulate(dt);
              
                var tmp = engine.GetV() * engine.GetM() / 1000;
                if(tmp > N)
                {
                    N = tmp;
                }
                
                time += dt;
            }

            Console.WriteLine($"Максимальная мощность получилась: {N}");
        }
    }
}
