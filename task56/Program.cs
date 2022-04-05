// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

using System;



const int size_w = 20;  // размер матрицы пусть будет таким
const int size_h = 10;

void init_matrix(int [,] local_matrix) //заполняем матрицу случайными числами
{
    Random rnd = new Random();
    for(int i=0;i<local_matrix.GetLength(0);i++)
        for(int j=0;j<local_matrix.GetLength(1);j++)
        {
            local_matrix[i,j] = rnd.Next(-99,100); // диапазон от -99 до 99
        }
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

int GetMinLineSumm(int [,] local_matrix)  // ищем строку с минимальной суммой всех элементов
{
    int ret = 0;
    int local_summ = 0;
    int min_summ = 100*local_matrix.GetLength(1);  // заведомо большое число
    for(int i=0;i<local_matrix.GetLength(0);i++)
    {
        local_summ = 0;
        for(int j=0;j<local_matrix.GetLength(1);j++)
        {
            local_summ += local_matrix[i,j];
        }
        if (min_summ>local_summ) 
        {
            min_summ = local_summ;  // запоминаем строку с минимальной суммой всех элементов
            ret = i;                // тут индекс строки
        }
    }
    return ret;
}

// сама программа
int [,] matrix = new int [size_h,size_w];
init_matrix(matrix);
Console.WriteLine("Исходная матрица:");
print_matrix(matrix);
Console.WriteLine($"Строка с наименьшей суммой элементов: {GetMinLineSumm(matrix)}");
