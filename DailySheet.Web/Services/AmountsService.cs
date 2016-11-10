using DailySheet.data;
using DailySheet.Web.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DailySheet.Web.Services
{
    public class AmountsService : BaseService
    {
        public static List<Amount> SelectAll()
        {
            List<Amount> list = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Amounts_SelectAll"
             , inputParamMapper: null, map: delegate (IDataReader r, short set)
             {
                 Amount ds = new Amount();
                 int ordinal = 0;
                 ds.Id = r.GetInt32(ordinal++);
                 ds.Transit = r.GetSafeDecimal(ordinal++);
                 ds.Tax = r.GetSafeDecimal(ordinal++);
                 ds.Total = r.GetSafeDecimal(ordinal++);
                 if (list == null)
                 {
                     list = new List<Amount>();
                 }
                 list.Add(ds);
             });
            return list;
        }
    }
}