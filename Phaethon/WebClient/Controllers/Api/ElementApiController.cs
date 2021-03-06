﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebClient.Controllers.Api
{
    [RoutePrefix("Api/Element")]
    public class ElementApiController : ApiController
    {
        private readonly HttpClient _client;

        public ElementApiController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:64007/Element/");
        }

        [Route("GetInvoiceElements")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetInvoiceElements(int id)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["id"] = id.ToString();
            return await _client.GetAsync("GetInvoiceElements?" + parameters);
        }
    }
}
