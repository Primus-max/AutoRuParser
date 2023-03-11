using AutoRuScrapper.Models;
using AutoRuScrapper.ViewModels;
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
            Guid guid = Guid.NewGuid();
            string RandomId = guid.ToString();

            //ItemParse itemParse = new ItemParse() { UrlParse = RandomId };

            //// Создаем новый элемент, используя шаблон
            //DataTemplate template = (DataTemplate)FindResource("ParsingItemTemplate");
            ////FrameworkElement newItem = (FrameworkElement)template.LoadContent();
            //// Создаем новый экземпляр объекта
            //var newItem = (FrameworkElement)Activator.CreateInstance((Type)template.DataType);

            //// Находим нужный контейнер на форме, в который будем добавлять новый элемент
            //Grid gridContainer = (Grid)FindName("ParsingListGrid");

            //// Добавляем новый элемент в контейнер
            //gridContainer.Children.Add(newItem);

            //// Устанавливаем новый контекст данных для элемента
            ////newItem.DataContext = new YourViewModel();

            DataTemplate template = (DataTemplate)FindResource("ParsingItemTemplate");
            var newItem = (FrameworkElement)template.LoadContent();
            var itemParse = new ItemParse { UrlParse = RandomId };
            //newItem.DataContext = itemParse;
            StackPanel gridContainer = (StackPanel)FindName("ParsingListParent");
            gridContainer.Children.Add(newItem);
        }
    }
}
