using System;
using System.Collections.Generic;

namespace CadEstoque
{
    public static class Estoque
    {
        private static List<Produto> ListaDeProdutos { get; } = new List<Produto>();

        public static void CadastrarProduto(Produto produto)
        {
            ListaDeProdutos.Add(produto);
            Console.WriteLine("\nProduto cadastrado com sucesso!");
        }

        public static void ExibirEstoque()
        {
            Console.WriteLine("\nEstoque:");

            foreach (var produto in ListaDeProdutos)
            {
                Console.WriteLine($"Código do Produto: {produto.Codigo}, Nome do Produto: {produto.Nome}, Quantidade do Produto: {produto.Quantidade}, Preço do Produto: {produto.Preco:C}");
            }
        }
    }
}