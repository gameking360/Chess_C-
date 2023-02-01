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

        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
