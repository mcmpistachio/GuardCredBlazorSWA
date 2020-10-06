using BlazorApp.Shared;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Shared
{
    public class GetEmployee
    {
        public static IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
            .Create("8c1b31ea-5b35-40e1-bebf-179fc3fcbec4")
            .WithTenantId("4046c68b-c58b-4882-bf97-59a4f2b44512")
            .WithClientSecret("nF-Bu3augj1_z4jF._g8g39ZWMPvCma~W3")
            .Build();

        public static ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);

        public async Task EmpGraph(string employeeID)
        {
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            User user = await graphClient.Users[employeeID].Request().GetAsync();
            Console.WriteLine(user.Id);
            EmployeeUser emp = new EmployeeUser
            {
                FirstName = user.GivenName,
                LastName = user.Surname,
                Title = user.JobTitle,
                Active = (bool)user.AccountEnabled
            };
        }
    }
}
