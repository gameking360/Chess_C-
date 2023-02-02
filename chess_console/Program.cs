using chess_console.tabuleiro;
using System;
using JogoDeXadrez;

namespace chess_console
{
    class Program {
    
        static void Main(string[] args)
        {
            Tabuleiro t = new Tabuleiro(8, 8);

            try
            {
                t.ColocarPeca(new Rei(Enum.Parse<Cor>("Branca"), t), new Position(0, 4));
                t.ColocarPeca(new Rei(Enum.Parse<Cor>("Preta"), t), new Position(7, 4));

                t.ColocarPeca(new Torre(Enum.Parse<Cor>("Branca"), t), new Position(0, 0));
                t.ColocarPeca(new Torre(Enum.Parse<Cor>("Branca"), t), new Position(0, 7));

                t.ColocarPeca(new Torre(Enum.Parse<Cor>("Preta"), t), new Position(7, 0));
                t.ColocarPeca(new Torre(Enum.Parse<Cor>("Preta"), t), new Position(7, 7));




                Tela.ImprimirTabuleiro(t);
            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }

    }
    

}
