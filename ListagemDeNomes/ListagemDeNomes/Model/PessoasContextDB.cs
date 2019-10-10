using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListagemDeNomes.Model
{
    //tornar a classe púlica
    public class PessoasContextDB : DbContext //através do ':'definimos
        //nossa herança // Com o DbContext definimos que vamos herdar
                        //caixa de ferramentas do entity framework
    {
        //Definimos nossa tabela
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
