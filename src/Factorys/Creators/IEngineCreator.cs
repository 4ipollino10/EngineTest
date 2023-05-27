
namespace EngineTest.src.Factorys
{
    internal interface IEngineCreator
    {
        IEngine CreateEngine(int ambientTemperature);
    }
}
