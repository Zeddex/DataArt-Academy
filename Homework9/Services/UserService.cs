using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework9.Entities;

namespace Homework9.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }

    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Login = "test", Password = "test" }
        };

        public async Task<User> Authenticate(string login, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Login == login && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            return user.WithoutPassword();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _users.WithoutPasswords());
        }
    }
}
