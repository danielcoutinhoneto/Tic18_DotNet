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
                            Console.WriteLine();

                            Console.WriteLine("Informe descrição da tarefa:");
                            item.descricao = Console.ReadLine();
                            Console.WriteLine();

                            Console.WriteLine("Qual a data de vencimento da tarefa? (Ex.: xx/xx/xxxx ou xx/xx/xx)");
                            item.dataVencimento = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine();

                            Item.Inserir(item);
                            Console.WriteLine();
                        break;

                        case 2:
                            Console.WriteLine();
                            Item.Listar();
                            Console.WriteLine();
                        break;
                        
                        case 3:
                            Console.WriteLine();
                            Item.ListarConcluidas();
                            Console.WriteLine();
                        break;

                        case 4:
                            Console.WriteLine();
                            Item.ListarNaoConcluidas();
                            Console.WriteLine();
                        break;

                        case 5:
                            Console.WriteLine();
                            Console.WriteLine("Digite a palavra-chave para pesquisa: ");
                            string palavraChave = Console.ReadLine();
                            Item.PesquisarPorPalavraChave(palavraChave);
                            Console.WriteLine();
                        break;

                        case 6:
                            Console.WriteLine();
                            Console.WriteLine("Informe o índice da tarefa a ser marcada como concluída: (Ex.: O indice inicia em 0...)");
                            if (int.TryParse(Console.ReadLine(), out int indiceConclusao))
                            {
                                Item.MarcarComoConcluida(indiceConclusao);
                                Item.Listar(); 
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Índice inválido.");
                                Console.WriteLine();
                            }
                        break;

                        case 7:
                            Console.WriteLine();
                            Console.WriteLine("Informe o índice da tarefa a ser excluída: (Ex.: O indice inicia em 0...)");
                            if (int.TryParse(Console.ReadLine(), out int indiceExclusao))
                            {
                                Item.Excluir(indiceExclusao);
                                Item.Listar(); 
                                Console.WriteLine();

                            }
                            else
                            {
                                Console.WriteLine("Índice inválido.");
                                Console.WriteLine();
                            }
                        break;

                        case 8:
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
