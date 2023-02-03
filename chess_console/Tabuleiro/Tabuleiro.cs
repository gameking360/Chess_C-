using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_console.tabuleiro
{
     class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linha,int coluna)
        {
            this.linhas = linha;
            this.colunas = coluna;
            pecas = new Peca[linha,coluna];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca(Position pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public bool existePeca(Position pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Position pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição.");
            }
            
            pecas[pos.Linha,pos.Coluna] = p;
            p.position = pos;
        }

        public Peca RetirarPeca(Position pos)
        {
            if( peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.position = null;

            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }
        
        public bool PosicaoValida(Position pos)
        {
            if(pos.Linha < 0 || pos.Coluna < 0 || pos.Linha >= linhas || pos.Coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Position pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida");
            }
        }
    }
}
