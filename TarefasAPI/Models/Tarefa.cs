namespace TarefasAPI.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Date { get; set; }
        public bool Finalizada { get; set; }
    }
}
