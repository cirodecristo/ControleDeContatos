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

        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
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
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
