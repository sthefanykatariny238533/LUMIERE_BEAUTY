namespace Lumiere_Beauty.Models
{
    public class Servico
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string descricao { get; set; }

        public string preco { get; set; }

        public int id_categoria_fk { get; set; }
    }
}
