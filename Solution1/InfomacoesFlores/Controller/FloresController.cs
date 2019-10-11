using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfomacoesFlores.Model;//foi adicionado referência pasta model

namespace InfomacoesFlores.Controller
{
    public class FloresController
    {
        //adicionando estância nova para context
        FloresContext contextDB = new FloresContext();

        /// <summary>
        /// Listagem das flores
        /// </summary>
        /// <returns>Retorna Lista de todas as flores</returns>
        public IQueryable<Flor> GetFlores()
        {
            return contextDB.Flores;
        }
        /// <summary>
        /// Inserindo as flores
        /// </summary>
        /// <param name="item">Insere novas flores no sistema</param>
        public void InserirFlor(Flor item)
        {
            contextDB.Flores.Add(item);
            contextDB.SaveChanges();
        }
        /// <summary>
        /// Ordena as flores
        /// </summary>
        /// <returns>Retorna lista ordenada da quantidade de flores da maior 
        /// para a menor</returns>
        public IQueryable<Flor> OrdenarFlor()
        {
            return contextDB.Flores.OrderByDescending(x => x.Quantidade);
        }
        /// <summary>
        /// Soma a quantidade total de flores
        /// </summary>
        /// <returns>retorna a soma totam da quantidade de flores</returns>
        public int SomaFlor()
        {
            return contextDB.Flores.Sum(x => x.Quantidade);
        }
       
        

    }
    
}
