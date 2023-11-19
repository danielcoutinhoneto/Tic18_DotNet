using System;
using Namespace;

namespace listaTarefas
{
    class Program 
    {
        static void Main(string[] args)
        {
            string opcao;

            Console.WriteLine("[CADASTRO DE TAREFAS]");
            do {
                ItemTarefa item = new ItemTarefa();

                Console.WriteLine("Informe o título da tarefa:");
                item.titulo = Console.ReadLine();

                Console.WriteLine("Informe descrição da tarefa:");
                item.descricao = Console.ReadLine();

                Console.WriteLine("Qual a data de vencimento da tarefa?");
                item.dataVencimento = DateTime.Parse(Console.ReadLine());
                
                Item.Inserir(item);

                Console.WriteLine("Deseja adicionar mais tarefas: [s/n]");
                opcao = Console.ReadLine();

                switch(opcao) {
                    case "s":
                    Console.WriteLine("Adicione uma nova tarefa!");
                    break;

                    case "n":
                    Console.WriteLine("A lista das tarefas cadastradas são: ");
                    Console.WriteLine();
                    Item.Listar();
                    
                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1. Marcar como concluída");
                    Console.WriteLine("2. Excluir tarefa");
                    Console.WriteLine("3. Sair");
                    Console.Write("Opção: ");

                    if (int.TryParse(Console.ReadLine(), out int escolha))
                    {
                        switch (escolha)
                        {
                            case 1:
                                Console.Write("Informe o índice da tarefa a ser marcada como concluída: ");
                                if (int.TryParse(Console.ReadLine(), out int indice))
                                {
                                    Item.MarcarComoConcluida(indice);
                                    Item.Listar(); // Exibe a lista atualizada
                                }
                                else
                                {
                                    Console.WriteLine("Índice inválido.");
                                }
                                break;

                            case 2:
                                Console.Write("Informe o índice da tarefa a ser excluída: ");
                                if (int.TryParse(Console.ReadLine(), out int indiceExclusao))
                                {
                                    Item.Excluir(indiceExclusao);
                                    Item.Listar(); // Exibe a lista atualizada
                                }
                                else
                                {
                                    Console.WriteLine("Índice inválido.");
                                }
                                break;

                            case 3:
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
                        break;

                    default:
                        Console.WriteLine("O valor inserido é inválido!");
                    break;
                }
                
            } while (opcao == "s" || opcao == "n");
        }
    }
}