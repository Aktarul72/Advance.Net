using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hospital_Management.Controllers
{
    public class MedicineController : ApiController
    {
        [Route("api/medicine")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = MedicineService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/medicine/add")]
        [HttpPost]
        public HttpResponseMessage Add(MedicineDTO medicine)
        {
            try
            {
                var data = MedicineService.Add(medicine);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
