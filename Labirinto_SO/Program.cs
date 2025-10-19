using System;

class Program
{
    private const int LARGURA_LABIRINTO = 51;
    private const int ALTURA_LABIRINTO = 25;

    static void Main(string[] args)
    {
  

        Labirinto labirinto = new Labirinto(ALTURA_LABIRINTO, LARGURA_LABIRINTO);

        Console.WriteLine("--- Labirinto Aleatório Gerado  ---");
        labirinto.Imprimir();
        
        Console.WriteLine("\nPressione Enter para fechar o programa.");
        Console.ReadLine();
    }
}