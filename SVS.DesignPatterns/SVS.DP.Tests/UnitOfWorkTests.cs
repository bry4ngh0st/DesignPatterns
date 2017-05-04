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
        private UnitOfWork.UnitOfWork unitOfWork;

        [SetUp]
        public void SetUp()
        {
            users = new List<User>();

            users.Add(new User { Id = 1, Name = "Percy", Address = string.Empty });
            users.Add(new User { Id = 2, Name = "Kevin", Address = string.Empty });
            users.Add(new User { Id = 3, Name = "Max", Address = string.Empty });            
            users.Add(new User { Id = 4, Name = "Arthur", Address = string.Empty });
            users.Add(new User { Id = 5, Name = "Carlos", Address = string.Empty });
            users.Add(new User { Id = 6, Name = "Yordy", Address = string.Empty });

            unitOfWork = new UnitOfWork.UnitOfWork();

            unitOfWork.ExistingUsers = users;
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
        public void WhenUserHasIncorrectDataValidationThrowsAnException(int id, string name)
        {
            var invalidUser = new User { Id = id, Name = name };

            Assert.Throws<Exception>(() => invalidUser.IsValid());
        }

        [Test]
        public void WhenUserAlreadyExistsAddFeatureThrowsAnException()
        {
            var existingUser = unitOfWork.ExistingUsers.Find(u => u.Id.Equals(1));

            Assert.Throws<Exception>(() => unitOfWork.AddUser(existingUser));
        }

        [Test]
        public void Main()
        {
            
        }
    }
}
