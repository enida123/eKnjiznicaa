#pragma checksum "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd9209c2974865092adc99b2d47c32a619f86fa2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoginLayout), @"mvc.1.0.view", @"/Views/Shared/_LoginLayout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_LoginLayout.cshtml", typeof(AspNetCore.Views_Shared__LoginLayout))]
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
#line 1 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\_ViewImports.cshtml"
using eKnjiznica.Web;

#line default
#line hidden
#line 2 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\_ViewImports.cshtml"
using eKnjiznica.Web.ViewModels;

#line default
#line hidden
#line 3 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\_ViewImports.cshtml"
using eKnjiznica.Web.Models;

#line default
#line hidden
#line 4 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\_ViewImports.cshtml"
using eKnjiznica.Web.Areas.Administrator.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd9209c2974865092adc99b2d47c32a619f86fa2", @"/Views/Shared/_LoginLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9cb31b88d43af278c187a1fc4ce4e18f14346f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LoginLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("include", "Production", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hold-transition login-page"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(25, 1546, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd9209c2974865092adc99b2d47c32a619f86fa24559", async() => {
                BeginContext(31, 336, true);
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <title>AdminLTE 2 | Log in</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content=""width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"" name=""viewport"">
    <!-- Bootstrap 3.3.7 -->
    ");
                EndContext();
                BeginContext(367, 1195, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd9209c2974865092adc99b2d47c32a619f86fa25286", async() => {
                    BeginContext(401, 32, true);
                    WriteLiteral("\r\n        <link rel=\"stylesheet\"");
                    EndContext();
                    BeginWriteAttribute("href", " href=\'", 433, "\'", 479, 1);
#line 11 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
WriteAttributeValue("", 440, Url.Content("~/css/bootstrap.min.css"), 440, 39, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(480, 33, true);
                    WriteLiteral(">\r\n        <link rel=\"stylesheet\"");
                    EndContext();
                    BeginWriteAttribute("href", " href=\'", 513, "\'", 550, 1);
#line 12 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
WriteAttributeValue("", 520, Url.Content("~/css/site.css"), 520, 30, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(551, 64, true);
                    WriteLiteral(">\r\n        <!-- Font Awesome -->\r\n        <link rel=\"stylesheet\"");
                    EndContext();
                    BeginWriteAttribute("href", " href=\'", 615, "\'", 664, 1);
#line 14 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
WriteAttributeValue("", 622, Url.Content("~/css/font-awesome.min.css"), 622, 42, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(665, 62, true);
                    WriteLiteral(">\r\n\r\n        <!-- Ionicons -->\r\n        <link rel=\"stylesheet\"");
                    EndContext();
                    BeginWriteAttribute("href", " href=\'", 727, "\'", 772, 1);
#line 17 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
WriteAttributeValue("", 734, Url.Content("~/css/ionicons.min.css"), 734, 38, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(773, 65, true);
                    WriteLiteral(">\r\n\r\n        <!-- Theme style -->\r\n        <link rel=\"stylesheet\"");
                    EndContext();
                    BeginWriteAttribute("href", " href=\'", 838, "\'", 883, 1);
#line 20 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
WriteAttributeValue("", 845, Url.Content("~/css/AdminLTE.min.css"), 845, 38, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(884, 58, true);
                    WriteLiteral(">\r\n        <!-- iCheck -->\r\n        <link rel=\"stylesheet\"");
                    EndContext();
                    BeginWriteAttribute("href", " href=\'", 942, "\'", 979, 1);
#line 22 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
WriteAttributeValue("", 949, Url.Content("~/css/blue.css"), 949, 30, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(980, 568, true);
                    WriteLiteral(@">

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
    <script src=""https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js""></script>
    <script src=""https://oss.maxcdn.com/respond/1.4.2/respond.min.js""></script>
    <![endif]-->
        <!-- Google Font -->
        <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"">
    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1562, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1571, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1573, 1101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd9209c2974865092adc99b2d47c32a619f86fa211274", async() => {
                BeginContext(1614, 254, true);
                WriteLiteral("\r\n    <div class=\"login-box\">\r\n        <div class=\"login-logo\">\r\n            <a href=\"../../index2.html\"><b>eKnjiznica</b></a>\r\n        </div>\r\n        <!-- /.login-box-body -->\r\n        <div class=\"login-box-body\">\r\n\r\n            <div>\r\n                ");
                EndContext();
                BeginContext(1869, 12, false);
#line 43 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
           Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(1881, 105, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <!-- /.login-box -->\r\n    <!-- jQuery 3 -->\r\n    ");
                EndContext();
                BeginContext(1986, 627, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("environment", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd9209c2974865092adc99b2d47c32a619f86fa212413", async() => {
                    BeginContext(2020, 17, true);
                    WriteLiteral("\r\n        <script");
                    EndContext();
                    BeginWriteAttribute("src", " src=\'", 2037, "\'", 2077, 1);
#line 51 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
WriteAttributeValue("", 2043, Url.Content("~/js/jquery.min.js"), 2043, 34, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(2078, 61, true);
                    WriteLiteral("></script>\r\n        <!-- Bootstrap 3.3.7 -->\r\n        <script");
                    EndContext();
                    BeginWriteAttribute("src", " src=\'", 2139, "\'", 2182, 1);
#line 53 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
WriteAttributeValue("", 2145, Url.Content("~/js/bootstrap.min.js"), 2145, 37, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(2183, 54, true);
                    WriteLiteral("></script>\r\n\r\n        <!-- iCheck -->\r\n        <script");
                    EndContext();
                    BeginWriteAttribute("src", " src=\'", 2237, "\'", 2277, 1);
#line 56 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
WriteAttributeValue("", 2243, Url.Content("~/js/icheck.min.js"), 2243, 34, false);

#line default
#line hidden
                    EndWriteAttribute();
                    BeginContext(2278, 321, true);
                    WriteLiteral(@"></script>

        <script>
            $(function () {
                $('input').iCheck({
                    checkboxClass: 'icheckbox_square-blue',
                    radioClass: 'iradio_square-blue',
                    increaseArea: '20%' /* optional */
                });
            });</script>
    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.EnvironmentTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_EnvironmentTagHelper.Include = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2613, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2624, 41, false);
#line 67 "C:\Users\enida\Desktop\eKnjizica-master\eKnjiznica.Web\Views\Shared\_LoginLayout.cshtml"
   Write(RenderSection("Scripts", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(2665, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2674, 11, true);
            WriteLiteral("\r\n</html>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
