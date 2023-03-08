using AutoRuScrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRuScrapper.Models
{
    public class SubRegion : IRegion
    {
        public string? Url { get; set; }
        public string? Title { get; set; }
        public int Options { get; set; }
    }

    public class ListSubRegions
    {
        public List<SubRegion>? SubRegions { get; set; }
    }
}
