using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailySheet.Web.Models.Domain
{
    public class DailySheets
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int CardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public Decimal Transit { get; set; }
        public Decimal Tax { get; set; }
        public Decimal? Exempt { get; set; }
        public Decimal Total { get; set; }

    }
}