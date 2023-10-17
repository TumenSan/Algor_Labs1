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
using System.Diagnostics;

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
            chart1.Series[0].Points.Clear();

            for (int n = 1000; n <= 10000; n += 1000)
            {
                var stopwatch = new Stopwatch();
                int N = n; // Количество строк и столбцов

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
                        for (int i = 0; i < N; i++)
                        {
                            for (int j = 0; j < N; j++)
                            {
                                A[i, j] = -1;
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
                                A[i, j] = random.Next(1, int.MaxValue); // Генерация случайных чисел от -10 до 10
                            }
                        }
                        break;
                }

                // Подсчет количества положительных элементов
                int count = 0;

                // Засекаем начальное время
                stopwatch.Restart();
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
                // Засекаем конечное время
                stopwatch.Stop();

                label3.Text = count.ToString();

                double milliseconds = stopwatch.Elapsed.TotalMilliseconds;
                chart1.Series[0].Points.AddXY(N * N, milliseconds);
                chart1.Update();
            }
        }

        void sequence()
        {
            chart1.Series[0].Points.Clear();

            for (int n = 1000000; n <= 10000000; n += 100000)
            {
                Random random = new Random();
                double[] sequence = new double[n];

                switch (comboBox1.Text)
                {
                    case ("Случайное формирование данных"):
                        // Заполняем массив случайными числами (включая отрицательные)
                        for (int i = 0; i < sequence.Length; i++)
                        {
                            sequence[i] = random.NextDouble() * 2.2 - 1.1; // от -1.1 до 1.1
                        }
                        break;

                    case ("Минимизация числа вычислений"):
                        for (int i = 0; i < sequence.Length; i++)
                        {
                            sequence[i] = random.NextDouble() - 1.3; // отрицательные числа от -1.3 до -0.3
                        }
                        sequence[sequence.Length - 1] = 0;
                        break;

                    case ("Максимизация числа вычислений"):
                        for (int i = 0; i < sequence.Length; i++)
                        {
                            sequence[i] = random.NextDouble() + 0.3; // положительные числа от 0.3 до 1.3
                        }
                        sequence[sequence.Length - 1] = 0;
                        break;
                }

                double pr = 1;
                double maxElement = sequence[0]; // Инициализируем максимальный элемент первым элементом

                bool foundZero = false;

                int IndexMax = 0;

                // Засекаем начальное время
                var stopwatch = new Stopwatch();
                stopwatch.Restart();
                for (int i = 0; i < sequence.Length; i++)
                {
                    if (sequence[i] == 0)
                    {
                        foundZero = true;
                        break;
                    }

                    if (sequence[i] > 0)
                    {
                        pr *= sequence[i];
                    }

                    if (sequence[i] > maxElement)
                    {
                        maxElement = sequence[i];
                        IndexMax = i;
                    }
                }
                
                if (foundZero)
                {
                    sequence[IndexMax] = pr;
                }
                // Засекаем конечное время
                stopwatch.Stop();

                label3.Text = sequence[IndexMax].ToString();

                double milliseconds = stopwatch.Elapsed.TotalMilliseconds;
                chart1.Series[0].Points.AddXY(n, milliseconds);
                chart1.Update();
            }            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            matrix_count();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sequence();
        }
    }
}
