using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_console.tabuleiro
{
     class Peca
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

        
    }
}
