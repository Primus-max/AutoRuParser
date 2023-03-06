using AutoRuScrapper.Models;
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

namespace AutoRuScrapper
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

        private void CreateItem_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый элемент, используя шаблон
            DataTemplate template = (DataTemplate)FindResource("MyItemTemplate");
            FrameworkElement newItem = (FrameworkElement)template.LoadContent();

            // Создаем новый экземпляр объекта
            ItemParse item = new();

            // Находим нужный контейнер на форме, в который будем добавлять новый элемент
            Grid gridContainer = (Grid)FindName("TestGrid");

            // Добавляем новый элемент в контейнер
            gridContainer.Children.Add(newItem);

            // Устанавливаем новый контекст данных для элемента
            newItem.DataContext = item;
        }


    }
}
