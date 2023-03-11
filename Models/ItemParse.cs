using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRuScrapper.Models
{
    public class ItemParse
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Region { get; set; }
        public DateTime YearOfProduction { get; set; }
        public DateTime StartTime { get; set; }
        public string ParsingUrl { get; set; }
        public bool IsActive { get; set; } = false;
        public string UrlParse { get; set; }
        public List<string> ListMarks { get; set; }
        public Mark SelectedMark { get; set; }
        public List<Region> AllRegions { get; set; }
        public Region SelectedRegion { get; set; }
        public ItemParse() { }

        public ItemParse(string mark, string model, DateTime yearOfProduction, string region, DateTime startTime, string parsingUrl, bool isActive, string urlParse)
        {
            this.Mark = mark;
            this.Model = model;
            this.Region = region;
            this.StartTime = startTime;
            this.ParsingUrl = parsingUrl;
            this.IsActive = isActive;
            this.YearOfProduction = yearOfProduction;
            this.UrlParse = urlParse;
        }
    }
}
