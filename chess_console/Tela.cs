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
                    ImprimirPeca(t.peca(i, z)); 
                  
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.WriteLine();
        }

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.tab);
            imprimirPecasCapturadas(partida);

            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada da " + partida.jogadorAtual);

                if (partida.xeque)
                {
                    Console.WriteLine("Você está em xeque");
                }
            }
            else
            {
                Console.WriteLine("XEQUE MATE!!");
                Console.WriteLine("Vencedor: "+ partida.jogadorAtual);
            }
            
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.WriteLine();
            Console.ForegroundColor = aux;
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[ ");
            foreach (var item in conjunto)
            {
                Console.Write(item +" ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoePossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoePossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }


        public static void ImprimirPeca (Peca p)
        {
            if (p == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (p.Cor == Cor.Branca)
                {
                    Console.Write(p+" ");
                }

                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(p+" ");
                    Console.ForegroundColor = aux;
                }
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
