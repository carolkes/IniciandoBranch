using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfomacoesFlores.Controller;
using InfomacoesFlores.Model;

namespace InterfaceFloricultura
{
    class Program
    {
        static FloresController flores = new FloresController();
        static void Main(string[] args)
        {
            MenuSistema();

            Console.ReadKey();
        }
        public static void ImprimeMenu()
        {
            Console.WriteLine("MENU SISTEMA FLORICULTURA");
            Console.WriteLine("0 - Sair do Sistema");
            Console.WriteLine("1 - Cadastrar Flor");
            Console.WriteLine("2 - Listar Flores");
            Console.WriteLine("3 - Relatório Flores");
        }
        public static void MenuSistema()
        {
            ImprimeMenu();

            var opcao = int.Parse(Console.ReadLine());

            while (opcao != 0)
            {
                Console.Clear();

                switch (opcao)
                { 
                    case 1:
                        InserirFlores();
                        break;
                    case 2:
                        ListarFlor();
                        break;
                    case 3:
                        OrdenaFlor();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
                ImprimeMenu();
                opcao = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Saindo do Sistema..");
        }
        public static void InserirFlores()
        {
            Console.WriteLine("---Cadastro De Flores No Sistema---");
            Console.WriteLine("Digite o nome da flor que seseja cadastrar");
            var nome = Console.ReadLine();

            Console.WriteLine("Informe a quantidade desta mesma flor:");
            var quantidade = int.Parse(Console.ReadLine());

            flores.InserirFlor(new Flor()
            {
                Nome = nome,
                Quantidade = quantidade
            });

            Console.WriteLine("Flor Cadastrada Com Sucesso");

            Console.ReadKey();
        }
        public static void ListarFlor()
        {
            Console.WriteLine("---Listagem De Flores---");

            flores.GetFlores().ToList<Flor>()
                .ForEach(x => Console.WriteLine
                ($"Id: {x.Id} -- Flor: {x.Nome} -- Quantidade: {x.Quantidade} unidades"));

            Console.ReadKey();
        }
        public static void OrdenaFlor()
        {
            Console.WriteLine("**Lista De Flores Ordenada**");

            flores.OrdenarFlor().ToList<Flor>().
                ForEach(x =>
                Console.WriteLine($"Id: {x.Id} -- Flor: {x.Nome} -- Quantidade: {x.Quantidade} Mudas"));

            Console.WriteLine(
                $"Total Quantidade de Flores: {flores.SomaFlor()}");
  
            Console.ReadKey();
        }
        
    }
}
