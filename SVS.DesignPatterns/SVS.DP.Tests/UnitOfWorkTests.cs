using NUnit.Framework;
using SVS.DP.UnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVS.DP.Tests
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private List<User> users;

        [SetUp]
        public void SetUp()
        {
            users = new List<User>();
            users.Add(new User { Id = 1, Name = "Percy", Address = string.Empty });
        }

        [TestCase(1, "Percy")]
        [TestCase(2, "Kevin")]
        public void WhenUserHasCorrectDataValidationReturnsTrue(int id, string name)
        {
            var validUser = new User { Id = id, Name = name };

            Assert.IsTrue(validUser.IsValid());
        }

        [TestCase(0, "Percy")]
        [TestCase(1, "")]
        public void WhenUserHasIncorrectDataValidationReturnsFalse(int id, string name)
        {
            var invalidUser = new User { Id = id, Name = name };

            Assert.Throws<Exception>(() => invalidUser.IsValid());
        }

        [Test]
        public void Main()
        {
            var user = new User();
        }
    }
}
