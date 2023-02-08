using chess_console.tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeXadrez
{
     class Rei : Peca
    {

        private PartidaDeXadrez partida;

        public Rei(Cor cor, Tabuleiro tab,PartidaDeXadrez xadrez) : base(cor, tab)
        {
            this.partida = xadrez;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Position pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        private bool testeTorreParaRoque(Position pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QtdMovimentos == 0;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas,Tab.colunas];

            Position p = new Position(0, 0);

            //acima
            p.DefinirValores(position.Linha - 1, position.Coluna);
            if (Tab.PosicaoValida(p)&& PodeMover(p))
            {
                mat[p.Linha,p.Coluna ] = true;
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
            p.DefinirValores(position.Linha +1, position.Coluna);
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
            p.DefinirValores(position.Linha, position.Coluna +1);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }
            //esquerda
            p.DefinirValores(position.Linha, position.Coluna -1);
            if (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
            }

            // Roque - pequeno
            if (QtdMovimentos == 0 && !partida.xeque)
            {
                Position posT1 = new Position(position.Linha, position.Coluna + 3);
                if (testeTorreParaRoque(posT1))
                {
                    Position p1 = new Position(position.Linha, position.Coluna + 1);
                    Position p2 = new Position(position.Linha, position.Coluna + 2);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null)
                    {
                        mat[p.Linha, p.Coluna + 2] = true;
                    }
                }


                //Roque Grande
                Position posT2 = new Position(position.Linha, position.Coluna - 4);
                if (testeTorreParaRoque(posT2))
                {
                    Position p1 = new Position(position.Linha, position.Coluna - 1);
                    Position p2 = new Position(position.Linha, position.Coluna - 2);
                    Position p3 = new Position(position.Linha, position.Coluna - 3);

                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                    {
                        mat[p.Linha, p.Coluna - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
