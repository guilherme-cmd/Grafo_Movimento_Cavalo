using System;
using System.Collections.Generic;

class Movimento_Cavalo
{

    // Classe para armazenar os dados
    public class cell
    {
        public int x, y;
        public int dis;

        public cell(int x, int y, int dis)
        {
            this.x = x;
            this.y = y;
            this.dis = dis;
        }
    }

    // Método utilizado retornando verdadeiro
    // se (x, y) encontra-se no tabuleiro 
    static bool VerificarDentro(int x, int y, int N)
    {
        if (x >= 1 && x <= N && y >= 1 && y <= N)
            return true;      
            return false;
    }

    // Método de retorno do degrau minimo
    // Procurar a posição de destino
    static int MovimentoMinimoChegada(int[] PosIn,
                                    int[] PosFim, int Tam)
    {
        // direção de x e y, onde o cavalo possa se mover 
        int[] dx = { -2, -1, 1, 2, -2, -1, 1, 2 };
        int[] dy = { -1, -2, -2, -1, 1, 2, 2, 1 };

        //fila para armazenar as posições do cavalo no tabuleiro 
        Queue<cell> q = new Queue<cell>();

        // Inicia a posição do cavaleiro com zero.
        q.Enqueue(new cell(PosIn[0],
                           PosIn[1], 0));

        cell t;
        int x, y;
        bool[,] visit = new bool[Tam + 1, Tam + 1];

        for (int i = 1; i <= Tam; i++)
            for (int j = 1; j <= Tam; j++)
                visit[i, j] = false;

            // Visitando posição inicial 
            visit[PosIn[0], PosIn[1]] = true;


            // loop até nós tivermos um elemento na fila 
            while (q.Count != 0)
            {
                t = q.Peek();
                q.Dequeue();

                // Se a posição de inicio é igual a posição final
                // retornando a distância
                if (t.x == PosFim[0] && t.y == PosFim[1])
                    return t.dis;

                // loop para todas as posições do tabuleiro
                for (int i = 0; i < 8; i++)
                {
                    x = t.x + dx[i];
                    y = t.y + dy[i];

                    // se o estado alcançavel não for visitado dentro do tabuleiro, ele aguarda na fila de espera.
                    if (VerificarDentro(x, y, Tam) && !visit[x, y])
                    {
                        visit[x, y] = true;
                        q.Enqueue(new cell(x, y, t.dis + 1));
                    }
                }
            }
            return int.MaxValue;
        }        

    public static void Main(String[] args)
    {
        int tamanho_tabuleiro = 8, movlinhain, movcolunain, movlinhafim, movcolunafim;

        Console.WriteLine("Digite o movimento inicial do cavalo(Linha): ");
        movlinhain = int.Parse(Console.ReadLine());
        if (movlinhain >=1 && movlinhain <= tamanho_tabuleiro)
        {
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Digite um número válido!!");
            Environment.Exit(10);
        }
        Console.WriteLine("Digite o movimento inicial do cavalo(Coluna): ");
        movcolunain = int.Parse(Console.ReadLine());
        if (movcolunain >= 1 && movcolunain <= tamanho_tabuleiro)
        {
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Digite um número válido!!");
            Environment.Exit(10);
        }
        Console.WriteLine("Digite o movimento final do cavalo(Linha): ");
        movlinhafim = int.Parse(Console.ReadLine());
        if (movlinhafim >= 1 && movlinhafim <= tamanho_tabuleiro)
        {
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Digite um número válido!!");
            Environment.Exit(10);
        }
        Console.WriteLine("Digite o movimento final do cavalo(Coluna): ");
        movcolunafim = int.Parse(Console.ReadLine());
        if (movcolunafim >= 1 && movcolunafim <= tamanho_tabuleiro)
        {
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Digite um número válido!!");
            Environment.Exit(10);
        }
        int[] PosInicio = { movlinhain, movcolunain };
        int[] PosFim = { movlinhafim, movcolunafim };
        
        Console.WriteLine(MovimentoMinimoChegada(PosInicio, PosFim, tamanho_tabuleiro));
        

        Console.ReadKey();
    }
}