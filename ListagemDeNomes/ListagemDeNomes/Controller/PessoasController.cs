using ListagemDeNomes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListagemDeNomes.Controller
{
    //usar nossa pasta model
    //adicionar instância nova para contextDB
    //tornar pública
    public class PessoasController
    {
        static PessoasContextDB contextDB = new PessoasContextDB();

        public IQueryable<Pessoa> GetPessoas()
        {
            //retorna os nomes dentro do sistema
            return contextDB.Pessoas;
        }
        public void AddNomes(Pessoa item)
        {
            //adiciona novos nomes no sistema
            contextDB.Pessoas.Add(item);
            //salva no nosso banco de dados
            contextDB.SaveChanges();
        }
    }
}
