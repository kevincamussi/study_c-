using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste.Models;

namespace teste.Repositories
{
    public class UserRepository
    {
        private readonly ObservableCollection<User> _users;

        public UserRepository()
        {
            _users = new ObservableCollection<User>();
        }

        public ObservableCollection<User> GetUsers() => _users;

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void RemoveUser(User user)
        {
            _users.Remove(user);
        }
    }
}
