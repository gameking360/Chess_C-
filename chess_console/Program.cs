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

                    Console.WriteLine();
                    Console.WriteLine("Turno: " + partida.turno);
                    Console.WriteLine("Aguardando jogada da "+partida.jogadorAtual);

                    Console.Write("Origem: ");
                    Position origem = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validaPosicao(origem);

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab,posicoesPossiveis);




                    Console.WriteLine("Destino: ");
                    Position destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validaPosicaoDestino(origem,destino);

                    partida.RealizaJogada(origem, destino);
                }


            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }

    }

}
