
namespace EngineTest.src
{
    internal interface IEngine
    {
        void UploadParams();
        void TurnOn(double ambientTemperature);
        void Simulate(double dt);
    }
}
