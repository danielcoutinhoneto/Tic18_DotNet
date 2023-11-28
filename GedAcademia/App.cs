using System;
using System.Collections.Generic;

namespace GedAcademia
{
    public static class GestaoClientesTreinadores
    {
        public static List<Cliente> ListaDeClientes { get; } = new List<Cliente>();
        public static List<Treinador> ListaDeTreinadores { get; } = new List<Treinador>();

        public static void CadastrarCliente((string? Nome, string? CPF, DateTime DataNasc, double Altura, double Peso) clienteInfo)
        {
            Cliente cliente = new Cliente
            {
                Nome = clienteInfo.Nome,
                CPF = clienteInfo.CPF,
                DataNasc = clienteInfo.DataNasc,
                Altura = clienteInfo.Altura,
                Peso = clienteInfo.Peso
            };

            ListaDeClientes.Add(cliente);
        }

        public static void CadastrarTreinador((string? Nome, DateTime DataNasc, string? CPF, string? CREF) treinadorInfo)
        {
            Treinador treinador = new Treinador
            {
                Nome = treinadorInfo.Nome,
                DataNasc = treinadorInfo.DataNasc,
                CPF = treinadorInfo.CPF,
                CREF = treinadorInfo.CREF
            };

            ListaDeTreinadores.Add(treinador);
        }

        public static void RelIdadeEntreMinMax(int idadeMinima, int idadeMaxima)
        {
            // Obtém a data atual
            DateTime dataAtual = DateTime.Now;

            // Filtra os treinadores com idade entre os valores fornecidos
            var treinadoresEntreMinMax = ListaDeTreinadores.Where(treinador =>
            {
                int idade = dataAtual.Year - treinador.DataNasc.Year;

                // Ajusta a idade se ainda não tiver completado o aniversário este ano
                if (dataAtual.Month < treinador.DataNasc.Month || (dataAtual.Month == treinador.DataNasc.Month && dataAtual.Day < treinador.DataNasc.Day))
                {
                    idade--;
                }

                return idade >= idadeMinima && idade <= idadeMaxima;
            });

            // Print column headers with fixed width
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Nome", "Data de Nascimento", "CPF", "CREF");

            // Print a line of equal signs as a separator
            Console.WriteLine(new string('=', 83));

            Console.WriteLine($"Treinadores com idade entre {idadeMinima} e {idadeMaxima} anos:");

            foreach (var treinador in treinadoresEntreMinMax)
            {
                // Print information about each treinador with fixed width
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", treinador.Nome, treinador.DataNasc.ToString("dd/MM/yyyy"), treinador.CPF, treinador.CREF);
                Console.WriteLine(new string('.', 83));
            }
        }

        public static void RelIdadeClientesEntreMinMax(int idadeMinima, int idadeMaxima)
        {
            DateTime dataAtual = DateTime.Now;

            var clientesEntreMinMax = ListaDeClientes.Where(cliente =>
            {
                int idade = dataAtual.Year - cliente.DataNasc.Year;

                if (dataAtual.Month < cliente.DataNasc.Month || (dataAtual.Month == cliente.DataNasc.Month && dataAtual.Day < cliente.DataNasc.Day))
                {
                    idade--;
                }

                return idade >= idadeMinima && idade <= idadeMaxima;
            });

            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "Nome", "Data de Nascimento", "Altura", "Peso");

            Console.WriteLine(new string('=', 83));

            Console.WriteLine($"Clientes com idade entre {idadeMinima} e {idadeMaxima} anos:");

            foreach (var cliente in clientesEntreMinMax)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", cliente.Nome, cliente.DataNasc.ToString("dd/MM/yyyy"), cliente.Altura, cliente.Peso);
                Console.WriteLine(new string('.', 83));
            }
        }

         public static void RelatorioClientesIMC(double valorMinimoIMC)
        {
            var clientesFiltrados = ListaDeClientes
                .Where(cliente => CalcularIMC(cliente) > valorMinimoIMC)
                .OrderBy(cliente => CalcularIMC(cliente));

            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "Nome", "Data de Nascimento", "Altura", "Peso", "IMC");

            Console.WriteLine(new string('=', 103));

            Console.WriteLine($"Clientes com IMC maior que {valorMinimoIMC}:");

            foreach (var cliente in clientesFiltrados)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", cliente.Nome, cliente.DataNasc.ToString("dd/MM/yyyy"), cliente.Altura, cliente.Peso, CalcularIMC(cliente).ToString("F2"));
                Console.WriteLine(new string('.', 103));
            }
        }

        private static double CalcularIMC(Cliente cliente)
        {
            if (cliente.Altura <= 0 || cliente.Peso <= 0)
            {
                return 0.0; 
            }

            double alturaMetros = cliente.Altura / 100; 
            return cliente.Peso / (alturaMetros * alturaMetros);
        }

    }
}
