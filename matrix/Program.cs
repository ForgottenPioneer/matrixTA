//матрицы(массивы перемножение)
using System;
class Program
{
    static void Main()
    {
        Random random = new Random();
        Console.WriteLine("Введите количество строк первой матрицы (A):");
        int rowsA = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов первой матрицы (A):");
        int colsA = int.Parse(Console.ReadLine());
        int[,] A = new int[rowsA, colsA];

        Console.WriteLine("Ваша матрица A: ");
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsA; j++)
            {
                A[i, j] = random.Next(-100, 100);
                Console.Write("{0}\t", A[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine("Введите количество строк второй матрицы (B):");
        int rowsB = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов второй матрицы (B):");
        int colsB = int.Parse(Console.ReadLine());

        if (colsA != rowsB)
        {
            Console.WriteLine("Ошибка: количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
            return;
        }

        Console.WriteLine("Ваша матрица B: ");
        int[,] B = new int[rowsB, colsB];
        for (int i = 0; i < rowsB; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                B[i, j] = random.Next(-100, 100);
                Console.Write("{0}\t", B[i, j]);
            }
            Console.WriteLine();
        }
        //создаем финальную матричку
        int[,] C = new int[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                C[i, j] = 0;
                for (int k = 0; k < colsA; k++)
                {
                    C[i, j] += A[i, k] * B[k, j];

                }
            }
        }

        Console.WriteLine("Финальная матрица C (до сортировки):");
        PrintMatrix(C);

        int totalSize = rowsA * colsB;
        int[] flatArray = new int[totalSize];
        int index = 0;
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                flatArray[index++] = C[i, j];
            }
        }


        Array.Sort(flatArray);

        index = 0;
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                C[i, j] = flatArray[index++];
            }
        }

        Console.WriteLine("Финальная матрица C (после сортировки):");
        PrintMatrix(C);
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
