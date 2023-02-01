using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_console.Tabuleiro
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
    }
}
