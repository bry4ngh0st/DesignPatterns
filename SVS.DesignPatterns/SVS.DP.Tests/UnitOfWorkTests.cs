using NUnit.Framework;
using SVS.DP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using SVS.DP.Patterns.UnitOfWork;

namespace SVS.DP.Tests
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private UnitOfWork _unitOfWork;

        [SetUp]
        public void SetUp()
        {
            var users = new List<User>();

            users.Add(new User { Id = 1, Name = "Percy", Address = string.Empty });
            users.Add(new User { Id = 2, Name = "Kevin", Address = string.Empty });
            users.Add(new User { Id = 3, Name = "Max", Address = string.Empty });            
            users.Add(new User { Id = 4, Name = "Arthur", Address = string.Empty });
            users.Add(new User { Id = 5, Name = "Carlos", Address = string.Empty });
            users.Add(new User { Id = 6, Name = "Yordy", Address = string.Empty });

            _unitOfWork = new UnitOfWork();

            _unitOfWork.ExistingUsers = users;
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
            var existingUser = _unitOfWork.ExistingUsers.Find(u => u.Id.Equals(1));

            Assert.Throws<Exception>(() => _unitOfWork.AddUser(existingUser));
        }

        [Test]
        public void WhenTryToUpdateUnexistingUserThrowsAnException()
        {
            var unexistingUser = new User() { Id = 100, Name = "Unknown" };

            Assert.Throws<Exception>(() => _unitOfWork.UpdateUser(unexistingUser));
        }

        [Test]
        public void WhenTryToRemoveUnexistingUserThrowsAnException()
        {
            var unexistingUser = new User() { Id = 100, Name = "Unknown"};

            Assert.Throws<Exception>(() => _unitOfWork.RemoveUser(unexistingUser));
        }

        [Test]
        public void Main()
        {
            var newUser = new User() { Id = 7, Name = "Nuevo" };
            var existingUser = _unitOfWork.ExistingUsers.Find(u => u.Id.Equals(1));
            existingUser.Name = "Percy Ivan";

            _unitOfWork.AddUser(newUser);
            _unitOfWork.UpdateUser(existingUser);

            _unitOfWork.Commit();

            Assert.IsTrue(_unitOfWork.ExistingUsers.Any(u => u.Id.Equals(7)));
            Assert.IsTrue(_unitOfWork.ExistingUsers.Find(u => u.Id.Equals(1)).Name.Equals("Percy Ivan"));
        }
    }
}
