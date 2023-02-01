using System;
using chess_console.tabuleiro;
namespace chess_console
{
     class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro t)
        {
            for (int i = 0; i < t.linhas; i++)
            {
                for (int z = 0; z < t.colunas; z++)
                {
                    if(t.peca(i,z) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(t.peca(i, z) + " ");
                    }
                  
                }
                Console.WriteLine();
            }
        }
    }
}
