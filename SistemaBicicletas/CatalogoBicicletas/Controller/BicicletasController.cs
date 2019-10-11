using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoBicicletas.Model;

namespace CatalogoBicicletas.Controller
{
    public class BicicletasController
    {
        BicicletasContext contextDB = new BicicletasContext();

        /// <summary>
        /// Listagem
        /// </summary>
        /// <returns>Retorna listagem de bicicletas</returns>
        public IQueryable<Bicicleta> GetBicicletas()
        {
            return contextDB.Bicicletas
                .Where(x => x.Ativo == true);
        }
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="item">Insere nova item na lista</param>
        public bool InserirBicicleta(Bicicleta item)
        {
            if (string.IsNullOrWhiteSpace(item.Modelo))
                return false;

            if (string.IsNullOrWhiteSpace(item.Marca))
                return false;

            if (item.Valor <= 0)
                return false;

            contextDB.Bicicletas.Add(item);
            contextDB.SaveChanges();

            return true;
        }
        /// <summary>
        /// Remover
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Removem bicicleta da lista por comparação de id</returns>
        public bool RemoverBicicleta(int id)
        {
            var bicicleta = contextDB.Bicicletas
                .FirstOrDefault(x => x.Id == id);

            if (bicicleta == null)
                return false;

            bicicleta.Ativo = false;

            contextDB.SaveChanges();

            return true;
        }
        /// <summary>
        /// Atualiza
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Método que atualiza item de nossa lista Bicicletas</returns>
        public bool AtualizaBicicleta(Bicicleta item)
        {
            var bicicleta = contextDB.Bicicletas
                .FirstOrDefault(x => x.Id == item.Id);

            if (bicicleta == null)
                return false;
            else
            {
                item.DataAlteracao = DateTime.Now;
            }

            contextDB.SaveChanges();

            return true;
        }
        public IQueryable<Bicicleta> OrderBicicleta()
        {
            return contextDB.Bicicletas.OrderByDescending(x => x.Valor);
        }
        public double SomaValor()
        {
            return contextDB.Bicicletas.Sum(x => x.Valor);
        }
    }
}
