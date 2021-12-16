using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace CloudflareBlazorTrialFunctions
{
    public class ReturnDatetime
    {
        private readonly ILogger<ReturnDatetime> _logger;

        public ReturnDatetime(ILogger<ReturnDatetime> log)
        {
            _logger = log;
        }

        [FunctionName("ReturnDatetime")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "datetime" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(DateTime), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            DateTime responseMessage = DateTime.UtcNow;

            return new JsonResult(responseMessage);
        }
    }
}

