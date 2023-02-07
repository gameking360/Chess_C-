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
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
            terminada = false;
            xeque = false;
        }

        public Peca ExecutaMovimento(Position origem, Position destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQuantidade();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        private Cor CorAdversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
                
            }
            return null;
        }
        public HashSet<Peca> pecasCapturadas(Cor c)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if (x.Cor == c)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }


        public bool estaEmXeque(Cor cor)
        {
            Peca r = rei(cor);
            if(r == null)
            {
                throw new TabuleiroException("Não há rei dessa cor");
            }

            foreach (Peca x in pecasEmJogo(CorAdversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[r.position.Linha, r.position.Coluna])
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool testeXequeMate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();
                for(int i = 0; i< tab.linhas; i++)
                {
                    for(int j = 0; j< tab.colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origem = x.position;
                            Position destino = new Position(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem,destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino,pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void desfazMovimento(Position origem, Position destino, Peca capturada)
        {

            Peca p = tab.RetirarPeca(destino);
            p.DecrementarQuantidade();
            if(capturada != null)
            {
                tab.ColocarPeca(capturada, destino);
                capturadas.Remove(capturada);
            }
            tab.ColocarPeca(p, origem);
        }
        public void RealizaJogada(Position origem, Position destino)
        {
            

            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em cheque");
            }

            if (estaEmXeque(CorAdversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (testeXequeMate(CorAdversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudaJogador();
            }
            
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
        public void colocarNovaPeca(char coluna, int linha, Peca p)
        {
            tab.ColocarPeca(p,new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(p);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('e', 1, new Rei(Cor.Branca,tab));
            colocarNovaPeca('e',8, new Rei(Cor.Preta,tab));

            colocarNovaPeca('a',1,new Torre(Cor.Branca,tab));
            colocarNovaPeca('a', 8, new Torre(Cor.Preta, tab));

            colocarNovaPeca('h', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('h', 8, new Torre(Cor.Preta, tab));

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
