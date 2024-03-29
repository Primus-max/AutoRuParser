﻿//using AutoRuScrapper.Commands;
//using AutoRuScrapper.Models;
//using AutoRuScrapper.Resources;
//using AutoRuScrapper.ViewModels.Base;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel.Design;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Input;
//using Microsoft.Extensions.DependencyInjection;


//namespace AutoRuScrapper.ViewModels
//{
//    internal class MainWindowViewModel : BaseViewModel
//    {
//        #region Марки машин
//        private Mark _selectedMark;
//        public Mark SelectedMark
//        {
//            get => _selectedMark;
//            set => Set(ref _selectedMark, value);
//        }

//        private List<Mark> _listMarks;
//        public List<Mark> ListMarks
//        {
//            get => _listMarks;
//            set => Set(ref _listMarks, value);
//        }

//        #endregion

//        #region Регионы

//        private Region _selectedRegion;
//        public Region SelectedRegion
//        {
//            get => _selectedRegion;
//            set => Set(ref _selectedRegion, value);
//        }

//        private List<Region> _listMainRegions;
//        public List<Region> ListMainRegions
//        {
//            get => _listMainRegions;
//            set => Set(ref _listMainRegions, value);
//        }

//        private List<Region> _listSubRegions;
//        public List<Region> ListSubRegions
//        {
//            get => _listSubRegions;
//            set => Set(ref _listSubRegions, value);
//        }

//        private List<Region> _allRegions;
//        public List<Region> AllRegions
//        {
//            get => _allRegions;
//            set => Set(ref _allRegions, value);
//        }

//        #endregion

//        private string _title = "Автору парсер";
//        public string Title
//        {
//            get => _title;
//            set => Set(ref _title, value);
//        }

//        #region Парсер

//        private string _pareserUrl;
//        public string ParserUrl
//        {
//            get => _pareserUrl;
//            set => Set(ref _pareserUrl, value);
//        }

//        private List<string> _parsers;
//        public List<string> Parsers
//        {
//            get => _parsers;
//            set => Set(ref _parsers, value);
//        }
//        #endregion



//        #region Комманды
//        public ICommand StartParserCommand { get; }

//        private bool CanStartParserCommandExecute(object p) => true;
//        public void OnStartParserCommandExecuted(object p)
//        {
//            string asdf = ParserUrl.Trim();
//            MessageBox.Show("START!");
//        }


//        #endregion


//        public MainWindowViewModel()
//        {

//            #region Добавляю список марок машин
//            try
//            {
//                string carMarksjson = File.ReadAllText(@"Z:\Programming\ProjectC#\AutoRuScrapper\Data\Car\Marks.json");
//                ListMarkCars? listMarkCars = JsonConvert.DeserializeObject<ListMarkCars>(carMarksjson);

//                if (listMarkCars?.Marks != null)
//                    ListMarks = listMarkCars.Marks;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//            #endregion

//            #region Добавляю регионы

//            try
//            {
//                #region Основные регионы
//                string mainRegionjson = File.ReadAllText(@"Z:\Programming\ProjectC#\AutoRuScrapper\Data\Regions\MainRegions.json");
//                ListMainRegions? listMainRegions = JsonConvert.DeserializeObject<ListMainRegions>(mainRegionjson);

//                if (listMainRegions?.MainRegions != null)
//                    ListMainRegions = listMainRegions.MainRegions;
//                #endregion

//                #region Области
//                string subRegionjson = File.ReadAllText(@"Z:\Programming\ProjectC#\AutoRuScrapper\Data\Regions\SubRegions.json");
//                ListSubRegions? listSubRegions = JsonConvert.DeserializeObject<ListSubRegions>(subRegionjson);

//                if (listSubRegions?.SubRegions != null)
//                    ListSubRegions = listSubRegions.SubRegions;
//                #endregion

//                // Объяденяю регионы
//                AllRegions = ListMainRegions.Concat(ListSubRegions).ToList();
//            }
//            catch (Exception)
//            {
//                throw;
//            }

//            #endregion

//            #region Создание и добавление парсера
//            #endregion

//            #region Вызов комманд
//            StartParserCommand = new LambdaCommand(OnStartParserCommandExecuted, CanStartParserCommandExecute);

//            #endregion
//        }
//    }
//}
