using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Classes.Json;

namespace WebApplication1.Classes
{
    public class Database
    {

        private static string connString = "Server=127.0.0.1;Port=3306;Database=testeapi;User Id=root;Password=rafa2001;";

        public static void RegistrarErro(string app, string varTela, string varRotina, string varMensagem, string varRequisicao)
        {
            Console.WriteLine($"Erro: {varMensagem}");
        }
        
        public bool InserirMotorista(string nome, string cpf, DateTime dataNascimento, string endereco, string telefone, string email)
        {
            bool sucesso = false;

            try
            {
                using (MySqlConnection varConn = new MySqlConnection(connString))
                {
                    varConn.Open();

                    string query = @"INSERT INTO Motorista (Nome, CPF, DataNascimento, Endereco, Telefone, Email) 
                                     VALUES (@Nome, @CPF, @DataNascimento, @Endereco, @Telefone, @Email);"
                    ;

                    using (MySqlCommand varComm = new MySqlCommand(query, varConn))
                    {
                        // Adiciona os parâmetros à query
                        varComm.Parameters.AddWithValue("@Nome", nome);
                        varComm.Parameters.AddWithValue("@CPF", cpf);
                        varComm.Parameters.AddWithValue("@DataNascimento", dataNascimento.ToString("yyyy-MM-dd"));
                        varComm.Parameters.AddWithValue("@Endereco", endereco);
                        varComm.Parameters.AddWithValue("@Telefone", telefone);
                        varComm.Parameters.AddWithValue("@Email", email);

                        // Executa a query
                        varComm.ExecuteNonQuery();
                        sucesso = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, registra o erro
                RegistrarErro("WebApplication1", "Database.cs", "InserirMotorista", ex.Message, string.Empty);
                sucesso = false;
            }

            return sucesso;
        }

        public GetMotoristaResponse ListarTodosMotoristas()
        {
            GetMotoristaResponse response = new GetMotoristaResponse
            {
                Motoristas = new List<GetMotoristaResponse.MotoristasList>()
            };

            try
            {
                using (MySqlConnection varConn = new MySqlConnection(connString))
                {
                    varConn.Open();

                    string query = "SELECT * FROM Motorista;";

                    using (MySqlCommand varComm = new MySqlCommand(query, varConn))
                    {
                        using (MySqlDataReader reader = varComm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var motorista = new GetMotoristaResponse.MotoristasList
                                {
                                    MotoristaID = reader.GetInt32("MotoristaID"),
                                    Nome = reader.GetString("Nome"),
                                    CPF = reader.GetString("CPF"),
                                    DataNascimento = reader.GetDateTime("DataNascimento").ToString("yyyy-MM-dd"),
                                    Endereco = reader.IsDBNull(reader.GetOrdinal("Endereco")) ? null : reader.GetString("Endereco"),
                                    Telefone = reader.IsDBNull(reader.GetOrdinal("Telefone")) ? null : reader.GetString("Telefone"),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
                                    DataCadastro = reader.GetDateTime("DataCadastro").ToString("yyyy-MM-dd HH:mm:ss")
                                };

                                response.Motoristas.Add(motorista);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, registra o erro
                RegistrarErro("WebApplication1", "Database.cs", "ListarTodosMotoristas", ex.Message, string.Empty);
            }

            return response;
        }

        public GetFonteResponse ListarTodasFontes()
        {
            GetFonteResponse response = new GetFonteResponse
            {
                fontes = new List<GetFonteResponse.FontesList>()
            };

            try
            {
                using (MySqlConnection varConn = new MySqlConnection(connString))
                {
                    varConn.Open();

                    string query = "SELECT * FROM Fontes;";

                    using (MySqlCommand varComm = new MySqlCommand(query, varConn))
                    {
                        using (MySqlDataReader reader = varComm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var fonte = new GetFonteResponse.FontesList
                                {
                                    fonteID = reader.GetInt32("fonteID"),
                                    parametros = reader.GetString("parametros"),                                                           
                                };

                                response.fontes.Add(fonte);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, registra o erro
                RegistrarErro("WebApplication1", "Database.cs", "ListarTodosMotoristas", ex.Message, string.Empty);
            }

            return response;
        }

        public GetCarroResponse ListarTodosCarros()
        {
            GetCarroResponse response = new GetCarroResponse
            {
                Carros = new List<GetCarroResponse.CarrosList>()
            };

            try
            {
                using (MySqlConnection varConn = new MySqlConnection(connString))
                {
                    varConn.Open();

                    string query = "SELECT Carro.CarroID,Carro.Placa,Carro.Modelo,Carro.Marca,Carro.AnoFabricacao,Carro.Cor,Motorista.Nome AS MotoristaNome,Motorista.Email AS MotoristaEmail,Motorista.CPF AS MotoristaCPF FROM Carro INNER JOIN Motorista ON Carro.MotoristaID = Motorista.MotoristaID;";

                    using (MySqlCommand varComm = new MySqlCommand(query, varConn))
                    {
                        using (MySqlDataReader reader = varComm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var carro = new GetCarroResponse.CarrosList
                                {
                                    AnoFabricacao = reader.GetInt32("AnoFabricacao"),
                                    CarroID = reader.GetInt32("CarroID"),
                                    Cor = reader.GetString("Cor"),
                                    Marca = reader.GetString("Marca"),
                                    MotoristaCPF = reader.GetString("MotoristaCPF"),
                                    MotoristaEmail = reader.GetString("MotoristaEmail"),
                                    MotoristaNome = reader.GetString("MotoristaNome"),
                                    Placa=reader.GetString("Placa")                                    
                                };

                                response.Carros.Add(carro);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, registra o erro
                RegistrarErro("WebApplication1", "Database.cs", "ListarTodosMotoristas", ex.Message, string.Empty);
            }

            return response;
        }
    }

}

