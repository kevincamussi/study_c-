using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfLogin.Data
{
    public class DataBaseManager
    {
        private string connectionString = "Server:localhost; Database=users User ID=root;Password=ca7458990";
    
        public void CreateDataBase()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "CREATE DATABASE IF NOT EXISTES users";
                    command.ExecuteNonQuery();
                    System.Windows.MessageBox.Show("Banco de dados ja criado ou ja existe");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar criar o banco de dados:");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro inesperado:");
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateTable()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS usuarios (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            nome VARCHAR(100) NOT NULL,
                            email VARCHAR(100) NOT NULL UNIQUE,
                            data_nascimento DATE
                        )";
                    command.ExecuteNonQuery();
                    Console.WriteLine("Tabela criada ou já existe.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar criar a tabela:");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro inesperado:");
                Console.WriteLine(ex.Message);
            }
        }
    
    
    
    
    
   
    
    
    
    }


}
