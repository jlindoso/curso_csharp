using System.Linq;
using curso_csharp.Context;
using curso_csharp.Model;
using Microsoft.AspNetCore.Mvc;

namespace curso_csharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController: ControllerBase
    {
        public Contexto _contexto { get; set; }

        public ProdutosController(Contexto contexto){
            _contexto = contexto;
        }

         [HttpGet]
         public ActionResult Get(){
             return Ok(_contexto.Produtos.Where(p=>p.Ativo==true).ToList());
         }

        [HttpPost]
         public ActionResult Post(Produto produto){
             _contexto.Produtos.Add(produto);
             _contexto.SaveChanges();
             return Ok(produto);
         }

         [HttpPut("{id}")]
         public ActionResult Put(int id, [FromBody] Produto produto){
             if(id != produto.Id)
                return BadRequest("Id Inválido");


            
            var prod = _contexto.Produtos.Find(id);
            prod.Nome = produto.Nome;
            prod.Ativo = produto.Ativo;
             _contexto.SaveChanges();
             return Ok(produto);
         }
         
         [HttpDelete("{id}")]
         public ActionResult Delete(int id){
            var prod = _contexto.Produtos.Find(id);
            prod.Ativo = false;
             _contexto.SaveChanges();
             return Ok("Deletado com sucesso!");
         }

    }
}