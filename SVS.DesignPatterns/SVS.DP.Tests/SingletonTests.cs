using NUnit.Framework;
using SVS.DP.Patterns.Singleton;

namespace SVS.DP.Tests
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void Main()
        {
            var singleton = new Singleton();

            var property = singleton.GetProperty();

            Assert.IsNotNull(property);
        }
    }
}
