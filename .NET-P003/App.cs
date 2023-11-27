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

        public static void ExibirEstoque()
        {
            Console.WriteLine("\nEstoque:");

            foreach (var produto in ListaDeProdutos)
            {
                Console.WriteLine($"Código: {produto.Codigo}, Nome: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco:C}");
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

        private static int SolicitarInteiro(string mensagem)
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
    }
}
