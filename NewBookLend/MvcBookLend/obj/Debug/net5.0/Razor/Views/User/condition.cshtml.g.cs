#pragma checksum "C:\Users\merit\source\repos\NewBookLend\MvcBookLend\Views\User\condition.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0455981dde36aef3cff81b2d60b53270638db3fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_condition), @"mvc.1.0.view", @"/Views/User/condition.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\merit\source\repos\NewBookLend\MvcBookLend\Views\_ViewImports.cshtml"
using MvcBookLend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\merit\source\repos\NewBookLend\MvcBookLend\Views\_ViewImports.cshtml"
using MvcBookLend.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0455981dde36aef3cff81b2d60b53270638db3fb", @"/Views/User/condition.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96da1a5a227a0e6dd85cc81e1453b1d55aa360cd", @"/Views/_ViewImports.cshtml")]
    public class Views_User_condition : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MvcBookLend.Models.UserTable>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 3 "C:\Users\merit\source\repos\NewBookLend\MvcBookLend\Views\User\condition.cshtml"
Write(ViewData["email"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MvcBookLend.Models.UserTable> Html { get; private set; }
    }
}
#pragma warning restore 1591