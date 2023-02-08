using chess_console.tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeXadrez
{
     class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tab) : base(cor, tab)
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

            //NO
            p.DefinirValores(position.Linha - 1, position.Coluna - 1);
            while(Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if(Tab.peca(p) != null &&Tab.peca(p).Cor != Cor)
                {
                    break;
                }
                p.DefinirValores(p.Linha - 1, p.Coluna - 1);
            }
            //NE
            p.DefinirValores(position.Linha - 1, position.Coluna + 1);
            while (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tab.peca(p) != null && Tab.peca(p).Cor != Cor)
                {
                    break;
                }
                p.DefinirValores(p.Linha - 1, p.Coluna + 1);
            }
            //SE
            p.DefinirValores(position.Linha + 1, position.Coluna - 1);
            while (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tab.peca(p) != null && Tab.peca(p).Cor != Cor)
                {
                    break;
                }
                p.DefinirValores(p.Linha + 1, p.Coluna - 1);
            }
            //SO
            p.DefinirValores(position.Linha + 1, position.Coluna + 1);
            while (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tab.peca(p) != null && Tab.peca(p).Cor != Cor)
                {
                    break;
                }
                p.DefinirValores(p.Linha + 1, p.Coluna + 1);
            }




            return mat;
        }
        public override string ToString()
        {
            return "B";
        }
    }
}
