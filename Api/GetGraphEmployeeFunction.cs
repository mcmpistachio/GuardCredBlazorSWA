using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace BlazorApp.Api
{
    public static class GetGraphEmployeeFunction
    {
        [FunctionName("GetGraphEmployee")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string employeeID = req.Query["employeeID"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            employeeID = employeeID ?? data?.employeeID;

/*            string responseMessage = string.IsNullOrEmpty(employeeID)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {employeeID}. This HTTP triggered function executed successfully.";*/

            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create("8c1b31ea-5b35-40e1-bebf-179fc3fcbec4")
                .WithTenantId("4046c68b-c58b-4882-bf97-59a4f2b44512")
                .WithClientSecret("nF-Bu3augj1_z4jF._g8g39ZWMPvCma~W3")
                .Build();

            ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            User user = await graphClient.Users[employeeID].Request().GetAsync();

            EmployeeUser emp = new EmployeeUser
            {
                FirstName = user.GivenName,
                LastName = user.Surname,
                Title = user.JobTitle,
                Active = (bool)user.AccountEnabled
            };


            return new OkObjectResult(emp);
        }
    }
}
