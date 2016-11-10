using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailySheet.Web.Models.Domain
{
    public class Amount
    {
        public int Id { get; set; }
        public decimal Transit { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}