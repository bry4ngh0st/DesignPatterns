using SVS.DP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SVS.DP.Patterns.UnitOfWork
{
    public class UnitOfWork
    {
        public List<User> ExistingUsers { get; set; }

        private List<User> NewUsers = new List<User>();
        private List<User> UpdatedUsers = new List<User>();
        private List<User> RemovedUsers = new List<User>();

        public void AddUser(User user)
        {
            if (ExistingUsers.Contains(user))
                throw new Exception("User already exists.");

            if (user.IsValid())
                NewUsers.Add(user);
        }

        public void UpdateUser(User user)
        {
            if (!ExistingUsers.Contains(user))
                throw new Exception("Unexisting user cannot be updated.");

            if (user.IsValid())
                UpdatedUsers.Add(user);
        }

        public void RemoveUser(User user)
        {
            if (!ExistingUsers.Contains(user))
                throw new Exception("Unexisting user cannot be removed.");

            if (user.IsValid())
                RemovedUsers.Add(user);
        }

        public void Commit()
        {
            if (NewUsers.Any())
            {
                ExistingUsers.AddRange(NewUsers);
            }

            if (UpdatedUsers.Any())
            {
                foreach (var updatedUser in UpdatedUsers)
                    ExistingUsers.Remove(updatedUser);

                ExistingUsers.AddRange(UpdatedUsers);
            }

            foreach (var removedUser in RemovedUsers)
            {
                ExistingUsers.Remove(removedUser);
            }
        }
    }
}
