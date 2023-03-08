using AutoRuScrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRuScrapper.Models
{
    public class MainRegion : IRegion
    {
        public string? Url { get; set; }
        public string? Title { get; set; }
        public int Options { get; set; }
    }

    public class ListMainRegions
    {
        public List<MainRegion>? MainRegions { get; set; }
    }
}
