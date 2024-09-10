using carregar_csv.DAOs;
using carregar_csv.DAOImpls;
using carregar_csv.Entities;
using carregar_csv.Services;

namespace carregar_csv
{
    //Classe principal do programa
    //Cria uma instância da classe EscolaService e utiliza seus métodos
    //para realizar operações no banco de dados
    class Program
    {
        //String de conexãO
        //O parâmetro "Server" deve ser passado de acordo com a configuração da máquina
        //em que o programa está rodando 
        static readonly string connectionString = "Server=localhost\\sqlexpress; Integrated Security=true; Trusted_Connection=true; TrustServerCertificate=true;";

        static async Task Main()
        {
            string nomeDb = "EscolasDB";
            string csvUrl = "http://dados.prefeitura.sp.gov.br/dataset/8da55b0e-b385-4b54-9296-d0000014ddd5/resource/a12ad63d-d944-4e35-9aac-71a5ae0b7bdf/download/escolas122022.csv";

            try
            {
                IEscolaDAO escolaDAO = new EscolaDAOImpl(connectionString);
                LerCsvService lerCsvService = new();

                escolaDAO.CriarDb(nomeDb);
                escolaDAO.CriarTabela(nomeDb);

                List<Escola> escolas = await lerCsvService.buscarDados(csvUrl);

                escolaDAO.InserirEscola(nomeDb, escolas);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}