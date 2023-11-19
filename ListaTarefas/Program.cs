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
                    Console.Write("Opção: ");

                       if (int.TryParse(Console.ReadLine(), out int escolha))
                        {
                            Console.Write("Informe o índice da tarefa: ");
                            if (int.TryParse(Console.ReadLine(), out int indice))
                            {
                                switch (escolha)
                                {
                                    case 1:
                                        Item.MarcarComoConcluida(indice);
                                        break;

                                    case 2:
                                        Item.Excluir(indice);
                                        break;

                                    default:
                                        Console.WriteLine("Opção inválida.");
                                        break;
                                }

                                Item.Listar(); // Exibe a lista atualizada
                            }
                            else
                            {
                                Console.WriteLine("Índice inválido.");
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
            } while (opcao == "s");
        }
    }
}

