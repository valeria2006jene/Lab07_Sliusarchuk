using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab07
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbX1.Text = string.Empty;
            tbX2.Text = string.Empty;
            tbY.Text = string.Empty;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 1. Перевірка, чи не порожні поля
            if (string.IsNullOrEmpty(tbX1.Text) || string.IsNullOrEmpty(tbX2.Text))
            {
                tbY.Text = "Не введено даних!";
                return;
            }

            try
            {
                // 2. Зчитування значень з полів (конвертація тексту в числа)
                double x1 = double.Parse(tbX1.Text);
                double x2 = double.Parse(tbX2.Text);

                // 3. Обчислення основної формули (Варіант 10)
                // Спочатку знаменник дробу: x1 + 53 * (x2 у квадраті)
                double denominator = x1 + 53 * Math.Pow(x2, 2);

                // Якщо знаменник 0, ділити не можна (захист від помилки)
                if (denominator == 0)
                {
                    tbY.Text = "Ділення на нуль!";
                    return;
                }

                // Дріб: x2 / знаменник
                double fraction = x2 / denominator;

                // Аргумент синуса: x1 * дріб
                double argument = x1 * fraction;

                // Результат: синус у квадраті
                double y = Math.Pow(Math.Sin(argument), 2);

                // 4. Вивід результату Y у поле (формат F4 - 4 знаки після коми)
                tbY.Text = y.ToString("F4");

                // 5. ДОДАТКОВЕ ЗАВДАННЯ (Варіанти 0...3)
                // Середнє арифметичне x1 та x2
                double average = (x1 + x2) / 2;

                // Виводимо додатковий результат у спливаюче вікно
                MessageBox.Show("Середнє арифметичне X1 та X2: " + average.ToString("F4"), "Додаткове завдання");

            }
            catch (FormatException)
            {
                // Якщо користувач ввів літери замість цифр
                MessageBox.Show("Помилка! Введіть коректні числа.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    }
