using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRuScrapper.Models
{
    public class ItemParser
    {
        public int Id { get; set; }
        public Mark CarMark { get; set; }
        public string Model { get; set; }
        public Region SaerchRegion { get; set; }
        public DateTime YearOfProduction { get; set; }
        public DateTime StartTime { get; set; }
        public string ParsingUrl { get; set; }
        public bool IsActive { get; set; } = false;
        public string UrlParse { get; set; }

        public ItemParser() { }

        public ItemParser(Mark mark, string model, DateTime yearOfProduction, Region region, DateTime startTime, string parsingUrl, bool isActive, string urlParse)
        {
            this.CarMark = mark;
            this.Model = model;
            this.SaerchRegion = region;
            this.StartTime = startTime;
            this.ParsingUrl = parsingUrl;
            this.IsActive = isActive;
            this.YearOfProduction = yearOfProduction;
            this.UrlParse = urlParse;
        }
    }
}
