using System;
using System.Threading;

namespace Teste
{
    internal class Rato
    {
        private const char RATO = 'R';
        private const char CAMINHO = ' ';
        private const char VISITADO = '.';
        private readonly char[,] _mapa;
        private int _linha;
        private int _coluna;
        private readonly int _altura;
        private readonly int _largura;
        private bool _achouQueijo = false;

        public Rato(Labirinto labirinto, int linhaInicial, int colunaInicial)
        {
            _mapa = labirinto.ObterMapa();
            _altura = _mapa.GetLength(0);
            _largura = _mapa.GetLength(1);
            _linha = linhaInicial;
            _coluna = colunaInicial;
        }

        public void Mover()
        {
            _mapa[_linha, _coluna] = RATO;
            Explorar(_linha, _coluna);

            if (!_achouQueijo)
                Console.WriteLine("\nO rato não encontrou o queijo 😿");
        }

        private void Explorar(int linha, int coluna)
        {
            if (_achouQueijo)
                return;

            if (_mapa[linha, coluna] == 'Q')
            {
                _achouQueijo = true;
                Console.Clear();
                ImprimirMapa();
                Console.WriteLine("\nO rato encontrou o queijo! 🧀");
                return;
            }

            _mapa[linha, coluna] = RATO;
            Thread.Sleep(80);
            Console.Clear();
            ImprimirMapa();
            _mapa[linha, coluna] = VISITADO;

            // Tenta as 4 direções
            foreach (var direcao in Direcao.ObterDirecoesAleatorias())
            {
                int novaL = linha + direcao.Linha;
                int novaC = coluna + direcao.Coluna;

                if (novaL >= 0 && novaL < _altura && novaC >= 0 && novaC < _largura &&
                    (_mapa[novaL, novaC] == CAMINHO || _mapa[novaL, novaC] == 'Q'))
                {
                    Explorar(novaL, novaC);
                    if (_achouQueijo) return;
                }
            }
        }

        private void ImprimirMapa()
        {
            for (int i = 0; i < _altura; i++)
            {
                for (int j = 0; j < _largura; j++)
                    Console.Write(_mapa[i, j]);
                Console.WriteLine();
            }
        }
    }
}
