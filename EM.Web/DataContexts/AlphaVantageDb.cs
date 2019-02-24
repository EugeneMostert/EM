using EM.Services.AlphaVantage.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EM.Web.DataContexts
{
    public class AlphaVantageDb: DbContext
    {
        public AlphaVantageDb() 
            : base("DefaulConnection")
        {

        }
        public DbSet<MetaData> MetaDatas { get; set; }
    }
}