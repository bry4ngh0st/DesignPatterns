using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVS.DP.Patterns.Builder
{
    public class BicycleBuilder : Builder
    {
        public override void Build()
        {
            Console.WriteLine("Building a bicycle");
        }
    }
}
