using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using CloudflareBlazorTrialFunctions.Models;
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
    public class GetPeople
    {
        private readonly ILogger<ReturnDatetime> _logger;

        public GetPeople(ILogger<ReturnDatetime> log)
        {
            _logger = log;
        }

        [FunctionName("GetPeople")]
        [OpenApiOperation(operationId: "GetPeople", tags: new[] { "peopleDTO" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<PeopleDTO>), Description = "The OK response")]
        public async Task<List<PeopleDTO>> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            List<PeopleDTO> peopleList = new() { new PeopleDTO { Name = "Thomas", Age = 24 }, new PeopleDTO { Name = "Jens", Age = 55 }, new PeopleDTO { Name = "Lars", Age = 11 } };

            return peopleList;
        }
    }
}

