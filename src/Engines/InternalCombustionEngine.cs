using System;
using System.Linq;

namespace EngineTest.src.Engines
{
    internal class InternalCombustionEngine : IEngine
    {
        private int I = 10;
        private int[] M = { 20, 75, 100, 105, 75, 0 };
        private int[] V = { 0, 75, 150, 200, 250, 300 };
        private int ambientTemperature;
        private double H_m = 0.01;
        private double H_v = 0.0001;
        private double C = 0.1;
        private double v = 0;
        private double m = 0;

        public double CurentTemperature { get; set; }
        public int SuperheatTemperature { get; set; }

        public void TurnOn(double ambientTemperature)
        {
            this.ambientTemperature = (int)ambientTemperature;
            CurentTemperature = ambientTemperature;
            SuperheatTemperature = 110;
        }

        public void Simulate(double dt)
        {
            double V_h;
            double V_c;
            m = FindM(v);
            v += CountAcceleration(m, I) * dt;

            V_h = m * H_m + v * v * H_v;
            V_c = C * (ambientTemperature - CurentTemperature);
            CurentTemperature += (V_h + V_c);
        }

        private double FindM(double v)
        {
            int index = 0;
            for(int i = 1; i < V.Length; i++)
            {
                if (v <= V[i])
                {
                    index = i; 
                    break;
                }
            }

            return (v - V[index - 1]) / (V[index] - V[index - 1]) * (M[index] - M[index - 1]) + M[index - 1];

        } 

        private double CountAcceleration(double M, int I)
        {
            return M / I;
        }

        public void UploadParams()
        {
            throw new NotImplementedException();
        }

        public double GetV()
        {
            return v;
        }

        public double GetM()
        {
            return m;
        }

        public int GetLastVValue()
        {
            return V.Last();
        }
    }
}
