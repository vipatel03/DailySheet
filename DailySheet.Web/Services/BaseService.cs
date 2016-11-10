
using DailySheet.data.Providers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DailySheet.Web.Services
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseService
    {
        //SiteConfig _siteConfig;

        protected static IDao DataProvider
        {

            get { return DailySheet.data.DataProvider.Instance; }
        }

        protected static SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);


        }

        //public SiteConfig SiteConfig
        //{
        //    get
        //    {
        //        if (SiteConfig == null)
        //        {
        //            _siteConfig = new SiteConfig();
        //        }
        //        return _siteConfig;
        //    }
        //}


    }
}