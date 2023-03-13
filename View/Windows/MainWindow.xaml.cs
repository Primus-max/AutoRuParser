using AutoRuScrapper.Models;
using AutoRuScrapper.Resources;
using AutoRuScrapper.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
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
using AutoRuScrapper.ViewModels.Base;
using Newtonsoft.Json;

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
            this.DataContext = this;
        }

        #region Марки машин
        private Mark _selectedMark;
        public Mark SelectedMark
        {
            get => _selectedMark;
            set => _selectedMark = value;
        }

        private List<Mark> _listMarks;
        public List<Mark> ListMarks
        {
            get => _listMarks;
            set => _listMarks = value;
        }

        #endregion

        #region Регионы

        private Region _selectedRegion;
        public Region SelectedRegion
        {
            get => _selectedRegion;
            set => _selectedRegion = value;
        }

        private List<Region> _listMainRegions;
        public List<Region> ListMainRegions
        {
            get => _listMainRegions;
            set => _listMainRegions = value;
        }

        private List<Region> _listSubRegions;
        public List<Region> ListSubRegions
        {
            get => _listSubRegions;
            set => _listSubRegions = value;
        }

        private List<Region> _allRegions;
        public List<Region> AllRegions
        {
            get => _allRegions;
            set => _allRegions = value;
        }

        #endregion

        private string _pareserUrl;
        public string ParserUrl
        {
            get => _pareserUrl;
            set => _pareserUrl = value;
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
            var itemParse = new ItemParser { UrlParse = RandomId };
            //newItem.DataContext = itemParse;
            StackPanel gridContainer = (StackPanel)FindName("ParsingListParent");
            gridContainer.Children.Add(newItem);
        }

        private void StartParser_Click(object sender, RoutedEventArgs e)
        {
            Mark mark = SelectedMark;
            Region region = SelectedRegion;
            string asdf = ParserUrl;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region Добавляю список марок машин
            try
            {
                string carMarksjson = File.ReadAllText(@"Z:\Programming\ProjectC#\AutoRuScrapper\Data\Car\Marks.json");
                ListMarkCars? listMarkCars = JsonConvert.DeserializeObject<ListMarkCars>(carMarksjson);

                if (listMarkCars?.Marks != null)
                    ListMarks = listMarkCars.Marks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion

            #region Добавляю регионы

            try
            {
                #region Основные регионы
                string mainRegionjson = File.ReadAllText(@"Z:\Programming\ProjectC#\AutoRuScrapper\Data\Regions\MainRegions.json");
                ListMainRegions? listMainRegions = JsonConvert.DeserializeObject<ListMainRegions>(mainRegionjson);

                if (listMainRegions?.MainRegions != null)
                    ListMainRegions = listMainRegions.MainRegions;
                #endregion

                #region Области
                string subRegionjson = File.ReadAllText(@"Z:\Programming\ProjectC#\AutoRuScrapper\Data\Regions\SubRegions.json");
                ListSubRegions? listSubRegions = JsonConvert.DeserializeObject<ListSubRegions>(subRegionjson);

                if (listSubRegions?.SubRegions != null)
                    ListSubRegions = listSubRegions.SubRegions;
                #endregion

                // Объяденяю регионы
                AllRegions = ListMainRegions.Concat(ListSubRegions).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            #endregion
        }
    }
}
