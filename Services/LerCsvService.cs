using System.Globalization;
using carregar_csv.Entities;
using CsvHelper;
using CsvHelper.Configuration;

namespace carregar_csv.Services
{
    public class LerCsvService
    {
        private static readonly HttpClient httpClient = new();

        public async Task<List<Escola>> buscarDados(string url)
        {
            List<Escola> escolas = [];

            try
            {
                using(HttpResponseMessage responseMessage = await httpClient.GetAsync(url))
                {
                    var stream = await responseMessage.Content.ReadAsStreamAsync();

                    using StreamReader reader = new(stream);
                    using(CsvReader csv = new(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";",
                        HasHeaderRecord = true
                    }))
                    {
                        while(csv.Read())
                        {
                            Escola escola = new()
                            {
                                Id = csv.GetField<int>("_id"),
                                Dre = csv.GetField<string>("DRE"),
                                CodEsc = csv.GetField<int>("CODESC"),
                                TipoEsc = csv.GetField<string>("TIPOESC"),
                                NomEscOfi = csv.GetField<string>("NOMESCOFI"),
                                Ceu = csv.GetField<string>("CEU"),
                                Diretoria = csv.GetField<string>("DIRETORIA"),
                                SubPref = csv.GetField<string>("SUBPREF"),
                                Endereco = csv.GetField<string>("ENDERECO"),
                                Numero = csv.GetField<int>("NUMERO"),
                                Bairro = csv.GetField<string>("BAIRRO"),
                                Cep = csv.GetField<int>("CEP"),
                                Tel_1 = csv.GetField<int>("TEL1"),
                                Tel_2 = csv.GetField<int>("TEL2"),
                                Fax = csv.GetField<int>("FAX"),
                                Situacao = csv.GetField<string>("SITUACAO"),
                                CodDist = csv.GetField<int>("CODDIST"),
                                Distrito = csv.GetField<string>("DISTRITO"),
                                Setor = csv.GetField<int>("SETOR"),
                                CodInep = csv.GetField<int>("CODINEP"),
                                Cd_Cie = csv.GetField<int>("CD_CIE"),
                                Eh = csv.GetField<int>("EH"),
                                Fx_Etaria = csv.GetField<string>("FX_ETARIA"),
                                Dt_Criacao = csv.GetField<DateTime>("DT_CRIACAO"),
                                Ato_Criacao = csv.GetField<string>("ATO_CRIACAO"),
                                Dom_Criacao = csv.GetField<DateTime>("DOM_CRIACAO"),
                                Dt_Ini_Conv = csv.GetField<string>("DT_INI_CONV"),
                                Dt_Autoriza = csv.GetField<string>("DT_AUTORIZA"),
                                Dt_Extincao = csv.GetField<string>("DT_EXTINCAO"),
                                Nome_Ant = csv.GetField<string>("NOME_ANT"),
                                Rede = csv.GetField<string>("REDE"),
                                Latitude = csv.GetField<string>("LATITUDE"),
                                Longitude = csv.GetField<string>("LONGITUDE"),
                                Database = csv.GetField<DateTime>("DATABASE")
                            };
                            escolas.Add(escola);
                        }
                    }  
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