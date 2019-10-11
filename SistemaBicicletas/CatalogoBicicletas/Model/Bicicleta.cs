using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoBicicletas.Model
{
    public class Bicicleta : Controles
    {
        [Key]//Adicionar primary key e intentity (1,1)
        public int Id { get; set; }

        [MaxLength(30)]//Máximo de caracteres
        [Required]//not null
        public string Modelo { get; set; }

        [MaxLength(30)]
        [Required]
        public string Marca { get; set; }

        [Required]
        public double Valor { get; set; }
    }
}
