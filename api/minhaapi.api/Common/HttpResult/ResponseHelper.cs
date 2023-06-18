using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace minhaapi.Common.HttpResult
{
    public static class ResponseHelper
    {
        public static JsonResult Return(string txtmessage, object objReturn, bool isError)
        {
            ResponseDefault resp = new ResponseDefault(txtmessage, objReturn, isError);
            return new JsonResult(resp);
        }
        public static JsonResult Return<T>(string txtmessage, T objReturn, bool isError)
        {
            var serializedObject = JsonConvert.SerializeObject(objReturn);
            ResponseDefault resp = new ResponseDefault(txtmessage, JsonConvert.DeserializeObject<T>(serializedObject), isError);
            return new JsonResult(resp);
        }

        public static JsonResult Error(string txtmessage, HttpStatusCode statusCode)
        {
            ResponseError resp = new ResponseError(txtmessage);
            return new JsonErrorResult(resp, statusCode);
        }
    }
}
