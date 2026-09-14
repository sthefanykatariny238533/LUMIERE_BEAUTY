namespace Lumiere_Beauty.Models
{
    public class Servico
    {
        public int id_servico { get; set; }

        public string nome_serv { get; set; }

        public string descricao { get; set; }

        public string preco { get; set; }

        public int id_categoria_fk { get; set; }
    }
}
