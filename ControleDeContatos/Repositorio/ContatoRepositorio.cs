using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly DataContext _dataContext;
        public ContatoRepositorio(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            // gravar no banco de dados
            _dataContext.Contato.Add(contato);
            _dataContext.SaveChanges();
            return contato;

        }
    }
}
