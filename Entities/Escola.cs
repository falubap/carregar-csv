namespace carregar_csv.Entities
{
    // Classe de modelo que representa a entidade Escola
    // Implementa as propriedades da entidade, que correspondem aos
    // campos do arquivo CSV a ser lido
    public class Escola
    {
        public int Id { get; set; }
        public string Dre { get; set; }
        public int CodEsc { get; set; }
        public string TipoEsc { get; set; }
        public string Nomes { get; set; }
        public string NomEscOfi { get; set; }
        public string Ceu { get; set; }
        public string Diretoria { get; set; }
        public string SubPref { get; set; }
        public string Endereco { get; set; }
        public int? Numero { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public string Tel_1 { get; set; }
        public string Tel_2 { get; set; }
        public int? Fax { get; set; }
        public string Situacao { get; set; }
        public int CodDist { get; set; }
        public string Distrito { get; set; }
        public int Setor { get; set; }
        public int? CodInep { get; set; }
        public int? Cd_Cie { get; set; }
        public float? Eh { get; set; }
        public string Fx_Etaria { get; set; }
        public DateTime? Dt_Criacao { get; set; }
        public string Ato_Criacao { get; set; }
        public DateTime? Dom_Criacao { get; set; }
        public string Dt_Ini_Conv { get; set; }
        public string Dt_Autoriza { get; set; }
        public int? Dt_Extincao { get; set; }
        public string Nome_Ant { get; set; }
        public string Rede { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime Data_base { get; set; }
    }       
}