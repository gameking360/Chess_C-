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

        private bool existeInimigo(Position pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p.Cor != this.Cor;
        }

        private bool livre(Position pos)
        {
            return Tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];

            Position p = new Position(0, 0);

           if(Cor == Cor.Branca)
            {
                p.DefinirValores(position.Linha - 1, position.Coluna);
                if(Tab.PosicaoValida(p) && livre(p))
                {
                    mat[p.Linha, p.Coluna] = true;
                }

                p.DefinirValores(position.Linha - 2, position.Coluna);
              if(Tab.PosicaoValida(p) && livre(p) && QtdMovimentos == 0)
                {
                    mat[p.Linha, p.Coluna] = true;
                }

                p.DefinirValores(position.Linha - 1, position.Coluna - 1);
                if(Tab.PosicaoValida(p) && existeInimigo(p))
                {
                    mat[p.Linha, p.Coluna] = true;
                }

                p.DefinirValores(position.Linha - 1, position.Coluna +1);
                if(Tab.PosicaoValida(p) && existeInimigo(p))
                {
                    mat[p.Linha, p.Coluna] = true;
                }

            }
            else
            {
                p.DefinirValores(position.Linha + 1, position.Coluna);
                if (Tab.PosicaoValida(p) && livre(p))
                {
                    mat[p.Linha, p.Coluna] = true;
                }

                p.DefinirValores(position.Linha + 2, position.Coluna);
                if (Tab.PosicaoValida(p) && livre(p) && QtdMovimentos == 0)
                {
                    mat[p.Linha, p.Coluna] = true;
                }

                p.DefinirValores(position.Linha + 1, position.Coluna - 1);
                if (Tab.PosicaoValida(p) && existeInimigo(p))
                {
                    mat[p.Linha, p.Coluna] = true;
                }

                p.DefinirValores(position.Linha + 1, position.Coluna + 1);
                if (Tab.PosicaoValida(p) && existeInimigo(p))
                {
                    mat[p.Linha, p.Coluna] = true;
                }
            }

            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
