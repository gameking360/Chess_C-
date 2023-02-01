using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_console.Tabuleiro
{
     class Peca
    {
        public Cor Cor { get; set; }
        public Position Position { get; protected set; }

        public int QtdMovimentos { get; protected set; }

        public Tabuleiro Tab { get; protected set; }

        public Peca(Cor cor, Position position, Tabuleiro tab)
        {
            Cor = cor;
            Position = position;
            Tab = tab;
            QtdMovimentos = 0;
        }
    }
}
