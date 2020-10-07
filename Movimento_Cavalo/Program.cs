using System;
using System.Collections.Generic;

class Movimento_Cavalo
{

    // Classe para armazenar osdsds dados
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

    // Método utilizado retornando verdadeirodddd
    // if (x, y) lies inside Board 
    static bool VerificarDentro(int x, int y, int N)
    {
        if (x >= 1 && x <= N && y >= 1 && y <= N)
            return true;
        return false;
    }

    // Method returns minimum step 
    // Procurar a posição de destino
    static int minStepToReachTarget(int[] PosIn,
                                    int[] PosFim, int Tam)
    {
        // direção de x e y, onde o cavalo possa se mover 
        int[] dx = { -2, -1, 1, 2, -2, -1, 1, 2 };
        int[] dy = { -1, -2, -2, -1, 1, 2, 2, 1 };

        //fila para armazenar as posições do cavalo no tabuleiro 
        Queue<cell> q = new Queue<cell>();

        // push starting position of knight with 0 distance 
        q.Enqueue(new cell(PosIn[0],
                           PosIn[1], 0));

        cell t;
        int x, y;
        bool[,] visit = new bool[Tam + 1, Tam + 1];

        // make all cell unvisited 
        for (int i = 1; i <= Tam; i++)
            for (int j = 1; j <= Tam; j++)
                visit[i, j] = false;

        // Visitando posição inicial 
        visit[PosIn[0], PosIn[1]] = true;

        // loop untill we have one element in queue 
        while (q.Count != 0)
        {
            t = q.Peek();
            q.Dequeue();

            // if current cell is equal to target cell, 
            // return its distance 
            if (t.x == PosFim[0] && t.y == PosFim[1])
                return t.dis;

            // loop for all reachable states 
            for (int i = 0; i < 8; i++)
            {
                x = t.x + dx[i];
                y = t.y + dy[i];

                // If reachable state is not yet visited and 
                // inside board, push that state into queue 
                if (VerificarDentro(x, y, Tam) && !visit[x, y])
                {
                    visit[x, y] = true;
                    q.Enqueue(new cell(x, y, t.dis + 1));
                }
            }
        }
        return int.MaxValue;
    }

    // Driver code 
    public static void Main(String[] args)
    {
        int tamanho_tabuleiro = 8;
        int[] PosInicio = { 1, 1 };
        int[] PosFim = { 8, 8 };
        Console.WriteLine(
            minStepToReachTarget(
                PosInicio,
                PosFim, tamanho_tabuleiro));
    }
}