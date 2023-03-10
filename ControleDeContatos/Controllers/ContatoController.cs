using ControleDeContatos.Data;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;


namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio, DataContext context)
        {
            _contatoRepositorio = contatoRepositorio;
            this._context = context;
        }

        private readonly DataContext _context;


        public IActionResult Criar()
        {
           return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

           public IActionResult Apagar(int id)
        {
             try
            {
                {
                    bool apagado = _contatoRepositorio.Apagar(id);

                    if (apagado)
                    {
                        TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                    else
                    {
                        TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato";
                    }
                     
                    return RedirectToAction("Index");
                } 
            }

            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato. Tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contatos = _context.Contato.ToList( );
            return View( contatos );
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato. Tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
           
        }

        [HttpPost]
        public IActionResult Alterar (ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos alterar seu contato. Tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

           
           
        }
    }
}
