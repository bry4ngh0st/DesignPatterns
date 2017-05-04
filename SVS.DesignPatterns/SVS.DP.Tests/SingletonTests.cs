using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVS.DP.Tests
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void Main()
        {
            var singleton = new Singleton();

            Assert.IsNotNull(singleton.value);
        }

        // Creational Pattern
        internal class Singleton
        {
            public string value { get; set; }

            public Singleton()
            {
                if (value == null)
                    value = string.Empty;
            }
        }
    }
}
