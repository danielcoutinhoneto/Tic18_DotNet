using System;

namespace CadEstoque
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string opcao;

            Console.WriteLine("[SISTEMA DE GERENCIAMENTO DE ESTOQUE]");
            Console.WriteLine("=====================================");
            Console.WriteLine();
            do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine();
                Console.WriteLine("1.  CADASTRO DE PRODUTO ");
                Console.WriteLine("2.  LISTAGEM DE PRODUTO ");
                Console.WriteLine("3.  PESQUISA DE PRODUTO ");
                Console.WriteLine("4.  SAÍDA DE PRODUTO ");
                Console.WriteLine("5.  RELATÓRIO DE QUANTIDADE ABAIXO ");
                Console.WriteLine("6.  RELATÓRIO DE VALORES MIN/MAX ");
                Console.WriteLine("7.  RELATÓRIO DE VALORES TOTAIS  ");
                Console.WriteLine("0.           SAIR   ");
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

                        case 5:
                            Console.Write("Informe o limite de quantidade: ");
                            if (int.TryParse(Console.ReadLine(), out int limiteQuantidade))
                            {
                                Estoque.RelQuantAbxLimite(limiteQuantidade);
                            }
                            else
                            {
                                Console.WriteLine("Limite inválido.");
                            }
                            Console.WriteLine();
                            break;

                        case 6:
                            Console.Write("Informe o valor mínimo: ");
                            if (double.TryParse(Console.ReadLine(), out double valorMinimo))
                            {
                                Console.Write("Informe o valor máximo: ");
                                if (double.TryParse(Console.ReadLine(), out double valorMaximo))
                                {
                                    Estoque.RelValorEntreMinMax(valorMinimo, valorMaximo);
                                }
                                else
                                {
                                    Console.WriteLine("Valor máximo inválido.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Valor mínimo inválido.");
                            }
                            Console.WriteLine();
                            break;

                        case 7:
                            Estoque.RelValorTotalEstoque();
                            Console.WriteLine();
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