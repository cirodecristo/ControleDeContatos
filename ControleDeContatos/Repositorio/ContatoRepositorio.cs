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

        public ContatoModel ListarPorId(int id)
        {
           return _dataContext.Contato.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null)
            {
                throw new Exception("Houve um erro na atualização do contato");
            }

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _dataContext.Contato.Update(contatoDB);
            _dataContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null)
            {
                throw new Exception("Houve um erro na deleção do contato");
                _dataContext.Contato.Remove(contatoDB);
                _dataContext.SaveChanges();
                return true;


            }

        }
    }
}
