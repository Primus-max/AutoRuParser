using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRuScrapper.Models
{
    public class Mark
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int Count { get; set; }
        public bool Popular { get; set; }
        public string? BigLogo { get; set; }
    }

    public class ListMarkCars
    {
        public List<Mark>? Marks { get; set; }
    }

}
