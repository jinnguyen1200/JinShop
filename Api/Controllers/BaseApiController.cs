using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class BaseApiController : ApiController
    {
        private JsonSerializerSettings _camelCase = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        [NonAction]
        public IHttpActionResult SuccessResult(object data = null, string message = "")
        {
            return Ok(new SuccessResponse
            {
                IsSuccess = true,
                Data = data,
                Message = message
            });
        }

        [NonAction]
        public IHttpActionResult ErrorResult(List<string> errorMessages)
        {
            return Ok(new ErrorResponse
            {
                IsSuccess = false,
                ErrorMessages = errorMessages
            });
        }

        [NonAction]
        public IHttpActionResult ErrorResult(string errorMessage)
        {
            return Ok(new ErrorResponse
            {
                IsSuccess = false,
                ErrorMessages = new List<string> {errorMessage}
            });
        }


    }

    public class SuccessResponse
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }

    public class ErrorResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
    
    public class PagingResult<T>
    {
        public long TotalRecord { get; set; }
        public List<T> Data { get; set; }
        public int TotalPage { get; set; }
    }
    
}
