using EngineTest.src.SISController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sisController = new SISController();

            sisController.StartWork();
        }
    }
}
