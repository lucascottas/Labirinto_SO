namespace Teste;

public class Direcao
{
    public int Linha { get; }
    public int Coluna { get; }

    private Direcao(int linha, int coluna)
    {
        Linha = linha;
        Coluna = coluna;
    }

    public static Direcao Cima = new(-1, 0);
    public static Direcao Baixo = new(1, 0);
    public static Direcao Esquerda = new(0, -1);
    public static Direcao Direita = new(0, 1);

    private static List<Direcao> Todas = new() { Cima, Baixo, Esquerda, Direita };
    private static Random _random = new();

    public static List<Direcao> ObterDirecoesAleatorias()
    {

        List<Direcao> direcoesEmbaralhadas = new List<Direcao>(Todas);


        int n = direcoesEmbaralhadas.Count;
        while (n > 1)
        {
            n--;
            int k = _random.Next(n + 1);


            Direcao temp = direcoesEmbaralhadas[k];
            direcoesEmbaralhadas[k] = direcoesEmbaralhadas[n];
            direcoesEmbaralhadas[n] = temp;
        }


        return direcoesEmbaralhadas;
    }
}