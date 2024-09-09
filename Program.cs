using carregar_csv.DAOs;
using carregar_csv.Entities;
using carregar_csv.Services;

namespace carregar_csv
{
    class Program
    {
        static readonly string connectionString = "Server=localhost;Integrated Security=true;";

        static async Task Main()
        {
            string nomeDb = "EscolasDB";
            string csvUrl = "http://dados.prefeitura.sp.gov.br/dataset/cadastro-de-escolas-municipais-conveniadas-e-privadas/resource/a12ad63d-d944-4e35-9aac-71a5ae0b7bdf";

            try
            {
                IEscolaDAO escolaDAO = new EscolaService(connectionString);
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