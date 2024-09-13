using System.Globalization;
using carregar_csv.Entities;
using CsvHelper;
using CsvHelper.Configuration;

namespace carregar_csv.Services
{
    //Classe responsável pelas atividades de leitura do arquivo CSV e
    //carregamento dos seus dados para uma tabela do tipo Escola
    public class LerCsvService
    {
        private static readonly HttpClient httpClient = new();

        //A operação é feita de forma assíncrona para permitir maior performance
        //e escalabilidade
        public async Task<List<Escola>> buscarDados(string url)
        {
            List<Escola> escolas = [];

            try
            {
                //Faz a requisição Http de forma não bloqueante e obtém o stream de modo assíncrono
                using HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
                var stream = await responseMessage.Content.ReadAsStreamAsync();

                using StreamReader reader = new(stream);
                using CsvReader csv = new(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    HasHeaderRecord = true
                });
                
                //Faz a leitura do cabeçalho do arquivo CSV sem carregar os seus dados para a tabela
                csv.Read();

                //Faz a leitura e o carregamento dos dados do arquivo CSV
                while (csv.Read())
                {
                    Escola escola = new()
                    {
                        Dre = csv.GetField<string>(0),
                        CodEsc = csv.GetField<int>(1),
                        TipoEsc = csv.GetField<string>(2),
                        Nomes = csv.GetField<string>(3),
                        NomEscOfi = csv.GetField<string>(4),
                        Ceu = csv.GetField<string>(5),
                        Diretoria = csv.GetField<string>(6),
                        SubPref = csv.GetField<string>(7),
                        Endereco = csv.GetField<string>(8),
                        Numero = csv.GetField<string>(9),
                        Bairro = csv.GetField<string>(10),
                        Cep = csv.GetField<int>(11),
                        Tel_1 = csv.GetField<string>(12),
                        Tel_2 = csv.GetField<string>(13),
                        Fax = csv.GetField<string>(14),
                        Situacao = csv.GetField<string>(15),
                        CodDist = csv.GetField<int>(16),
                        Distrito = csv.GetField<string>(17),
                        Setor = csv.GetField<int>(18),
                        CodInep = csv.GetField<string>(19),
                        Cd_Cie = csv.GetField<string>(20),
                        Eh = csv.GetField<string>(21),
                        Fx_Etaria = csv.GetField<string>(22),
                        Dt_Criacao = csv.GetField<string>(23),
                        Ato_Criacao = csv.GetField<string>(24),
                        Dom_Criacao = csv.GetField<string>(25),
                        Dt_Ini_Conv = csv.GetField<string>(26),
                        Dt_Autoriza = csv.GetField<string>(27),
                        Dt_Extincao = csv.GetField<string>(28),
                        Nome_Ant = csv.GetField<string>(29),
                        Rede = csv.GetField<string>(30),
                        Latitude = csv.GetField<float>(31),
                        Longitude = csv.GetField<float>(32),
                        Data_base = DateTime.ParseExact(csv.GetField<string>(33), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };
                    escolas.Add(escola);
                }
            }
            catch(HttpRequestException httpEx)
            {
                Console.WriteLine($"Erro na requisição HTTP: {httpEx.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro ao processar o arquivo CSV: {ex.Message}"); 
            }
            return escolas;
        }
    }
}