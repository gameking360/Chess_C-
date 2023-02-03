using System;
using chess_console.tabuleiro;
using JogoDeXadrez;

namespace chess_console
{
     class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro t)
        {
            for (int i = 0; i < t.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int z = 0; z < t.colunas; z++)
                {
                    if(t.peca(i,z) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(t.peca(i,z));
                        Console.Write(" ");
                    }
                  
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirPeca (Peca p)
        {
            if(p.Cor == Cor.Branca)
            {
                Console.Write(p);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p);
                Console.ForegroundColor = aux;
            }
            
        }
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);

        }
    }
}
