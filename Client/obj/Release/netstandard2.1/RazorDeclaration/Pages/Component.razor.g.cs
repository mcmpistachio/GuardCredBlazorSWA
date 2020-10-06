#pragma checksum "D:\GuardCredBlazorSWA\Client\Pages\Component.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2263410ef979cbd9724093ef2234a2c7797fec6f"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Microsoft.Graph;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Microsoft.Graph.Auth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Microsoft.Identity.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\GuardCredBlazorSWA\Client\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/comp/{id}")]
    public partial class Component : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 14 "D:\GuardCredBlazorSWA\Client\Pages\Component.razor"
       

    [Parameter]
    public string ID { get; set; }

    User emp;




    private static string clientId = "8c1b31ea-5b35-40e1-bebf-179fc3fcbec4";
    private static string tenantID = "4046c68b-c58b-4882-bf97-59a4f2b44512";
    private static string clientSecret = "nF-Bu3augj1_z4jF._g8g39ZWMPvCma~W3";
    private static IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
        .Create(clientId)
        .WithTenantId(tenantID)
        .WithClientSecret(clientSecret)
        .Build();

    static ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);


    private async Task getGraph(MouseEventArgs args, string userID)
    {
        GraphServiceClient graphClient = new GraphServiceClient(authProvider);
        emp = await graphClient.Users[userID].Request().GetAsync();
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
