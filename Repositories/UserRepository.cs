using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste.Models;

namespace teste.Repositories
{
    public class UserRepository
    {
        private readonly ObservableCollection<User> _users;
        private int _nextId;

        private const string FilePath = "users.json";
        public UserRepository()
        {
            _users = new ObservableCollection<User>();
            LoadUsers();
            _nextId = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
        }

        public ObservableCollection<User> GetUsers() => _users;

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
                user.Id = _nextId++;
                _users.Add(user);
                SaveUsers();
        }

        public void SaveUsers()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_users);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Erro ao salvar dados {ex.Message}");
            }
        }

        public void RemoveUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof (user));
            }
            if (_users.Contains(user))
            {
                _users.Remove(user);
                SaveUsers();
            }
            else
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }
        }

        public void LoadUsers()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var json = File.ReadAllText(FilePath);
                    var users = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
                    if (users != null)
                    {
                        foreach (var user in users)
                        {
                            _users.Add(user);
                        }
                    }
                    _nextId = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Erro ao carregar dados {ex.Message}");
            }
        }

    }
}
