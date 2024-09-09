using carregar_csv.Entities;

namespace carregar_csv.DAOs
{
    public interface IEscolaDAO
    {
        public void CriarDb(string nomeDb);
        public void CriarTabela(string nomeDb);
        public void InserirEscola(string nomeDb, List<Escola> escolas);
    }
}