using chess_console.Tabuleiro;
using System;

namespace chess_console
{
    class Program {
    
        static void Main(string[] args)
        {
            Position p = new Position(2, 5);

            Console.WriteLine(p.ToString());
        }
    }
    

}
