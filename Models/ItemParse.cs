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
        public string Marka { get; set; }
        public string Model { get; set; }
        public DateTime DateRevision { get; set; }

        public ItemParse() { }

        public ItemParse(string marka, string model, DateTime dateRevision)
        {
            this.Marka = marka;
            this.Model = model;
            DateRevision = dateRevision;
        }
    }
}
