using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasAPI.Models;
using TarefasAPI.Context;
using Microsoft.Identity.Client;

namespace TarefasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaContexto _context;
        public TarefaController(TarefaContexto context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarTarefa(Tarefa tarefa )
        {
            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
            
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
           
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);
            

            if(tarefaBanco == null)
            {
                return NotFound();
            }

            tarefaBanco.Nome = tarefa.Nome;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Finalizada = tarefa.Finalizada;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();
            return Ok(tarefaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTarefa(int id) 
        {
            var deletarTarefa = _context.Tarefas.Find(id);

            if(deletarTarefa == null) 
            {
                return NotFound();
            }

            _context.Tarefas.Remove(deletarTarefa);
            return NoContent();
            
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos(string nome)
        {
            var tarefa = _context.Tarefas.ToList();
            return Ok(tarefa);

        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefa = _context.Tarefas.Where(x => x.Descricao.ToUpper().Contains(titulo.ToUpper())).ToList();
            return Ok(tarefa);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Date.Date == data.Date);
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(bool status)
        {
            var tarefa = _context.Tarefas.Where(x => x.Finalizada == status);
            return Ok(tarefa);
        }








        


    }
}




