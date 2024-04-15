using Prakt10;
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

namespace Prakt13_Rodin_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public int[,] matr;

        private void CreateMatric_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                int str = (int)kolRow.Value;
                int column = (int)kolColumn.Value;
                matr = new int[str, column];
                datagrib.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FillMatric_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                int min = (int)minRand.Value;
                int max = (int)maxRand.Value;
                Random rnd = new Random();

                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        matr[i, j] = rnd.Next(min, max);
                    }
                }

                datagrib.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ClearMatric_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                matr = null;
                datagrib.ItemsSource = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetResult_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                int maxOfAll = 0;
                int polozh = 0;
                int strMax = 0;

                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    polozh = 0;
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        if (matr[i, j] > 0) polozh++;
                    }
                    if (polozh > maxOfAll)
                    {
                        maxOfAll = polozh;
                        strMax = i;
                    }
                }
                strMax++;
                textResults.Text = strMax.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Info_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Калитин С.А. ИСП-41\nИмеется матрица размера N*M. Определить в какой строке количество положительных элементов наибольшее");
        }
    }
}
