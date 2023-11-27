﻿using System;

namespace CadEstoque
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string opcao;

            Console.WriteLine("[CADASTRO DE TAREFAS]");
            Console.WriteLine("=====================");
            Console.WriteLine();
            do
            {
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
                            var produtoInfo = Estoque.SolicitarInformacoesProduto();
                            Estoque.CadastrarProduto(produtoInfo);
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
