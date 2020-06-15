using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoposition = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilposition = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int evilrow = evilposition[0];
                int evilcol = evilposition[1];

                while (evilrow >= 0 && evilcol >= 0)
                {
                    if (evilrow >= 0 && evilrow < matrix.GetLength(0) && evilcol >= 0 && evilcol < matrix.GetLength(1))
                    {
                        matrix[evilrow, evilcol] = 0;
                    }
                    evilrow--;
                    evilcol--;
                }

                int ivorow = ivoposition[0];
                int ivocol = ivoposition[1];

                while (ivorow >= 0 && ivocol < matrix.GetLength(1))
                {
                    if (ivorow >= 0 && ivorow < matrix.GetLength(0) && ivocol >= 0 && ivocol < matrix.GetLength(1))
                    {
                        sum += matrix[ivorow, ivocol];
                    }

                    ivocol++;
                    ivorow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}
