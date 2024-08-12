
using MySql.Data.MySqlClient;
using System.Data;

namespace ecommerce.PordutoAPI.Model
{
    public class MySqlContext
    {
        private readonly string _connectionString;

        public MySqlContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public async Task Criar(Produto produto)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre a conexão de forma assíncrona
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                                  INSERT INTO Produto (Codigo, Descricao, DepartamentoId, Preco, Status)
                                  VALUES (@codigo, @descricao, @departamentoId, @preco, @status)";

                    command.Parameters.AddWithValue("@codigo", produto.Codigo);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@departamentoId", produto.DepartamentoId);
                    command.Parameters.AddWithValue("@preco", produto.Preco);
                    command.Parameters.AddWithValue("@status", produto.Status);

                    await command.ExecuteNonQueryAsync(); // Executa o comando de forma assíncrona
                }
            }
        }

        

        public async Task Atualizar(Produto produto)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre a conexão de forma assíncrona
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                           UPDATE Produto 
                           SET 
                               Codigo = @codigo,
                               Descricao = @descricao,
                               DepartamentoId = @departamentoId,
                               Preco = @preco,
                               Status = @status
                           WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", produto.Id);
                    command.Parameters.AddWithValue("@codigo", produto.Codigo);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@departamentoId", produto.DepartamentoId);
                    command.Parameters.AddWithValue("@preco", produto.Preco);
                    command.Parameters.AddWithValue("@status", produto.Status);

                    await command.ExecuteNonQueryAsync(); // Executa o comando de forma assíncrona
                }
            }
        }
        public async Task<List<Produto>> Buscar()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Aguarda a abertura da conexão de forma assíncrona
                var command = connection.CreateCommand();
                command.CommandText = @"
                                SELECT p.Id, p.Codigo, p.Descricao, p.Preco, p.Status, 
                                d.Id AS DepartamentoId
                                FROM Produto p
                                JOIN Departamento d ON p.DepartamentoId = d.Id
                                where  p.Status = true";


                using (var reader = await command.ExecuteReaderAsync()) // Executa a leitura de forma assíncrona
                {
                    var produtos = new List<Produto>();
                    while (await reader.ReadAsync()) // Lê os resultados de forma assíncrona
                    {
                        produtos.Add(new Produto
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                            Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                            Preco = reader.GetDecimal(reader.GetOrdinal("Preco")),
                            Status = reader.GetBoolean(reader.GetOrdinal("Status")),
                            DepartamentoId = reader.GetInt32(reader.GetOrdinal("DepartamentoId")),
                        });
                    }

                    return produtos;
                }
            }
        }
        public async Task<Produto> BuscarPorId(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync(); 
                var command = connection.CreateCommand();
                command.CommandText = @"
                                SELECT p.Id, p.Codigo, p.Descricao, p.Preco, p.Status, 
                                d.Id AS DepartamentoId
                                FROM Produto p
                                JOIN Departamento d ON p.DepartamentoId = d.Id
                                WHERE p.Id = @Id and p.Status = true;";

                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Produto
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                            Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                            Preco = reader.GetDecimal(reader.GetOrdinal("Preco")),
                            Status = reader.GetBoolean(reader.GetOrdinal("Status")),
                            DepartamentoId = reader.GetInt32(reader.GetOrdinal("DepartamentoId")),
                        };
                    }
                    else
                    {
                        return new Produto();
                    } 
                }
            }
        }
        public async Task Deletar(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre a conexão de forma assíncrona
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                                     UPDATE Produto
                                     SET Status = @status
                                     WHERE Id = @id";

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@status", false);

                    await command.ExecuteNonQueryAsync(); // Executa o comando de forma assíncrona
                }
            }
        }
        public async Task<List<Departamento>> BuscarDepartamentos()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Aguarda a abertura da conexão de forma assíncrona
                var command = connection.CreateCommand();
                command.CommandText = @"
                                select *
                                from departamento";


                using (var reader = await command.ExecuteReaderAsync()) // Executa a leitura de forma assíncrona
                {
                    var produtos = new List<Departamento>();
                    while (await reader.ReadAsync()) // Lê os resultados de forma assíncrona
                    {
                        produtos.Add(new Departamento
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                            Descricao = reader.GetString(reader.GetOrdinal("Descricao"))
                        });
                    }

                    return produtos;
                }
            }
        }


        public async Task Seed()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                        INSERT INTO Departamento (Codigo, Descricao) VALUES
                        ('010', 'BEBIDAS'),
                        ('020', 'CONGELADOS'),
                        ('030', 'LATICINIOS'),
                        ('040', 'VEGETAIS')
                        ON DUPLICATE KEY UPDATE Descricao = VALUES(Descricao);";

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}