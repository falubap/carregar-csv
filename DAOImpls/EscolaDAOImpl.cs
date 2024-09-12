using carregar_csv.Entities;
using carregar_csv.DAOs;
using Microsoft.Data.SqlClient;

namespace carregar_csv.DAOImpls
{
    //Classe responsável por implementar os métodos da interface EscolaDAO
    public class EscolaDAOImpl : IEscolaDAO
    {
        //Declaração da string de conexão a ser utilizada para conectar ao banco de dados
        private readonly string connectionString;

        public EscolaDAOImpl(string _connectionString)
        {
            connectionString = _connectionString;
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