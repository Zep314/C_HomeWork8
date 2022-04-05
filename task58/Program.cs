// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

using System;



const int size_l = 20;  // размер матриц пусть будет таким
const int size_m = 10;
const int size_n = 20;

int [,] init_matrix(int s_w,int s_h) //заполняем матрицу случайными числами
{
    int [,] ret_matrix = new int [s_w,s_h];
    Random rnd = new Random();
    for(int i=0;i<ret_matrix.GetLength(0);i++)
        for(int j=0;j<ret_matrix.GetLength(1);j++)
        {
            ret_matrix[i,j] = rnd.Next(-9,10); // диапазон от -9 до 9
        }
    return ret_matrix;
}


void print_matrix(int [,] local_matrix)  // красивая печать матрицы
{
    for(int i=0;i<local_matrix.GetLength(0);i++)
    {
        Console.Write("[");  // каждую строку начинаем печатать с символа [
        for(int j=0;j<local_matrix.GetLength(1)-1;j++)
        {
            Console.Write($"{local_matrix[i,j],5} ");  // печатаем очередной элемент матрицы, с 2-мя знаками
                                                        // после запятой и пробелом после всего числа
        }
        Console.WriteLine($"{local_matrix[i,local_matrix.GetLength(1)-1],5}]"); 
                                    //печатаем поcледний элемент в строке и символ ]
    }    
}

int [,] multiple_matrix(int [,] local_matrixA,int [,] local_matrixB)  // умножение матриц по всем правилам
{
    int [,] ret_matrix = new int [local_matrixA.GetLength(0),local_matrixB.GetLength(1)];
    for(int i=0;i<local_matrixA.GetLength(0);i++)
        for(int j=0;j<local_matrixB.GetLength(0);j++)
            for(int k=0;k<local_matrixB.GetLength(1);k++)
            {
                ret_matrix[i,k] += local_matrixA[i,j] * local_matrixB[j,k];
            }
    return ret_matrix;
}

// сама программа
int [,] matrixA = init_matrix(size_l,size_m);
// int [,] matrixA = {{1,2},{3,4}};
Console.WriteLine("Матрица A:");
print_matrix(matrixA);
int [,] matrixB = init_matrix(size_m,size_n);
// int [,] matrixB = {{0,0},{1,1}};
Console.WriteLine("Матрица B:");
print_matrix(matrixB);
Console.WriteLine("Произведение матриц A*B:");
print_matrix(multiple_matrix(matrixA,matrixB));
