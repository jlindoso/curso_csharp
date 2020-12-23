using curso_csharp.Model;
using Microsoft.EntityFrameworkCore;

namespace curso_csharp.Context
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options){

        }

        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}

    }
}