using System;
using System.Collections.Generic;

namespace CadEstoque
{
    public static class Estoque
    {
        private static List<Produto> ListaDeProdutos { get; } = new List<Produto>();

        public static void CadastrarProduto((int Codigo, string Nome, int Quantidade, double Preco) produtoInfo)
        {
            Produto produto = new Produto
            {
                Codigo = produtoInfo.Codigo,
                Nome = produtoInfo.Nome,
                Quantidade = produtoInfo.Quantidade,
                Preco = produtoInfo.Preco
            };

            ListaDeProdutos.Add(produto);
            Console.WriteLine();
            Console.WriteLine("\nProduto cadastrado com sucesso!");
        }

        public static void SaidaEstoque(string codigoOuNome, int quantidade)
        {
             Produto produto = null;

            if (int.TryParse(codigoOuNome, out int codigo))
            {
                produto = ListaDeProdutos.Find(p => p.Codigo == codigo);
            }
            else
            {
                produto = ListaDeProdutos.Find(p => p.Nome.Equals(codigoOuNome, StringComparison.OrdinalIgnoreCase));
            }

            if (produto != null && produto.Quantidade >= quantidade)
            {
                produto.Quantidade -= quantidade;

                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Código", "Nome", "Quantidade", "Preço");

                Console.WriteLine(new string('=', 83));

                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", produto.Codigo, produto.Nome, produto.Quantidade, produto.Preco.ToString("C"));
                Console.WriteLine(new string('.', 83));

                Console.WriteLine();
                Console.WriteLine($"Saída de {quantidade} unidades do produto {produto.Nome} realizada com sucesso. Estoque atualizado.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Produto não encontrado ou quantidade insuficiente em estoque para dar baixa.");
                Console.WriteLine();
            }
        }

        public static void ExibirEstoque()
        {
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Código", "Nome", "Quantidade", "Preço");

            Console.WriteLine(new string('=', 83));

            foreach (var produto in ListaDeProdutos)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", produto.Codigo, produto.Nome, produto.Quantidade, produto.Preco.ToString("C"));
                Console.WriteLine(new string('.', 83));
            }
        }

        public static (int Codigo, string Nome, int Quantidade, double Preco) SolicitarInformacoesProduto()
        {
            int codigo = SolicitarInteiro("Digite o código do Produto:");
            Console.WriteLine();

            Console.WriteLine("Digite o nome do Produto:");
            string nome = Console.ReadLine();
            Console.WriteLine();

            int quantidade = SolicitarInteiro("Digite a Quantidade do Produto:");
            Console.WriteLine();

            double preco = SolicitarDouble("Digite o Preço do Produto:");
            Console.WriteLine();

            return (codigo, nome, quantidade, preco);
        }
        

        public static void PesquisarPorPalavraChave(string palavraChave)
        {
            var resultados = ListaDeProdutos.Where(produto =>
                produto.Nome?.Contains(palavraChave, StringComparison.OrdinalIgnoreCase) == true ||
                produto.Quantidade.ToString().Contains(palavraChave, StringComparison.OrdinalIgnoreCase) == true ||
                produto.Preco.ToString("C").Contains(palavraChave, StringComparison.OrdinalIgnoreCase) == true);

            Console.WriteLine();
            Console.WriteLine($"Resultados da pesquisa por '{palavraChave}':");
            Console.WriteLine();

            if(resultados.Any())
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Código", "Nome", "Quantidade", "Preço");
                Console.WriteLine(new string('=', 83));

                foreach (var produto in resultados)
                {
                    Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", produto.Codigo, produto.Nome, produto.Quantidade, produto.Preco.ToString("C"));
                    Console.WriteLine(new string('.', 83));
                }
            }
            else
            {
                Console.WriteLine("Produto Não encontrado.");
            }
        }

        internal static int SolicitarInteiro(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                if (int.TryParse(Console.ReadLine(), out int valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, digite um número inteiro válido.");
                    Console.WriteLine();
                }
            }
        }

        private static double SolicitarDouble(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                if (double.TryParse(Console.ReadLine(), out double valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, digite um número válido.");
                    Console.WriteLine();
                }
            }
        }

        public static void RelQuantAbxLimite(int limite)
        {
            var produtosAbaixoLimite = ListaDeProdutos.Where(produto => produto.Quantidade < limite);

            // Print column headers with fixed width
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Código", "Nome", "Quantidade");

            // Print a line of equal signs as a separator
            Console.WriteLine(new string('=', 63));

            Console.WriteLine($"Produtos com quantidade abaixo de {limite}:");

            foreach (var produto in produtosAbaixoLimite)
            {
                // Print information about each product with fixed width
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", produto.Codigo, produto.Nome, produto.Quantidade);
                Console.WriteLine(new string('.', 83));
            }
        }

        public static void RelValorEntreMinMax(double valorMinimo, double valorMaximo)
        {
            var produtosEntreMinMax = ListaDeProdutos.Where(produto => produto.Preco >= valorMinimo && produto.Preco <= valorMaximo);

            // Print column headers with fixed width
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Código", "Nome", "Preço");

            // Print a line of equal signs as a separator
            Console.WriteLine(new string('=', 63));

            Console.WriteLine($"Produtos com valor entre {valorMinimo:C} e {valorMaximo:C}:");

            foreach (var produto in produtosEntreMinMax)
            {
                // Print information about each product with fixed width
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", produto.Codigo, produto.Nome, produto.Preco.ToString("C"));
                Console.WriteLine(new string('.', 83));
            }
        }

        public static void RelValorTotalEstoque()
        {
           
            double valorTotalEstoque = ListaDeProdutos.Sum(produto => produto.Quantidade * produto.Preco);
            
            Console.WriteLine();
            Console.WriteLine($"Valor total do estoque: {valorTotalEstoque:C}");

            Console.WriteLine("Valor total de cada produto de acordo com o estoque:");
            Console.WriteLine();

            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Código", "Nome", "Valor Total");
            Console.WriteLine(new string('=', 63));

            foreach (var produto in ListaDeProdutos)
            {
                double valorTotalProduto = produto.Quantidade * produto.Preco;
                // Print information about each product with fixed width
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", produto.Codigo, produto.Nome, valorTotalProduto.ToString("C"));
                Console.WriteLine(new string('.', 63));
            }
        }

    }
}
