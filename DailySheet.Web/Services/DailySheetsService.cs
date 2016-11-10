using System;
using System.Collections.Generic;
using DailySheet.Web.Models.Domain;
using DailySheet.Web.Services;
using System.Data;
using System.Data.SqlClient;
using DailySheet.data;
using DailySheet.Web.Models.Request;

namespace DailySheet.Web.Services
{
    public class DailySheetsService : BaseService
    {
        public static List<DailySheets> SelectAll()
        {
            List<DailySheets> list = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Dailylogs_SelectAll"
             , inputParamMapper: null, map: delegate (IDataReader r, short set)
             {
                 DailySheets ds = new DailySheets();
                 int ordinal = 0;
                 ds.Id = r.GetInt32(ordinal++);
                 ds.RoomNumber = r.GetInt32(ordinal++);
                 ds.CardNumber = r.GetInt32(ordinal++);
                 ds.FirstName = r.GetString(ordinal++);
                 ds.LastName = r.GetString(ordinal++);
                 ds.Checkin = r.GetDateTime(ordinal++);
                 ds.Checkout = r.GetDateTime(ordinal++);
                 ds.Transit = r.GetSafeDecimal(ordinal++);
                 ds.Tax = r.GetSafeDecimal(ordinal++);
                 ds.Exempt = r.GetSafeDecimal(ordinal++);
                 ds.Total = r.GetSafeDecimal(ordinal++);
                 if (list == null)
                 {
                     list = new List<DailySheets>();
                 }
                 list.Add(ds);
             });
            return list;
        }
        public static List<DailySheets> SelectByDate(DateTime checkIn)
        {
            List<DailySheets> list = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Dailylogs_SelectByDate"
             , inputParamMapper: delegate (SqlParameterCollection paramCollection)
             {
                 paramCollection.AddWithValue("@CheckIn", checkIn);
             }
             , map: delegate (IDataReader r, short set)
             {
                 DailySheets ds = new DailySheets();
                 int ordinal = 0;
                 ds.Id = r.GetInt32(ordinal++);
                 ds.RoomNumber = r.GetInt32(ordinal++);
                 ds.CardNumber = r.GetInt32(ordinal++);
                 ds.FirstName = r.GetString(ordinal++);
                 ds.LastName = r.GetString(ordinal++);
                 ds.Checkin = r.GetDateTime(ordinal++);
                 ds.Checkout = r.GetDateTime(ordinal++);
                 ds.Transit = r.GetSafeDecimal(ordinal++);
                 ds.Tax = r.GetSafeDecimal(ordinal++);
                 ds.Exempt = r.GetSafeDecimal(ordinal++);
                 ds.Total = r.GetSafeDecimal(ordinal++);
                 if (list == null)
                 {
                     list = new List<DailySheets>();
                 }
                 list.Add(ds);
             });
            return list;
        }
        public static int Insert(DailySheetAddRequest model)
        {
            //Insert returns new record Id, so must declare int Id for return statement
            int id = 0;

            //Get connection to DB and tell it to run proc
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Dailylogs_Insert"
                //inputParamMapper creates new Collection to get values from DB
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    //Put values from request model into paramCollection to deliver to DB
                    SetCommonParameters(model, paramCollection);

                    //Make space in paramCollection for Id value, indicate direction is output, not input
                    SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    p.Direction = System.Data.ParameterDirection.Output;
                    paramCollection.Add(p);

                    //grab value of @Id, parse it from string and store int in id
                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@Id"].Value.ToString(), out id);
                }

            );
            //return the id of the new record
            return id;
        }

        public static void Update(DailySheetUpdateRequest model, int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Dailylogs_Update"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                 SetCommonParameters(model, paramCollection);
                     paramCollection.AddWithValue("@Id", model.Id);
            }
            );
        }

       

        private static void SetCommonParameters(DailySheetAddRequest model, SqlParameterCollection paramCollection)
        {
            paramCollection.AddWithValue("@RoomNumber", model.RoomNumber);
            paramCollection.AddWithValue("@CardNumber", model.CardNumber);
            paramCollection.AddWithValue("@FirstName", model.FirstName);
            paramCollection.AddWithValue("@LastName", model.LastName);
            paramCollection.AddWithValue("@Checkin", model.Checkin);
            paramCollection.AddWithValue("@Checkout", model.Checkout);
            paramCollection.AddWithValue("@Transit", model.Transit);
            paramCollection.AddWithValue("@Tax", model.Tax);
            paramCollection.AddWithValue("@Exempt", model.Exempt);
            paramCollection.AddWithValue("@Total", model.Total);
        }
    }
}
