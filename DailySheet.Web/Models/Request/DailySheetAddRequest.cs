using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DailySheet.Web.Models.Request
{
    public class DailySheetAddRequest
    {
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public int CardNumber { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public Decimal Transit { get; set; }
        public Decimal Tax { get; set; }
        public Decimal? Exempt { get; set; }
        public Decimal Total { get; set; }
    }
}