using chess_console.tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeXadrez
{
     class Cavalo : Peca
    {

        public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }
        private bool PodeMover(Position pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];

            Position p = new Position(0, 0);

            p.DefinirValores(position.Linha - 1, position.Coluna - 2);
            if(Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.DefinirValores(position.Linha - 1, position.Coluna + 2);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.DefinirValores(position.Linha + 1, position.Coluna - 2);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.DefinirValores(position.Linha + 1, position.Coluna + 2);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.DefinirValores(position.Linha - 2, position.Coluna - 1);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.DefinirValores(position.Linha - 2, position.Coluna + 1);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.DefinirValores(position.Linha + 2, position.Coluna - 2);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            p.DefinirValores(position.Linha + 2, position.Coluna + 2);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }


            return mat;
        }
        public override string ToString()
        {
            return "C";
        }
    }
}
