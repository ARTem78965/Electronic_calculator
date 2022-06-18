using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Main
{
    public partial class Main : MaterialForm
    {
        public Main()
        {
            InitializeComponent();
            
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue400, Primary.Blue800, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        // Форма Задание
        Exercise exercise = new Exercise();

        // Запрет ввода букв.
        private void materialSingleLineTextField2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.KeyChar));
        }
        
        // Запрет ввода букв.
        private void materialSingleLineTextField1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.KeyChar));
        }

        // Функция кнопки РАСЧЕТ.
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text != "" && materialSingleLineTextField1.Text != "")
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                float S = float.Parse(materialSingleLineTextField2.Text);
                float v = float.Parse(materialSingleLineTextField1.Text);

                // Проверка на совпадения со значениями из формы "ЗАДАНИЕ". 
                if (exercise.val1 == materialSingleLineTextField2.Text && exercise.val2 == materialSingleLineTextField1.Text)
                {

                    // Проверка типа числа
                    if (S % v == 0)
                    {
                       float i_t = S / v;

                       // Вывод целочисленного числа.
                       MessageBox.Show("Автомобиль был в пути " + Convert.ToString(Convert.ToInt32(i_t)) + " ч.",
                                       "Результат",
                                       MessageBoxButtons.OK
                                       );
                    }
                    else
                    {
                       float f_t = S / v;

                       // Вывод числа с плавающей точкой.
                       MessageBox.Show("Автомобиль был в пути " + Convert.ToString(f_t) + " ч.",
                                       "Результат",
                                       MessageBoxButtons.OK
                                       );
                    }

                    // Закрытие формы Main, Exersice.
                    exercise.Close();
                    Close();
                }
                else
                {
                   MessageBox.Show("Не соответвует со значенимя из задания!",
                                   "Ошибка",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error
                                   );
                }
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label1.Text = "обязательное заполенение полей.";
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            // Открытие формы "Задание"
            exercise.Show();
        }
    }
}
