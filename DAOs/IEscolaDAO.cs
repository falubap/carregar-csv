using carregar_csv.Entities;

namespace carregar_csv.DAOs
{
    // Interface DAO para a entidade Escola
    // Declara os métodos da entidade Escola 
    public interface IEscolaDAO
    {
        public void InserirEscola(string nomeDb, List<Escola> escolas);
    }
}