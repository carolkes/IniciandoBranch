using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListagemDeNomes.Model
{
    //primeiro passo - deixar a classe pública
    public class Pessoa
    {
        [Key]//Adicionei Primary Key and Identity(1,1)
        public int Id { get; set; }
        [MaxLength(50)]//Limite máximo de 50 cararcetres
        [Required]//no null
        public string Nome { get; set; }
    }
}
