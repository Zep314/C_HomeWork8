// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива(в пределах всего массива).

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

int [,] sort_matrix(int [,] local_matrix) // сортировка "пузырями"
{
    // объявляем матрицу такой же размерности, что и исходную. Ее будем возвращать из метода
    int [,] ret = new int [local_matrix.GetLength(0),local_matrix.GetLength(1)];
    // Копируем исходую матрицу в конечную
    Array.Copy(local_matrix,ret,local_matrix.GetLength(0)*local_matrix.GetLength(1));

    // Работаем с матрицей - как с одномерным массивом (используем только одну переменную в цикле)
    for(int i=0;i<local_matrix.GetLength(0)*local_matrix.GetLength(1);i++)  // цикл по всей матрице
    {
        int index_min = i;  // тут храним индекс минимального элемента 
                            // в еще неотсортированной части матрицы
        for(int j=i;j<local_matrix.GetLength(0) * local_matrix.GetLength(1);j++) // цикл по еще 
                                                                                 // неотсортированной
                                                                                 // части матрицы
        {
            if (ret[index_min / local_matrix.GetLength(1),index_min % local_matrix.GetLength(1)]
                >ret[j / local_matrix.GetLength(1),j % local_matrix.GetLength(1)])  // сравнение
            {
                index_min = j;
            }
        }
        // обмен значениями
        int tmp = ret[i / local_matrix.GetLength(1),i % local_matrix.GetLength(1)];

        ret[i / local_matrix.GetLength(1),i % local_matrix.GetLength(1)] = 
        ret[index_min / local_matrix.GetLength(1),index_min % local_matrix.GetLength(1)];

        ret[index_min / local_matrix.GetLength(1),index_min % local_matrix.GetLength(1)] = tmp;
    }
    return ret;
}

// сама программа
int [,] matrix = new int [size_h,size_w];
init_matrix(matrix);
Console.WriteLine("Исходная матрица:");
print_matrix(matrix);
matrix=sort_matrix(matrix);
Console.WriteLine("Отсортированная матрица:");
print_matrix(matrix);
