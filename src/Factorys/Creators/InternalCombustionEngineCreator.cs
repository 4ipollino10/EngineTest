using EngineTest.src.Engines;

namespace EngineTest.src.Factorys
{
    internal class InternalCombustionEngineCreator : IEngineCreator
    {
        public IEngine CreateEngine(int ambientTemperature)
        {
            return new InternalCombustionEngine();
        }
    }
}
