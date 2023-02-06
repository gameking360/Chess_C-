using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_console.tabuleiro
{
     abstract class Peca
    {
        public Cor Cor { get; protected set; }
        public Position position { get;  set; }

        public int QtdMovimentos { get; protected set; }

        public Tabuleiro Tab { get; protected set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            Cor = cor;
            this.position = null;
            Tab = tab;
            QtdMovimentos = 0;
        }

        public void IncrementarQuantidade()
        {
            QtdMovimentos++;
        }


        public abstract bool[,] movimentosPossiveis();
        
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < Tab.linhas; i++)
            {
                for (int j = 0; j < Tab.colunas; j++)
                {
                    if (mat[i,j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool PodeMoverPara(Position position)
        {
            return movimentosPossiveis()[position.Linha, position.Coluna];
        }
    }
}
