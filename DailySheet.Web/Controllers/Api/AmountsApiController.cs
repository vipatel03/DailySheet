using DailySheet.Web.Models.Domain;
using DailySheet.Web.Models.Responses;
using DailySheet.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DailySheet.Web.Controllers.Api
{
    [RoutePrefix("api/amounts")]
    public class AmountsApiController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage SelectAll()
        {
            try
            {
                ItemsResponse<Amount> response = new ItemsResponse<Amount>();
                response.Items = AmountsService.SelectAll();
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
