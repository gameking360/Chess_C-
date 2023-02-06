using chess_console.tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeXadrez
{
     class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tab) : base(cor, tab) { }

        private bool PodeMover(Position pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];

            Position p = new Position(0, 0);

            //acima
            p.DefinirValores(position.Linha - 1, position.Coluna);
            while (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if(Tab.peca(p) != null && Tab.peca(p).Cor != this.Cor) {
                    break;
                }
                p.Linha = p.Linha - 1 ;
            }

            //abaixo
            p.DefinirValores(position.Linha + 1, position.Coluna);
            while (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tab.peca(p) != null && Tab.peca(p).Cor != this.Cor)
                {
                    break;
                }
                p.Linha = p.Linha + 1;
            }

            //direita
            p.DefinirValores(position.Linha, position.Coluna + 1);
            while (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tab.peca(p) != null && Tab.peca(p).Cor != Cor)
                {
                    break;
                }
                p.Coluna = p.Coluna + 1;
            }

            //Esquerda
            p.DefinirValores(position.Linha, position.Coluna - 1);
            while (Tab.PosicaoValida(p) && PodeMover(p))
            {
                mat[p.Linha, p.Coluna] = true;
                if (Tab.peca(p) != null && Tab.peca(p).Cor != this.Cor)
                {
                    break;
                }
                p.Coluna = p.Coluna - 1;
            }


            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
