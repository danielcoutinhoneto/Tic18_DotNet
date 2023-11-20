namespace Namespace;
public static class Item 
{
    private static List<ItemTarefa> tarefas;

    static Item()
    {
        tarefas = new List<ItemTarefa>();
    }


    public static void Inserir(ItemTarefa tarefa) 
    {
        tarefas.Add(tarefa);
    }

    public static void MarcarComoConcluida(int indice)
    {
        if (VerificarIndiceValido(indice))
        {
            tarefas[indice].concluida = true;
            Console.WriteLine($"Tarefa {indice} marcada como concluída.");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }
    
    public static void Excluir(int indice)
    {
        if (VerificarIndiceValido(indice))
        {
            tarefas.RemoveAt(indice);
            Console.WriteLine($"Tarefa {indice} excluída.");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    public static void ListarConcluidas()
    {
        Console.WriteLine("Tarefas Concluídas:");
        Console.WriteLine("{0,-20} {1,-120} {2,-20} {3,-10}", "Título", "Descrição", "Data de Vencimento", "Concluída");
        Console.WriteLine(new string('-', 185));

        for (int i = 0; i < tarefas.Count; i++)
       {
            if (tarefas[i].concluida)
            {
                Console.WriteLine("{0,-20} {1,-120} {2,-20} {3,-10}", tarefas[i].titulo, tarefas[i].descricao, tarefas[i].dataVencimento.ToString("dd/MM/yyyy"), tarefas[i].concluida ? "Sim" : "Não");
            }
        }
    }

    public static void ListarNaoConcluidas()
        {
            Console.WriteLine("Tarefas Não Concluídas:");
            Console.WriteLine("{0,-20} {1,-120} {2,-20} {3,-10}", "Título", "Descrição", "Data de Vencimento", "Concluída");
            Console.WriteLine(new string('-', 185));

            for (int i = 0; i < tarefas.Count; i++)
            {
                if (!tarefas[i].concluida)
            {
                Console.WriteLine("{0,-20} {1,-120} {2,-20} {3,-10}", tarefas[i].titulo, tarefas[i].descricao, tarefas[i].dataVencimento.ToString("dd/MM/yyyy"), tarefas[i].concluida ? "Sim" : "Não");
            }
        }
    }

    public static void PesquisarPorPalavraChave(string palavraChave)
    {
        var resultados = tarefas.Where(tarefa => tarefa.titulo?.Contains(palavraChave, StringComparison.OrdinalIgnoreCase) == true || tarefa.descricao?.Contains(palavraChave, StringComparison.OrdinalIgnoreCase) == true);

        Console.WriteLine($"Resultados da pesquisa por '{palavraChave}':");
        Console.WriteLine("{0,-20} {1,-120} {2,-20} {3,-10}", "Título", "Descrição", "Data de Vencimento", "Concluída");
        Console.WriteLine(new string('-', 185));

        foreach (var tarefa in resultados)
        {
            Console.WriteLine("{0,-20} {1,-120} {2,-20} {3,-10}", tarefa.titulo, tarefa.descricao, tarefa.dataVencimento.ToString("dd/MM/yyyy"), tarefa.concluida ? "Sim" : "Não");
        }
    }

    private static bool VerificarIndiceValido(int indice)
    {
        return indice >= 0 && indice < tarefas.Count;
    }

    public static void Listar()
    {
        Console.WriteLine("{0,-30} {1,-120} {2,-20} {3,-10}", "Título", "Descrição", "Data de Vencimento", "Concluída");
        Console.WriteLine(new string('-', 185));

       for (int i = 0; i < tarefas.Count; i++)
        {
            Console.WriteLine("{0,-30} {1,-120} {2,-20} {3,-10}", tarefas[i].titulo, tarefas[i].descricao, tarefas[i].dataVencimento.ToString("dd/MM/yyyy"), tarefas[i].concluida ? "Sim" : "Não");
        }
    }
}
