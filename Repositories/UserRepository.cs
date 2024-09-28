using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using teste.Models;

namespace teste.Repositories
{
    public class UserRepository
    {
        private readonly ObservableCollection<User> _users;
        private int _nextId;
        private readonly string _connectionString; ///

        private const string FilePath = "users.json";
        public UserRepository()
        {
            _users = new ObservableCollection<User>();
            _connectionString = "Server=localhost;Database=users;User ID=root;Password=ca7458990;SslMode=None;";
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
            //_users.Add(user);
            //SaveUsers();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                INSERT INTO usuarios (id, nome, email, cidade, regiao, cep, pais, telefone)
                VALUES (@Id, @Nome, @Email, @Cidade, @Regiao, @Cep, @Pais, @Telefone)";

                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@Nome", user.Name);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Cidade", user.City);
                    command.Parameters.AddWithValue("@Regiao", user.Region);
                    command.Parameters.AddWithValue("@Cep", user.PostalCode);
                    command.Parameters.AddWithValue("@Pais", user.Country);
                    command.Parameters.AddWithValue("@Telefone", user.Phone);

                    command.ExecuteNonQuery();
                    _users.Add(user);

                }

            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show($"Erro ao adicionar ao banco de dados  {ex.Number}: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Trate outras exceções
                System.Windows.MessageBox.Show($"Erro: {ex.Message}");
            }

        }

        //public void SaveUsers()
        //{
        //    try
        //    {
        //        var json = JsonConvert.SerializeObject(_users);
        //        File.WriteAllText(FilePath, json);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.MessageBox.Show($"Erro ao salvar dados {ex.Message}");
        //    }
        //}

        public void RemoveUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM usuarios WHERE id = @Id";
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.ExecuteNonQuery();

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    _users.Remove(user);
                }
                }
                    //_users.Remove(user);
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show($"Não foi possivel exclui os dados do banco de dados {ex.Number} {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Erro ao execurar a operação {ex.Message}");
            }
            //if (_users.Contains(user))
            //{
            //    _users.Remove(user);
            //    //SaveUsers();
            //}
            //else
            //{
            //    throw new InvalidOperationException("Usuário não encontrado");
            //}
        }

        public void LoadUsers()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM usuarios";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User()
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("nome"),
                                Email = reader.GetString("email"),
                                City = reader.GetString("cidade"),
                                Region = reader.GetString("regiao"),
                                PostalCode = reader.GetString("cep"),
                                Country = reader.GetString("pais"),
                                Phone = reader.GetString("telefone")
                            };
                            _users.Add(user);
                        }

                    }
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show($"Erro ao carregar dados do banco de dados {ex.Number} {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Erro {ex.Message}");
            }
            //try
            //{
            //    if (File.Exists(FilePath))
            //    {
            //        var json = File.ReadAllText(FilePath);
            //        var users = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
            //        if (users != null)
            //        {
            //            foreach (var user in users)
            //            {
            //                _users.Add(user);
            //            }
            //        }
            //        _nextId = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.MessageBox.Show($"Erro ao carregar dados {ex.Message}");
            //}
        }

        public bool UserExists(string name)
        {
            return _users.Any(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }


    }
}
