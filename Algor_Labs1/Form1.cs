using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Algor_Labs1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*Вариант № 3

1. Найти произведение отрицательных элементов главной 
    диагонали квадратной матрицы и сравнить с суммой элементов первой строки.

2. Найти множество всех слов, которые встречаются в 
        каждом из двух заданных предложений. */

        void matrix_count()
        {
            int N = 10000; // Количество строк и столбцов

            // Создайте матрицу и инициализируйте её случайными числами (для примера)
            int[,] A = new int[N, N];
            Random random = new Random();

            switch (comboBox1.Text)
            {
                case ("Случайное формирование данных"):
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            A[i, j] = random.Next(int.MinValue, int.MaxValue); // Генерируйте случайные числа от -10 до 10
                        }
                    }
                    break;

                case ("Минимизация числа вычислений"):
                    /*
                    создаем матрицу, в которой все элементы равны 0, 
                    за исключением элементов,
                    стоящих на пересечении нечетных строк и столбцов. 
                    Эти элементы могут быть установлены в положительные значения.
                     */
                    for (int i = 1; i < N; i += 2) // Нечетные строки
                    {
                        for (int j = 1; j < N; j += 2) // Нечетные столбцы
                        {
                            A[i, j] = 1; // Минимизируем вычисления, устанавливая значения в 1
                        }
                    }
                    break;

                case ("Максимизация числа вычислений"):
                    /*
                     создаем матрицу случайных чисел, 
                     а затем изменяем каждый элемент на главной 
                     диагонали на случайное отрицательное число. 
                     Это гарантирует, что алгоритм будет выполнять 
                     максимальное количество сравнений отрицательных элементов 
                     на главной диагонали и сумму элементов первой строки
                    */
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            A[i, j] = random.Next(-10, 10); // Генерация случайных чисел от -10 до 10
                        }
                    }

                    // Заставим элементы на главной диагонали различаться
                    for (int i = 0; i < N; i++)
                    {
                        A[i, i] = random.Next(-10, 0); // Генерация случайных отрицательных чисел
                    }
                    break;
            }

            // Подсчитайте количество положительных элементов
            int count = 0;

            for (int i = 1; i < N; i += 2) // Нечетные строки
            {
                for (int j = 1; j < N; j += 2) // Нечетные столбцы
                {
                    if (A[i, j] > 0)
                    {
                        count++;
                    }
                }
            }

            label3.Text = count.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            matrix_count();
        }
    }
}
