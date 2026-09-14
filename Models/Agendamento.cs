namespace Lumiere_Beauty.Models
{
    public class Agendamento
    {
        public int id_agend { get; set; }

        public  DateTime data_agend { get; set; } 

        public TimeOnly horario_agend { get; set; }

        public string status_agend { get; set; } 

        public int id_servico_fk { get; set; }

        public int id_profissional_fk { get; set; }

        public int id_cliente_fk { get; set; }
    }
}
