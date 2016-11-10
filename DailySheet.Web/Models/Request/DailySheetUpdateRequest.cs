using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DailySheet.Web.Models.Request
{
    public class DailySheetUpdateRequest : DailySheetAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}