using NUnit.Framework;
using SVS.DP.Patterns.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVS.DP.Tests
{
    [TestFixture]
    public class BuilderTests
    {
        [Test]
        public void Main()
        {
            var shop = new Shop();

            var carBuilder = new CarBuilder();
            var bicycleBuilder = new BicycleBuilder();

            shop.Contruct(carBuilder);
            shop.Contruct(bicycleBuilder);
        }
    }
}
