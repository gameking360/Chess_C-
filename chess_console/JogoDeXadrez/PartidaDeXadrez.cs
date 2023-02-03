using chess_console.tabuleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeXadrez
{
     class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
            terminada = false;
        }

        public void ExecutaMovimento(Position origem, Position destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQuantidade();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);

        }

        private void colocarPecas()
        {
            tab.ColocarPeca(new Rei(Enum.Parse<Cor>("Branca"), tab), new PosicaoXadrez('e', 1).toPosicao());
            tab.ColocarPeca(new Rei(Enum.Parse<Cor>("Preta"), tab), new PosicaoXadrez('e', 8).toPosicao());

            tab.ColocarPeca(new Torre(Enum.Parse<Cor>("Branca"), tab), new PosicaoXadrez('a', 1).toPosicao());
            tab.ColocarPeca(new Torre(Enum.Parse<Cor>("Branca"), tab), new PosicaoXadrez('h', 1).toPosicao());

        }
    }
}
