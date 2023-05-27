using EngineTest.src.utils;
using System.Collections.Generic;

namespace EngineTest.src.Factorys
{
    internal class EngineFactory
    {
        private Dictionary<EnginesTypes, IEngineCreator> EngineCreators;
        public EngineFactory() 
        {
            EngineCreators = new Dictionary<EnginesTypes, IEngineCreator>
            {
                { EnginesTypes.InternalCombustionEngine, new InternalCombustionEngineCreator() }
            };
        }
        
        public IEngine CreateEngine(EnginesTypes type, int ambientTemperature)
        {
            return EngineCreators[type].CreateEngine(ambientTemperature);
        } 
    }
}
