using System;

namespace SVS.DP.Patterns.Builder
{
    public class CarBuilder : Builder
    {
        public override void Build()
        {
            Console.WriteLine("Building a car");
        }
    }
}
