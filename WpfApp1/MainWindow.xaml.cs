using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var csv = new StringBuilder();
            Random rnd = new Random();

            string filePath = "numbers.csv";
            int a = 1;
            int b = 100;


            for (int i = a; i <= b; i++)
            {
                csv.AppendLine(rnd.Next(a,b).ToString()+',');
            }

            File.WriteAllText(filePath, csv.ToString());
            MessageBox.Show("Файл находиться в папке с программой", "Кажеться готово");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string filePath = "numbers.csv";
            var lines = File.ReadLines(filePath);
            List<numbers> listNum = new List<numbers>();
            foreach (string line in lines)
            {
                Regex regex = new Regex(@",");
                string result = regex.Replace(line, "");
                int num = Convert.ToInt32(result);
                int info = num <= 50 ? 0 : 1;
                listNum.Add(new numbers(){num = num, info = info});
            }

            GridNum.ItemsSource = listNum;
            count.Text = String.Format("Количесвто чисел больше 50 = {0}", listNum.Where(o=>o.info==1).Count());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int s = int.Parse(TextBox.Text);
            int F = 1;
            
            for (int c = s; c > 1; c--)
                F = F * c;
            TextInfo.Text = F.ToString();
        }
    }

    class numbers
    {
        public int num { get; set; }
        public int info { get; set; }
    }
}
