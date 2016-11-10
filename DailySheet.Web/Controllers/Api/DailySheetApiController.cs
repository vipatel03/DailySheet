using DailySheet.Web.Models.Responses;
using DailySheet.Web.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DailySheet.Web.Models.Request;
using DailySheet.Web.Services;

namespace DailySheet.Web.Controllers.Api
{
    [RoutePrefix("api/dailysheets")]
    public class DailySheetApiController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage SelectAll()
        {
            try
            {
                ItemsResponse<DailySheets> response = new ItemsResponse<DailySheets>();
                response.Items = DailySheetsService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route(), HttpPost]
        public HttpResponseMessage Insert(DailySheetAddRequest model)
        {
            if (!ModelState.IsValid && model != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                ItemResponse<int> response = new ItemResponse<int>();
                int id = DailySheetsService.Insert(model);
                response.Item = id;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(DailySheetUpdateRequest model, int id)
        {
            if (!ModelState.IsValid && model != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                DailySheetsService.Update(model, id);
                SuccessResponse sr = new SuccessResponse();
                return Request.CreateResponse(HttpStatusCode.OK, sr);
            }
            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }
        [Route("{CheckIn:DateTime}"), HttpGet]
        public HttpResponseMessage SelectByDate(DateTime checkIn)
        {
            try
            {
                ItemsResponse<DailySheets> response = new ItemsResponse<DailySheets>();
                response.Items = DailySheetsService.SelectByDate(checkIn);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    
}
