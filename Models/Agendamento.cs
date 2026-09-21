namespace Lumiere_Beauty.Models
{
    public class Agendamento
    {
        public int id { get; set; }

        public  DateTime data { get; set; } 

        public TimeOnly horario { get; set; }

        public string status { get; set; } 

        public int id_servico_fk { get; set; }

        public int id_profissional_fk { get; set; }

        public int id_cliente_fk { get; set; }
    }
}
