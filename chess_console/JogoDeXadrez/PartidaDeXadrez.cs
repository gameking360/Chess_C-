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
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
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

        public void RealizaJogada(Position origem, Position destino)
        {
            ExecutaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else if(jogadorAtual == Cor.Preta)
            {
                jogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas()
        {
            tab.ColocarPeca(new Rei(Enum.Parse<Cor>("Branca"), tab), new PosicaoXadrez('e', 1).toPosicao());
            tab.ColocarPeca(new Rei(Enum.Parse<Cor>("Preta"), tab), new PosicaoXadrez('e', 8).toPosicao());

            tab.ColocarPeca(new Torre(Enum.Parse<Cor>("Branca"), tab), new PosicaoXadrez('a', 1).toPosicao());
            tab.ColocarPeca(new Torre(Enum.Parse<Cor>("Branca"), tab), new PosicaoXadrez('h', 1).toPosicao());

        }

        public void validaPosicao(Position pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça nessa posição.");

            }
            
            if(jogadorAtual != tab.peca(pos).Cor)
            {
                throw new TabuleiroException("Essa peça não pertence a você");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há lugares para mover essa peça");
            }
        }
        public void validaPosicaoDestino(Position origem,Position destino)
        {
            if(!tab.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }
    }
}
