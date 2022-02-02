using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transport.Repository
{
    public static class UnitOfWork
    {
        public static LinqRepositoryDataContext context = new LinqRepositoryDataContext();
    }
}