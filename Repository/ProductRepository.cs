using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transport.Repository
{
    public static class ProductRepository
    {
        public static List<Product> GetAll()
        {
            return UnitOfWork.context.Products.ToList();
        }
    }
}