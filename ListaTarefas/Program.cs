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
            Console.WriteLine("=====================");
            Console.WriteLine();
            do
            {
                ItemTarefa item = new ItemTarefa();

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Cadastrar tarefa");
                Console.WriteLine("2. Listar tarefas");
                Console.WriteLine("3. Marcar como concluída");
                Console.WriteLine("4. Excluir tarefa");
                Console.WriteLine("5. Sair");
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
                            Console.Write("Informe o índice(Ex.: inicia em 0...) da tarefa a ser marcada como concluída: ");
                            if (int.TryParse(Console.ReadLine(), out int indice))
                            {
                                Item.MarcarComoConcluida(indice);
                                Item.Listar(); 
                            }
                            else
                            {
                                Console.WriteLine("Índice inválido.");
                            }
                            break;

                        case 4:
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

                        case 5:
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
