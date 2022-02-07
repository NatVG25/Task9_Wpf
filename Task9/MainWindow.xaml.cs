using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Task9
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
        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Документ открыт");
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Документ сохранен");
        }

        private void ExitCanExecuted(object sender, CanExecuteRoutedEventArgs e)
        { //прописывается условие доступности команды
            if (textBox != null && textBox.Text.Length == 0)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as string);
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }
        private void ComboBox_ChangeFontSize(object sender, SelectionChangedEventArgs e) //обработчик события выбора размера шрифта
        {
            double fontSize = Convert.ToDouble((sender as ComboBox).SelectedItem);
            if (textBox != null)
            {
                textBox.FontSize = fontSize; //присваиваем размер шрифта в textBox
            }
        }

        private void RadioButton_Checked1(object sender, RoutedEventArgs e)//обработчик события выбора цвета шрифта
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black; //обращаемся к textBox и присваиваем ему в свойство Foreground - цвет черный
            }
        }

        private void RadioButton_Checked2(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.FontWeight = FontWeights.Bold;
            }
        }

        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
        }

        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.TextDecorations = TextDecorations.Underline;
            }
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); //создаем экземпляр класса OpenFileDialog

            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"; //создаем фильтр для выбора файлов
            if (openFileDialog.ShowDialog() == true) //проверяем условие, что выбран файл
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName); //записываем текст в файл
            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); //создаем экземпляр класса SaveFileDialog
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"; //создаем фильтр для выбора файлов
            if (saveFileDialog.ShowDialog() == true) //проверяем условие, что выбран файл
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);//записываем текст в файл
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); //закрываем файл
        }


        private void themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            //получаем ссылку в виде объекта Uri на нужную тему, в конструкторе указываем название нужной темы
            Uri theme = new Uri(themes.SelectedIndex == 0 ? "Light.xaml" : "Dark.xaml", UriKind.Relative);
            ResourceDictionary themeDict = Application.LoadComponent(theme) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(themeDict);
        }
    }
}
