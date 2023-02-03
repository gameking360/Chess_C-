using chess_console.tabuleiro;
using System;
using JogoDeXadrez;

namespace chess_console
{
    class Program {
    
        static void Main(string[] args)
        {
           

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(partida.terminada != true)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);

                    Console.Write("Origem: ");
                    Position origem = Tela.lerPosicaoXadrez().toPosicao();

                    Console.WriteLine("Destino: ");
                    Position destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }


            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }

    }
    

}
