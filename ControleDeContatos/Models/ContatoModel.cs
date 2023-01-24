using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        [Key]
        public int Id { get; set; }
        public string  Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
    }
}
