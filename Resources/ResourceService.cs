using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoRuScrapper.Resources
{
    internal class ResourceService : IResourceService
    {
        public object FindResource(string resourceName)
        {
            return Application.Current.FindResource(resourceName);
        }
    }
}
