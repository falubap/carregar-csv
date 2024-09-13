using System.Globalization;
using System.Text.RegularExpressions;
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

        //método para tratar casos de text armazenado em campos numeric
        private int? ParseIntField(string field)
        {
            string cleannedField = Regex.Replace(field, "[^0-9]", "");

            if(int.TryParse(cleannedField, out int result))
                return result;
            else
                return null;
        }

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
                        Numero = ParseIntField(csv.GetField<string>(9)),
                        Bairro = csv.GetField<string>(10),
                        Cep = csv.GetField<int>(11),
                        Tel_1 = csv.GetField<string>(12),
                        Tel_2 = csv.GetField<string>(13),
                        Fax = ParseIntField(csv.GetField<string>(14)),
                        Situacao = csv.GetField<string>(15),
                        CodDist = csv.GetField<int>(16),
                        Distrito = csv.GetField<string>(17),
                        Setor = csv.GetField<int>(18),
                        CodInep = string.IsNullOrEmpty(csv.GetField<string>(19)) ? null : csv.GetField<int>(19),
                        Cd_Cie = string.IsNullOrEmpty(csv.GetField<string>(20)) ? null : csv.GetField<int>(20),
                        Eh = string.IsNullOrEmpty(csv.GetField<string>(21)) ? null : csv.GetField<float>(21),
                        Fx_Etaria = csv.GetField<string>(22),
                        Dt_Criacao = string.IsNullOrEmpty(csv.GetField<string>(23)) ? null : DateTime.ParseExact(csv.GetField<string>(23), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Ato_Criacao = csv.GetField<string>(24),
                        Dom_Criacao = string.IsNullOrEmpty(csv.GetField<string>(25)) ? null : DateTime.ParseExact(csv.GetField<string>(25), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Dt_Ini_Conv = csv.GetField<string>(26),
                        Dt_Autoriza = csv.GetField<string>(27),
                        Dt_Extincao = string.IsNullOrEmpty(csv.GetField<string>(28)) ? null : csv.GetField<int>(28),
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