using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRuScrapper.Resources
{
    internal interface IResourceService
    {
        object FindResource(string resourceName);
    }
}
