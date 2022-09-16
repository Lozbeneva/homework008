//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

int[,] Fill2DArrrayInt(int row, int column, int minValue, int maxValue)
{
    int[,] array2D = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            array2D[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return array2D;
}

void Print2DArrayInt(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {

            Console.Write(array[i, j] + "; ");

        }
        Console.WriteLine();
    }
}


Console.WriteLine("Введите количество строк -> ");
int row = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество столбцов -> ");
int column = int.Parse(Console.ReadLine());

int[,] massiveInt = Fill2DArrrayInt(row, column, 0, 10);
Print2DArrayInt(massiveInt);
int temp;

for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
           for(int k=j+1; k<column; k++)
           {
            if(massiveInt[i, j]<massiveInt[i,k])
            {
                temp=massiveInt[i,j];
                massiveInt[i,j]=massiveInt[i,k];
                massiveInt[i,k]=temp;
            }
           }
        }
    }
Console.WriteLine();
Print2DArrayInt(massiveInt);


//***********************************************************************************
//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
 
Console.WriteLine("Введите количество строк -> ");
int row2 = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество столбцов -> ");
int column2 = int.Parse(Console.ReadLine());

if (row2 == column2)
{
    Console.WriteLine("Это не прямоугольный массив");
    return;
}

int[,] massiveInt2 = Fill2DArrrayInt(row2, column2, 0, 10);
Print2DArrayInt(massiveInt2);

int[] massiveSumma = new int[row2];

for (int i = 0; i < row2; i++)
{
    for (int j = 0; j < column2; j++)
    {
        massiveSumma[i] += massiveInt2[i, j];
    }
}

Console.WriteLine("Суммы строк: ");
Console.WriteLine(String.Join(", ", massiveSumma));

int minRowSumm=0;

for(int i=1; i<row2; i++)
{
    if(massiveSumma[minRowSumm]>massiveSumma[i])
    {
        minRowSumm=i;
    }
}

Console.WriteLine($"Индекс строки с минимальной суммой чисел {minRowSumm}"); 


//***********************************************************************************
//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц. 

Console.WriteLine("Введите количество строк первой матрицы -> ");
int rowFirstMatrix = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество столбцов первой матрицы -> ");
int columnFirstMatrix = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество строк второй матрицы (должно совпадать с числом столбцов первой матрицы) -> ");
int rowSecondMatrix = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество строк второй матрицы -> ");
int columnSecondMatrix = int.Parse(Console.ReadLine());

if (columnFirstMatrix != rowSecondMatrix)
{
    Console.WriteLine("Матрицы нельзя умножить, количество столбцов первой матрицы не совпадает с количеством строк второй ");
    return;
}

int[,] matrix1 = Fill2DArrrayInt(rowFirstMatrix, columnFirstMatrix, 1, 10);
Print2DArrayInt(matrix1);
Console.WriteLine();
int[,] matrix2 = Fill2DArrrayInt(rowSecondMatrix, columnSecondMatrix, 1, 10);
Print2DArrayInt(matrix2);
Console.WriteLine();
int[,] matrix3 = new int[rowFirstMatrix, columnSecondMatrix];

for (int i = 0; i < rowFirstMatrix; i++)
{
    for (int j = 0; j < columnFirstMatrix; j++)
    {
        for (int k = 0; k < columnSecondMatrix; k++)
        {
            matrix3[i, k] += matrix1[i, j] * matrix2[j, k];
        }
    }
}
Console.WriteLine();
Print2DArrayInt(matrix3);



//***********************************************************************************
//Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
//Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

int[,,] Fill3DArray(int x, int y, int z) // заполняет трехмерный массив с помощью метода GenerateRandom
{
    int[,,] arr = new int[x, y, z];
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                arr[i, j, k] = GenerateRandom(10, 100, arr); //по условию нужны двузначные числа
            }
        }
    }

    return arr;
}

int GenerateRandom(int a, int b, int[,,] arr) //выдает рандомное число, проверяет это число в массиве, если нет, то возвращает его, и если есть, то вызывает сама себя
{
    int res;
    res = new Random().Next(a, b);
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                if (arr[i, j, k] == res)
                {
                    res = GenerateRandom(a, b, arr);
                    return res;
                }
            }
        }
    }
    return res;
}

void Print3DArray(int[,,] arr)
{
    for (int i = 0; i < arr.GetLength(2); i++) //цикл по глубине z
    {
        for (int j = 0; j < arr.GetLength(0); j++) //цикл по x
        {
            for (int k = 0; k < arr.GetLength(1); k++) // по y
            {
                Console.Write($"{arr[j, k, i]} ({j},{k},{i})   ");
            }
            Console.WriteLine();
        }
    }
}

Console.WriteLine("Введите количество строк 3D массива -> ");
int sizeRow = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество строк 3D массива -> ");
int sizeColumn = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество строк 3D массива -> ");
int sizeDeep = int.Parse(Console.ReadLine());

if(sizeRow*sizeColumn*sizeDeep >90 )
{
    Console.WriteLine("Слишком большой массив! Программа не сможет подобрать больше 90 неповторяющихся двухначных чисел!");
    return;
}

int[,,] array3D = Fill3DArray(sizeRow, sizeColumn, sizeDeep);
Print3DArray(array3D);



 //***********************************************************************************
//Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4. (работает на массиве до 7х7)

Console.WriteLine("Введите количество строк и столбцов квардратного массива от 2 до 7 -> ");
int size = int.Parse(Console.ReadLine());

string[,] spiral = new string[size, size];

string[] arrayString = { "00","01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", 
"12", "13", "14", "15", "16" , "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", 
"27", "28", "29", "30", "31", "32", "33", "34", "35", "36","37","38","39","40","41","42","43","44","45","46","47", "48"};

int k = 0;
int countRows = 0; 
int countColumns = 0;

 while (size > 0)
        {
            for (int i = countColumns; i <= countColumns + size - 1; i++)
            {
                spiral[countRows, i] = arrayString[k];
                k++;
                
            }

            for (int j = countRows + 1; j <= countRows + size - 1; j++) //
            {
                spiral[j, countColumns + size - 1] = arrayString[k];
                k++;
            }

            for (int l = countColumns + size - 2; l >= countColumns; l--)
            {
                spiral[countRows + size - 1, l] = arrayString[k];
                k++;
            }

            for (int m = countRows + size - 2; m >= countRows + 1; m--)
            {
                spiral[m, countColumns] = arrayString[k];
                k++;
            }

            countRows = countRows + 1;
            countColumns = countColumns + 1;
            size = size - 2;
        }


for (int i = 0; i < spiral.GetLength(0); i++) //цикл вывода на экран
{
    for (int j = 0; j < spiral.GetLength(1); j++)
    {

        Console.Write(spiral[i, j] + "; ");

    }
    Console.WriteLine();
}
