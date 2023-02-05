using chess_console.tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeXadrez
{
     class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tab): base(cor, tab) { }


        private bool PodeMover(Position pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];

            Position p = new Position(0, 0);

            //acima
            p.DefinirValores(position.Linha - 1, position.Coluna);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }
            //Acima direita
            p.DefinirValores(position.Linha - 1, position.Coluna + 1);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }
            //Acima esquerda
            p.DefinirValores(position.Linha - 1, position.Coluna - 1);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            //abaixo
            p.DefinirValores(position.Linha + 1, position.Coluna);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }
            //Abaixo esquerda
            p.DefinirValores(position.Linha + 1, position.Coluna - 1);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            //Abaixo direita
            p.DefinirValores(position.Linha + 1, position.Coluna + 1);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            //direita
            p.DefinirValores(position.Linha, position.Coluna + 1);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }
            //esquerda
            p.DefinirValores(position.Linha, position.Coluna - 1);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
