using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopCompulsory.Core.Entity
{
    public class Filter
    {
        public int CurrentPage { get; set; }

        public int ItemsPrPage { get; set; }

        public string SortField { get; set; }

        public string SortOrder { get; set; }
    }
}
