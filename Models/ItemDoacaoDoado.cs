namespace AjudaCertaApi.Models
{
    public class ItemDoacaoDoado
    {
        public int idDoacao { get; set; }
        public Doacao Doacao { get; set; }
        public int idItem { get; set; }
        public ItemDoacao ItemDoacao { get; set; }
    }
}