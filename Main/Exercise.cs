using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Main
{
    public partial class Exercise : MaterialForm
    {
        // Наследование "Поверка Расстояние".
        public string val1
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        // Наследование "Проверка Скорости".
        public string val2
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public Exercise()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue400, Primary.Blue800, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        public string path = @"value.csv";
        private void Exercise_Load(object sender, EventArgs e)
        {
             // Открытие файла CSV.
            using (var reader = File.OpenText(path))
            {
                Random r = new Random();
                int number = r.Next(1, 16);  
                var pattern = "^" + number + ";([^;]+);([^;]+)$";
                string s;
                Match match = null;
                while ((s = reader.ReadLine()) != null)
                {
                    match = Regex.Match(s, pattern);
                    if (match.Success)
                    {
                        break;
                    }
                }
                if (match.Success)
                {
                    textBox1.Text = match.Groups[1].Value;
                    textBox2.Text = match.Groups[2].Value;
                }
            }
        }
    }
}
