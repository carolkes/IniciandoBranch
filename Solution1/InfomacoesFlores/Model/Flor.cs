using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //adicionamos a referência de dattaAnnotations
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfomacoesFlores.Model
{
    public class Flor
    {
        [Key]//Primary key Identity(1,1)
        public int Id { get; set; }

        [MaxLength(30)]//Definido a quantidade de caracteres para o nome da flor
        [Required]//not null
        public string Nome { get; set; }

        [Required]//not null
        public int Quantidade { get; set; }
    }
}
