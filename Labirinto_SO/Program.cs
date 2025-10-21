using System;
using Teste;

class Program
{
    private const int LARGURA_LABIRINTO = 31;
    private const int ALTURA_LABIRINTO = 15;

    static void Main(string[] args)
    {
        Labirinto labirinto = new Labirinto(ALTURA_LABIRINTO, LARGURA_LABIRINTO);

        Console.WriteLine("--- Labirinto Aleatório Gerado ---");
        labirinto.Imprimir();

        Console.WriteLine("\nPressione [R] para soltar o rato...");
        while (Console.ReadKey(true).Key != ConsoleKey.R) { }

        // rato nasce no canto oposto do queijo
        Rato rato = new Rato(labirinto, ALTURA_LABIRINTO - 2, LARGURA_LABIRINTO - 2);

        Console.Clear();
        labirinto.Imprimir();
        Console.WriteLine("\nRato posicionado! Pressione Enter para começar o movimento...");
        Console.ReadLine();

        rato.Mover();

        Console.WriteLine("\nPressione Enter para encerrar.");
        Console.ReadLine();
    }
}
