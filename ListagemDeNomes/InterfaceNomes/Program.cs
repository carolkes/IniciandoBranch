using ListagemDeNomes.Controller;
using ListagemDeNomes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNomes
{
    class Program
    {
        static PessoasController nomes = new PessoasController();
        static void Main(string[] args)
        {
            MenuSistema();
            Console.ReadKey();
        }
        private static void ImprimeMenu()
        {
            Console.WriteLine("----Menu Sistema De Nomes----");
            Console.WriteLine("0 - Sair do Sistema");
            Console.WriteLine("1 - Listar Nomes");
            Console.WriteLine("2 - Inserir Nome");
        }
        private static void MenuSistema()
        {
            ImprimeMenu();

            var menuEscolhido = int.Parse(Console.ReadLine());

            while(menuEscolhido != 0)
            {
                switch (menuEscolhido)
                {
                    case 1:
                        ListarNome();
                        break;
                    case 2:
                       AddNomes();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do Sistema");
                        break;
                    default:
                        Console.WriteLine("Opção Inválida.");
                        break;
                }
                ImprimeMenu();
                menuEscolhido = int.Parse(Console.ReadLine());
                Console.Clear();
            }
        }
        private static void ListarNome()
        {
            Console.WriteLine("Lista De Nomes");
            nomes.GetPessoas()
                .ToList<Pessoa>()
                .ForEach(x =>
                Console.WriteLine($"Id: {x.Id} Nome:{x.Nome}"));

            Console.ReadKey();
        }
        private static void AddNomes()
        {
            Console.WriteLine("Adicionar Novo Nome No Sistema");
            Console.WriteLine("Digite o nome que deseja adicionar ao sistema:");
            var nomePessoa = Console.ReadLine();

            nomes.AddNomes(new Pessoa()
            {
                Nome = nomePessoa
            });

            Console.ReadKey();
        }
    }
}
