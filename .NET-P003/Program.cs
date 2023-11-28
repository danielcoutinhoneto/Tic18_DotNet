using System;

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
                Console.WriteLine("3. Pesquisar por palavra-chave");
                Console.WriteLine("4 -Saída de Produto");
                Console.WriteLine("0. Sair");
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
                            Console.WriteLine();
                            Console.WriteLine("Digite a palavra-chave para a pesquisa:");
                            string palavraChave = Console.ReadLine();
                            if (palavraChave != null)
                            {
                                Estoque.PesquisarPorPalavraChave(palavraChave);
                            }
                            Console.WriteLine();
                            break;

                        case 4:
                            Console.WriteLine("Digite o código ou nome do produto para dar baixa:");
                            string codigoOuNome = Console.ReadLine();
                            int quantidadeBaixa = Estoque.SolicitarInteiro("Digite a quantidade para dar baixa:");

                            Estoque.SaidaEstoque(codigoOuNome, quantidadeBaixa);
                        break;

                        case 0:
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