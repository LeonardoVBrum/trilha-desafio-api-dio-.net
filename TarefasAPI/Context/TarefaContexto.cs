using Microsoft.EntityFrameworkCore;
using TarefasAPI.Models;

namespace TarefasAPI.Context
{

    // Criamos uma herança da classe DBContext par centralizar nossas informações no banco.
    public class TarefaContexto : DbContext
    {
        // Criamos um construtor par que possamos passr nossas informações para a classe DBContext.
        public TarefaContexto(DbContextOptions<TarefaContexto> options) : base(options) { }
        // ele vai receber uma configuração .


        // Criamos uma propriedade com a classe tarefa qual vai ser nossa tabela no banco de dados.
         public DbSet<Tarefa> Tarefas { get; set; }


    }

   
}
