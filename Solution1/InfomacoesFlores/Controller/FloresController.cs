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

        //Listando as flores
        public IQueryable<Flor> GetFlores()
        {
            return contextDB.Flores;
        }
        /// <summary>
        /// inserindo as flores
        /// </summary>
        /// <param name="item"></param>
        public void InserirFlor(Flor item)
        {
            contextDB.Flores.Add(item);
            contextDB.SaveChanges();
        }
        public IQueryable<Flor> OrdenarFlor()
        {
            return contextDB.Flores.OrderByDescending(x => x.Quantidade);
        }
        public int SomaFlor()
        {
            return contextDB.Flores.Sum(x => x.Quantidade);
        }
       
        

    }
    
}
