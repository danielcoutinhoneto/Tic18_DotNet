﻿using System;
using Namespace;

namespace listaTarefas
{
    class Program 
    {
        static void Main(string[] args)
        {
            string opcao;

            Console.WriteLine("[CADASTRO DE TAREFAS]");
            Console.WriteLine("=====================");
            Console.WriteLine();
            do
            {
                ItemTarefa item = new ItemTarefa();

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Cadastrar tarefa");
                Console.WriteLine("2. Listar todas as tarefas");
                Console.WriteLine("3. Listar tarefas concluídas");
                Console.WriteLine("4. Listar tarefas não concluídas");
                Console.WriteLine("5. Pesquisar por palavra-chave");
                Console.WriteLine("6. Marcar como concluída");
                Console.WriteLine("7. Excluir tarefa");
                Console.WriteLine("8. Sair");
                Console.WriteLine();
                
                Console.Write("Opção: ");

                if (int.TryParse(Console.ReadLine(), out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.WriteLine("Informe o título da tarefa:");
                            item.titulo = Console.ReadLine();

                            Console.WriteLine("Informe descrição da tarefa:");
                            item.descricao = Console.ReadLine();

                            Console.WriteLine("Qual a data de vencimento da tarefa?");
                            item.dataVencimento = DateTime.Parse(Console.ReadLine());

                            Item.Inserir(item);
                        break;

                        case 2:
                            Console.WriteLine("A lista das tarefas cadastradas é:");
                            Item.Listar();
                        break;
                        
                        case 3:
                            Item.ListarConcluidas();
                        break;

                        case 4:
                            Item.ListarNaoConcluidas();
                        break;

                        case 5:
                            Console.Write("Digite a palavra-chave para a pesquisa: ");
                            string palavraChave = Console.ReadLine();
                            Item.PesquisarPorPalavraChave(palavraChave);
                        break;

                        case 6:
                            Console.Write("Informe o índice(Ex.: inicia em 0...) da tarefa a ser marcada como concluída: ");
                            if (int.TryParse(Console.ReadLine(), out int indiceConclusao))
                            {
                                Item.MarcarComoConcluida(indiceConclusao);
                                Item.Listar(); 
                            }
                            else
                            {
                                Console.WriteLine("Índice inválido.");
                            }
                            break;

                        case 7:
                            Console.Write("Informe o índice(Ex.: inicia em 0...) da tarefa a ser excluída: ");
                            if (int.TryParse(Console.ReadLine(), out int indiceExclusao))
                            {
                                Item.Excluir(indiceExclusao);
                                Item.Listar(); 
                            }
                            else
                            {
                                Console.WriteLine("Índice inválido.");
                            }
                            break;

                        case 8:
                            Console.WriteLine("Saindo do programa.");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
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
