using System;
using CadEstoque;

namespace CadEstoque
{
    class Program
    {
        public static void Main(string[] args)
        {
            string opcao;

            Console.WriteLine("[SISTEMA DE GERENCIAMENTO DE ESTOQUE]");
            Console.WriteLine("=====================================");
            Console.WriteLine();
            do
            {
                Produto item = new Produto();

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine();
                Console.WriteLine("1. Cadastrar tarefa");
                Console.WriteLine("2. Exibir Estoque");
                Console.WriteLine("3. Sair");
                Console.WriteLine();

                Console.Write("Opção: ");

                if (int.TryParse(Console.ReadLine(), out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.WriteLine("Digite o código do Produto:");
                            if (int.TryParse(Console.ReadLine(), out int codigo))
                            {
                                item.Codigo = codigo;
                            }
                            Console.WriteLine();

                            Console.WriteLine("Digite o nome do Produto:");
                            item.Nome = Console.ReadLine();
                            Console.WriteLine();

                            Console.WriteLine("Digite a Quantidade do Produto:");
                            if (int.TryParse(Console.ReadLine(), out int quantidade))
                            {
                                item.Quantidade = quantidade;
                            }
                            Console.WriteLine();

                            Console.WriteLine("Digite o Preço do Produto:");
                            if (double.TryParse(Console.ReadLine(), out double preco))
                            {
                                item.Preco = preco;
                            }
                            Console.WriteLine();

                            Estoque.CadastrarProduto(item);
                            Console.WriteLine();
                            break;

                        case 2:
                            Console.WriteLine();
                            Estoque.ExibirEstoque();
                            Console.WriteLine();
                            break;

                        case 3:
                            Console.WriteLine("Saindo do programa.");
                            Console.WriteLine();
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            Console.WriteLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }

                Console.WriteLine("Deseja continuar: [s/n]");
                opcao = Console.ReadLine();
            } while (opcao.ToLower() == "s");
        }
    }
}