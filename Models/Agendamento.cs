using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Lumiere_Beauty.Models
{
    public class Agendamento
    {
        public int id { get; set; }


        [Required(ErrorMessage = "A data do agendamento é obrigatória.")]        
        public DateOnly? data { get; set; }

        [Required(ErrorMessage = "O horário do agendamento é obrigatório.")]
        public TimeOnly horario { get; set; }

        [Required(ErrorMessage = "O status do agendamento é obrigatório.")]
        [StringLength(200, ErrorMessage ="O status deve ter no máximo 200 caracteres.")]
        public string status { get; set; }

        [Required(ErrorMessage = "O id do serviço é obrigatório.")]
        public int id_servico_fk { get; set; }

        [Required(ErrorMessage = "O id do profissional é obrigatório.")]
        public int id_profissional_fk { get; set; }

        [Required(ErrorMessage = "O id do cliente é obrigatório.")]
        public int id_cliente_fk { get; set; }
    }
}
