using System;
using Teste;

public class Labirinto
{
    private char[,] _mapa;
    private int _altura;
    private int _largura;

    public const char PAREDE = '#';
    public const char CAMINHO = ' ';
    public const char QUEIJO = 'Q';

    public Labirinto(int altura, int largura)
    {
        _altura = (altura % 2 == 0) ? altura + 1 : altura;
        _largura = (largura % 2 == 0) ? largura + 1 : largura;
        _mapa = new char[_altura, _largura];

        Gerar();
    }

    private void Gerar()
    {
        // inicializa com paredes
        for (int i = 0; i < _altura; i++)
            for (int j = 0; j < _largura; j++)
                _mapa[i, j] = PAREDE;

        // cava o labirinto a partir do queijo
        CavarCaminho(1, 1);

        // garante que há caminho até o canto onde o rato nasce
        AbrirCaminhoAteCanto(_altura - 2, _largura - 2);

        // define o queijo
        _mapa[1, 1] = QUEIJO;
    }

    private void CavarCaminho(int linha, int coluna)
    {
        _mapa[linha, coluna] = CAMINHO;

        foreach (var direcao in Direcao.ObterDirecoesAleatorias())
        {
            int novaLinha = linha + direcao.Linha * 2;
            int novaColuna = coluna + direcao.Coluna * 2;

            if (novaLinha > 0 && novaLinha < _altura - 1 &&
                novaColuna > 0 && novaColuna < _largura - 1 &&
                _mapa[novaLinha, novaColuna] == PAREDE)
            {
                _mapa[linha + direcao.Linha, coluna + direcao.Coluna] = CAMINHO;
                CavarCaminho(novaLinha, novaColuna);
            }
        }
    }

    private void AbrirCaminhoAteCanto(int destinoLinha, int destinoColuna)
    {
        // Caminho simples (garantido)
        int linha = 1;
        int coluna = 1;
        while (linha < destinoLinha)
        {
            linha++;
            _mapa[linha, coluna] = CAMINHO;
        }
        while (coluna < destinoColuna)
        {
            coluna++;
            _mapa[linha, coluna] = CAMINHO;
        }
    }

    public void Imprimir()
    {
        for (int i = 0; i < _altura; i++)
        {
            for (int j = 0; j < _largura; j++)
                Console.Write(_mapa[i, j] + " ");
            Console.WriteLine();
        }
    }

    public char[,] ObterMapa()
    {
        return _mapa;
    }
}
