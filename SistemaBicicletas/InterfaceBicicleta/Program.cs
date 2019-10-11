using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoBicicletas.Model;
using CatalogoBicicletas.Controller;


namespace InterfaceBicicleta
{
    class Program
    {
        static BicicletasController bicicletas = new BicicletasController();
        static void Main(string[] args)
        {
            MenuSistema();
            Console.ReadKey();
        }
        public static void ImprimeMenu()
        {
            Console.WriteLine("**MENU SISTEMA DE BICICLETAS**");
            Console.WriteLine("1 - Cadastrar Bicicleta");
            Console.WriteLine("2 - Atualizar Bicicleta");
            Console.WriteLine("3 - Remover Bicicleta");
            Console.WriteLine("4 - Listar Bicicleta");
            Console.WriteLine("5 - Relatório Bicicleta");
            Console.WriteLine("0 - Sair Do Sistema");
        }
        public static void MenuSistema()
        {
            ImprimeMenu(); 

            var opcao = int.Parse(Console.ReadLine());

            while (opcao != 0)
            {
                Console.Clear(); 

                switch(opcao)
                {
                    case 1:
                        InsereBicicleta();
                        break;
                    case 2:
                        AtualizaBicicleta();
                        break;
                    case 3:
                        RemoveBicicleta();
                        break;
                    case 4:
                        ListarBicicleta();
                        break;
                    case 5:
                        OrdenaBicicleta();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
                
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial");
                Console.ReadKey(true);
                ImprimeMenu();
                opcao = int.Parse(Console.ReadLine());
            }

        }
        public static void InsereBicicleta()
        {
            Console.WriteLine("**Cadastar Nova Bicicleta**");
            Console.WriteLine("Insira o Modelo da Bicicleta:");
            var modelo = Console.ReadLine();

            Console.WriteLine("Insira a Marca da Bicicleta:");
            var marca = Console.ReadLine();

            Console.WriteLine("Insira o Valor da Bicicleta:");
            var valor = double.Parse(Console.ReadLine());

            var resultado = bicicletas.InserirBicicleta(new Bicicleta()
            {
                Modelo = modelo,
                Marca = marca,
                Valor = valor
            });

            if (resultado)
                Console.WriteLine("Bicicleta Cadastrada Com Sucesso!");
            else
                Console.WriteLine("Erro Ao Cadastrar!");

            Console.ReadKey();
        }
        public static void AtualizaBicicleta()
        {
            Console.WriteLine("**Atualizar Bicicleta Cadastrada**");
            bicicletas.GetBicicletas()
                .ToList<Bicicleta>()
                .ForEach(x => Console.WriteLine(
                    $"Id: {x.Id} - Modelo: {x.Modelo} - Marca: {x.Marca} - Valor: {x.Valor}"));

            Console.WriteLine("Informe o Id para alteração no registro:");
            var bicicletaId = int.Parse(Console.ReadLine());

            var bicicleta = bicicletas.GetBicicletas()
                .FirstOrDefault(x => x.Id == bicicletaId);

            if (bicicleta == null)
            {
                Console.WriteLine("Id Inválido!");
                return;
            }

            Console.WriteLine("Informe o Modelo da Bicicleta:");
            bicicleta.Modelo = Console.ReadLine();

            Console.WriteLine("Informe a Marca da Bicicleta:");
            bicicleta.Marca = Console.ReadLine();

            Console.WriteLine("Informe o Valor da Bicicleta");
            bicicleta.Valor = double.Parse(Console.ReadLine());

            var resultado = bicicletas.AtualizaBicicleta(bicicleta);

            if (resultado)
                Console.WriteLine("Bicicleta Atualizada Com Sucesso!");
            else
                Console.WriteLine("Erro Ao Atualizar!");

            Console.ReadKey();
        }
        public static void RemoveBicicleta()
        {
            Console.WriteLine("**Remover Bicicleta**");

            bicicletas.GetBicicletas()
                .ToList<Bicicleta>()
                .ForEach(x => Console.WriteLine($"Id: {x.Id} - Modelo: {x.Modelo} - Marca {x.Marca} - Valor: {x.Valor}"));

            Console.WriteLine("Informe o Id da bicicleta que deseja remover:");
            var bicicletaId = int.Parse(Console.ReadLine());

            var resposta = bicicletas.RemoverBicicleta(bicicletaId);

            if (resposta)
                Console.WriteLine("Bicicleta Removida Com Sucesso!");
            else
                Console.WriteLine("Erro Ao Remover!");

            Console.ReadKey();
        }
        public static void ListarBicicleta()
        {
            Console.WriteLine("**Listagem Bicicletas**");
            bicicletas.GetBicicletas()
                .ToList<Bicicleta>()
                .ForEach(x => Console.WriteLine(
                    $"Id: {x.Id} - Modelo: {x.Modelo} - Marca: {x.Marca} - Valor: {x.Valor}"));

            Console.ReadKey();
        }
        public static void OrdenaBicicleta()
        {
            Console.WriteLine("**Relatório De Bicicletas**");

            bicicletas.OrderBicicleta()
                .ToList<Bicicleta>()
                .ForEach(x => 
                Console.WriteLine($"Id: {x.Id} - Modelo: {x.Modelo} - Marca: {x.Marca} - Valor: {x.Valor}"));

            Console.WriteLine($"Valor Total:{bicicletas.SomaValor()}");

            Console.ReadKey();
        }

    }
}
