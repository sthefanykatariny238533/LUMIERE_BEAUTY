using System.ComponentModel.DataAnnotations;

namespace Lumiere_Beauty.Models
{
    public class Servico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do serviço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório.")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public int IdCategoria { get; set; }
    }
}