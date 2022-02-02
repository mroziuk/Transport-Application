using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transport.Models
{
    public class ProductPresentationModel
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<Product> Items { get; set; }
        public int TotalRows { get; set; }
    }
}