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
        private Mark _selectedMark;
        public Mark SelectedMark
        {
            get => _selectedMark;
            set => Set(ref _selectedMark, value);
        }

        private List<Mark> _listMarks;
        public List<Mark> ListMarks
        {
            get => _listMarks;
            set => Set(ref _listMarks, value);
        }

        #endregion

        #region Регионы

        private Region _selectedRegion;
        public Region SelectedRegion
        {
            get => _selectedRegion;
            set => Set(ref _selectedRegion, value);
        }

        private List<Region> _listMainRegions;
        public List<Region> ListMainRegions
        {
            get => _listMainRegions;
            set => Set(ref _listMainRegions, value);
        }

        private List<Region> _listSubRegions;
        public List<Region> ListSubRegions
        {
            get => _listSubRegions;
            set => Set(ref _listSubRegions, value);
        }

        private List<Region> _allRegions;
        public List<Region> AllRegions
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


        public MainWindowViewModel()
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
