using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array2D = { { 1, 2, 3 }, 
                                { 4, 5, 6 }, 
                                { 7, 8, 9 } };

            

            AddRows(array2D);
            void AddRows(int[,] array)
            {
                for (int i = 0; i< array.GetLength(0); i++)
                {
                    int num = 0;
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        num += array[i, j];
                    }
                    Console.WriteLine(num);
                }
            }
        }
    }
}
