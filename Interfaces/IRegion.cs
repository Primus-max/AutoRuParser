using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRuScrapper.Interfaces
{
    internal interface IRegion
    {
        string? Url { get; set; }
        string? Title { get; set; }
        int Options { get; set; }
    }
}
