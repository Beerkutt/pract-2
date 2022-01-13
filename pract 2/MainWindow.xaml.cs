using LibMas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Lib_2;
using Microsoft.Win32;

namespace pract_2
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

        Arrayx array;

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ИСП - 34, Голота, Вариант 2. Ввести n целых чисел(>0 или <0). Найти произведение чисел. Результат вывести на экран.");
        }

        private void find(object sender, RoutedEventArgs e)
        {
            try
            {
                array = new Arrayx(int.Parse(tbnums.Text));
                array.Initialize();
                datagrid1.ItemsSource = array.ToDataTable().DefaultView;
                tbprod.Text = array.GetProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Data.ToString()}");
            }
        }

        private void save(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                savefile.DefaultExt = ".txt";
                savefile.FilterIndex = 1;
                savefile.Title = "Сохранение массива";

                if (savefile.ShowDialog() == true)
                {
                    array.Save(savefile.FileName);
                }
                datagrid1.ItemsSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Data.ToString()}");
            }
        }

        private void open(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openfile.DefaultExt = ".txt";
                openfile.FilterIndex = 1;
                openfile.Title = "Открытие массива";

                if (openfile.ShowDialog() == true)
                {
                    array.Open(openfile.FileName);
                }
                datagrid1.ItemsSource = array.ToDataTable().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Data.ToString()}");
            }
        }
    }
}
