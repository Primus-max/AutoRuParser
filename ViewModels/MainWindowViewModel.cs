using AutoRuScrapper.Interfaces;
using AutoRuScrapper.Models;
using AutoRuScrapper.ViewModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace AutoRuScrapper.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {

        #region Марки машин

        private List<Mark> _listMarks;
        public List<Mark> ListMarks
        {
            get => _listMarks;
            set => Set(ref _listMarks, value);
        }

        private List<string> _lstMarkNames;
        public List<string> ListMarkNames
        {
            get => _lstMarkNames;
            set => Set(ref _lstMarkNames, value);
        }

        #endregion

        #region Регионы

        private List<MainRegion> _listMainRegions;
        public List<MainRegion> ListMainRegions
        {
            get => _listMainRegions;
            set => Set(ref _listMainRegions, value);
        }

        private List<string> _listMainRegionNames;
        public List<string> ListMainRegionNames
        {
            get => _listMainRegionNames;
            set => Set(ref _listMainRegionNames, value);
        }

        private List<SubRegion> _listSubRegions;
        public List<SubRegion> ListSubRegions
        {
            get => _listSubRegions;
            set => Set(ref _listSubRegions, value);
        }

        private List<string> _listSubRegionNames;
        public List<string> ListSubRegionNames
        {
            get => _listSubRegionNames;
            set => Set(ref _listSubRegionNames, value);
        }

        private List<string> _allRegions;
        public List<string> AllRegions
        {
            get => _allRegions;
            set => Set(ref _allRegions, value);
        }

        #endregion

        private string _title = "Автору парсер";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        //private List<>
        //public string Title
        //{
        //    get => _title;
        //    set => Set(ref _title, value);
        //}


        public MainWindowViewModel()
        {
            #region Добавляю список марок машин
            try
            {
                string carMarksjson = File.ReadAllText(@"Z:\Programming\ProjectC#\AutoRuScrapper\Data\Car\Marks.json");
                ListMarkCars? listMarkCars = JsonConvert.DeserializeObject<ListMarkCars>(carMarksjson);
                ListMarks = listMarkCars.Marks;

                if (ListMarks != null)
                    ListMarkNames = ListMarks.Select(mark => mark.Name).ToList();
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
                ListMainRegions = listMainRegions.MainRegions;

                if (ListMainRegions != null)
                    ListMainRegionNames = ListMainRegions.Select(mark => mark.Title).ToList();
                #endregion

                #region Области
                string subRegionjson = File.ReadAllText(@"Z:\Programming\ProjectC#\AutoRuScrapper\Data\Regions\SubRegions.json");
                ListSubRegions? listSubRegions = JsonConvert.DeserializeObject<ListSubRegions>(subRegionjson);
                ListSubRegions = listSubRegions.SubRegions;

                ListSubRegionNames = ListSubRegions.Select(mark => mark.Title).ToList();

                #endregion

                // Объядения регионы
                AllRegions = ListMainRegionNames.Concat(ListSubRegionNames).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            #endregion
        }
    }
}
