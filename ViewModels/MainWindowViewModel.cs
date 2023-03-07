using AutoRuScrapper.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRuScrapper.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private string _title = "Автору парсер";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
