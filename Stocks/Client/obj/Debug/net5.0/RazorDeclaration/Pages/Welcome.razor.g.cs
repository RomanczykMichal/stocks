// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Stocks.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Stocks.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Stocks.Shared.DTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Stocks.Shared.DTOs.Tickers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Stocks.Shared.DTOs.Article;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Stocks.Shared.DTOs.Response;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Syncfusion.Blazor.Charts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Syncfusion.Blazor.DropDowns;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Syncfusion.Blazor.Layouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Stocks.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Stocks.Client.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Stocks.Client.Repositories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Stocks.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Uczelnia\4 sem\APBD\Cw\projekt\projekt-koncowy-s20422\Stocks\Client\_Imports.razor"
using Stocks.Client.Models.DTOs;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Welcome : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
