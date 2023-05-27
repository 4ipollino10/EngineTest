
namespace EngineTest.src.TestStands
{
    internal interface ITestStand
    {
        void SetEngine(IEngine engine);
        void Test(double ambientTemperature);
    }
}
