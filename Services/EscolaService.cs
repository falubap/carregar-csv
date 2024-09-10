using carregar_csv.Entities;
using carregar_csv.DAOs;
using Microsoft.Data.SqlClient;

namespace carregar_csv.Services
{
    //Classe responsável por implementar os métodos da interface EscolaDAO
    public class EscolaService : IEscolaDAO
    {
        //Declaração da string de conexão a ser utilizada para conectar ao banco de dados
        private readonly string connectionString;

        public EscolaService(string _connectionString)
        {
            connectionString = _connectionString;
        }
        
        //Cria o banco de dados a ser utilizado para receber os dados do arquivo CSV na tabela
        public void CriarDb(string nomeDb)
        {
            string query = $"IF DB_ID('{nomeDb}') IS NULL CREATE DATABASE {nomeDb}";

            using SqlConnection conn = new(connectionString);
            try
            {
            conn.Open();
            SqlCommand command = new(query, conn);
            command.ExecuteNonQuery();
            Console.WriteLine($"Banco de dados {nomeDb} criado com sucesso.");
            }
            catch(SqlException ex)
            {
                Console.WriteLine($"Erro ao tentar criar banco de dados {nomeDb}: {ex.Message}");
            }
        }

        //Cria a tabela a ser utilizada para receber os dados do arquivo CSV
        public void CriarTabela(string nomeDb)
        {
            string query = $@"
                USE {nomeDb};
                IF OBJECT_ID('dbo.Escolas', 'U') IS NULL
                CREATE TABLE dbo.Escolas (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Dre VARCHAR(255),
                    CodEsc VARCHAR(255),   
                    TipoEsc VARCHAR(255),
                    Nomes VARCHAR(255),
                    NomEscOfi VARCHAR(255),
                    Ceu VARCHAR(255),
                    Diretoria VARCHAR(255),
                    SubPref VARCHAR(255),
                    Endereco VARCHAR(255),
                    Numero VARCHAR(255),
                    Bairro VARCHAR(255),
                    Cep VARCHAR(255),
                    Tel_1 VARCHAR(255),
                    Tel_2 VARCHAR(255),
                    Fax VARCHAR(255),
                    Situacao VARCHAR(255),
                    CodDist VARCHAR(255),
                    Distrito VARCHAR(255),
                    Setor VARCHAR(255),
                    CodInep VARCHAR(255),
                    Cd_Cie VARCHAR(255),
                    Eh VARCHAR(255),
                    Fx_Etaria VARCHAR(255),
                    Dt_Criacao VARCHAR(255),
                    Ato_Criacao VARCHAR(255),
                    Dom_Criacao VARCHAR(255),
                    Dt_Ini_Conv VARCHAR(255),
                    Dt_Autoriza VARCHAR(255),
                    Dt_Extincao VARCHAR(255),
                    Nome_Ant VARCHAR(255),
                    Rede VARCHAR(255),
                    Latitude VARCHAR(255),
                    Longitude VARCHAR(255),
                    Data_base VARCHAR(255)
                )";

            using SqlConnection conn = new(connectionString);
            try
            {
            conn.Open();
            SqlCommand command = new(query, conn);
            command.ExecuteNonQuery();
            Console.WriteLine("Tabela dbo.Escolas criado com sucesso.");
            }
            catch(SqlException ex)
            {
                Console.WriteLine($"Erro ao tentar criar tabela dbo.Escolas: {ex.Message}");
            }
        }

        //Insere os dados lidos do arquivo CSV na tabela criada
        public void InserirEscola(string nomeDb, List<Escola> escolas)
        {
            string query = @"
                INSERT INTO escolas (Dre, CodEsc, TipoEsc, Nomes, NomEscOfi, Ceu, Diretoria, SubPref,
                Endereco, Numero, Bairro, Cep, Tel_1, Tel_2, Fax, Situacao, CodDist, Distrito, Setor,
                CodInep, Cd_Cie, Eh, Fx_Etaria, Dt_Criacao, Ato_Criacao, Dom_Criacao, Dt_Ini_Conv,
                Dt_Autoriza, Dt_Extincao, Nome_Ant, Rede, Latitude, Longitude, Data_base)
                VALUES (@Dre, @CodEsc, @TipoEsc, @Nomes, @NomEscOfi, @Ceu, @Diretoria, @SubPref,
                @Endereco, @Numero, @Bairro, @Cep, @Tel_1, @Tel_2, @Fax, @Situacao, @CodDist, @Distrito, @Setor,
                @CodInep, @Cd_Cie, @Eh, @Fx_Etaria, @Dt_Criacao, @Ato_Criacao, @Dom_Criacao, @Dt_Ini_Conv,
                @Dt_Autoriza, @Dt_Extincao, @Nome_Ant, @Rede, @Latitude, @Longitude, @Data_base);";

            using SqlConnection conn = new($"{connectionString}Database={nomeDb}");
            conn.Open();
            try{
                foreach(Escola escola in escolas)
                {
                    using SqlCommand command = new(query, conn);
                    command.Parameters.AddWithValue("@Dre", escola.Dre);
                    command.Parameters.AddWithValue("@CodEsc", escola.CodEsc);
                    command.Parameters.AddWithValue("@TipoEsc", escola.TipoEsc);
                    command.Parameters.AddWithValue("@Nomes", escola.Nomes);
                    command.Parameters.AddWithValue("@NomEscOfi", escola.NomEscOfi);
                    command.Parameters.AddWithValue("@Ceu", escola.Ceu);
                    command.Parameters.AddWithValue("@Diretoria", escola.Diretoria);
                    command.Parameters.AddWithValue("@SubPref", escola.SubPref);
                    command.Parameters.AddWithValue("@Endereco", escola.Endereco);
                    command.Parameters.AddWithValue("@Numero", escola.Numero);
                    command.Parameters.AddWithValue("@Bairro", escola.Bairro);
                    command.Parameters.AddWithValue("@Cep", escola.Cep);
                    command.Parameters.AddWithValue("@Tel_1", escola.Tel_1);
                    command.Parameters.AddWithValue("@Tel_2", escola.Tel_2);
                    command.Parameters.AddWithValue("@Fax", escola.Fax);
                    command.Parameters.AddWithValue("@Situacao", escola.Situacao);
                    command.Parameters.AddWithValue("@CodDist", escola.CodDist);
                    command.Parameters.AddWithValue("@Distrito", escola.Distrito);
                    command.Parameters.AddWithValue("@Setor", escola.Setor);
                    command.Parameters.AddWithValue("@CodInep", escola.CodInep);
                    command.Parameters.AddWithValue("@Cd_Cie", escola.Cd_Cie);
                    command.Parameters.AddWithValue("@Eh", escola.Eh);
                    command.Parameters.AddWithValue("@Fx_Etaria", escola.Fx_Etaria);
                    command.Parameters.AddWithValue("@Dt_Criacao", escola.Dt_Criacao);
                    command.Parameters.AddWithValue("@Ato_Criacao", escola.Ato_Criacao);
                    command.Parameters.AddWithValue("@Dom_Criacao", escola.Dom_Criacao);
                    command.Parameters.AddWithValue("@Dt_Ini_Conv", escola.Dt_Ini_Conv);
                    command.Parameters.AddWithValue("@Dt_Autoriza", escola.Dt_Autoriza);
                    command.Parameters.AddWithValue("@Dt_Extincao", escola.Dt_Extincao);
                    command.Parameters.AddWithValue("@Nome_Ant", escola.Nome_Ant);
                    command.Parameters.AddWithValue("@Rede", escola.Rede);
                    command.Parameters.AddWithValue("@latitude", escola.Latitude);
                    command.Parameters.AddWithValue("@Longitude", escola.Longitude);
                    command.Parameters.AddWithValue("@Data_base", escola.Data_base);

                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Dados inseridos na tabela dbo.Escolas com sucesso.");
            }
            catch(SqlException ex)
            {
                Console.WriteLine($"Erro ao inserir os dados na tabela dbo.Escolas: {ex.Message}");
            }
        }
    }
}